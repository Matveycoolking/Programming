using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Customer
    {

        private readonly int _id;
        private string _fullname;
        private Address _address;
        private Cart _cart;
        private List<Order> _orders;



        /// <summary>
        /// Конструктор с параметрами адреса (КОМПОЗИЦИЯ)
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="index"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="building"></param>
        /// <param name="apartment"></param>
        /// <param name="id"></param>
        public Customer(string fullname, int index, string country, string city,
                       string street, string building, string apartment, int id = 0)
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
            // СОЗДАЕМ адрес внутри конструктора - это композиция
            _address = new Address(index, country, city, street, building, apartment);
            _cart = new Cart(); // композиция т.к при удаление покупателя удалиться и корзина
            _orders = new List<Order>();
        }
        /// <summary>
        /// конструктор при копирование.
        /// </summary>
        /// <param name="other"></param>
        public Customer(Customer other)
        {
            _id = other.Id;
            _fullname = other.FullName;
            // СОЗДАЕМ новый адрес на основе существующего
            _address = new Address(
                other.Address.Index,
                other.Address.Country,
                other.Address.City,
                other.Address.Street,
                other.Address.Building,
                other.Address.Apartment
            );
            _cart = new Cart();
            _orders = new List<Order>();
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
            private set => _address = value;
        }
        /// <summary>
        /// свойсвта для корзины.
        /// </summary>
        public Cart Cart
        {
            get => _cart;
            private set => _cart = value;
        }

        /// <summary>
        /// Список заказов покупателя.
        /// </summary>
        public List<Order> Orders
        {
            get => _orders;
            private set => _orders = value;
        }

        /// <summary>
        ///  Метод для обновления адреса (вместо сеттера)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="building"></param>
        /// <param name="apartment"></param>
        public void UpdateAddress(int index, string country, string city,
                                 string street, string building, string apartment)
        {
            _address = new Address(index, country, city, street, building, apartment);
        }


    }
}