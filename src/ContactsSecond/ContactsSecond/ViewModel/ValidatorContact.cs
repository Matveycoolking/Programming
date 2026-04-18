using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using View.Model;

namespace View.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactValidator : INotifyDataErrorInfo
        {
            private readonly Dictionary<string, List<string>> _errors = new();
            private Contact _contact;

            public ContactValidator(Contact contact)
            {
                _contact = contact ?? throw new ArgumentNullException(nameof(contact));
            }

            /// <summary>
            /// Проверка имени (публичный метод)
            /// </summary>
            public void ValidateName()
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(_contact.Name))
                {
                    errors.Add("Имя не может быть пустым");
                }
                else if (_contact.Name.Length > 100)
                {
                    errors.Add("Имя должно быть меньше 100 символов");
                }

                UpdateErrors(nameof(Contact.Name), errors);
            }

            /// <summary>
            /// Проверка номера телефона (публичный метод)
            /// </summary>
            public void ValidatePhoneNumber()
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(_contact.PhoneNumber))
                {
                    errors.Add("Телефонный номер не может быть пустым");
                }
                else if (_contact.PhoneNumber.Length > 100)
                {
                    errors.Add("Телефонный номер должен быть меньше 100 символов");
                }
                else if (!IsValidPhoneNumber(_contact.PhoneNumber))
                {
                    errors.Add("Телефонный номер может содержать цифры и + - () пример: 8 923 406 5501");
                }

                UpdateErrors(nameof(Contact.PhoneNumber), errors);
            }

            /// <summary>
            /// Проверка email (публичный метод)
            /// </summary>
            public void ValidateEmail()
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(_contact.Email))
                {
                    errors.Add("Почта не может быть пустой");
                }
                else if (_contact.Email.Length > 100)
                {
                    errors.Add("Почта должна содержать меньше 100 символов");
                }
                else if (!_contact.Email.Contains('@'))
                {
                    errors.Add("Почта обязана содержать @ символ");
                }

                UpdateErrors(nameof(Contact.Email), errors);
            }

            /// <summary>
            /// Проверка всех полей сразу
            /// </summary>
            public void ValidateAll()
            {
                ValidateName();
                ValidatePhoneNumber();
                ValidateEmail();
            }

            /// <summary>
            /// Проверка корректности формата телефона через Regex
            /// </summary>
            private bool IsValidPhoneNumber(string phone)
            {
                if (string.IsNullOrWhiteSpace(phone))
                    return false;

                string pattern = @"^[\d+\-\(\)\s]+$";
                return Regex.IsMatch(phone, pattern);
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
            }

            /// <summary>
            /// Проверка валидности всего контакта
            /// </summary>
            public bool IsValid => _errors.Count == 0;

            /// <summary>
            /// Проверка валидности конкретного контакта (статический метод)
            /// </summary>
            public static bool IsContactValid(Contact contact)
            {
                if (contact == null) return false;

                // Проверка имени
                if (string.IsNullOrWhiteSpace(contact.Name) || contact.Name.Length > 100)
                    return false;

                // Проверка телефона
                if (string.IsNullOrWhiteSpace(contact.PhoneNumber) || contact.PhoneNumber.Length > 100)
                    return false;

                string pattern = @"^[\d+\-\(\)\s]+$";
                if (!Regex.IsMatch(contact.PhoneNumber, pattern))
                    return false;

                // Проверка email
                if (string.IsNullOrWhiteSpace(contact.Email) || contact.Email.Length > 100 || !contact.Email.Contains('@'))
                    return false;

                return true;
            }

            /// <inheritdoc/>
            public bool HasErrors => _errors.Count > 0;

        /// <inheritdoc/>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        /// <inheritdoc/>
        public IEnumerable GetErrors(string? propertyName)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    return Array.Empty<string>();
                }

                return _errors.TryGetValue(propertyName, out var errors) ? errors : Array.Empty<string>();
            }
        }
}

    