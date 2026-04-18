using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using View.Commands;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    public class MainVM : INotifyPropertyChanged, INotifyDataErrorInfo
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
                if (_contacts != value)
                {
                    _contacts = value;
                    OnPropertyChanged();
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
                if (_filteredContacts != value)
                {
                    _filteredContacts = value;
                    OnPropertyChanged();
                }
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

                if (_selectedContact != value)
                {
                    _selectedContact = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(PhoneNumber));

                    CommandManager.InvalidateRequerySuggested();
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
                if (_searchText != value)
                {
                    _searchText = value ?? string.Empty;
                    OnPropertyChanged();
                    UpdateFilteredContacts();
                }
            }
        }

        public string Name
        {
            get { return SelectedContact?.Name ?? string.Empty; }
            set
            {
                if (SelectedContact != null && SelectedContact.Name != value)
                {
                    SelectedContact.Name = value;
                    OnPropertyChanged();
                    _currentValidator?.ValidateName();

                    if (!_isUpdating)
                    {
                        _isUpdating = true;
                        UpdateFilteredContacts();
                        _isUpdating = false;
                    }

                    CommandManager.InvalidateRequerySuggested();
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
                if (SelectedContact != null && SelectedContact.Email != value)
                {
                    SelectedContact.Email = value;
                    OnPropertyChanged();
                    _currentValidator?.ValidateEmail();
                    CommandManager.InvalidateRequerySuggested();
                    OnErrorsChanged(nameof(Email));
                }
            }
        }

        public string PhoneNumber
        {
            get { return SelectedContact?.PhoneNumber ?? string.Empty; }
            set
            {
                if (SelectedContact != null && SelectedContact.PhoneNumber != value)
                {
                    SelectedContact.PhoneNumber = value;
                    OnPropertyChanged();
                    _currentValidator?.ValidatePhoneNumber();
                    CommandManager.InvalidateRequerySuggested();
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
                if (_isInAddMode != value)
                {
                    _isInAddMode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsInAddOrEditMode));
                    OnPropertyChanged(nameof(IsApplyButtonVisible));
                    OnPropertyChanged(nameof(IsEditAndRemoveEnabled));
                    OnPropertyChanged(nameof(IsAddEnabled));
                    OnPropertyChanged(nameof(AreFieldsReadOnly));
                    CommandManager.InvalidateRequerySuggested();
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
                if (_isInEditMode != value)
                {
                    _isInEditMode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsInAddOrEditMode));
                    OnPropertyChanged(nameof(IsApplyButtonVisible));
                    OnPropertyChanged(nameof(IsEditAndRemoveEnabled));
                    OnPropertyChanged(nameof(IsAddEnabled));
                    OnPropertyChanged(nameof(AreFieldsReadOnly));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public bool IsInAddOrEditMode => _isInAddMode || _isInEditMode;
        public bool IsApplyButtonVisible => IsInAddOrEditMode;
        public bool IsEditAndRemoveEnabled => !IsInAddOrEditMode && _selectedContact != null;
        public bool IsAddEnabled => !IsInAddOrEditMode;
        public bool AreFieldsReadOnly => !IsInAddOrEditMode;

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ApplyCommand { get; }

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
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
            CommandManager.InvalidateRequerySuggested();
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
        private bool CanExecuteAdd(object? parameter) => IsAddEnabled;

        /// <summary>
        /// Выполнение добавления.
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteAdd(object? parameter)
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
        private bool CanExecuteEdit(object? parameter) => IsEditAndRemoveEnabled;

       /// <summary>
       /// Выполнение редактирования 
       /// </summary>
       /// <param name="parameter"></param>
        private void ExecuteEdit(object? parameter)
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
        private bool CanExecuteRemove(object? parameter) => IsEditAndRemoveEnabled;

        /// <summary>
        /// Выполнение удаления.
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteRemove(object? parameter)
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

        private bool CanExecuteApply(object? parameter)
        {
            return IsInAddOrEditMode && (_currentValidator?.IsValid ?? false);
        }

        private void ExecuteApply(object? parameter)
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}