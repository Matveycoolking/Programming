using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Item
    {
        private readonly int _id;
        private string _name;
        private string _info;
        private double _cost;
        private Category _category;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">айди</param>
        /// <param name="name">название</param>
        /// <param name="info">информация</param>
        /// <param name="cost">цена</param>
        /// <param name="category">категория</param>
        public Item(string name, string info, double cost, Category category, int id = 0)
        {
            if (id == 0)
            {
                _id = IdGenerator.GetNextItemId();
            }
            else
            {
                _id = id;
            }

            ValueValidator.ValidateItemValues(name, info, cost);
            _name = name;
            _info = info;
            _cost = cost;
            _category = category;
        }

        /// <summary>
        /// автосвойства для Id 
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// свойсвта с валидацией
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Свойства с валидацией
        /// </summary>

        public string Info
        {
            get => _info;
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, nameof(Info));
                _info = value;
            }
        }

        /// <summary>
        /// Свойсвта с валидацией
        /// </summary>
        public double Cost
        {
            get => _cost;
            set
            {
                ValueValidator.ValidateCost(value);
                _cost = value;
            }
        }

        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category
        {
            get => _category;
            set => _category = value;
        }

    }
}