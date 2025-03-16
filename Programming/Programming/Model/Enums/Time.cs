using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Enums
{
    public class Time
    {
        // Целочисленное поле Часы (от 0 до 23)
        private int _hours;
        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(Hours), "Часы должны быть в диапазоне от 0 до 23.");
                }
                _hours = value;
            }
        }

        // Целочисленное поле Минуты (от 0 до 59)
        private int _minutes;
        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(Minutes), "Минуты должны быть в диапазоне от 0 до 59.");
                }
                _minutes = value;
            }
        }

        // Целочисленное поле Секунды (от 0 до 59)
        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(Seconds), "Секунды должны быть в диапазоне от 0 до 59.");
                }
                _seconds = value;
            }
        }

        // Конструктор класса
        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;   // Здесь будет вызван сеттер с проверкой
            Minutes = minutes; // Здесь будет вызван сеттер с проверкой
            Seconds = seconds; // Здесь будет вызван сеттер с проверкой
        }
    }
 }
