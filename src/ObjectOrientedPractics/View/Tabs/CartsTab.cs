using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CartsTab : UserControl
    {
        private List<Item> _items;
        private List<Customer> _customers;

        public CartsTab()
        {
            InitializeComponent();
            _items = new List<Item>();
            _customers = new List<Customer>();
            //CreateSampleData();
        }
        /// <summary>
        /// Метод для создания демонстрационных данных.
        /// </summary>
        //public void CreateSampleData()
        //{
        //    // Создаем демонстрационные товары
        //    _items = new List<Item>
        //    {
        //        new Item("iPhone 15 Pro", "Флагманский смартфон Apple", 999.90, Category.Electronics),
        //        new Item("MacBook Air M2", "Ноутбук Apple с чипом M2", 1299.99, Category.Electronics),
        //        new Item("Джинсы Levi's", "Классические джинсы 501", 89.99, Category.Clothing),
        //        new Item("Научная фантастика", "Сборник лучших НФ рассказов", 24.50, Category.Books),
        //        new Item("Кофеварка", "Автоматическая кофеварка Delonghi", 199.99, Category.Home),
        //        new Item("Беспроводные наушники", "Sony WH-1000XM4", 349.99, Category.Electronics),
        //        new Item("Футболка хлопковая", "Белая футболка 100% хлопок", 19.99, Category.Clothing),
        //        new Item("Программирование на C#", "Учебник по C# для начинающих", 45.00, Category.Books)
        //    };

        //    // Создаем демонстрационных покупателей
        //    _customers = new List<Customer>
        //    {
        //        new Customer("Иван Иванов", 123456, "Россия", "Москва", "Ленина", "10", "25"),
        //        new Customer("Петр Петров", 654321, "Россия", "Санкт-Петербург", "Невский", "15", "8"),
        //        new Customer("Мария Сидорова", 111222, "Россия", "Казань", "Баумана", "22", "13"),
        //        new Customer("Анна Козлова", 333444, "Россия", "Екатеринбург", "Мира", "5", "41"),
        //        new Customer("Сергей Смирнов", 555666, "Россия", "Новосибирск", "Красный", "18", "7")
        //    };

        //    // Добавляем товары в корзины некоторых покупателей для демонстрации
        //    _customers[0].Cart.Items.Add(_items[0]); // iPhone в корзине Ивана
        //    _customers[0].Cart.Items.Add(_items[2]); // Джинсы в корзине Ивана

        //    _customers[1].Cart.Items.Add(_items[1]); // MacBook в корзине Петра
        //    _customers[1].Cart.Items.Add(_items[4]); // Кофеварка в корзине Петра
        //    _customers[1].Cart.Items.Add(_items[6]); // Футболка в корзине Петра

        //    _customers[2].Cart.Items.Add(_items[3]); // Книга в корзине Марии
        //    _customers[2].Cart.Items.Add(_items[7]); // Учебник в корзине Марии

        //    // Обновляем интерфейс
        //    UpdateItemsListBox();
        //    UpdateCustomersComboBox();
        //}


        /// <summary>
        /// Список товаров (привязан к ListBox).
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value ?? new List<Item>();
                UpdateItemsListBox();
            }
        }
        

        /// <summary>
        /// Список покупателей (привязан к ComboBox).
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value ?? new List<Customer>();
                UpdateCustomersComboBox();
            }
        }
        

        /// <summary>
        /// Обновляет данные в ListBox товаров.
        /// </summary>
        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in _items)
            {
                ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
            }
        }

        /// <summary>
        /// Обновляет данные в ComboBox покупателей.
        /// </summary>
        private void UpdateCustomersComboBox()
        {
            CustomersComboBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomersComboBox.Items.Add($"{customer.FullName} (ID: {customer.Id})");
            }

            if (CustomersComboBox.Items.Count > 0)
            {
                CustomersComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Возвращает выбранный товар в ListBox.
        /// </summary>
        public Item SelectedItem
        {
            get
            {
                if (ItemsListBox.SelectedIndex >= 0 && ItemsListBox.SelectedIndex < _items.Count)
                {
                    return _items[ItemsListBox.SelectedIndex];
                }
                return null;
            }
        }

        /// <summary>
        /// Возвращает выбранного покупателя в ComboBox.
        /// </summary>
        public Customer SelectedCustomer
        {
            get
            {
                if (CustomersComboBox.SelectedIndex >= 0 && CustomersComboBox.SelectedIndex < _customers.Count)
                {
                    return _customers[CustomersComboBox.SelectedIndex];
                }
                return null;
            }
        }

        // События для уведомления об изменениях выбора
        public event EventHandler SelectedItemChanged;
        public event EventHandler SelectedCustomerChanged;


        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemChanged?.Invoke(this, e);
        }

        private void CustomersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCustomerChanged?.Invoke(this, e);
        }
    }
}

