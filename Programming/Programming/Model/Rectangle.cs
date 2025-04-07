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
        private string name;
        private string color;
        private static int _allRectanglesCount;
        private int _id;
       

        internal Point2D Center { get; set; }
        /// <summary>
        /// конструктр инициализация
        /// </summary>
        /// <param name="width">ширина</param>
        /// <param name="height">высота</param>
        internal Rectangle(float width, float height, Point2D center)
        {
            this.width = width;
            this.height = height;
            this.Center = center;
            center = new Point2D(center.X, center.Y); // возможно заменить
            _allRectanglesCount++;
            this._id = _allRectanglesCount;
            

        }
        public int ID => _id;
        /// <summary>
        /// свойства доступ к полям
        /// </summary>
        public int Width
        {
            get { return (int)width; }
            set {
                Validator.AssertOnPositiveValue(value, nameof(width));
                width = value; }
        }
        public int Height
        {
            get { return (int)height; }
            set { Validator.AssertOnPositiveValue(value, nameof(height));
                height = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public static int AllRectanglesCount()
        {
            return _allRectanglesCount;
        }
    }
}
