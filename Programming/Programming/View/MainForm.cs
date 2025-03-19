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
        private List<Model.Enums.Film> films = new List<Model.Enums.Film>();
        public MainForm()
        {
            InitializeComponent();
        }

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
            void ChangeTextBoxtrd(int index)
        {
            var Width = rectangles[index].Width;
            var Height = rectangles[index].Height;
            var Color = rectangles[index].Color;

            WidthBox.Text = Width.ToString();
            HeightBox.Text = Height.ToString();
            ColorBox.Text = Color.ToString();
        }

     
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (BGenerated)
            {
                ListOfRectangles.SelectedIndex = FindMaxWidth(rectangles);
            }
        }


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

        private void AddFilmBox_Click(object sender, EventArgs e)
        {
            try
            {
                var title = NameBox.Text;
                var durability = int.Parse(DurabiltyBox.Text);
                var year = int.Parse(YearBox.Text);
                var genre = GenreBox.Text;
                var rating = float.Parse(RatingBox.Text);
                Model.Enums.Film film = new Model.Enums.Film
                {
                    Title = title,
                    Durability = durability,
                    Year = year,
                    Genre = genre,
                    Rating = rating
                };
                films.Add(film);
                FilmBox.Items.Add(film.Title);
                FilmBox.Text = title;
                NameBox.Text = string.Empty;
                DurabiltyBox.Text = string.Empty;
                YearBox.Text = string.Empty;
                GenreBox.Text = string.Empty;
                RatingBox.Text = string.Empty;
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуста введи корректные данные");

                NameBox.BackColor = Color.Red;
                DurabiltyBox.BackColor = Color.Red;
                YearBox.BackColor = Color.Red;
                GenreBox.BackColor = Color.Red;
                RatingBox.BackColor = Color.Red;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < films.Count; i++)
            {
                if (films[i].Rating > max)
                    max = (int)films[i].Rating;
                index = i;
            }
            FilmBox.SelectedIndex = index;
        }
        //230
    }
    }


