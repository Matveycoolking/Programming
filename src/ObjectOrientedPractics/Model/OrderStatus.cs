using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public enum OrderStatus
    {
        /// <summary>
        /// Новый заказ.
        /// </summary>
        New=0,

        /// <summary>
        /// Обрабатывается.
        /// </summary>
        Processing=1,

        /// <summary>
        /// Собирается на складе.
        /// </summary>
        Assembly=2,

        /// <summary>
        /// Отправлен.
        /// </summary>
        Sent=3,

        /// <summary>
        /// Доставлен.
        /// </summary>
        Delivered=4,

        /// <summary>
        /// Возврат.
        /// </summary>
        Returned=5,

        /// <summary>
        /// Отменен (со стороны магазина).
        /// </summary>
        Abandoned=6

    }
}
