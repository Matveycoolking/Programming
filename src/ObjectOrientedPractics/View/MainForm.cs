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

                // Подписываемся на событие изменения товаров
                itemsTab1.ItemsChanged += (s, e) =>
                {
                    // При изменении товаров автоматически обновляем Store.Items
                    // так как это один и тот же список
                };

                // Обработчик переключения вкладок
                tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации вкладок: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) // Вкладка Carts
            {
                cartsTab1.RefreshData();
            }
        }

        private void itemsTab1_Load(object sender, EventArgs e)
        {
        }
    }
}