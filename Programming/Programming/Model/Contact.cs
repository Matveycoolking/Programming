using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programming.Model
{
    class Contact
    {
        private string _Name;
        private string _Surname;

        public Contact(string name, string surname) 
        {
            if(!AssertStringContainsOnlyLetters(name) || !AssertStringContainsOnlyLetters(surname))
            {
                throw new ArgumentException("Имя должно содержать английские буквы");
            }
            else
            {
                throw new ArgumentException("Фамилия должна содержать английские буквы");
            }

            _Name = name;
            _Surname = surname;
        }

        private bool AssertStringContainsOnlyLetters(string input)
        {
            return Regex.IsMatch(input, @"^[A-Za-z]+$");
        }
    }
}
