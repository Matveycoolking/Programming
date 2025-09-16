using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirPlan.Models;
using AirPlan.Models.Enums;

namespace AirPlan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
            FlyingListBox.SelectedIndexChanged += FlyingListBox_SelectedIndexChanged;
        }
        private void InitializeControls()
        {
            
            
            FlyingComboBox.DataSource = Enum.GetValues(typeof(Flying));

           
        }

        private void ADDButton_Click_1(object sender, EventArgs e)
        {
            string nameStart = FirstPlaceBox.Text;
            string nameEnd = FinalyBox.Text;
            try
            {
                DepartureTime startDateTime = new DepartureTime(departureDateTimePicker.Value);
                int timeInFly = int.Parse(TimeinFlyBox.Text);
                Flying typeFly = (Flying)FlyingComboBox.SelectedItem;
                Fly newFly = new Fly(nameStart, nameEnd, startDateTime, timeInFly, typeFly);
                Fly.Flys.Add(newFly);
                var sortedFlights = Fly.Flys.OrderBy(f => f.StartTime).ToList();

                // Обновляем ListBox
                FlyingListBox.Items.Clear();
                foreach (var flight in sortedFlights)
                {

                    FlyingListBox.Items.Add($"{flight.NameStart} -> {flight.NameEnd}, Время: {flight.StartTime}, Длительность: {flight.TimeInFly}, Тип: {flight .TypeFly}");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректное время в формате чисел.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DELButton_Click(object sender, EventArgs e)
        {
            if (FlyingListBox.SelectedItem != null)
            {
                // Получаем индекс выбранного элемента
                int selectedIndex = FlyingListBox.SelectedIndex;

                // Удаляем элемент из коллекции Fly.Flys
                Fly.Flys.RemoveAt(selectedIndex);

                // Удаляем элемент из ListBox
                FlyingListBox.Items.RemoveAt(selectedIndex);
                var sortedFlights = Fly.Flys.OrderBy(f => f.StartTime).ToList();

                // Обновляем ListBox
                FlyingListBox.Items.Clear();
                foreach (var flight in sortedFlights)
                {
                    FlyingListBox.Items.Add($"{flight.NameStart} -> {flight.NameEnd}, Время: {flight.StartTime}, Длительность: {flight.TimeInFly}, Тип: {flight.TypeFly}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
    }
        private void ChangeButton_Click_1(object sender, EventArgs e)
        {
            if (FlyingListBox.SelectedItem != null)
            {
                // Получаем индекс выбранного элемента
                int selectedIndex = FlyingListBox.SelectedIndex;

                // Формируем новую строку на основе введенных данных
                string newStart = FirstPlaceBox.Text;
                string newEnd = FinalyBox.Text;
                try
                {
                    DepartureTime newTime = new DepartureTime(departureDateTimePicker.Value);

                    string newDuration = TimeinFlyBox.Text;
                    string newType = FlyingComboBox.SelectedItem.ToString();

                    // Создаем новую строку для обновления
                    //string updatedItem = $"{newStart} -> {newEnd}, Время: {newTime}, Длительность: {newDuration}, Тип: {newType}";
                    Fly.Flys[selectedIndex].NameStart = newStart;
                    Fly.Flys[selectedIndex].NameEnd = newEnd;
                    Fly.Flys[selectedIndex].StartTime = newTime;
                    Fly.Flys[selectedIndex].TimeInFly = int.Parse(newDuration);
                    Fly.Flys[selectedIndex].TypeFly = (Flying)Enum.Parse(typeof(Flying), newType);

                    // Обновляем элемент в ListBox
                    var sortedFlights = Fly.Flys.OrderBy(f => f.StartTime).ToList();
                    FlyingListBox.Items.Clear();
                    foreach (var flight in sortedFlights)
                    {
                        FlyingListBox.Items.Add($"{flight.NameStart} -> {flight.NameEnd}, Время: {flight.StartTime}, Длительность: {flight.TimeInFly}, Тип: {flight.TypeFly}");
                    }

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный формат времени.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FlyingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlyingListBox.SelectedItem != null)
            {
                // Получаем выбранный элемент
                string selectedItem = FlyingListBox.SelectedItem.ToString();
                string[] parts = selectedItem.Split(new[] { " -> ", ", Время: ", ", Длительность: ", ", Тип: " }, StringSplitOptions.None);

                if (parts.Length >= 4)
                {
                    // Заполняем текстовые поля
                    FirstPlaceBox.Text = parts[0]; // Начало
                    FinalyBox.Text = parts[1]; // Конец

                    // Извлекаем длительность
                    string durationPart = parts[3].Replace("Длительность: ", "").Trim();
                    TimeinFlyBox.Text = durationPart;

                    // Извлекаем время вылета и устанавливаем его в DateTimePicker
                    string timePart = parts[2].Replace("Время: ", "").Trim();
                    try
                    {


                        DepartureTime departureTime = new DepartureTime(DateTime.Parse(timePart));
                        departureDateTimePicker.Value = departureTime.Departure;
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка ввода даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Некорректный формат времени.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Устанавливаем тип полета в ComboBox
                    string typePart = parts[4].Replace("Тип: ", "").Trim();
                    if (Enum.TryParse(typePart, out Flying selectedType))
                    {
                        FlyingComboBox.SelectedItem = selectedType; // Устанавливаем выбранный элемент в ComboBox
                    }
                }
            }

        }

        

        
    }
}
