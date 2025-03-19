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
        private string _Genre;
        private float _Rating;
        /// <summary>
        /// инициализация класса
        /// </summary>
        /// <param name="_Title">имя</param>
        /// <param name="_Durability">продолжительность</param>
        /// <param name="_Year">год от 1900 до нашего</param>
        /// <param name="_Genre">жанр</param>
        /// <param name="_Rating">рейтинг от 0 до 1</param>
       public Film(string _Title, int _Durability, int _Year, string _Genre, float _Rating)
        {
            this._Title = _Title;
            this._Durability = _Durability;
            this._Year = _Year;
            this._Genre = _Genre;
            this._Rating = _Rating;
        }
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
                if (value < 1900 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException(nameof(_Year), "Год выпуска должен быть в диапазоне от 1900 до текущего года.");
                }
                _Year = value; }
        }

        public string Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        public float Rating
        {
            get { return _Rating; }
            set { if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(Rating), "Рейтинг должен быть в диапазоне от 0 до 10.");
                }
                _Rating = value; }
        }
    }
}
