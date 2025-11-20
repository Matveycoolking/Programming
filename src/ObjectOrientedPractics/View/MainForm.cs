using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View.Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics
{
    public partial class MainForm : Form
    {
        private Store _store;

        public MainForm()
        {
            InitializeComponent();
            _store = new Store();
            InitializeTabs();
        }

        private void InitializeTabs()
        {
            try
            {
                // Инициализируем списки в Store
                _store.Items = _store.Items ?? new List<Item>();
                _store.Customers = _store.Customers ?? new List<Customer>();

                // Используем уже созданные в дизайнере контролы и передаем им данные
                itemsTab1.Items = _store.Items;
                customersTab1.Customers = _store.Customers;
                cartsTab1.Items = _store.Items;
                cartsTab1.Customers = _store.Customers;
                ordersTab1.Customers = _store.Customers;

                // Подписываемся на событие изменения товаров
                itemsTab1.ItemsChanged += ItemsTab1_ItemsChanged;
                // Обработчик переключения вкладок
                tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации вкладок: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события изменения товаров
        /// </summary>
        private void ItemsTab1_ItemsChanged(object sender, EventArgs e)
        {
            // При изменении товаров обновляем все вкладки, которые зависят от списка товаров
            cartsTab1.RefreshData();
            ordersTab1.RefreshData();

            // Если есть другие вкладки, зависящие от товаров, добавляем их здесь
            // priorityOrdersTab.RefreshData();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) // Вкладка Carts
            {
                cartsTab1.RefreshData();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                ordersTab1.RefreshData();
            }
            
        }

        private void itemsTab1_Load(object sender, EventArgs e)
        {
        }
    }
}