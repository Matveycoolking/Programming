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
        /// Обновляет данные в ListBox товаров.
        /// </summary>
        private void UpdateItemsListBox()
        {
            ItemslistBox1.Items.Clear();
            foreach (var item in _items)
            {
                ItemslistBox1.Items.Add($"{item.Name} - {item.Cost:C}");
            }
        }

        /// <summary>
        /// Обновляет данные в ComboBox покупателей.
        /// </summary>
        private void UpdateCustomersComboBox()
        {
            CustomercomboBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomercomboBox.Items.Add($"{customer.FullName} (ID: {customer.Id})");
            }

            if (CustomercomboBox.Items.Count > 0)
            {
                CustomercomboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Возвращает выбранный товар в ListBox.
        /// </summary>
        public Item SelectedItem
        {
            get
            {
                if (ItemslistBox1.SelectedIndex >= 0 && ItemslistBox1.SelectedIndex < _items.Count)
                {
                    return _items[ItemslistBox1.SelectedIndex];
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
                if (CustomercomboBox.SelectedIndex >= 0 && CustomercomboBox.SelectedIndex < _customers.Count)
                {
                    return _customers[CustomercomboBox.SelectedIndex];
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

