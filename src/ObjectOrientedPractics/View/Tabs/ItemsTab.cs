using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        private List<Item> _items = new List<Item>();
        private Item _currentItem;
        public event EventHandler ItemsChanged;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value ?? new List<Item>();
                ApplySearchAndSort();
            }
        }

        public ItemsTab()
        {
            InitializeComponent();
            InitializeCategoryComboBox();
            InitializeOrderComboBox();

            this.AutoValidate = AutoValidate.Disable;

            // Подписываемся на события изменения текста для автоматического сохранения
            NametextBox.TextChanged += NameTextBox_TextChanged;
            DescriptiontextBox.TextChanged += DescriptionTextBox_TextChanged;
            CosttextBox.TextChanged += CostTextBox_TextChanged;
            CategorycomboBox1.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;

            // Подписываемся на события потери фокуса для гарантированного сохранения
            NametextBox.Leave += TextBox_Leave;
            DescriptiontextBox.Leave += TextBox_Leave;
            CosttextBox.Leave += TextBox_Leave;

            FindTextBox.TextChanged += FindTextBox_TextChanged;
            OrderComboBox.SelectedIndexChanged += OrderComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Автоматическое сохранение при изменении названия
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && !string.IsNullOrEmpty(NametextBox.Text))
            {
                try
                {
                    _currentItem.Name = NametextBox.Text;
                    OnItemsChanged(); // Уведомляем об изменении
                }
                catch (Exception ex)
                {
                    // Можно показать сообщение об ошибке или просто не сохранять
                    Console.WriteLine($"Ошибка сохранения названия: {ex.Message}");
                }
            }
            ValidateNameField();
        }

        /// <summary>
        /// Автоматическое сохранение при изменении описания
        /// </summary>
        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                try
                {
                    _currentItem.Info = DescriptiontextBox.Text;
                    OnItemsChanged(); // Уведомляем об изменении
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка сохранения описания: {ex.Message}");
                }
            }
            ValidateDescriptionField();
        }

        /// <summary>
        /// Автоматическое сохранение при изменении цены
        /// </summary>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && !string.IsNullOrEmpty(CosttextBox.Text))
            {
                try
                {
                    if (double.TryParse(CosttextBox.Text, out double cost))
                    {
                        _currentItem.Cost = cost;
                        OnItemsChanged(); // Уведомляем об изменении
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка сохранения цены: {ex.Message}");
                }
            }
            ValidateCostField();
        }

        /// <summary>
        /// Автоматическое сохранение при изменении категории
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && CategorycomboBox1.SelectedItem is Category category)
            {
                try
                {
                    _currentItem.Category = category;
                    OnItemsChanged(); // Уведомляем об изменении
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка сохранения категории: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Гарантированное сохранение при уходе с поля ввода
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            // Принудительно сохраняем изменения при потере фокуса
            if (_currentItem != null)
            {
                SaveCurrentItem();
            }
        }

        /// <summary>
        /// Сохраняет текущий товар
        /// </summary>
        private void SaveCurrentItem()
        {
            if (_currentItem == null) return;

            try
            {
                // Сохраняем название
                if (!string.IsNullOrEmpty(NametextBox.Text))
                {
                    _currentItem.Name = NametextBox.Text;
                }

                // Сохраняем описание
                _currentItem.Info = DescriptiontextBox.Text;

                // Сохраняем цену
                if (!string.IsNullOrEmpty(CosttextBox.Text) && 
                    double.TryParse(CosttextBox.Text, out double cost))
                {
                    _currentItem.Cost = cost;
                }

                // Сохраняем категорию
                if (CategorycomboBox1.SelectedItem is Category category)
                {
                    _currentItem.Category = category;
                }

                OnItemsChanged(); // Уведомляем об изменении
                ApplySearchAndSort(); // Обновляем отображение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Инициализация ComboBox способов сортировки
        /// </summary>
        private void InitializeOrderComboBox()
        {
            // Заполняем ComboBox вариантами сортировки
            OrderComboBox.Items.AddRange(new object[]
            {
                "Name (А-Я)",
                "Cost (Ascending)",
                "Cost (Descending)"
            });

            // Устанавливаем сортировку по имени по умолчанию
            OrderComboBox.SelectedIndex = 0;
            OrderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Обработчик изменения выбора в ComboBox сортировки
        /// </summary>
        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchAndSort();
        }

        /// <summary>
        /// Обработчик изменения текста в поисковой строке
        /// </summary>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchAndSort();
        }


        /// <summary>
        /// Применяет поиск и сортировку товаров
        /// </summary>
        private void ApplySearchAndSort()
        {
            string searchText = FindTextBox.Text.Trim();

            List<Item> itemsToDisplay;

            // 1. Фильтрация
            if (string.IsNullOrEmpty(searchText))
            {
                itemsToDisplay = _items;
            }
            else
            {
                itemsToDisplay = DataTools.FilterItems(_items, item =>
                    item.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            // 2. Сортировка
            itemsToDisplay = ApplySorting(itemsToDisplay);

            // 3. Обновление ListBox с сохранением выделения
            UpdateListBox(itemsToDisplay);
        }

        /// <summary>
        /// Применяет выбранную сортировку к списку товаров
        /// </summary>
        private List<Item> ApplySorting(List<Item> items)
        {
            if (OrderComboBox.SelectedIndex == -1)
                return items;

            // Сохраняем текущий выбранный элемент
            var selectedItem = ItemsListBox.SelectedItem as Item;

            switch (OrderComboBox.SelectedIndex)
            {
                case 0: // По имени (А-Я)
                    return DataTools.SortItems(items, DataTools.SortByName);
                case 1: // По цене (возрастание)
                    return DataTools.SortItems(items, DataTools.SortByCostAscending);
                case 2: // По цене (убывание)
                    return DataTools.SortItems(items, DataTools.SortByCostDescending);
                default:
                    return items;
            }
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
            // Временно отписываемся от событий чтобы не вызывать сохранение
            NametextBox.TextChanged -= NameTextBox_TextChanged;
            DescriptiontextBox.TextChanged -= DescriptionTextBox_TextChanged;
            CosttextBox.TextChanged -= CostTextBox_TextChanged;

            IdtextBox.Text = string.Empty;
            NametextBox.Text = string.Empty;
            DescriptiontextBox.Text = string.Empty;
            CosttextBox.Text = string.Empty;
            CategorycomboBox1.SelectedIndex = 0;


            NametextBox.BackColor = Color.White;
            DescriptiontextBox.BackColor = Color.White;
            CosttextBox.BackColor = Color.White;

            // Снова подписываемся на события
            NametextBox.TextChanged += NameTextBox_TextChanged;
            DescriptiontextBox.TextChanged += DescriptionTextBox_TextChanged;
            CosttextBox.TextChanged += CostTextBox_TextChanged;
        }

        /// <summary>
        /// Обновляет листбокс указанным списком товаров
        /// </summary>
        private void UpdateListBox(List<Item> itemsToDisplay)
        {
            // Сохраняем текущий элемент до обновления
            Item currentSelectedItem = ItemsListBox.SelectedItem as Item;

            // Временно отключаем события выбора
            ItemsListBox.SelectedIndexChanged -= ItemsListBox_SelectedIndexChanged;

            try
            {
                ItemsListBox.BeginUpdate();
                ItemsListBox.Items.Clear();

                if (itemsToDisplay != null)
                {
                    foreach (var item in itemsToDisplay)
                    {
                        ItemsListBox.Items.Add(item);
                    }

                    // Устанавливаем DisplayMember после заполнения
                    ItemsListBox.DisplayMember = null; // Сначала сбрасываем
                    ItemsListBox.DisplayMember = "Name";

                    // Восстанавливаем выделение
                    if (currentSelectedItem != null)
                    {
                        // Ищем элемент с таким же ID в новом списке
                        var itemToSelect = itemsToDisplay.FirstOrDefault(item =>
                            item.Id == currentSelectedItem.Id);

                        if (itemToSelect != null)
                        {
                            ItemsListBox.SelectedItem = itemToSelect;
                        }
                    }
                }
            }
            finally
            {
                ItemsListBox.EndUpdate();
                // Снова включаем события выбора
                ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            }
        }

        /// <summary>
        /// Вызывает событие ItemsChanged
        /// </summary>
        private void OnItemsChanged()
        {
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Редактор изменений в листбоксе предметов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Сохраняем предыдущий элемент перед переключением
            if (_currentItem != null)
            {
                SaveCurrentItem();
            }

            if (ItemsListBox.SelectedItem is Item selectedItem)
            {
                _currentItem = selectedItem;

                // Временно отписываемся чтобы не вызывать сохранение при загрузке данных
                NametextBox.TextChanged -= NameTextBox_TextChanged;
                DescriptiontextBox.TextChanged -= DescriptionTextBox_TextChanged;
                CosttextBox.TextChanged -= CostTextBox_TextChanged;

                IdtextBox.Text = selectedItem.Id.ToString();
                NametextBox.Text = selectedItem.Name;
                DescriptiontextBox.Text = selectedItem.Info;
                CosttextBox.Text = selectedItem.Cost.ToString("F2");
                CategorycomboBox1.SelectedItem = selectedItem.Category;

                // Снова подписываемся
                NametextBox.TextChanged += NameTextBox_TextChanged;
                DescriptiontextBox.TextChanged += DescriptionTextBox_TextChanged;
                CosttextBox.TextChanged += CostTextBox_TextChanged;

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

                ApplySearchAndSort(); 
                ClearFields();
                OnItemsChanged();
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

                ApplySearchAndSort();
                ClearFields();
                OnItemsChanged();
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