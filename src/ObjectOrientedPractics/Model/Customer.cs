using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    internal class Customer
    {
        
        private readonly int _id;
        private string _fullname;
        private string _address;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="address"></param>
        /// <param name="id"></param>
        public Customer(string fullname, string address, int id = 0)
        {
            if ( id == 0 )
            {
                _id = IdGenerator.GetNextId();
            }
            else
            {
                _id = id;
            }

            ValueValidator.ValidateCustomerValues(fullname, address);
            _fullname = fullname;
            _address = address;
        }
        /// <summary>
        /// свойства для айди
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// Свойства для полного имени
        /// </summary>
        public string FullName
        {
            get => _fullname;
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, nameof(FullName));
                _fullname = value;
            }
        }
        /// <summary>
        /// свойства для адреса
        /// </summary>
        public string Address
        {
            get => _address;
            set
            {
                ValueValidator.AssertStringOnLength(_address, 200, nameof(Address));
                _address = value;
            }
        }
       
    }
}
