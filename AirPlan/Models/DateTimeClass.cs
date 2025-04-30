using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlan.Models
{
    public class DepartureTime : IComparable<DepartureTime>
    {
        private DateTime _departure;


        public DateTime Departure
        {
            get => _departure;
            set
            {
                if (value.Date > DateTime.Today)
                    throw new ArgumentException("Время вылета не может быть раньше сегодняшнего дня");

                _departure = value;
            }
        }

        public DepartureTime()
        {
            _departure = DateTime.Today; // Значение по умолчанию - текущее время
        }

        public DepartureTime(DateTime departureTime)
        {
            try
            {
                Departure = departureTime; // Это вызовет исключение, если дата недопустима
            }
            catch (ArgumentException ex)
            {
                // Здесь можно обработать исключение, если нужно
                throw new ArgumentException("Недопустимая дата: " + ex.Message);
            }
        }
        public int CompareTo(DepartureTime other)
        {
            if (other == null) return 1; // Если other - null, текущий объект больше
            return Departure.CompareTo(other.Departure); // Сравнение по времени вылета
        }

        // Переопределение ToString для удобного отображения
        public override string ToString()
        {
            return _departure.ToString("dd.MM.yyyy"); // Формат даты
        }
    }
}