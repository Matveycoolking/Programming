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
                Validator.AssertValueInRange(value, 0, 23, nameof(_hours));
                _hours = value;
            }
        }

        // Целочисленное поле Минуты (от 0 до 59)
        private int _minutes;
        public int Minutes
        {
            get { return _minutes; }
            set
            {Validator.AssertValueInRange(value,0,59, nameof(_minutes));
                _minutes = value;
            }
        }

        // Целочисленное поле Секунды (от 0 до 59)
        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {Validator.AssertValueInRange(value, 0, 59, nameof(_seconds));
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
