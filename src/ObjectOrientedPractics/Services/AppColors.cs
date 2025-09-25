using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    internal class AppColors
    {
        /// <summary>
        /// Базовый цвет для корректного ввода
        /// </summary>
        public static System.Drawing.Color BaseInput => System.Drawing.Color.White;

        /// <summary>
        /// Цвет для ошибочного ввода
        /// </summary>
        public static System.Drawing.Color ErrorInput => System.Drawing.Color.LightPink;
    }
}
