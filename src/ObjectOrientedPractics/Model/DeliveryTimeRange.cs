using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public enum DeliveryTimeRange
    {
        /// <summary>
        /// 9:00 – 11:00
        /// </summary>
        Morning9_11 = 0,

        /// <summary>
        /// 11:00 – 13:00
        /// </summary>
        Day11_13 = 1,

        /// <summary>
        /// 13:00 – 15:00
        /// </summary>
        Day13_15 = 2,

        /// <summary>
        /// 15:00 – 17:00
        /// </summary>
        Afternoon15_17 = 3,

        /// <summary>
        /// 17:00 – 19:00
        /// </summary>
        Evening17_19 = 4,

        /// <summary>
        /// 19:00 – 21:00
        /// </summary>
        Evening19_21 = 5
    }
}
