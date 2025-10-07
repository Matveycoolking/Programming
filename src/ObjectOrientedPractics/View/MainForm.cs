using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View.Tabs;

namespace ObjectOrientedPractics
{
    public partial class MainForm : Form
    {
        private CartsTab itemsCustomersControl;
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
                // Сначала создаем все вкладки
                var itemsTab = new ItemsTab();
                var customersTab = new CustomersTab();
                var cartsTab = new CartsTab();

                // ПОТОМ устанавливаем данные
                itemsTab.Items = _store.Items;
                customersTab.Customers = _store.Customers;
                cartsTab.Items = _store.Items;
                cartsTab.Customers = _store.Customers;

                // ПОТОМ добавляем на форму
                itemsTab.Dock = DockStyle.Fill;
                itemsTab1.Controls.Add(itemsTab);

                customersTab.Dock = DockStyle.Fill;
                customersTab1.Controls.Add(customersTab);

                cartsTab.Dock = DockStyle.Fill;
                cartsTab1.Controls.Add(cartsTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации вкладок: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void itemsTab1_Load(object sender, EventArgs e)
        {

        }
    }
}