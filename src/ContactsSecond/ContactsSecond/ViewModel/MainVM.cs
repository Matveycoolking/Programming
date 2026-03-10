// View/ViewModel/MainVM.cs
using System;
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
    public class MainVM : INotifyPropertyChanged
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
        /// Конструктор по умолчанию
        /// </summary>
        public MainVM()
        {
            // Инициализация коллекций
            _contacts = new ObservableCollection<Contact>();
            _filteredContacts = new ObservableCollection<Contact>();

            // Загрузка данных из файла
            LoadData();

            // Если данных нет (первый запуск), загружаем тестовые данные
            if (_contacts.Count == 0)
            {
                LoadTestData();
            }

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
            if (loadedContacts.Any())
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
        /// Загрузка тестовых данных (только если нет сохраненных)
        /// </summary>
        private void LoadTestData()
        {
            var testContacts = new[]
            {
                new Contact("Абельцев Сергей", "abeltsev@mail.com", "+7 (901) 234-56-78"),
                new Contact("Абраменков Дмитрий", "abramenkov@mail.com", "+7 (902) 345-67-89"),
                new Contact("Аверчев Владимир", "averchev@mail.com", "+7 (903) 456-78-90"),
                new Contact("Алфёров Жорес", "alferov@mail.com", "+7 (904) 567-89-01"),
                new Contact("Бабичев Игорь", "babichev@mail.com", "+7 (905) 678-90-12"),
                new Contact("Багаутдинов Габдуллахит", "bagautdinov@mail.com", "+7 (906) 789-01-23"),
                new Contact("Безбородов Николай", "nikolai.bezborodov@no.mail", "+7 (999) 111-22-33")
            };

            foreach (var contact in testContacts)
            {
                _contacts.Add(contact);
            }
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

        // Свойства для привязки данных (прокси к выбранному контакту)
        public string Name
        {
            get { return SelectedContact?.Name ?? string.Empty; }
            set
            {
                if (SelectedContact != null && SelectedContact.Name != value)
                {
                    SelectedContact.Name = value;
                    OnPropertyChanged();

                    // Обновляем отображение в списке, но без вызова дополнительных событий
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

        /// <summary>
        /// Обновление отфильтрованного списка
        /// </summary>
        private void UpdateFilteredContacts()
        {
            // Предотвращаем рекурсию
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

        // Реализация команд
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
                    // Выбираем следующий или предыдущий контакт
                    if (currentIndex < _contacts.Count)
                        SelectedContact = _contacts[currentIndex];
                    else
                        SelectedContact = _contacts[_contacts.Count - 1];
                }
                else
                {
                    SelectedContact = null;
                }

                // Обновляем фильтр
                UpdateFilteredContacts();

                // Сохраняем изменения
                SaveData();
            }
        }

        private bool CanExecuteApply(object? parameter)
        {
            return true;
        }

        private void ExecuteApply(object? parameter)
        {
            if (_isInAddMode && _tempContact != null)
            {
                // Добавляем новый контакт в коллекцию
                _contacts.Add(_tempContact);
                _selectedContact = _tempContact;
                _tempContact = null;

                IsInAddMode = false;

                // Обновляем фильтр
                UpdateFilteredContacts();

                // Обновляем привязки
                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));

                // Сохраняем изменения
                SaveData();
            }
            else if (_isInEditMode)
            {
                // Выходим из режима редактирования
                IsInEditMode = false;
                _contactBeforeEdit = null;

                // Обновляем фильтр
                UpdateFilteredContacts();

                // Сохраняем изменения
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
                // Просто выходим из режима добавления
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
                // Восстанавливаем сохраненные данные
                _selectedContact.Name = _contactBeforeEdit.Name;
                _selectedContact.Email = _contactBeforeEdit.Email;
                _selectedContact.PhoneNumber = _contactBeforeEdit.PhoneNumber;

                // Обновляем отображение
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(PhoneNumber));

                // Обновляем фильтр
                UpdateFilteredContacts();

                IsInEditMode = false;
                _contactBeforeEdit = null;
            }
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