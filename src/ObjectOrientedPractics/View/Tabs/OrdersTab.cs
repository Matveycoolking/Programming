using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
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
    public partial class OrdersTab : UserControl
    {
        private List<Customer> _customers;
        private Order _selectedOrder;
        private PriorityOrder _selectedPriorityOrder;

        public OrdersTab()
        {
            InitializeComponent();
            ConfigureDataGridView();
            InitializeStatusComboBox();
            InitializePriorityOrderPanel();

        }

        /// <summary>
        /// Инициализация панели для приоритетных заказов
        /// </summary>
        private void InitializePriorityOrderPanel()
        {
            

            // Настройка ComboBox для времени доставки
            DeliveryTimeComboBox.DataSource = Enum.GetValues(typeof(DeliveryTimeRange));
            DeliveryTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;

            // Изначально скрываем панель
            PriorityOrderPanel1.Visible = false;
            PriorityOrderPanel2.Visible = false;
        }
        /// <summary>
        /// Обновление информации.
        /// </summary>
        public void RefreshData()
        {
            UpdateDataGridView();
            _selectedOrder = null;
            _selectedPriorityOrder = null;
            ClearSelectedOrderPanel();
        }
        /// <summary>
        /// Свойства выбранного заказа.
        /// </summary>
        private Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;

                // ОБНОВЛЕНО: Сохраняем заказ также в _selectedPriorityOrder если это PriorityOrder
                if (_selectedOrder is PriorityOrder priorityOrder)
                {
                    _selectedPriorityOrder = priorityOrder;
                }
                else
                {
                    _selectedPriorityOrder = null;
                }

                UpdateSelectedOrderPanel();
            }
        }
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран приоритетный заказ и выбран валидный элемент
            if (_selectedPriorityOrder != null && DeliveryTimeComboBox.SelectedItem is DeliveryTimeRange timeRange)
            {
                // Сохраняем новое время доставки в приоритетный заказ
                _selectedPriorityOrder.DeliveryTimeRange = timeRange;

                // Для отладки можно добавить вывод в консоль
                Console.WriteLine($"Delivery time changed to: {timeRange}");
            }
        }
        /// <summary>
        /// Инициализация комбобокса.
        /// </summary>
        private void InitializeStatusComboBox()
        {
            comboBox1.DataSource = Enum.GetValues(typeof(OrderStatus));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Настройка интерфейса.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }
        /// <summary>
        /// Управление таблицей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedOrderId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                var order = FindOrderById(selectedOrderId);

                // ОБНОВЛЕНО: Сохраняем заказ в оба поля
                _selectedOrder = order;

                if (order is PriorityOrder priorityOrder)
                {
                    _selectedPriorityOrder = priorityOrder;
                }
                else
                {
                    _selectedPriorityOrder = null;
                }

                UpdateSelectedOrderPanel();
            }
            else
            {
                _selectedOrder = null;
                _selectedPriorityOrder = null;
                UpdateSelectedOrderPanel();
            }
        }
        /// <summary>
        /// нахождение заказа по айди
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private Order FindOrderById(int orderId)
        {
            if (_customers != null)
            {
                foreach (var customer in _customers)
                {
                    if (customer.Orders != null)
                    {
                        // АГРЕГАЦИЯ: работаем с заказами через ссылки
                        var order = customer.Orders.FirstOrDefault(o => o.Id == orderId);
                        if (order != null)
                            // Возвращаем ссылку на существующий заказ
                            return order;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Обновление панели заказа.
        /// </summary>
        private void UpdateSelectedOrderPanel()
        {
            if (SelectedOrder != null)
            {
                textBox1.Text = SelectedOrder.Id.ToString();
                textBox2.Text = SelectedOrder.Date.ToString("dd.MM.yyyy HH:mm");
                comboBox1.SelectedItem = SelectedOrder.Status;

                if (SelectedOrder.Address != null)
                {
                    addressControl1.Address = SelectedOrder.Address;
                }

                UpdateOrderItemsListBox();

                Pricelabel8.Text = SelectedOrder.Total.ToString("C");

                SetPanelEnabled(true);
                UpdatePriorityOrderControls();


            }
            else
            {
                ClearSelectedOrderPanel();
                SetPanelEnabled(false);
            }
        }
        /// <summary>
        /// Обновление контролов для приоритетных заказов
        /// </summary>
        private void UpdatePriorityOrderControls()
        {
            if (_selectedPriorityOrder != null)
            {
                // Показываем панель для приоритетных заказов
                PriorityOrderPanel1.Visible = true;
                PriorityOrderPanel2.Visible = true;

                // Устанавливаем значения
                DeliveryTimeComboBox.SelectedItem = _selectedPriorityOrder.DeliveryTimeRange;

                
                DeliveryTimeComboBox.Enabled = true;
            }
            else
            {
                // Скрываем панель для обычных заказов
                PriorityOrderPanel1.Visible = false;
                PriorityOrderPanel2.Visible = false;
            }
        }

        /// <summary>
        /// Обновление предметов в листбоксе.
        /// </summary>
        private void UpdateOrderItemsListBox()
        {
            OrderItemsListBox.Items.Clear();

            if (SelectedOrder != null && SelectedOrder.Items != null)
            {
                // АГРЕГАЦИЯ: отображаем товары, которые существуют независимо от заказа
                foreach (var item in SelectedOrder.Items)
                {
                    OrderItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }
        }
        /// <summary>
        /// Очищение панели заказов.
        /// </summary>
        private void ClearSelectedOrderPanel()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            addressControl1.ClearFields();
            OrderItemsListBox.Items.Clear();
            Pricelabel8.Text = "$0.00";
            PriorityOrderPanel1.Visible = false;
            PriorityOrderPanel2.Visible = false;
        }
        /// <summary>
        /// Установление панели состояния.
        /// </summary>
        /// <param name="enabled"></param>
        private void SetPanelEnabled(bool enabled)
        {
            textBox1.Enabled = enabled;
            textBox2.Enabled = enabled;
            addressControl1.Enabled = enabled;
            OrderItemsListBox.Enabled = enabled;
            comboBox1.Enabled = false;
            if (enabled)
            {
                addressControl1.SetReadOnly(true);
            }
        }
        /// <summary>
        /// Свойства списка покупателей.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value ?? new List<Customer>();
                UpdateDataGridView();
            }
        }
        /// <summary>
        /// обновление показа таблицы.
        /// </summary>
        private void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();

            if (_customers != null)
            {
                foreach (var customer in _customers)
                {
                    if (customer.Orders != null && customer.Orders.Count > 0)
                    {
                        foreach (var order in customer.Orders)
                        {
                            string priorityIndicator = order.IsPriority ? "★ " : "";
                            dataGridView1.Rows.Add(
                                order.Id,
                                order.Date.ToString("dd.MM.yyyy HH:mm"),
                                priorityIndicator + order.Status.ToString(),
                                customer.FullName,
                                GetAddressString(order.Address),
                                order.Total.ToString("C")
                            );
                        }
                    }
                }
            }

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }
        /// <summary>
        /// Вывод адресса.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private string GetAddressString(Address address)
        {
            if (address == null) return "No address";
            return $"{address.Index}, {address.Country}, {address.City}, {address.Street}, {address.Building}, {address.Apartment}";
        }
        /// <summary>
        /// Настройка выбора предметов поведения комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedOrder != null && comboBox1.SelectedItem is OrderStatus newStatus)
            {
                SelectedOrder.Status = newStatus;
                UpdateStatusInDataGridView(SelectedOrder.Id, newStatus);
            }
        }
        /// <summary>
        /// обновление статуса.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        private void UpdateStatusInDataGridView(int orderId, OrderStatus status)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((int)row.Cells["Id"].Value == orderId)
                {
                    row.Cells["OrderStatus"].Value = status.ToString();
                    break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}