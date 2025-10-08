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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CustomersTab : UserControl
    {
        private List<Customer> _customers;

        /// <summary>
        /// Открытое свойство для доступа к списку покупателей вкладки
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value ?? new List<Customer>();
                UpdateListBox();
            }
        }

        /// <summary>
        /// конструктор.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;


            FullNametextBoxc.TextChanged += (s, e) => ValidateNameField();

            
        }

        /// <summary>
        /// Валидация поля имени - подсвечиваем только если текст не пустой и невалидный
        /// </summary>
        private void ValidateNameField()
        {

            if (string.IsNullOrWhiteSpace(FullNametextBoxc.Text))
            {
                FullNametextBoxc.BackColor = Color.White; // Пустое поле - белый фон
            }
            else
            {
                bool isValid = FullNametextBoxc.Text.Length <= 200;
                FullNametextBoxc.BackColor = isValid ? Color.White : Color.LightPink;
            }
        }

        /// <summary>
        /// Проверка всех полей перед добавлением
        /// </summary>
        private bool ValidateAllFields()
        {
            bool nameValid = !string.IsNullOrWhiteSpace(FullNametextBoxc.Text) && FullNametextBoxc.Text.Length <= 200;
            bool addressValid = addressControl1.ValidateAddress();


            FullNametextBoxc.BackColor = string.IsNullOrWhiteSpace(FullNametextBoxc.Text) ? Color.White :
                                       (nameValid ? Color.White : Color.LightPink);

            return nameValid && addressValid;
        }

        /// <summary>
        /// метод для обновления листбокса
        /// </summary>
        private void UpdateListBox()
        {
            CustomerslistBox.Items.Clear();
            if (_customers != null)
            {               
                foreach (var customer in _customers)
                {
                    CustomerslistBox.Items.Add(customer);
                }
                CustomerslistBox.DisplayMember = "FullName";
                CustomerslistBox.ValueMember = "Id";
            }
        }

        /// <summary>
        /// очищает полей ввода.
        /// </summary>
        private void ClearFields()
        {
            IdtextBoxc.Text = string.Empty;
            FullNametextBoxc.Text = string.Empty;
            addressControl1.ClearFields();


            FullNametextBoxc.BackColor = Color.White;
        }
        /// <summary>
        /// кнопка по добавлению элементов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddbuttonC_Click_1(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в полях! Проверьте имя и адрес.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string fullname = FullNametextBoxc.Text.Trim();

                // Получаем адрес из контрола
                Address address = addressControl1.Address;

                // СОЗДАЕМ Customer с параметрами адреса - композиция!
                Customer newCustomer = new Customer(
                    fullname,
                    address.Index,
                    address.Country,
                    address.City,
                    address.Street,
                    address.Building,
                    address.Apartment
                );

                _customers.Add(newCustomer);

                UpdateListBox();
                ClearFields();
                MessageBox.Show("Покупатель добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// кнопка удаления элементов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Removebuttonc_Click_1(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                _customers.Remove(selectedCustomer);
                UpdateListBox();
                ClearFields();
                MessageBox.Show("Покупатель удалён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите покупателя для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Редактор изменений в листбоксе покупателей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerslistBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                IdtextBoxc.Text = selectedCustomer.Id.ToString();
                FullNametextBoxc.Text = selectedCustomer.FullName;

                // Заполняем контрол адреса данными из выбранного клиента через свойство Address
                addressControl1.Address = selectedCustomer.Address;

                FullNametextBoxc.BackColor = Color.White;
            }
            else
            {
                ClearFields();
            }
        }



    }
}