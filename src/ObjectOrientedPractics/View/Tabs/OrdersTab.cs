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
    public partial class OrdersTab : UserControl
    {
        private List<Customer> _customers;
        private Order _selectedOrder;

        public OrdersTab()
        {
            InitializeComponent();
            ConfigureDataGridView();
            InitializeStatusComboBox();
            

        }
        
        public void RefreshData()
        {
            UpdateDataGridView();
            SelectedOrder = null;
            ClearSelectedOrderPanel();
        }

        private Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                UpdateSelectedOrderPanel();
            }
        }

        private void InitializeStatusComboBox()
        {
            comboBox1.DataSource = Enum.GetValues(typeof(OrderStatus));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedOrderId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                SelectedOrder = FindOrderById(selectedOrderId);
            }
            else
            {
                SelectedOrder = null;
            }
        }

        private Order FindOrderById(int orderId)
        {
            if (_customers != null)
            {
                foreach (var customer in _customers)
                {
                    if (customer.Orders != null)
                    {
                        var order = customer.Orders.FirstOrDefault(o => o.Id == orderId);
                        if (order != null)
                            return order;
                    }
                }
            }
            return null;
        }

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

                Pricelabel8.Text = SelectedOrder.Amount.ToString("C");

                SetPanelEnabled(true);

                
            }
            else
            {
                ClearSelectedOrderPanel();
                SetPanelEnabled(false);
            }
        }

        private void UpdateOrderItemsListBox()
        {
            OrderItemsListBox.Items.Clear();

            if (SelectedOrder != null && SelectedOrder.Items != null)
            {
                foreach (var item in SelectedOrder.Items)
                {
                    OrderItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }
        }

        private void ClearSelectedOrderPanel()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            addressControl1.ClearFields();
            OrderItemsListBox.Items.Clear();
            Pricelabel8.Text = "$0.00";
        }

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
                            dataGridView1.Rows.Add(
                                order.Id,
                                order.Date.ToString("dd.MM.yyyy HH:mm"),
                                order.Status.ToString(),
                                customer.FullName,
                                GetAddressString(order.Address),
                                order.Amount.ToString("C")
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

        private string GetAddressString(Address address)
        {
            if (address == null) return "No address";
            return $"{address.Index}, {address.Country}, {address.City}, {address.Street}, {address.Building}, {address.Apartment}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedOrder != null && comboBox1.SelectedItem is OrderStatus newStatus)
            {
                SelectedOrder.Status = newStatus;
                UpdateStatusInDataGridView(SelectedOrder.Id, newStatus);
            }
        }

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
    }
}