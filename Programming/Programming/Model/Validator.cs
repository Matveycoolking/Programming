using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
   public static class Validator
    {
        public static void AssertOnPositiveValue(int value, string nowName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Свойство{nowName} должно быть положительным");
            }
        }
        public static void AssertOnPositiveValue(double value, string nowName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Свойство {nowName} должно быть положительным");
            }
        }
        public static void AssertValueInRange(int value, int min, int max, string nowName)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"свойство {nowName} должно быть в диапозоне от {min} до {max}");
            }
        }
    }
}
