using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Model.Services;

namespace ViewModel
{
    public class MainVM : ObservableObject, INotifyDataErrorInfo
    {
        private ObservableCollection<Contact> _contacts;
        private ObservableCollection<Contact> _filteredContacts;
        private Contact? _selectedContact;
        private bool _isInAddMode;
        private bool _isInEditMode;
        private Contact? _contactBeforeEdit;
        private Contact? _tempContact;
        private string _searchText = string.Empty;
        private bool _isUpdating;

        /// <summary>
        /// Валидатор для текущего редактируемого контакта.
        /// </summary>
        private ContactValidator? _currentValidator;

        public MainVM()
        {
            _contacts = new ObservableCollection<Contact>();
            _filteredContacts = new ObservableCollection<Contact>();

            LoadData();

            AddCommand = new RelayCommand(ExecuteAdd, CanExecuteAdd);
            EditCommand = new RelayCommand(ExecuteEdit, CanExecuteEdit);
            RemoveCommand = new RelayCommand(ExecuteRemove, CanExecuteRemove);
            ApplyCommand = new RelayCommand(ExecuteApply, CanExecuteApply);

            UpdateFilteredContacts();
        }

        /// <summary>
        /// Загрузка данных.
        /// </summary>
        private void LoadData()
        {
            var loadedContacts = ContactSerializer.Load();
            if (loadedContacts.Count > 0)
            {
                _contacts = loadedContacts;
            }
        }

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        public void SaveData()
        {
            if (!AreAllContactsValid())
            {
                System.Diagnostics.Debug.WriteLine("Не может сохранить данные т.к некоторые данные не валидны");
                return;
            }

            ContactSerializer.Save(_contacts);
        }

        /// <summary>
        /// Все ли данные валидны.
        /// </summary>
        /// <returns></returns>
        private bool AreAllContactsValid()
        {
            foreach (var contact in _contacts)
            {
                if (!ContactValidator.IsContactValid(contact))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Сипсок контактов.
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                if (SetProperty(ref _contacts, value))
                {
                    UpdateFilteredContacts();
                }
            }
        }

        /// <summary>
        /// Список отфильтрованных контактов.
        /// </summary>
        public ObservableCollection<Contact> FilteredContacts
        {
            get { return _filteredContacts; }
            private set
            {
                SetProperty(ref _filteredContacts, value);
            }
        }

        /// <summary>
        /// Выбранный контакт.
        /// </summary>
        public Contact? SelectedContact
        {
            get
            {
                if (_isInAddMode && _tempContact != null)
                    return _tempContact;
                return _selectedContact;
            }
            set
            {
                if (_isInAddMode || _isInEditMode)
                {
                    CancelEditing();
                }

                if (SetProperty(ref _selectedContact, value))
                {
                    OnSelectedContactChanged();
                    NotifyCommandsCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Поиск текста.
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (SetProperty(ref _searchText, value ?? string.Empty))
                {
                    UpdateFilteredContacts();
                }
            }
        }

        public string Name
        {
            get { return SelectedContact?.Name ?? string.Empty; }
            set
            {
                if (SelectedContact != null
                    && SetProperty(SelectedContact.Name, value, SelectedContact, static (contact, name) => contact.Name = name))
                {
                    _currentValidator?.ValidateName();

                    if (!_isUpdating)
                    {
                        _isUpdating = true;
                        UpdateFilteredContacts();
                        _isUpdating = false;
                    }

                    NotifyCommandsCanExecuteChanged();
                    // Уведомляем об изменении ошибок
                    OnErrorsChanged(nameof(Name));
                }
            }
        }

        public string Email
        {
            get { return SelectedContact?.Email ?? string.Empty; }
            set
            {
                if (SelectedContact != null
                    && SetProperty(SelectedContact.Email, value, SelectedContact, static (contact, email) => contact.Email = email))
                {
                    _currentValidator?.ValidateEmail();
                    NotifyCommandsCanExecuteChanged();
                    OnErrorsChanged(nameof(Email));
                }
            }
        }

        public string PhoneNumber
        {
            get { return SelectedContact?.PhoneNumber ?? string.Empty; }
            set
            {
                if (SelectedContact != null
                    && SetProperty(SelectedContact.PhoneNumber, value, SelectedContact, static (contact, phoneNumber) => contact.PhoneNumber = phoneNumber))
                {
                    _currentValidator?.ValidatePhoneNumber();
                    NotifyCommandsCanExecuteChanged();
                    OnErrorsChanged(nameof(PhoneNumber));
                }
            }
        }

        /// <summary>
        /// Режим добавления.
        /// </summary>
        public bool IsInAddMode
        {
            get { return _isInAddMode; }
            private set
            {
                if (SetProperty(ref _isInAddMode, value))
                {
                    OnModeChanged();
                    NotifyCommandsCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Режим редактирования.
        /// </summary>
        public bool IsInEditMode
        {
            get { return _isInEditMode; }
            private set
            {
                if (SetProperty(ref _isInEditMode, value))
                {
                    OnModeChanged();
                    NotifyCommandsCanExecuteChanged();
                }
            }
        }

        public bool IsInAddOrEditMode => _isInAddMode || _isInEditMode;
        public bool IsApplyButtonVisible => IsInAddOrEditMode;
        public bool IsEditAndRemoveEnabled => !IsInAddOrEditMode && _selectedContact != null;
        public bool IsAddEnabled => !IsInAddOrEditMode;
        public bool AreFieldsReadOnly => !IsInAddOrEditMode;

        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand RemoveCommand { get; }
        public IRelayCommand ApplyCommand { get; }

        #region Валидация 

        public bool HasErrors => _currentValidator?.HasErrors ?? false;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (_currentValidator == null || string.IsNullOrEmpty(propertyName))
                return Array.Empty<string>();

            return _currentValidator.GetErrors(propertyName);
        }

        /// <summary>
        /// Наличие ошибок.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnErrorsChanged(string? propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
            NotifyCommandsCanExecuteChanged();
        }

        private void OnSelectedContactChanged()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(IsEditAndRemoveEnabled));
        }

        private void OnModeChanged()
        {
            OnPropertyChanged(nameof(IsInAddOrEditMode));
            OnPropertyChanged(nameof(IsApplyButtonVisible));
            OnPropertyChanged(nameof(IsEditAndRemoveEnabled));
            OnPropertyChanged(nameof(IsAddEnabled));
            OnPropertyChanged(nameof(AreFieldsReadOnly));
        }

        private void NotifyCommandsCanExecuteChanged()
        {
            AddCommand.NotifyCanExecuteChanged();
            EditCommand.NotifyCanExecuteChanged();
            RemoveCommand.NotifyCanExecuteChanged();
            ApplyCommand.NotifyCanExecuteChanged();
        }

        #endregion
        /// <summary>
        /// Обновление фильтрованных контактов.
        /// </summary>
        private void UpdateFilteredContacts()
        {
            if (_isUpdating) return;

            try
            {
                _isUpdating = true;
                var filtered = string.IsNullOrWhiteSpace(_searchText)
                    ? _contacts
                    : new ObservableCollection<Contact>(
                        _contacts.Where(c => c.Name.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0));
                FilteredContacts = new ObservableCollection<Contact>(filtered);
            }
            finally
            {
                _isUpdating = false;
            }
        }

        /// <summary>
        /// Возможность выполнения добавления
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanExecuteAdd() => IsAddEnabled;

        /// <summary>
        /// Выполнение добавления.
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteAdd()
        {
            _tempContact = new Contact();
            _selectedContact = _tempContact;
            _currentValidator = new ContactValidator(_tempContact);

            // Подписываемся на события валидатора
            _currentValidator.ErrorsChanged += (s, e) => OnErrorsChanged(e.PropertyName);
            _currentValidator.ValidateAll();

            OnPropertyChanged(nameof(SelectedContact));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnErrorsChanged(null);

            IsInAddMode = true;
        }

        /// <summary>
        /// Возможность выполнения редактирования 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanExecuteEdit() => IsEditAndRemoveEnabled;

       /// <summary>
       /// Выполнение редактирования 
       /// </summary>
       /// <param name="parameter"></param>
        private void ExecuteEdit()
        {
            if (_selectedContact != null)
            {
                _contactBeforeEdit = new Contact
                {
                    Name = _selectedContact.Name,
                    Email = _selectedContact.Email,
                    PhoneNumber = _selectedContact.PhoneNumber
                };

                _currentValidator = new ContactValidator(_selectedContact);

                // Подписываемся на события валидатора
                _currentValidator.ErrorsChanged += (s, e) => OnErrorsChanged(e.PropertyName);
                _currentValidator.ValidateAll();

                OnErrorsChanged(null);
                IsInEditMode = true;
            }
        }


        /// <summary>
        /// Возможность выполнения удаления. 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanExecuteRemove() => IsEditAndRemoveEnabled;

        /// <summary>
        /// Выполнение удаления.
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteRemove()
        {
            if (_selectedContact != null)
            {
                int currentIndex = _contacts.IndexOf(_selectedContact);
                _contacts.Remove(_selectedContact);

                if (_contacts.Count > 0)
                {
                    SelectedContact = currentIndex < _contacts.Count
                        ? _contacts[currentIndex]
                        : _contacts[_contacts.Count - 1];
                }
                else
                {
                    SelectedContact = null;
                }

                UpdateFilteredContacts();
                SaveData();
            }
        }

        private bool CanExecuteApply()
        {
            return IsInAddOrEditMode && (_currentValidator?.IsValid ?? false);
        }

        private void ExecuteApply()
        {
            if (_isInAddMode && _tempContact != null && (_currentValidator?.IsValid == true))
            {
                _contacts.Add(_tempContact);
                _selectedContact = _tempContact;
                _tempContact = null;
                _currentValidator = null;
                IsInAddMode = false;

                UpdateFilteredContacts();
                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));
                OnErrorsChanged(null);
                SaveData();
            }
            else if (_isInEditMode && (_currentValidator?.IsValid == true))
            {
                _currentValidator = null;
                IsInEditMode = false;
                _contactBeforeEdit = null;

                UpdateFilteredContacts();
                OnErrorsChanged(null);
                SaveData();
            }
        }

        private void CancelEditing()
        {
            if (_isInAddMode)
            {
                _tempContact = null;
                _currentValidator = null;
                IsInAddMode = false;
                _selectedContact = null;

                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));
                OnErrorsChanged(null);
            }
            else if (_isInEditMode && _contactBeforeEdit != null && _selectedContact != null)
            {
                _selectedContact.Name = _contactBeforeEdit.Name;
                _selectedContact.Email = _contactBeforeEdit.Email;
                _selectedContact.PhoneNumber = _contactBeforeEdit.PhoneNumber;

                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));

                UpdateFilteredContacts();
                _currentValidator = null;
                IsInEditMode = false;
                _contactBeforeEdit = null;
                OnErrorsChanged(null);
            }
        }
    }
}
