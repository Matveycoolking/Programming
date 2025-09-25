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
        List<Customer> _customers = new List<Customer>();
        /// <summary>
        /// конструктор.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            UpdateListBox();

            FullNametextBoxc.Validating += FullNametextBox_Validating;
            AddresstextBoxc.Validating += AddresstextBox_Validating;
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
        /// <summary>
        /// очищает полей ввода.
        /// </summary>
        private void ClearFields()
        {
            IdtextBoxc.Text = string.Empty;
            FullNametextBoxc.Text = string.Empty;
            AddresstextBoxc.Text = string.Empty;
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
                AddresstextBoxc.Text = selectedCustomer.Address;
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
                string address = AddresstextBoxc.Text.Trim();

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
        private void AddresstextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddresstextBoxc.Text))
            {
                AddresstextBoxc.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                AddresstextBoxc.BackColor = Color.White;
            }
        }

        
    }
}
