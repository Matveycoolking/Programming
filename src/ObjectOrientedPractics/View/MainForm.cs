using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View.Tabs;

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
            // —оздаем вкладку товаров и передаем список из Store
            var itemsTab = new ItemsTab();
            itemsTab.Items = _store.Items; // ѕрисваиваем список товаров из Store

            itemsTab.Dock = DockStyle.Fill;
            itemsTab1.Controls.Add(itemsTab);

            // —оздаем вкладку покупателей и передаем список из Store
            var customersTab = new CustomersTab();
            customersTab.Customers = _store.Customers; // ѕрисваиваем список покупателей из Store

            customersTab.Dock = DockStyle.Fill;
            customersTab1.Controls.Add(customersTab);
        }


        private void itemsTab1_Load(object sender, EventArgs e)
        {

        }
    }
}
