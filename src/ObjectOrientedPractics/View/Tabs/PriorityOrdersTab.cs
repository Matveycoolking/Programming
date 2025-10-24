using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Tabs 
{
    public partial class PriorityOrdersTab : UserControl
    {
        private PriorityOrder _currentPriorityOrder;
        private AddressControl _addressControl;
        private List<Item> _availableItems;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> AvailableItems
        {
            get { return _availableItems; }
            set { _availableItems = value; }
        }

        public PriorityOrdersTab()
        {
            InitializeComponent();
            // Создаем начальный экземпляр заказа с адресом
            _currentPriorityOrder = CreateNewPriorityOrder();
            _addressControl = addressControl1; // Используем существующий контрол
            _availableItems = new List<Item>();
            InitializeComboBoxes();
            UpdateOrderInfo();

            // Подписываемся на событие изменения адреса
            _addressControl.AddressChanged += AddressControl_AddressChanged;
        }

        private void AddressControl_AddressChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder != null && _addressControl.Address != null)
            {
                _currentPriorityOrder.Address = _addressControl.Address;
            }
        }

        private PriorityOrder CreateNewPriorityOrder()
        {
            var order = new PriorityOrder();
            // Инициализируем адрес по умолчанию
            order.Address = new Address();
            order.Items = new List<Item>(); // Инициализируем коллекцию товаров
            return order;
        }

        private void InitializeComboBoxes()
        {
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            DeliveryTimeComboBox.DataSource = Enum.GetValues(typeof(DeliveryTimeRange));

            // Устанавливаем начальные значения
            if (_currentPriorityOrder != null)
            {
                StatusComboBox.SelectedItem = _currentPriorityOrder.Status;
                DeliveryTimeComboBox.SelectedItem = _currentPriorityOrder.DeliveryTimeRange;
            }
        }

        private void UpdateOrderInfo()
        {
            if (_currentPriorityOrder == null) return;

            // Обновляем основные поля заказа
            IdTextBox.Text = _currentPriorityOrder.Id.ToString();
            CreatedTextBox.Text = _currentPriorityOrder.Date.ToString("dd.MM.yyyy HH:mm");

            // Устанавливаем статус заказа
            if (StatusComboBox.Items.Contains(_currentPriorityOrder.Status))
                StatusComboBox.SelectedItem = _currentPriorityOrder.Status;

            // Обновляем адрес
            if (_currentPriorityOrder.Address != null)
            {
                _addressControl.Address = _currentPriorityOrder.Address;
            }

            // Устанавливаем время доставки
            if (DeliveryTimeComboBox.Items.Contains(_currentPriorityOrder.DeliveryTimeRange))
                DeliveryTimeComboBox.SelectedItem = _currentPriorityOrder.DeliveryTimeRange;

            // Обновляем список товаров и сумму
            UpdateItemsList();
            UpdateAmount();

            // Делаем поля Id и Created доступными только для чтения
            IdTextBox.ReadOnly = true;
            CreatedTextBox.ReadOnly = true;
        }

        private void UpdateItemsList()
        {
            ItemsListBox.Items.Clear();
            if (_currentPriorityOrder.Items != null)
            {
                foreach (var item in _currentPriorityOrder.Items)
                {
                    // Отображаем все данные товара в ListBox
                    ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C} - {item.Category} - {item.Info}");
                }
            }
        }

        private void UpdateAmount()
        {
            if (_currentPriorityOrder != null && _currentPriorityOrder.Items != null)
            {
                double totalAmount = 0;
                foreach (var item in _currentPriorityOrder.Items)
                {
                    totalAmount += item.Cost;
                }
                PriceLabel.Text = totalAmount.ToString("C");
            }
            else
            {
                PriceLabel.Text = "0";
            }
        }

        private void AddRandomItem()
        {
            try
            {
                if (_currentPriorityOrder == null) return;

                // Сохраняем текущие данные из контролов в объект
                SaveCurrentDataToOrder();

                Item randomItem;

                if (_availableItems != null && _availableItems.Count > 0)
                {
                    var random = new Random();
                    int randomIndex = random.Next(0, _availableItems.Count);
                    var originalItem = _availableItems[randomIndex];

                    randomItem = new Item(
                        name: originalItem.Name,
                        info: originalItem.Info,
                        cost: originalItem.Cost,
                        category: originalItem.Category
                    );
                }
                else
                {
                    randomItem = GenerateRandomItem();
                }

                // Добавляем товар в заказ
                _currentPriorityOrder.Items.Add(randomItem);
                UpdateItemsList();
                UpdateAmount();

                if (ItemsListBox.Items.Count > 0)
                {
                    ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveCurrentDataToOrder()
        {
            if (_currentPriorityOrder == null) return;

            try
            {
                string debugInfo = "";

                // Сохраняем статус
                if (StatusComboBox.SelectedItem != null)
                {
                    var status = (OrderStatus)StatusComboBox.SelectedItem;
                    _currentPriorityOrder.Status = status;
                    debugInfo += $"Status: {status}\n";
                }

                // Сохраняем время доставки
                if (DeliveryTimeComboBox.SelectedItem != null)
                {
                    var deliveryTime = (DeliveryTimeRange)DeliveryTimeComboBox.SelectedItem;
                    _currentPriorityOrder.DeliveryTimeRange = deliveryTime;
                    debugInfo += $"DeliveryTime: {deliveryTime}\n";
                }

                // Сохраняем адрес
                if (_addressControl.Address != null)
                {
                    _currentPriorityOrder.Address = _addressControl.Address;
                    debugInfo += $"Address set\n";
                }

                MessageBox.Show($"Saved data:\n{debugInfo}", "Debug Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Debug Error");
            }
        }

        private Item GenerateRandomItem()
        {
            var random = new Random();
            var categories = Enum.GetValues(typeof(Category));
            var category = (Category)categories.GetValue(random.Next(categories.Length));

            // Генерируем случайные данные для товара
            string[] productNames = { "Laptop", "Smartphone", "Tablet", "Headphones", "Monitor", "Keyboard", "Mouse", "Camera" };
            string[] productDescriptions = { "High quality product", "Latest model", "Premium edition", "Standard version", "Professional grade" };

            string name = $"{productNames[random.Next(productNames.Length)]} {random.Next(1000, 9999)}";
            string info = $"{productDescriptions[random.Next(productDescriptions.Length)]} with advanced features";
            double cost = Math.Round(random.NextDouble() * 1000 + 10, 2);

            return new Item(
                name: name,
                info: info,
                cost: cost,
                category: category
            );
        }

        private void RemoveSelectedItem()
        {
            if (_currentPriorityOrder == null || _currentPriorityOrder.Items == null) return;

            // Сохраняем текущие данные из контролов в объект
            SaveCurrentDataToOrder();

            if (ItemsListBox.SelectedIndex >= 0 && _currentPriorityOrder.Items.Count > 0)
            {
                int selectedIndex = ItemsListBox.SelectedIndex;
                _currentPriorityOrder.Items.RemoveAt(selectedIndex);
                UpdateItemsList();
                UpdateAmount();

                if (_currentPriorityOrder.Items.Count > 0)
                {
                    if (selectedIndex < ItemsListBox.Items.Count)
                    {
                        ItemsListBox.SelectedIndex = selectedIndex;
                    }
                    else
                    {
                        ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearOrder()
        {
            // Сохраняем текущие данные из контролов перед очисткой
            SaveCurrentDataToOrder();

            // Очищаем только товары, сохраняя остальные данные заказа
            _currentPriorityOrder.Items.Clear();
            UpdateItemsList();
            UpdateAmount();
        }

        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder != null && DeliveryTimeComboBox.SelectedItem != null)
            {
                _currentPriorityOrder.DeliveryTimeRange = (DeliveryTimeRange)DeliveryTimeComboBox.SelectedItem;
            }
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder != null && StatusComboBox.SelectedItem != null)
            {
                _currentPriorityOrder.Status = (OrderStatus)StatusComboBox.SelectedItem;
            }
        }

        

        public void SetPriorityOrder(PriorityOrder order)
        {
            _currentPriorityOrder = order ?? CreateNewPriorityOrder();
            UpdateOrderInfo();
        }

        public PriorityOrder GetPriorityOrder()
        {
            return _currentPriorityOrder;
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При выборе товара в списке можно отобразить его детали
            if (ItemsListBox.SelectedIndex >= 0 && _currentPriorityOrder.Items != null
                && ItemsListBox.SelectedIndex < _currentPriorityOrder.Items.Count)
            {
                var selectedItem = _currentPriorityOrder.Items[ItemsListBox.SelectedIndex];
                // Можно добавить отображение деталей выбранного товара если нужно
            }
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            SaveCurrentDataToOrder();
            AddRandomItem();

        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem();
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            ClearOrder();
        }
       

    }
}
