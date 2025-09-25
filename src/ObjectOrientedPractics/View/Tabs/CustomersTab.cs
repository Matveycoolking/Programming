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
    public partial class CustomersTab : UserControl
    {
        List<Customer> _customers = new List<Customer>();
        private AddressControl _addressControl = new AddressControl();
        /// <summary>
        /// конструктор.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            InitializeAddressControl();

            UpdateListBox();

            FullNametextBoxc.Validating += FullNametextBox_Validating;
            
        }
        /// <summary>
        /// метод для обновления листбокса
        /// </summary>
        private void UpdateListBox()
        {
            CustomerslistBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomerslistBox.Items.Add(customer);
            }
            CustomerslistBox.DisplayMember = "FullName";// что выводит в листбоксе
            CustomerslistBox.ValueMember = "Id";//как хранит
        }

        private void InitializeAddressControl()
        {
            _addressControl.Location = new Point(10, 100); // Настройте позицию
            _addressControl.Size = new Size(400, 150); // Настройте размер
            this.Controls.Add(_addressControl);
        }

        /// <summary>
        /// очищает полей ввода.
        /// </summary>
        private void ClearFields()
        {
            IdtextBoxc.Text = string.Empty;
            FullNametextBoxc.Text = string.Empty;
            _addressControl.Address = new Address();
        }

        /// <summary>
        /// логика по листбоксу и выбору элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                IdtextBoxc.Text = selectedCustomer.Id.ToString();
                FullNametextBoxc.Text = selectedCustomer.FullName;
                _addressControl.Address = selectedCustomer.Address;
            }
            else
            {
                ClearFields();
            }
        }
        /// <summary>
        /// кнопка по добавлению покупателей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddbuttonC_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Исправьте ошибки в полях!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string fullname = FullNametextBoxc.Text.Trim();
                Address address = _addressControl.Address;

                Customer newCustomer = new Customer(fullname, address);
                _customers.Add(newCustomer);

                UpdateListBox();
                ClearFields();
                MessageBox.Show("Покупатель добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// кнопка по удалению покупателей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Removebuttonc_Click(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                _customers.Remove(selectedCustomer);
                UpdateListBox();
                ClearFields();
                MessageBox.Show("Покупатель удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите покупателя для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Валидация и смена цвета для имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullNametextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNametextBoxc.Text))
            {
                FullNametextBoxc.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                FullNametextBoxc.BackColor = Color.White;
            }
        }
        /// <summary>
        /// валидация и смена цвета для адреса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        
    }
}
