using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model.Orders
{
    public class Order
    {
        protected readonly int _id;
        protected readonly DateTime _date;
        protected List<Item> _items;
        protected double _amount;
        protected Address _address;
        protected OrderStatus _status;
        protected bool _isPriority;
        protected double _discountAmount;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Order()
        {
            _id = IdGenerator.GetNextOrderId();
            _date = DateTime.Now;
            _items = new List<Item>();
            _amount = 0.0;
            _status = OrderStatus.New;
            _isPriority = false;
            _discountAmount = 0.0;
        }

        /// <summary>
        /// Конструктор на основе корзины и адреса.
        /// </summary>
        /// <param name="cart">Корзина товаров.</param>
        /// <param name="address">Адрес доставки.</param>
        public Order(Cart cart, Address address)
        {
            _id = IdGenerator.GetNextOrderId();
            _date = DateTime.Now;
            _address = address;
            _items = new List<Item>();
            if (cart?.Items != null)
            {
                foreach (var item in cart.Items)
                {
                    _items.Add(item); // Добавляем товары в заказ
                }
            }
            _amount = cart?.Amount ?? 0.0; // Используем стоимость из корзины
            _status = OrderStatus.New;
            _isPriority = false;
            _discountAmount = 0.0;
        }

        /// <summary>
        /// Уникальный идентификатор заказа (только для чтения).
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Дата создания заказа (только для чтения).
        /// </summary>
        public DateTime Date => _date;

        /// <summary>
        /// Адрес доставки заказа.
        /// </summary>
        public Address Address
        {
            get => _address;
            set => _address = value;
        }

        /// <summary>
        /// Список товаров в заказе.
        /// АГРЕГАЦИЯ: товары существуют независимо от заказа
        /// </summary>
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                UpdateAmount(); // Обновляем стоимость при изменении списка
            }
        }

        /// <summary>
        /// Общая стоимость заказа (аналогична общей стоимости из корзины).
        /// </summary>
        public double Amount
        {
            get => _amount;
            private set => _amount = value;
        }
        /// <summary>
        /// перечисление статусов.
        /// </summary>
        public OrderStatus Status
        {
            get => _status;
            set => _status = value;
        }
        /// <summary>
        /// Указывает, является ли заказ приоритетным
        /// </summary>
        public bool IsPriority
        {
            get => _isPriority;
            set => _isPriority = value;
        }
       
        /// <summary>
        /// Размер примененной скидки
        /// </summary>
        public double DiscountAmount
        {
            get => _discountAmount;
            set => _discountAmount = value;
        }

        /// <summary>
        /// Конечная стоимость заказа с учетом скидки
        /// </summary>
        public double Total
        {
            get => _amount - _discountAmount;
        }


        /// <summary>
        /// Обновляет общую стоимость заказа на основе списка товаров.
        /// </summary>
        private void UpdateAmount()
        {
            _amount = 0.0;
            if (_items != null)
            {
                foreach (var item in _items)
                {
                    _amount += item.Cost;
                }
            }
        }
    }
}
