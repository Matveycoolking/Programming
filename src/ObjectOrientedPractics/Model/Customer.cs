﻿using ObjectOrientedPractics.Services;
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
        private Address _address;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="address"></param>
        /// <param name="id"></param>
        public Customer(string fullname, Address address, int id = 0)
        {
            if (id == 0)
            {
                _id = IdGenerator.GetNextCustomerId();
            }
            else
            {
                _id = id;
            }

            
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
        public Address Address 
        {
            get => _address;
            set
            {
                
                _address = value;
            }
        }

    }
}