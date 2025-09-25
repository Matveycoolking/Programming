using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    internal class IdGenerator
    {
        private static int _currentItemId = 1;
        private static int _currentCustomerId = 1;

        /// <summary>
        /// переход к след айди.
        /// </summary>
        /// <returns></returns>
        public static int GetNextItemId()
        {
            return _currentItemId++;
        }
        /// <summary>
        /// переход к след айди
        /// </summary>
        /// <returns></returns>
        public static int GetNextCustomerId()
        {
            return _currentCustomerId++;
        }
        /// <summary>
        /// перезапуск айди
        /// </summary>
        /// <param name="startValue">начальное значение</param>
        public static void ResetItemId(int startValue = 1)
        {
            _currentItemId = startValue;
        }
        /// <summary>
        /// перезапуск айди
        /// </summary>
        /// <param name="startValue">начальное значение</param>

        public static void ResetCustomerId(int startValue = 1)
        {
            _currentCustomerId = startValue;
        }
     }
}
