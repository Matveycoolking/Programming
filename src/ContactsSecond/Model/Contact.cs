using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Model
{
    public class Contact : ObservableObject
    {
        private string _name;
        private string _email;
        private string _phoneNumber;

        /// <summary>
        /// Свойства контакта.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        /// <summary>
        /// констурктор с параметрами.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="email">Почта.</param>
        /// <param name="phoneNumber">Телефонный номер.</param>
        public Contact(string name, string email, string phoneNumber)
        {
            _name = name;
            _email = email;
            _phoneNumber = phoneNumber;
        }


        /// <summary>
        /// конструктор по умолчанию.
        /// </summary>
        public Contact()
        {
            _name = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }

        /// <summary>
        /// Метод для создания копии контакта
        /// </summary>
        public Contact Clone()
        {
            return new Contact
            {
                Name = this.Name,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber
            };
        }
    }
}
