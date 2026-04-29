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
    public partial class MainVM : ObservableObject, INotifyDataErrorInfo
    {
        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [ObservableProperty]
        private ObservableCollection<Contact> filteredContacts;

        private Contact? _selectedContact;

        [ObservableProperty]
        private bool _isInAddMode;

        [ObservableProperty]
        private bool _isInEditMode;

        private Contact? _contactBeforeEdit;
        private Contact? _tempContact;

        [ObservableProperty]
        private string _searchText = string.Empty;

        private bool _isUpdating;

        /// <summary>
        /// Валидатор для текущего редактируемого контакта.
        /// </summary>
        private ContactValidator? _currentValidator;

        public MainVM()
        {
            contacts = new ObservableCollection<Contact>();
            filteredContacts = new ObservableCollection<Contact>();

            LoadData();

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
                Contacts = loadedContacts;
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

            ContactSerializer.Save(Contacts);
        }

        /// <summary>
        /// Все ли данные валидны.
        /// </summary>
        /// <returns></returns>
        private bool AreAllContactsValid()
        {
            foreach (var contact in Contacts)
            {
                if (!ContactValidator.IsContactValid(contact))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Выбранный контакт.
        /// </summary>
        public Contact? SelectedContact
        {
            get
            {
                if (IsInAddMode && _tempContact != null)
                    return _tempContact;
                return _selectedContact;
            }
            set
            {
                if (IsInAddMode || IsInEditMode)
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
                    && SetProperty(SelectedContact.PhoneNumber, value, SelectedContact,
                    static (contact, phoneNumber) => contact.PhoneNumber = phoneNumber))
                {
                    _currentValidator?.ValidatePhoneNumber();
                    NotifyCommandsCanExecuteChanged();
                    OnErrorsChanged(nameof(PhoneNumber));
                }
            }
        }

        public bool IsInAddOrEditMode => IsInAddMode || IsInEditMode;
        public bool IsApplyButtonVisible => IsInAddOrEditMode;
        public bool IsEditAndRemoveEnabled => !IsInAddOrEditMode && _selectedContact != null;
        public bool IsAddEnabled => !IsInAddOrEditMode;
        public bool AreFieldsReadOnly => !IsInAddOrEditMode;

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

        private void NotifyCommandsCanExecuteChanged()
        {
            AddCommand.NotifyCanExecuteChanged();
            EditCommand.NotifyCanExecuteChanged();
            RemoveCommand.NotifyCanExecuteChanged();
            ApplyCommand.NotifyCanExecuteChanged();
        }

        partial void OnContactsChanged(ObservableCollection<Contact> value)
        {
            UpdateFilteredContacts();
        }

        partial void OnSearchTextChanged(string value)
        {
            UpdateFilteredContacts();
        }

        partial void OnIsInAddModeChanged(bool value)
        {
            OnModeRelatedPropertiesChanged();
        }

        partial void OnIsInEditModeChanged(bool value)
        {
            OnModeRelatedPropertiesChanged();
        }

        private void OnModeRelatedPropertiesChanged()
        {
            OnPropertyChanged(nameof(IsInAddOrEditMode));
            OnPropertyChanged(nameof(IsApplyButtonVisible));
            OnPropertyChanged(nameof(IsEditAndRemoveEnabled));
            OnPropertyChanged(nameof(IsAddEnabled));
            OnPropertyChanged(nameof(AreFieldsReadOnly));
            NotifyCommandsCanExecuteChanged();
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
                var filtered = string.IsNullOrWhiteSpace(SearchText)
                    ? Contacts
                    : new ObservableCollection<Contact>(
                        Contacts.Where(c => c.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
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
        private bool CanExecuteAdd() => IsAddEnabled;

        /// <summary>
        /// Выполнение добавления.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanExecuteAdd))]
        private void Add()
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
        private bool CanExecuteEdit() => IsEditAndRemoveEnabled;

       /// <summary>
       /// Выполнение редактирования 
       /// </summary>
        [RelayCommand(CanExecute = nameof(CanExecuteEdit))]
        private void Edit()
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
        private bool CanExecuteRemove() => IsEditAndRemoveEnabled;

        /// <summary>
        /// Выполнение удаления.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanExecuteRemove))]
        private void Remove()
        {
            if (_selectedContact != null)
            {
                int currentIndex = Contacts.IndexOf(_selectedContact);
                Contacts.Remove(_selectedContact);

                if (Contacts.Count > 0)
                {
                    SelectedContact = currentIndex < Contacts.Count
                        ? Contacts[currentIndex]
                        : Contacts[Contacts.Count - 1];
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

        [RelayCommand(CanExecute = nameof(CanExecuteApply))]
        private void Apply()
        {
            if (IsInAddMode && _tempContact != null && (_currentValidator?.IsValid == true))
            {
                var tempContact = _tempContact;
                Contacts.Add(tempContact);
                _selectedContact = tempContact;
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
            else if (IsInEditMode && (_currentValidator?.IsValid == true))
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
            if (IsInAddMode)
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
            else if (IsInEditMode && _contactBeforeEdit != null && _selectedContact != null)
            {
                var contactBeforeEdit = _contactBeforeEdit;
                var selectedContact = _selectedContact;

                selectedContact.Name = contactBeforeEdit.Name;
                selectedContact.Email = contactBeforeEdit.Email;
                selectedContact.PhoneNumber = contactBeforeEdit.PhoneNumber;

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
