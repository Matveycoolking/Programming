using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Item : ICloneable, IEquatable<Item>, IComparable<Item>
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


        /// <summary>
        /// создаёт объект копию класса Item.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Item(_name, _info, _cost, _category);
        }

        /// <summary>
        /// Определяет, равен ли указанный объект текущему объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns>true, если указанный объект равен текущему объекту; в противном случае — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Item other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Определяет, равен ли указанный объект Item текущему объекту Item.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Item other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return _id == other._id &&
                   _name == other._name &&
                   _info == other._info &&
                   _cost == other._cost &&
                   _category == other._category;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего объекта.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _id.GetHashCode();
                hash = hash * 23 + (_name?.GetHashCode() ?? 0);
                hash = hash * 23 + (_info?.GetHashCode() ?? 0);
                hash = hash * 23 + _cost.GetHashCode();
                hash = hash * 23 + _category.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Сравнивает текущий объект Item с другим объектом Item по стоимости.
        /// </summary>
        /// <param name="other">Объект Item для сравнения с текущим объектом.</param>
        /// <returns>
        /// Меньше нуля: текущий объект меньше другого объекта по стоимости.
        /// Ноль: объекты равны по стоимости.
        /// Больше нуля: текущий объект больше другого объекта по стоимости.
        /// </returns>
        public int CompareTo(Item other)
        {
            if (other is null) return 1; // null всегда меньше любого объекта

            return _cost.CompareTo(other._cost);
        }
    }
}