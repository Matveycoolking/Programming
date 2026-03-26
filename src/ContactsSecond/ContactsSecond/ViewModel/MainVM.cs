using System;
using System.Collections;
using System.Collections.Generic;
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
    /// <summary>
    /// Главная ViewModel приложения
    /// </summary>
    public class MainVM : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Коллекция контактов
        /// </summary>
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Отфильтрованная коллекция для отображения
        /// </summary>
        private ObservableCollection<Contact> _filteredContacts;

        /// <summary>
        /// Выбранный контакт
        /// </summary>
        private Contact? _selectedContact;

        /// <summary>
        /// Флаг режима добавления
        /// </summary>
        private bool _isInAddMode;

        /// <summary>
        /// Флаг режима редактирования
        /// </summary>
        private bool _isInEditMode;

        /// <summary>
        /// Копия контакта для отмены редактирования
        /// </summary>
        private Contact? _contactBeforeEdit;

        /// <summary>
        /// Временный контакт для режима добавления
        /// </summary>
        private Contact? _tempContact;

        /// <summary>
        /// Текст для поиска
        /// </summary>
        private string _searchText = string.Empty;

        /// <summary>
        /// Флаг для предотвращения рекурсии при обновлении
        /// </summary>
        private bool _isUpdating;

        /// <summary>
        /// Словарь ошибок валидации
        /// </summary>
        private readonly Dictionary<string, List<string>> _errors = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainVM()
        {
            // Инициализация коллекций
            _contacts = new ObservableCollection<Contact>();
            _filteredContacts = new ObservableCollection<Contact>();

            // Загрузка данных из файла
            LoadData();

            // Инициализация команд
            AddCommand = new RelayCommand(ExecuteAdd, CanExecuteAdd);
            EditCommand = new RelayCommand(ExecuteEdit, CanExecuteEdit);
            RemoveCommand = new RelayCommand(ExecuteRemove, CanExecuteRemove);
            ApplyCommand = new RelayCommand(ExecuteApply, CanExecuteApply);

            // Первоначальное обновление фильтра
            UpdateFilteredContacts();
        }

        /// <summary>
        /// Загрузка данных из файла
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
        /// Сохранение данных в файл
        /// </summary>
        public void SaveData()
        {
            ContactSerializer.Save(_contacts);
        }

        /// <summary>
        /// Коллекция контактов
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
        /// Отфильтрованная коллекция для отображения
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
        /// Выбранный контакт
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
                // Если мы были в режиме добавления или редактирования - отменяем
                if (_isInAddMode || _isInEditMode)
                {
                    CancelEditing();
                }

                if (_selectedContact != value)
                {
                    _selectedContact = value;
                    OnPropertyChanged();

                    // Обновляем привязки полей
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(PhoneNumber));

                    // Обновляем состояние команд
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Текст для поиска
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

        // Свойства для привязки данных с валидацией
        public string Name
        {
            get { return SelectedContact?.Name ?? string.Empty; }
            set
            {
                if (SelectedContact != null && SelectedContact.Name != value)
                {
                    SelectedContact.Name = value;
                    OnPropertyChanged();
                    ValidateName(value);

                    // Обновляем отображение в списке
                    if (!_isUpdating)
                    {
                        _isUpdating = true;
                        UpdateFilteredContacts();
                        _isUpdating = false;
                    }
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
                    ValidateEmail(value);
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
                    ValidatePhoneNumber(value);
                }
            }
        }

        // Свойства состояния
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

        // Вычисляемые свойства
        public bool IsInAddOrEditMode => _isInAddMode || _isInEditMode;
        public bool IsApplyButtonVisible => IsInAddOrEditMode;
        public bool IsEditAndRemoveEnabled => !IsInAddOrEditMode && _selectedContact != null;
        public bool IsAddEnabled => !IsInAddOrEditMode;
        public bool AreFieldsReadOnly => !IsInAddOrEditMode;

        // Команды
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ApplyCommand { get; }

        #region Валидация

        /// <summary>
        /// Проверка имени
        /// </summary>
        private void ValidateName(string? name)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Name cannot be empty");
            }
            else if (name.Length > 100)
            {
                errors.Add("Name must be less than 100 characters");
            }

            UpdateErrors(nameof(Name), errors);
        }

        /// <summary>
        /// Проверка номера телефона
        /// </summary>
        private void ValidatePhoneNumber(string? phone)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(phone))
            {
                errors.Add("Phone number cannot be empty");
            }
            else if (phone.Length > 100)
            {
                errors.Add("Phone number must be less than 100 characters");
            }
            else if (!IsValidPhoneNumber(phone))
            {
                errors.Add("Phone number can only contain digits and + - ( ) characters. Example: +7 (999) 111-22-33");
            }

            UpdateErrors(nameof(PhoneNumber), errors);
        }

        /// <summary>
        /// Проверка email
        /// </summary>
        private void ValidateEmail(string? email)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add("Email cannot be empty");
            }
            else if (email.Length > 100)
            {
                errors.Add("Email must be less than 100 characters");
            }
            else if (!email.Contains('@'))
            {
                errors.Add("Email must contain @ symbol");
            }

            UpdateErrors(nameof(Email), errors);
        }

        /// <summary>
        /// Проверка корректности формата телефона
        /// </summary>
        private bool IsValidPhoneNumber(string phone)
        {
            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != '+' && c != '-' && c != '(' && c != ')' && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Обновление ошибок для свойства
        /// </summary>
        private void UpdateErrors(string propertyName, List<string> errors)
        {
            bool hasErrors = errors.Count > 0;
            bool hadErrors = _errors.ContainsKey(propertyName);

            if (hasErrors)
            {
                _errors[propertyName] = errors;
            }
            else if (hadErrors)
            {
                _errors.Remove(propertyName);
            }

            if (hasErrors != hadErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(IsValid));

            // Обновляем состояние команды Apply
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Проверка валидности всех полей текущего контакта
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (_isInAddMode && _tempContact != null)
                {
                    return IsContactValid(_tempContact);
                }
                if (_isInEditMode && _selectedContact != null)
                {
                    return IsContactValid(_selectedContact);
                }
                return true;
            }
        }

        /// <summary>
        /// Проверка валидности конкретного контакта
        /// </summary>
        private bool IsContactValid(Contact contact)
        {
            // Временная очистка ошибок для проверки
            var tempErrors = new Dictionary<string, List<string>>();

            // Проверяем имя
            var nameErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(contact.Name))
                nameErrors.Add("Name cannot be empty");
            else if (contact.Name.Length > 100)
                nameErrors.Add("Name must be less than 100 characters");
            if (nameErrors.Count > 0) tempErrors[nameof(Name)] = nameErrors;

            // Проверяем телефон
            var phoneErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
                phoneErrors.Add("Phone number cannot be empty");
            else if (contact.PhoneNumber.Length > 100)
                phoneErrors.Add("Phone number must be less than 100 characters");
            else if (!IsValidPhoneNumber(contact.PhoneNumber))
                phoneErrors.Add("Phone number can only contain digits and + - ( ) characters");
            if (phoneErrors.Count > 0) tempErrors[nameof(PhoneNumber)] = phoneErrors;

            // Проверяем email
            var emailErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(contact.Email))
                emailErrors.Add("Email cannot be empty");
            else if (contact.Email.Length > 100)
                emailErrors.Add("Email must be less than 100 characters");
            else if (!contact.Email.Contains('@'))
                emailErrors.Add("Email must contain @ symbol");
            if (emailErrors.Count > 0) tempErrors[nameof(Email)] = emailErrors;

            return tempErrors.Count == 0;
        }

        // INotifyDataErrorInfo implementation
        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return Array.Empty<string>();
            }

            return _errors.TryGetValue(propertyName, out var errors) ? errors : Array.Empty<string>();
        }

        #endregion

        /// <summary>
        /// Обновление отфильтрованного списка
        /// </summary>
        private void UpdateFilteredContacts()
        {
            if (_isUpdating) return;

            try
            {
                _isUpdating = true;

                var newFilteredList = new ObservableCollection<Contact>();

                var filtered = string.IsNullOrWhiteSpace(_searchText)
                    ? _contacts
                    : new ObservableCollection<Contact>(
                        _contacts.Where(c => c.Name.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0));

                foreach (var contact in filtered)
                {
                    newFilteredList.Add(contact);
                }

                FilteredContacts = newFilteredList;
            }
            finally
            {
                _isUpdating = false;
            }
        }

        private bool CanExecuteAdd(object? parameter)
        {
            return IsAddEnabled;
        }

        private void ExecuteAdd(object? parameter)
        {
            // Создаем временный контакт
            _tempContact = new Contact();

            // Устанавливаем его как выбранный
            _selectedContact = _tempContact;
            OnPropertyChanged(nameof(SelectedContact));

            // Обновляем привязки полей
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));

            // Очищаем ошибки валидации
            _errors.Clear();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));

            // Переходим в режим добавления
            IsInAddMode = true;
        }

        private bool CanExecuteEdit(object? parameter)
        {
            return IsEditAndRemoveEnabled;
        }

        private void ExecuteEdit(object? parameter)
        {
            if (_selectedContact != null)
            {
                // Сохраняем копию для отмены
                _contactBeforeEdit = new Contact
                {
                    Name = _selectedContact.Name,
                    Email = _selectedContact.Email,
                    PhoneNumber = _selectedContact.PhoneNumber
                };

                // Очищаем ошибки валидации
                _errors.Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));

                // Переходим в режим редактирования
                IsInEditMode = true;
            }
        }

        private bool CanExecuteRemove(object? parameter)
        {
            return IsEditAndRemoveEnabled;
        }

        private void ExecuteRemove(object? parameter)
        {
            if (_selectedContact != null)
            {
                int currentIndex = _contacts.IndexOf(_selectedContact);
                _contacts.Remove(_selectedContact);

                if (_contacts.Count > 0)
                {
                    if (currentIndex < _contacts.Count)
                        SelectedContact = _contacts[currentIndex];
                    else
                        SelectedContact = _contacts[_contacts.Count - 1];
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
            // Apply доступен только если нет ошибок валидации
            return IsInAddOrEditMode && IsValid;
        }

        private void ExecuteApply(object? parameter)
        {
            if (_isInAddMode && _tempContact != null)
            {
                _contacts.Add(_tempContact);
                _selectedContact = _tempContact;
                _tempContact = null;

                IsInAddMode = false;

                UpdateFilteredContacts();
                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));

                // Очищаем ошибки
                _errors.Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));

                SaveData();
            }
            else if (_isInEditMode)
            {
                IsInEditMode = false;
                _contactBeforeEdit = null;

                UpdateFilteredContacts();

                // Очищаем ошибки
                _errors.Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));

                SaveData();
            }
        }

        /// <summary>
        /// Отмена редактирования/добавления
        /// </summary>
        private void CancelEditing()
        {
            if (_isInAddMode)
            {
                _tempContact = null;
                IsInAddMode = false;
                _selectedContact = null;

                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));
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

                IsInEditMode = false;
                _contactBeforeEdit = null;
            }

            // Очищаем ошибки
            _errors.Clear();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));
        }

        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Метод для вызова события изменения свойства
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}