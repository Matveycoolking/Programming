using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Address
    {
        private int _index;
        private string _country;
        private string _city;
        private string _street;
        private string _building;
        private string _apartment;

        /// <summary>
        /// Почтовый индекс (целое шестизначное число)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение не является шестизначным числом</exception>
        public int Index
        {
            get { return _index; }
            set
            {
                if (value < 100000 || value > 999999)
                    throw new ArgumentException("Почтовый индекс должен быть шестизначным числом");
                _index = value;
            }
        }

        /// <summary>
        /// Страна/регион (не более 50 символов)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 50 символов</exception>
        public string Country
        {
            get { return _country; }
            set
            {
                if (value?.Length > 50)
                    throw new ArgumentException("Название страны не может превышать 50 символов");
                _country = value;
            }
        }

        /// <summary>
        /// Город (населенный пункт) (не более 50 символов)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 50 символов</exception>
        public string City
        {
            get { return _city; }
            set
            {
                if (value?.Length > 50)
                    throw new ArgumentException("Название города не может превышать 50 символов");
                _city = value;
            }
        }

        /// <summary>
        /// Улица (не более 100 символов)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 100 символов</exception>
        public string Street
        {
            get { return _street; }
            set
            {
                if (value?.Length > 100)
                    throw new ArgumentException("Название улицы не может превышать 100 символов");
                _street = value;
            }
        }
        /// <summary>
        /// Номер дома (не более 10 символов)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 10 символов</exception>
        public string Building
        {
            get { return _building; }
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentException("Номер дома не может превышать 10 символов");
                _building = value;
            }
        }

        /// <summary>
        /// Номер квартиры/помещения (не более 10 символов)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 10 символов</exception>
        public string Apartment
        {
            get { return _apartment; }
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentException("Номер квартиры не может превышать 10 символов");
                _apartment = value;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Конструктор с аргументами для инициализации данных объекта
        /// </summary>
        /// <param name="index">Почтовый индекс</param>
        /// <param name="country">Страна/регион</param>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="building">Номер дома</param>
        /// <param name="apartment">Номер квартиры</param>
        public Address(int index, string country, string city, string street, string building, string apartment)
        {
            _index = index;
            _country = country;
            _city = city;
            _street = street;
            _building = building;
            _apartment = apartment;
        }
}
}
