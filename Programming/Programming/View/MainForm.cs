using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming
{
    public partial class MainForm : Form
    {
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
                    break;
            }
        }

        private void VaulueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = VaulueListBox.SelectedIndex + 1;
            ValueBox.Text = text.ToString();
        }

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
    }
    }


