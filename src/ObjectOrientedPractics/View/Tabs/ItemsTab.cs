using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        private List<Item> _items = new List<Item>();
        public event EventHandler ItemsChanged;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value ?? new List<Item>();
                UpdateListBox();
            }
        }

        public ItemsTab()
        {
            InitializeComponent();
            InitializeCategoryComboBox();

            this.AutoValidate = AutoValidate.Disable;


            NametextBox.TextChanged += (s, e) => ValidateNameField();
            DescriptiontextBox.TextChanged += (s, e) => ValidateDescriptionField();
            CosttextBox.TextChanged += (s, e) => ValidateCostField();

          
        }

        /// <summary>
        /// Валидация поля названия - подсвечиваем только если текст не пустой и невалидный
        /// </summary>
        private void ValidateNameField()
        {

            if (string.IsNullOrWhiteSpace(NametextBox.Text))
            {
                NametextBox.BackColor = Color.White; // Пустое поле - белый фон
            }
            else
            {
                bool isValid = NametextBox.Text.Length <= 200;
                NametextBox.BackColor = isValid ? Color.White : Color.LightPink;
            }
        }

        /// <summary>
        /// Валидация поля описания
        /// </summary>
        private void ValidateDescriptionField()
        {

            if (string.IsNullOrWhiteSpace(DescriptiontextBox.Text))
            {
                DescriptiontextBox.BackColor = Color.White;
            }
            else
            {
                bool isValid = DescriptiontextBox.Text.Length <= 1000;
                DescriptiontextBox.BackColor = isValid ? Color.White : Color.LightPink;
            }
        }

        /// <summary>
        /// Валидация поля цены
        /// </summary>
        private void ValidateCostField()
        {

            if (string.IsNullOrWhiteSpace(CosttextBox.Text))
            {
                CosttextBox.BackColor = Color.White;
            }
            else
            {
                bool isValid = double.TryParse(CosttextBox.Text, out double cost) && cost >= 0;
                CosttextBox.BackColor = isValid ? Color.White : Color.LightPink;
            }
        }

        /// <summary>
        /// Проверка всех полей перед добавлением
        /// </summary>
        private bool ValidateAllFields()
        {
            bool nameValid = !string.IsNullOrWhiteSpace(NametextBox.Text) && NametextBox.Text.Length <= 200;
            bool descriptionValid = string.IsNullOrWhiteSpace(DescriptiontextBox.Text) || DescriptiontextBox.Text.Length <= 1000;
            bool costValid = !string.IsNullOrWhiteSpace(CosttextBox.Text) &&
                           double.TryParse(CosttextBox.Text, out double cost) && cost >= 0;


            NametextBox.BackColor = string.IsNullOrWhiteSpace(NametextBox.Text) ? Color.White :
                                  (nameValid ? Color.White : Color.LightPink);

            DescriptiontextBox.BackColor = string.IsNullOrWhiteSpace(DescriptiontextBox.Text) ? Color.White :
                                        (descriptionValid ? Color.White : Color.LightPink);

            CosttextBox.BackColor = string.IsNullOrWhiteSpace(CosttextBox.Text) ? Color.White :
                                  (costValid ? Color.White : Color.LightPink);

            return nameValid && descriptionValid && costValid;
        }

        /// <summary>
        /// Инициализация ComboBox категорий товаров
        /// </summary>
        private void InitializeCategoryComboBox()
        {
            CategorycomboBox1.DataSource = Enum.GetValues(typeof(Category));
            CategorycomboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Очищает поля ввода.
        /// </summary>
        private void ClearFields()
        {
            IdtextBox.Text = string.Empty;
            NametextBox.Text = string.Empty;
            DescriptiontextBox.Text = string.Empty;
            CosttextBox.Text = string.Empty;
            CategorycomboBox1.SelectedIndex = 0;


            NametextBox.BackColor = Color.White;
            DescriptiontextBox.BackColor = Color.White;
            CosttextBox.BackColor = Color.White;
        }

        /// <summary>
        /// Обновляет листбокс.
        /// </summary>
        private void UpdateListBox()
        {
            ItemsListBox.Items.Clear();
            if (_items != null)
            {


                foreach (var item in _items)
                {
                    ItemsListBox.Items.Add(item);
                }
                ItemsListBox.DisplayMember = "Name";
                ItemsListBox.ValueMember = "Id";
            }
        }
        /// <summary>
        /// Редактор изменений в листбоксе предметов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item selectedItem)
            {
                IdtextBox.Text = selectedItem.Id.ToString();
                NametextBox.Text = selectedItem.Name;
                DescriptiontextBox.Text = selectedItem.Info;
                CosttextBox.Text = selectedItem.Cost.ToString("F2");
                CategorycomboBox1.SelectedItem = selectedItem.Category;


                NametextBox.BackColor = Color.White;
                DescriptiontextBox.BackColor = Color.White;
                CosttextBox.BackColor = Color.White;
            }
            else
            {
                ClearFields();
            }
        }
        /// <summary>
        /// кнопка по добавлению элементов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в полях перед добавлением!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string name = NametextBox.Text.Trim();
                string info = DescriptiontextBox.Text.Trim();
                double cost = double.Parse(CosttextBox.Text);
                Category category = (Category)CategorycomboBox1.SelectedItem;

                Item newItem = new Item(name, info, cost, category);
                _items.Add(newItem);

                UpdateListBox();
                ClearFields();
                ItemsChanged?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Товар добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// кнопка по удалению элементов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item selectedItem)
            {
                _items.Remove(selectedItem);
                UpdateListBox();
                ClearFields();
                ItemsChanged?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Товар удален!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}