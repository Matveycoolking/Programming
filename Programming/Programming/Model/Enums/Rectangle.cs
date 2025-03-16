using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Enums
{
    /// <summary>
    /// конструктр класса прямоугольник
    /// </summary>
    public class Rectangle
    {
        // Поля данные класса
        private float width;
        private float height;
       // private string name;
        private string color;

        /// <summary>
        /// конструктр инициализация
        /// </summary>
        /// <param name="width">ширина</param>
        /// <param name="height">высота</param>
        public Rectangle(float width, float height, string color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }
        /// <summary>
        /// свойства доступ к полям
        /// </summary>
        public int Width
        {
            get { return (int)width; }
            set { if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(width), "диапозон должен быть положительным");
                } 
                width = value; }
        }
        public int Heigh
        {
            get { return (int)height; }
            set { if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(height), "диапозон должен быть положительным");
                }
                height = value; }
        }
        /*public string Name
        {
            get { return name; }
            set { name = value; }
        }*/
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
