using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlan.Models.Enums;

namespace AirPlan.Models
{
    public class Fly : IComparable<Fly>
    {
        private string _nameStart;
        private string _nameEnd;
        private DepartureTime _startTime;
        private int _timeInFly;
        public Flying TypeFly { get; set; }

        public static List<Fly> Flys { get; set; } = new List<Fly>();

        // Конструктор класса Fly
        public Fly(string nameStart, string nameEnd, DepartureTime startTime, int timeInFly, Flying typeFly)
        {
            _nameStart = nameStart;
            _nameEnd = nameEnd;
            _startTime = startTime;
            _timeInFly = timeInFly;
            TypeFly = typeFly; // Инициализация свойства
        }
        
        public string NameStart
        {
            get
            {
                return _nameStart;
            }
            set
            {
                if (Validator.AssertValueInRange(value.Length, 1, 101, nameof(NameStart)))
                    {
                    _nameStart = value;
                    }
                
            }
        }

        public string NameEnd
        {
            get
            {
                return _nameEnd;
            }
            set
            {
                if (Validator.AssertValueInRange(value.Length, 1, 101, nameof(NameEnd)))
                {
                    _nameEnd = value;
                }
                
            }
        }

        public DepartureTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public int TimeInFly
        {
            get
            {
                return _timeInFly;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 0, 1000, nameof(TimeInFly)))
                {
                    _timeInFly = value;
                }
                
            }
        }

        public int CompareTo(Fly other)
        {
            if (other == null) return 1; // Если other - null, текущий объект больше
            return StartTime.CompareTo(other.StartTime); // Сравнение по времени вылета
        }
    }
}
