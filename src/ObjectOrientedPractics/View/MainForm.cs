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
            // Создаем вкладку товаров и передаем список из Store
            var itemsTab = new ItemsTab();
            itemsTab.Items = _store.Items; // Присваиваем список товаров из Store
            itemsTab.Dock = DockStyle.Fill;
            itemsTab1.Controls.Add(itemsTab);

            // Создаем вкладку покупателей и передаем список из Store
            var customersTab = new CustomersTab();
            customersTab.Customers = _store.Customers; // Присваиваем список покупателей из Store
            customersTab.Dock = DockStyle.Fill;
            customersTab1.Controls.Add(customersTab);

            //Создаем вкладку корзин
           var cartsTab = new CartsTab();
            cartsTab.Dock = DockStyle.Fill;
            CartsTab.Controls.Add(cartsTab); // Добавляем на вкладку cartsTab1

            // Передаем данные в cartsTab
            cartsTab.Items = _store.Items;
            cartsTab.Customers = _store.Customers;

            // Подписываемся на события
            cartsTab.SelectedItemChanged += (s, e) =>
            {
                var selectedItem = cartsTab.SelectedItem;
                if (selectedItem != null)
                {
                    MessageBox.Show($"Выбран товар: {selectedItem.Name}\nЦена: {selectedItem.Cost:C2}\nКатегория: {selectedItem.Category}",
                        "Информация о товаре");
                }
            };

            cartsTab.SelectedCustomerChanged += (s, e) =>
            {
                var selectedCustomer = cartsTab.SelectedCustomer;
                if (selectedCustomer != null)
                {
                    string cartInfo = $"Товаров в корзине: {selectedCustomer.Cart.Items.Count}\n" +
                                    $"Общая стоимость: {selectedCustomer.Cart.Amount:C2}";
                    MessageBox.Show($"Выбран покупатель: {selectedCustomer.FullName}\n{cartInfo}",
                        "Информация о покупателе");
                }
            };

            
        }       

        private void itemsTab1_Load(object sender, EventArgs e)
        {

        }
    }
}
