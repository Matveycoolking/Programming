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
        List<Item> _items = new List<Item>();
        /// <summary>
        /// Конструктор по инициализации
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();

            InitializeCategoryComboBox();
            UpdateListBox();

            NametextBox.Validating += NametextBox_Validating;
            DescriptiontextBox.Validating += DescriptiontextBox_Validating;
            CosttextBox.Validating += CosttextBox_Validating;
        }
        /// <summary>
        /// Инициализация ComboBox категорий товаров
        /// </summary>
        private void InitializeCategoryComboBox()
        {
            // Заполняем ComboBox значениями из перечисления Category
            CategorycomboBox1.DataSource = Enum.GetValues(typeof(Category));
            CategorycomboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Валидация и смена цвета у имени.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NametextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NametextBox.Text))
            {
                NametextBox.BackColor = Color.LightCoral; // Красный фон
                e.Cancel = true; // Остановить переход с поля
            }
            else
            {
                NametextBox.BackColor = Color.White; // Нормальный фон
            }
        }
        /// <summary>
        /// Валидация и смена цвета у описания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptiontextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptiontextBox.Text))
            {
                DescriptiontextBox.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                DescriptiontextBox.BackColor = Color.White;
            }
        }
        /// <summary>
        /// Валидация и смена цвета у цены.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CosttextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(CosttextBox.Text, out double cost) || cost < 0)
            {
                CosttextBox.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                CosttextBox.BackColor = Color.White;
            }
        }
        /// <summary>
        /// метод запускающий валидацию для всех объектов выше.
        /// </summary>
        /// <returns></returns>
        private bool ValidateChildrenFields()
        {
            return this.ValidateChildren(); // Запускает Validating для всех контролов
        }

        /// <summary>
        /// Очищает поля.
        /// </summary>
        private void ClearFields()
        {
            IdtextBox.Text = string.Empty;
            NametextBox.Text = string.Empty;
            DescriptiontextBox.Text = string.Empty;
            CosttextBox.Text = string.Empty;
            CategorycomboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновляет листбокс.
        /// </summary>
        private void UpdateListBox()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
            ItemsListBox.DisplayMember = "Name";
            ItemsListBox.ValueMember = "Id";
        }
        /// <summary>
        /// Логика для Листобокса
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
            }
            else
            {
                ClearFields();
            }
        }
        /// <summary>
        /// Логика для кнопки добавления элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildrenFields())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в полях!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string name = NametextBox.Text.Trim();
                string info = DescriptiontextBox.Text.Trim();
                double cost = double.Parse(CosttextBox.Text);
                Category category = (Category)CategorycomboBox1.SelectedItem;

                // Создаем новый товар (валидация внутри конструктора)
                Item newItem = new Item(name, info, cost, category);
                _items.Add(newItem);

                UpdateListBox(); // Обновляем список
                ClearFields();   // Очищаем поля
                MessageBox.Show("Товар добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: стоимость должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UpdateListBox(); // Обновляем список
                ClearFields();   // Очищаем поля
                MessageBox.Show("Товар удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        

        

        
    }
}
