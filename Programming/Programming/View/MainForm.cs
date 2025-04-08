using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programming.Model;
using Programming.Model.Enums;

namespace Programming
{
    public partial class MainForm : Form
    {
        private List<Model.Enums.Rectangle> _rectangles = new List<Model.Enums.Rectangle>();
        private Model.Enums.Rectangle _currentRectangle;
        private List<Model.Enums.Rectangle> rectangles = new List<Model.Enums.Rectangle>();
        Model.Enums.Film[] film;
        private List<Panel> _rectanglePanels = new List<Panel>();
        bool BGenerated = false;
        //private List<Model.Enums.Film> films = new List<Model.Enums.Film>();
        public MainForm()
        {
            InitializeComponent();
        }
        // убрать
        private void Choose_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// добавляет элементы в листбокс
        /// </summary>
        /// <param name="enumType">сами элементы</param>
        void AddToValues(Type enumType)
        {
            VaulueListBox.Items.Clear();
            Array array = Enum.GetValues(enumType);
            foreach (var element in array)
            {
                VaulueListBox.Items.Add(element);
            }
        }
        /// <summary>
        /// само перечисление
        /// </summary>
        private void EnumListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EnumListbox.SelectedIndex)
            {
                case 0:
                    AddToValues(typeof(Model.Enums.color));
                    break;
                case 1:
                    AddToValues(typeof(Model.Enums.Genre));
                    break;
                case 2:
                    AddToValues(typeof(Model.Enums.EducationForm));
                    break;
                case 3:
                    AddToValues(typeof(Model.Enums.Year));
                    break;
                case 4:
                    AddToValues(typeof(Model.Enums.Weekday));
                    break;
                case 5:
                    AddToValues(typeof(Model.Enums.TypeOfSmartphone));
                    break;
            }
        }
        /// <summary>
        /// меняет индекс в текстбоксе со значениями
        /// </summary>
        private void VaulueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = VaulueListBox.SelectedIndex + 1;
            ValueBox.Text = text.ToString();
        }
        /// <summary>
        /// кнопка для обозначения дня недели
        /// </summary>
        private void ParseButton_Click(object sender, EventArgs e)
        {
            string inputText = ParseBox.Text.Trim();

            if (Enum.TryParse(inputText, true, out Model.Enums.Weekday weekday))
            {
                int dayNum = (int)weekday;
                if (dayNum >= 1 && dayNum <= 7)
                {
                    TextOfTheDay.Text = $"Это день недели ({weekday} = {dayNum})";
                }

            }
            else
            {
                TextOfTheDay.Text = "Нет такого дня нет";
            }
        }
        /// <summary>
        /// кнопка отвечающая за смену сезона
        /// </summary>
        private void SeasonButton_Click(object sender, EventArgs e)
        {
            switch (SeasoncomboBox1.SelectedIndex)
            {
                case 0:
                    tabPage1.BackColor= Color.Green;
                    break;
                case 1:
                    tabPage1.BackColor= Color.Yellow;
                    break;
                case 2:
                    MessageBox.Show("БРРР, холодно");
                    break;
                case 3:
                    MessageBox.Show("Ура! Солнце!");
                    break;
            }
        }

        /// <summary>
        /// генерация массива фильмов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateFilmArray_Click_Click(object sender, EventArgs e)
        {
            BGenerated = true;
            Random rnd = new Random();
            int amount;

            if (Int32.TryParse(CountOfFilms.Text, out amount) && amount > 0)
            {
                // Инициализация массива films
                film = new Model.Enums.Film[amount];
                FilmBox.Items.Clear();

                for (int i = 0; i < amount; i++)
                {
                    Genre randomGenre = (Genre)rnd.Next(0, Enum.GetValues(typeof(Genre)).Length);

                    // Создание нового объекта Film
                    Model.Enums.Film filma = new Model.Enums.Film
                    {
                        Title = "Film " + (i + 1),
                        Durability = rnd.Next(60, 180), // продолжительность от 60 до 180 минут
                        Year = rnd.Next(1900, DateTime.Now.Year + 1),
                        Genre = randomGenre,
                        Rating = rnd.Next(0,10) // рейтинг от 0 до 10
                    };
                   

                    Debug.WriteLine("Send to Debug output");

                    // Проверка перед добавлением в массив
                    if (i < film.Length) // Убедитесь, что индекс в пределах массива
                    {
                        film[i] = filma; // Создание нового объекта Film
                        FilmBox.Items.Add(filma.Title);
                    }
                    else
                    {
                        MessageBox.Show($"Индекс {i} выходит за пределы массива.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Некорректное количество фильмов.");
            }
        }
        /// <summary>
        /// отображение изменений
        /// </summary>
        /// <param name="index"></param>
        private void ChangeTextBoxFilm(int index)
        {
            var Name = film[index].Title;
            var Durability = film[index].Durability;
            var Genre = film[index].Genre;
            var Rating = film[index].Rating;
            var Year = film[index].Year;

            NameBox.Text = Name.ToString();
            DurabiltyBox.Text = Durability.ToString();
            YearBox.Text = Year.ToString();
            GenreBox.Text = Genre.ToString();
            RatingBox.Text = Rating.ToString("F1");

        }
        /// <summary>
        /// переключение между выборами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilmBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (BGenerated && FilmBox.SelectedIndex >= 0)
            {
                ChangeTextBoxFilm(FilmBox.SelectedIndex);
            }
        }
        /// <summary>
        /// массив прямоугольников генерация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateReactArray_Click(object sender, EventArgs e)
        {
            BGenerated = true;
            Random rnd = new Random();
            int amount;
            if (Int32.TryParse(CountOfRectangle.Text, out amount))
            {
                

                amount = int.Parse(CountOfRectangle.Text);
                MessageBox.Show(amount.ToString());
                _rectangles.Clear();
                rectangles.Clear();
               
                //System.Diagnostics.Trace.WriteLine("message");

                for (int i = 0; i < amount; i++)
                {
                    int j = i + 1;
                    Model.Enums.Rectangle _currentRectangle = new Model.Enums.Rectangle((float)rnd.Next(1, 500), (float)rnd.Next(1, 500), new Point2D(rnd.Next(1, 500), rnd.Next(1, 500)));
                   // Model.Enums.Rectangle rec = new Model.Enums.Rectangle((float)rnd.Next(0,500), (float)rnd.Next(0,500), new Point2D(rnd.Next(0, 500), rnd.Next(0,500)));
                    _currentRectangle.Name = "Rectangle" + j;
                    _currentRectangle.Color = "Red";
                    rectangles.Add(_currentRectangle);
                    _rectangles.Add(_currentRectangle);
                    ListOfRectangles.Items.Add(_currentRectangle.Name);
                    ListRectangle.Items.Add($"{_currentRectangle.ID}: (X = {_currentRectangle.Center.X}; Y = {_currentRectangle.Center.Y}; W = {_currentRectangle.Width}; H = {_currentRectangle.Height})");
                    CreateRectanglePanel(_currentRectangle);
                    FindCollisions();
                    Debug.WriteLine("Send to Debug output");
                }
                if (ListOfRectangles.Items.Count > 0)
                {
                    ListRectangle.SelectedIndex = 0;
                    ListOfRectangles.SelectedIndex = 0;
                } 
            }
            else
            {
                MessageBox.Show("Uncorrect");
            }
        }
        private void DELEATBUTTON_Click(object sender, EventArgs e)
        {

            // Получаем текущий выбранный индекс
            int selectedIndex = ListRectangle.SelectedIndex;
            
            if(selectedIndex == -1)
    {
                MessageBox.Show("Не выбран прямоугольник для удаления");
                return;
            }

            if (selectedIndex < 0 ||
        selectedIndex >= _rectangles.Count ||
        selectedIndex >= rectangles.Count)
            {
                MessageBox.Show("Ошибка: недопустимый индекс");
                return;
            }


            try
            {
                // Удаляем из всех коллекций
                rectangles.RemoveAt(selectedIndex);
                _rectangles.RemoveAt(selectedIndex);
                
                if (selectedIndex < _rectanglePanels.Count)
                {
                    CanvasPanel.Controls.Remove(_rectanglePanels[selectedIndex]);
                    _rectanglePanels[selectedIndex].Dispose();
                    _rectanglePanels.RemoveAt(selectedIndex);
                }

                ListOfRectangles.Items.RemoveAt(selectedIndex);
                ListRectangle.Items.RemoveAt(selectedIndex);

                // Очищаем текстовые поля
                ClearTextBoxes();
                
                if(ListRectangle.Items.Count > 0)
        {
                    int newIndex = selectedIndex > 0 ? selectedIndex - 1 : 0;
                    ListRectangle.SelectedIndex = newIndex;
                    ListOfRectangles.SelectedIndex = newIndex;
                }
                FindCollisions();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
       
        private void ClearTextBoxes()
        {
            WidthBox.Clear();
            WIDTHBOX1.Clear();
            HeightBox.Clear();
            HEIGHTBOX1.Clear();
            ColorBox.Clear();
            XBox.Clear();
            XBOX1.Clear();
            YBox.Clear();
            YBOX1.Clear();
            IDBOX1.Clear();
            LableID.Text = "";
        }

        private void ADDBUTTON_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Model.Enums.Rectangle rec = new Model.Enums.Rectangle((float)rnd.Next(1, 100), (float)rnd.Next(1, 100), new Point2D(rnd.Next(1, 250), rnd.Next(1, 250)));
            rec.Color = "Red";
            rec.Name = "Rectangle" + (rectangles.Count + 1);
            rectangles.Add(rec);
            _rectangles.Add(rec);
            ListRectangle.Items.Add($"{rec.ID}: (X = {rec.Center.X}; Y = {rec.Center.Y}; W = {rec.Width}; H = {rec.Height})");
            ListOfRectangles.Items.Add(rec.Name);
            CreateRectanglePanel(rec);
            FindCollisions();

            // Устанавливаем выделение
            int newIndex = rectangles.Count - 1;
            ListOfRectangles.SelectedIndex = newIndex;
            ListRectangle.SelectedIndex = newIndex;
            Debug.WriteLine("Send to Debug output");
        }
        private void FindCollisions()
        {
            // Сначала все панели делаем зелеными
            foreach (var panel in _rectanglePanels)
            {
                panel.BackColor = Color.FromArgb(127, 127, 255, 127); // Полупрозрачный зеленый
            }

            // Проверяем пересечения всех пар прямоугольников
            for (int i = 0; i < rectangles.Count; i++)
            {
                for (int j = i + 1; j < rectangles.Count; j++) // Начинаем с i+1 чтобы избежать повторных проверок
                {
                    if (CollisionManager.IsCollision(rectangles[i], rectangles[j]))
                    {
                        // Перекрашиваем оба пересекающихся прямоугольника в красный
                        if (i < _rectanglePanels.Count)
                            _rectanglePanels[i].BackColor = Color.FromArgb(127, 255, 127, 127);

                        if (j < _rectanglePanels.Count)
                            _rectanglePanels[j].BackColor = Color.FromArgb(127, 255, 127, 127);
                    }
                }
            }
        }


        private void CreateRectanglePanel(Model.Enums.Rectangle rectangle)
        {
            Panel panel = new Panel();

            // Устанавливаем свойства панели по данным прямоугольника
            panel.Width = (int)rectangle.Width;
            panel.Height = (int)rectangle.Height;
            panel.Location = new Point((int)rectangle.Center.X - panel.Width / 2,
                                     (int)rectangle.Center.Y - panel.Height / 2);

           
            panel.BackColor = Color.FromArgb(127, 127, 255, 127);

            
            CanvasPanel.Controls.Add(panel);
            _rectanglePanels.Add(panel);

            
        }
        /// <summary>
        /// отображение изменений
        /// </summary>
        /// <param name="index">порядок</param>
        public void ChangeTextBoxtrd(int index)
        {
            if (rectangles == null || rectangles.Count == 0)
            {
                ClearTextBoxes();
                return;
            }
            if (index < 0 || index >= rectangles.Count)
            {
                ClearTextBoxes();
                return;
            }

            // Проверяем валидность индекса
            if (index < 0 || index >= rectangles.Count || rectangles[index] == null)
            {
                ClearTextBoxes();
                return;
            }

            try
            {
                var rectangle = rectangles[index];
                if (rectangle == null)
                {
                    ClearTextBoxes();
                    return;
                }

                WidthBox.TextChanged -= WidthBox_TextChanged;
                HeightBox.TextChanged -= HeightBox_TextChanged;
                

                WidthBox.Text = rectangle.Width.ToString();
                WIDTHBOX1.Text = rectangle.Width.ToString();
                HeightBox.Text = rectangle.Height.ToString();
                HEIGHTBOX1.Text = rectangle.Height.ToString();
                ColorBox.Text = rectangle.Color ?? "Red";
                XBox.Text = rectangle.Center.X.ToString();
                XBOX1.Text = rectangle.Center.X.ToString();
                YBox.Text = rectangle.Center.Y.ToString();
                YBOX1.Text = rectangle.Center.Y.ToString();
                IDBOX1.Text = rectangle.ID.ToString();
                LableID.Text = rectangle.ID.ToString();
                XBox.ReadOnly = true;
                YBox.ReadOnly = true;
                IDBOX1.ReadOnly = true;

                // Восстанавливаем обработчики
                WidthBox.TextChanged += WidthBox_TextChanged;
                HeightBox.TextChanged += HeightBox_TextChanged;
                
            }
            catch (Exception ex)
            {
               
                ClearTextBoxes();
            }
        }
        /// <summary>
        /// нахождение максимальной ширины
        /// </summary>
        /// <param name="rectangles">прямоугольник</param>
        /// <returns></returns>
     
        private int FindMaxWidth(List<Model.Enums.Rectangle> rectangles)
        {
            int maxWidth = rectangles[0].Width;
            int index = 0;
            for (int i = 1; i < rectangles.Count; i++)
            {
                if(maxWidth <  rectangles[i].Width)
                {
                    maxWidth = rectangles[i].Width;
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// заменить название кнопка по нахождению максимальной ширины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (BGenerated)
            {
                ListOfRectangles.SelectedIndex = FindMaxWidth(rectangles);
            }
        }
        private void UpdateRectanglePanel(int index)
        {
            if (index < 0 || index >= rectangles.Count || index >= _rectanglePanels.Count)
                return;

            var rectangle = rectangles[index];
            var panel = _rectanglePanels[index];

            // Обновляем размеры и положение панели
            panel.Width = (int)rectangle.Width;
            panel.Height = (int)rectangle.Height;

            // Обновляем запись в ListBox
            UpdateListBoxItem(index);
        }

        private void UpdateListBoxItem(int index)
        {
            if (index < 0 || index >= rectangles.Count) return;

            var rec = rectangles[index];

            // Обновляем оба ListBox
            if (index < ListOfRectangles.Items.Count)
                ListOfRectangles.Items[index] = rec.Name;

            if (index < ListRectangle.Items.Count)
                ListRectangle.Items[index] = $"{rec.ID}: (X = {rec.Center.X}; Y = {rec.Center.Y}; W = {rec.Width}; H = {rec.Height})";
        }
        /// <summary>
        /// изменение высоты кнопка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var Height = 1;
            if (Int32.TryParse(HeightBox.Text, out Height) && BGenerated && ListOfRectangles.SelectedIndex != -1)
            {
                int selectedIndex = ListOfRectangles.SelectedIndex;
                var rec = rectangles[selectedIndex];
                rec.Height = Height;
                UpdateListBoxItem(selectedIndex);
                UpdateRectanglePanel(selectedIndex);
                FindCollisions();
            }
            else
            {
                MessageBox.Show("Введите корректное число");
                HeightBox.BackColor = Color.Red;
            }
        }
         /// <summary>
         /// функция по замене удалить
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void HeightBox_TextChanged(object sender, EventArgs e)
        {
            var Height = 1;
            if (Int32.TryParse(HeightBox.Text, out Height) && BGenerated && ListOfRectangles.SelectedIndex != -1)
            {
                int selectedIndex = ListOfRectangles.SelectedIndex;
                var rec = rectangles[selectedIndex];
                rec.Height = Height;
                UpdateListBoxItem(selectedIndex);
                UpdateRectanglePanel(selectedIndex);
                FindCollisions();
            }

        }
        /// <summary>
        /// изменение ширины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            var Width = 1;
            if (Int32.TryParse(WidthBox.Text, out Width) && BGenerated && ListOfRectangles.SelectedIndex != -1)
            {
                int selectedIndex = ListOfRectangles.SelectedIndex;
                var rec = rectangles[selectedIndex];
                rec.Width = Width;
                UpdateListBoxItem(selectedIndex);
                UpdateRectanglePanel(selectedIndex);
                FindCollisions();
            }
        }
        /// <summary>
        /// изменение цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBox_TextChanged(object sender, EventArgs e)
        {
            if (BGenerated && ListOfRectangles.SelectedIndex != -1)
            {
                int selectedIndex = ListOfRectangles.SelectedIndex;
                var rec = rectangles[selectedIndex];
                rec.Color = ColorBox.Text;
                UpdateListBoxItem(selectedIndex);
                FindCollisions();
            }
        }

        private void ListOfRectangles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfRectangles.SelectedIndex != -1)
            {
                // Синхронизируем выделение в другом ListBox
                ListRectangle.SelectedIndex = ListOfRectangles.SelectedIndex;

                // Обновляем текстовые поля
                ChangeTextBoxtrd(ListRectangle.SelectedIndex);
            }
            else
            {
                ClearTextBoxes();
            }
        }

        private void Rectangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeTextBoxtrd(ListRectangle.SelectedIndex);
        }







        /// <summary>
        /// нахождение максимального рейтинга замена названия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < film.Length; i++)
            {
                if (film[i].Rating > max)
                {
                    max = (int)film[i].Rating;
                    index = i;
                }
                
            }
            FilmBox.SelectedIndex = index;
        }
        /// <summary>
        /// изменение года фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeButtons_Click(object sender, EventArgs e)
        {
            var Param = 0;
            if (Int32.TryParse(YearBox.Text, out Param) && BGenerated)
            {
                var fill = film[FilmBox.SelectedIndex];
                fill.Year = Param;
                
            }
            else
            {
                MessageBox.Show("Only num:");
                
            }
        }
       /// <summary>
       /// изменение имени фильма
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            if (BGenerated)
            {
                var fill = film[FilmBox.SelectedIndex];
                fill.Title = NameBox.Text; // Присваиваем текст напрямую
            }
            else
            {
                MessageBox.Show("Only num:");
            }
        }

        
    }
 }



