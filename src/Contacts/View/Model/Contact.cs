using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    public class Contact
    {
        private string _name;
        private string _email;
        private string _phoneNumber;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Имя не может быть пустым");
                }
                _name = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Некорректный email");
                }
                _email = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Некорректный номер телефона");
                }
                _phoneNumber = value;
            }
        }

        public Contact(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Contact()
        {
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }
    }
}
