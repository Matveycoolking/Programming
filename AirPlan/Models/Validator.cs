using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlan.Models
{
    public static class Validator
    {
        public static bool AssertValueInRange(int value, int min, int max, string propertyName)
        {
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Некорректное значение в свойстве {propertyName}. Значение должно быть в диапазоне от {min} до {max}.");
            }
        }

    }
}
