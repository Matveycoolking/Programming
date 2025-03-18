using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Enums
{
    /// <summary>
    /// класс Race
    /// </summary>
    public class Race
    {
        // поля данные класса
        private string StartPoint;
        private string DestinationPoint;
        private int time;
        /// <summary>
        /// инициализация класса
        /// </summary>
        /// <param name="StartPoint">начальная точка</param>
        /// <param name="DestinationPoint">дистанция перелёта</param>
        /// <param name="time">время</param>
        public Race(string StartPoint, string DestinationPoint, int time)
        {
            this.StartPoint = StartPoint;
            this.DestinationPoint = DestinationPoint;
            this.time = time;
        }
        /// <summary>
        /// доступ к полям
        /// </summary>
        public string startPoint
        {
            get { return StartPoint; }
            set { StartPoint = value; }
        }
        public string destinationPoint
        {
            get { return DestinationPoint; }
            set { DestinationPoint = value; }
        }
        public int Time
        {
            get { return time; }
            set {if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(time), "диапозон должен быть положительным");
                }
                time = value; }
        }
    }
}
