using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    internal class Item
    {
        private readonly int _id;
        private int _customerId;
        private string _name;
        private string _info;
        private double _cost;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="cost"></param>
        public Item(string name, string info, double cost, int customerId = 0,  int id = 0)
        {
            if (id == 0)
            {
                _id = IdGenerator.GetNextId();
            }
            else
            {
                _id = id;
            }

            ValueValidator.ValidateItemValues(name, info, cost);
            _customerId = customerId;
            _name = name;
            _info = info;
            _cost = cost;
        }
        
        /// <summary>
        /// свойства
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// свойства
        /// </summary>

        public int CustomerId => _customerId;

        /// <summary>
        /// свойсвта с валидацией
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ValueValidator.AssertStringOnLength(value,200,nameof(Name));
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
                ValueValidator.AssertStringOnLength(value,1000,nameof(Info));
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
        /// Метод для перезагрузки счётчика;
        /// </summary>
        /// <param name="startValue"></param>
        public void SetCustomerId(int customerId)
        {
            _customerId = customerId;
        }

    }
}
