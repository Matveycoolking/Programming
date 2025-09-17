using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedPractics.Services
{
    internal class ValueValidator
    {
        /// <summary>
        /// Специальный метод для валидации строк
        /// </summary>
        /// <param name="value">название предмета для валидации</param>
        /// <param name="maxLength">максимальная длинна</param>
        /// <param name="propertyName">возврат свойства</param>
        /// <exception cref="ArgumentException"></exception>
        internal static void AssertStringOnLength(string value, int maxLength, string propertyName)
        {
            
            if(value != null && value.Length > maxLength)
            {
                throw new ArgumentException($"{propertyName} должен быть меньше {maxLength} символов. " +
                    $"Текущая длина: {value.Length} символов");
            }
        }
        /// <summary>
        /// Валидация для цены
        /// </summary>
        /// <param name="cost"></param>
        /// <exception cref="ArgumentException"></exception>
        internal static void ValidateCost(double cost)
        {
            if(cost<0 || cost>100_000)
            {
                throw new ArgumentException("Incorrect Cost");
            }
        }
        /// <summary>
        /// уникальный метод для валидации всех объектов для предметов
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="cost"></param>
        internal static void ValidateItemValues(string name, string info, double cost)
        {
            AssertStringOnLength(name, 200, "Название товара");
            AssertStringOnLength(info, 1000, "Описание товара");
            ValidateCost(cost);
        }
        /// <summary>
        /// метод для валидации всех объектов для покупателя
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="address"></param>
        internal static void ValidateCustomerValues(string fullName, string address)
        {
            AssertStringOnLength(fullName, 200, "Полное имя");
            AssertStringOnLength(address, 500, "Адрес");


        }

    }
}
