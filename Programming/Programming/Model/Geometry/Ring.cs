using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    class Ring
    {
        private Point2D center;
        private double outerRadious;
        private double innerRadious;

        public Point2D Center
        {
            get { return center; }
            set { center = value; }
        }
        public double OuterRadious
        {
            get { return outerRadious; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(outerRadious));
                if (value < innerRadious)
                    throw new ArgumentException("Внешний радиус не может быть меньше внутреннего радиуса.");
                outerRadious = value;
            }
        }
        public double InnerRadious
        {
            get { return innerRadious; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(innerRadious));
                if (value > outerRadious)
                    throw new ArgumentException("Внутренний радиус не может быть больше внешнего радиуса.");
                innerRadious = value;
            }
        }
        public Ring(Point2D center, double outerRadious, double innerRadious)
        {
            Center = center;
            OuterRadious = outerRadious; // Вызовет сеттер и проверит значение
            InnerRadious = innerRadious; // Вызовет сеттер и проверит значение
        }
        public double Area => Math.PI * (outerRadious * outerRadious - innerRadious * innerRadious);
    }
}
