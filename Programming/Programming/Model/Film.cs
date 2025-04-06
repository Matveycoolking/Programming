using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Enums
{
    /// <summary>
    /// класс Film
    /// </summary>
    public class Film
    {
        // поля данные класса
        private string _Title;
        private int _Durability;
        private int _Year;
        private Genre _Genre;
        private float _Rating;
        /// <summary>
        /// доступ к полям
        /// </summary>

        public string Title
        {
            get { return _Title; }
            set { _Title = value; } 
        }

        public int Durability
        {
            get { return _Durability; }
            set { _Durability = value; }
        }

        public int Year
        {
            get { return _Year; }
            set {
                Validator.AssertValueInRange(value, 1900, DateTime.Now.Year, nameof(_Year));
                _Year = value; }
        }

        public Genre Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        public float Rating
        {
            get { return _Rating; }
            set {
                Validator.AssertValueInRange((int)value, 0, 10, nameof(_Rating));
                _Rating = value; }
        }
    }
}
