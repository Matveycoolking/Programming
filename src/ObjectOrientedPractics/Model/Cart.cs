using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Cart
    {
        /// <summary>
        /// Список товаров в корзине.
        /// агрегация т.к время жизни разное
        /// при удаления корзины не удаляет товар
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Конструктор по умолчанию. Инициализирует новый экземпляр класса Cart.
        /// </summary>
        public Cart()
        {
            _items = new List<Item>();
        }

        /// <summary>
        /// Возвращает или задает список товаров в корзине.
        /// </summary>
        public List<Item> Items
        {
            get => _items;
            set => _items = value;
        }

        /// <summary>
        /// Возвращает общую стоимость всех товаров в корзине.
        /// Вычисляется с помощью цикла. Если список пустой или равен null, возвращает 0.0.
        /// </summary>
        public double Amount
        {
            get
            {
                if (_items == null || _items.Count == 0)
                {
                    return 0.0;
                }

                double totalAmount = 0.0;

                foreach (var item in _items)
                {
                    totalAmount += item.Cost;
                }

                return totalAmount;
            }
        }
        /// <summary>
        /// Вычисляет общую стоимость всех товаров в корзине
        /// </summary>
        /// <returns>Общая стоимость</returns>
        public decimal GetTotalAmount()
        {
            return _items.Sum(item => (decimal)item.Cost);
        }
    }
}