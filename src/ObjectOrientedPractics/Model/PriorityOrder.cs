using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class PriorityOrder : Order
    {
        private DateTime _deliveryDate;
        private DeliveryTimeRange _deliveryTimeRange;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public PriorityOrder()
        {
            IsPriority = true; // Добавить эту строку
        }

        /// <summary>
        /// Конструктор на основе корзины и адреса.
        /// </summary>
        /// <param name="cart">Корзина товаров.</param>
        /// <param name="address">Адрес доставки.</param>
        public PriorityOrder(Cart cart, Address address) : base(cart, address)
        {
            IsPriority = true; // Добавить эту строку
        }

        /// <summary>
        /// Конструктор по всем полям класса.
        /// </summary>
        /// <param name="cart">Корзина товаров.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="deliveryDate">Желаемая дата доставки.</param>
        /// <param name="deliveryTimeRange">Желаемое время доставки.</param>
        public PriorityOrder(Cart cart, Address address, DateTime deliveryDate, DeliveryTimeRange deliveryTimeRange)
            : base(cart, address)
        {
            IsPriority = true;  
            _deliveryDate = deliveryDate;
            _deliveryTimeRange = deliveryTimeRange;
        }

        /// <summary>
        /// Время доставки приоритетного заказа.
        /// </summary>
        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }

        /// <summary>
        /// Желаемое время доставки.
        /// </summary>
        public DeliveryTimeRange DeliveryTimeRange
        {
            get { return _deliveryTimeRange; }
            set { _deliveryTimeRange = value; }
        }
    }
}
