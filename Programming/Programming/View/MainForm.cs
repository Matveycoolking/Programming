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
        Model.Enums.Rectangle[] rectangles;
        Model.Enums.Film[] film;
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

        // убрать
        private void label3_Click(object sender, EventArgs e)
        {

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

        private void SeasoncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
                rectangles = new Model.Enums.Rectangle[amount];
                System.Diagnostics.Trace.WriteLine("message");

                for (int i = 0; i < amount; i++)
                {
                    int j = i + 1;
                    Model.Enums.Rectangle rec = new Model.Enums.Rectangle((float)rnd.Next(0,500), (float)rnd.Next(0,500));
                    rec.Name = "Rectangle" + j;
                    rec.Color = "Red";
                    rectangles[i] = rec;
                    ListOfRectangles.Items.Add(rec.Name);
                    Debug.WriteLine("Send to Debug output");
                }
            }
            else
            {
                MessageBox.Show("Uncorrect");
            }
        }
        /// <summary>
        /// отображение изменений
        /// </summary>
        /// <param name="index">порядок</param>
           public void ChangeTextBoxtrd(int index)
        {
            var Width = rectangles[index].Width;
            var Height = rectangles[index].Height;
            var Color = rectangles[index].Color;

            WidthBox.Text = Width.ToString();
            HeightBox.Text = Height.ToString();
            ColorBox.Text = Color.ToString();
        }
        /// <summary>
        /// нахождение максимальной ширины
        /// </summary>
        /// <param name="rectangles">прямоугольник</param>
        /// <returns></returns>
     
        private int FindMaxWidth(Model.Enums.Rectangle[] rectangles)
        {
            int maxWidth = 0;
            int index = 0;
            for (int i = 0; i < rectangles.Length; i++)
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

        /// <summary>
        /// изменение высоты кнопка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var Height = 0;
            if (Int32.TryParse(HeightBox.Text, out Height) && BGenerated)
            {
                var rec = rectangles[ListOfRectangles.SelectedIndex];
                rec.Height = Height;
            }
            else
            {
                MessageBox.Show("Only num:");
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
            var Height = 0;
            if (Int32.TryParse(HeightBox.Text, out Height) && BGenerated)
            {
                var rec = rectangles[ListOfRectangles.SelectedIndex];
                rec.Height = Height;
            }
            else
            {
                MessageBox.Show("Only num:");
                HeightBox.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// изменение ширины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            var Width = 0;
            if (Int32.TryParse(WidthBox.Text, out Width) && BGenerated)
            {
                var rec = rectangles[ListOfRectangles.SelectedIndex];
                rec.Width = Width;
            }
            else
            {
                MessageBox.Show("Only num:");
                HeightBox.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// изменение цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBox_TextChanged(object sender, EventArgs e)
        {
            if (BGenerated)
            {
                var rec = rectangles[ListOfRectangles.SelectedIndex];
                var Color = ColorBox.Text;
                rec.Color = Color;
            }
        }

        private void ListOfRectangles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeTextBoxtrd(ListOfRectangles.SelectedIndex);
        }

        

        private void CountOfRectangle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void FilmBox4_Enter(object sender, EventArgs e)
        {

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


