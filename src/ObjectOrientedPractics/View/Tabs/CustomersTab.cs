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
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Открытое свойство для доступа к списку покупателей вкладки
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (value != null)
                {
                    _customers.Clear();
                    _customers.AddRange(value);
                }
                else
                {
                    _customers.Clear();
                }
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

            // ✅ Визуальная подсветка ТОЛЬКО при вводе некорректных данных
            FullNametextBoxc.TextChanged += (s, e) => ValidateNameField();

            UpdateListBox();
        }

        /// <summary>
        /// Валидация поля имени - подсвечиваем только если текст не пустой и невалидный
        /// </summary>
        private void ValidateNameField()
        {
            // ✅ Пустое поле - нормальный цвет, подсвечиваем только если текст есть и он неправильный
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

            // ✅ Подсвечиваем только если поле не пустое и невалидное
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
            foreach (var customer in _customers)
            {
                CustomerslistBox.Items.Add(customer);
            }
            CustomerslistBox.DisplayMember = "FullName";
            CustomerslistBox.ValueMember = "Id";
        }

        /// <summary>
        /// очищает полей ввода.
        /// </summary>
        private void ClearFields()
        {
            IdtextBoxc.Text = string.Empty;
            FullNametextBoxc.Text = string.Empty;
            addressControl1.ClearFields();

            // ✅ При очистке сбрасываем подсветку на белый цвет
            FullNametextBoxc.BackColor = Color.White;
        }

        private void AddbuttonC_Click_1(object sender, EventArgs e)
        {
            // ✅ Используем нашу ручную проверку вместо ValidateChildren()
            if (!ValidateAllFields())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в полях! Проверьте имя и адрес.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string fullname = FullNametextBoxc.Text.Trim();
                Address address = addressControl1.Address;

                Customer newCustomer = new Customer(fullname, address);
                _customers.Add(newCustomer);

                UpdateListBox();
                ClearFields(); // ✅ После добавления очищаем поля - они станут белыми
                MessageBox.Show("Покупатель добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Removebuttonc_Click_1(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                _customers.Remove(selectedCustomer);
                UpdateListBox();
                ClearFields(); // ✅ При удалении тоже очищаем поля
                MessageBox.Show("Покупатель удалён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите покупателя для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CustomerslistBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CustomerslistBox.SelectedItem is Customer selectedCustomer)
            {
                IdtextBoxc.Text = selectedCustomer.Id.ToString();
                FullNametextBoxc.Text = selectedCustomer.FullName;
                addressControl1.Address = selectedCustomer.Address;

                // ✅ При загрузке данных поле валидно - белый фон
                FullNametextBoxc.BackColor = Color.White;
            }
            else
            {
                ClearFields();
            }
        }

        /// <summary>
        /// Кнопка очистки полей
        /// </summary>
       
    }
}