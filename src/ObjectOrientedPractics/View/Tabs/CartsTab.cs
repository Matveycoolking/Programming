using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Orders;
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
        private Customer _currentCustomer;

        public CartsTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обновляет данные на вкладке Carts
        /// </summary>
        public void RefreshData()
        {
            // Заново перезаполняем левый список ItemListBox товарами из Items
            UpdateItemsListBox();

            // Обновляем выпадающий список покупателей
            UpdateCustomersComboBox();

            // Сбрасываем выбранного покупателя
            CurrentCustomer = null;

            // Обновляем правый ListBox с товарами из корзины
            UpdateCartListBox();
        }

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
        /// Текущий выбранный покупатель
        /// </summary>
        private Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                UpdateCartListBox();
                UpdateTotalAmount();
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
            CustomersComboBox.Items.Add("-- Select Customer --");

            foreach (var customer in _customers)
            {
                CustomersComboBox.Items.Add(customer);
            }

            CustomersComboBox.DisplayMember = "FullName";
            CustomersComboBox.ValueMember = "Id";

            CustomersComboBox.SelectedIndex = 0;
            CurrentCustomer = null;
        }

        /// <summary>
        /// Обновляет ListBox корзины выбранного покупателя
        /// </summary>
        private void UpdateCartListBox()
        {
            CartlistBox.Items.Clear();

            if (CurrentCustomer != null && CurrentCustomer.Cart != null)
            {
                foreach (var item in CurrentCustomer.Cart.Items)
                {
                    CartlistBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }

            UpdateTotalAmount();
        }

        /// <summary>
        /// Обновляет отображение общей суммы корзины
        /// </summary>
        private void UpdateTotalAmount()
        {
            if (CurrentCustomer != null && CurrentCustomer.Cart != null)
            {
                Pricelabel.Text = CurrentCustomer.Cart.GetTotalAmount().ToString("C");
            }
            else
            {
                Pricelabel.Text = "$0.00";
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
                if (CustomersComboBox.SelectedItem is Customer customer)
                {
                    return customer;
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
            if (CustomersComboBox.SelectedIndex == 0)
            {
                CurrentCustomer = null;
            }
            else if (CustomersComboBox.SelectedItem is Customer selectedCustomer)
            {
                CurrentCustomer = selectedCustomer;
            }
            else
            {
                CurrentCustomer = null;
            }

            SelectedCustomerChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Обработчик кнопки добавления товара в корзину
        /// АГРЕГАЦИЯ 
        /// </summary>
        private void AddToCartbutton1_Click(object sender, EventArgs e)
        {
            if (SelectedItem != null && CurrentCustomer != null)
            {
                // Товар добавляется в корзину, но продолжает существовать независимо
                CurrentCustomer.Cart.Items.Add(SelectedItem);
                UpdateCartListBox();
            }
        }


        /// <summary>
        /// Обработчик кнопки удаления товара из корзины
        /// АГРЕГАЦИЯ
        /// </summary>
        private void Removebutton_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer != null && CartlistBox.SelectedIndex >= 0)
            {
                if (CartlistBox.SelectedIndex < CurrentCustomer.Cart.Items.Count)
                {
                    // Товар удаляется из корзины, но НЕ удаляется из системы
                    CurrentCustomer.Cart.Items.RemoveAt(CartlistBox.SelectedIndex);
                    UpdateCartListBox();
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки создания заказа
        /// </summary>
        private void Createbutton1_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer != null && CurrentCustomer.Cart != null && CurrentCustomer.Cart.Items.Count > 0)
            {
                Order order;

                // Проверяем, является ли покупатель приоритетным
                if (CurrentCustomer.IsPriority)
                {
                    // Создаем приоритетный заказ
                    order = new PriorityOrder(CurrentCustomer.Cart, CurrentCustomer.Address);
                }
                else
                {
                    // Создаем обычный заказ
                    order = new Order(CurrentCustomer.Cart, CurrentCustomer.Address);
                }

                // Добавляем заказ в список заказов покупателя
                CurrentCustomer.Orders.Add(order);

                // Очищаем корзину ПОСЛЕ создания заказа
                CurrentCustomer.Cart.Items.Clear();

                // Обновляем интерфейс
                UpdateCartListBox();

                string orderType = CurrentCustomer.IsPriority ? "Priority Order" : "Order";
                MessageBox.Show($"{orderType} #{order.Id} created successfully with {order.Items.Count} items!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a customer and add items to cart first!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// очищение корзины обработчик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clearbutton_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer != null && CurrentCustomer.Cart != null && CurrentCustomer.Cart.Items.Count > 0)
            {
                
                // Очищаем корзину ПОСЛЕ создания заказа
                CurrentCustomer.Cart.Items.Clear();

                // Обновляем интерфейс
                UpdateCartListBox();

                MessageBox.Show($"Order cleared successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a customer and add items to cart first!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}