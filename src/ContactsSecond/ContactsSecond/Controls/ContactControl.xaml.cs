using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsSecond.Controls
{
    /// <summary>
    /// Логика взаимодействия для ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public ContactControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Фильтрация вводимых символов для телефонного номера
        /// </summary>
        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Разрешаем только: цифры, +, -, (, ), пробел
            Regex regex = new Regex(@"^[\d+\-\(\)\s]$");

            // Проверяем каждый вводимый символ
            foreach (char c in e.Text)
            {
                if (!regex.IsMatch(c.ToString()))
                {
                    e.Handled = true; // Блокируем ввод
                    return;
                }
            }
        }

        /// <summary>
        /// Фильтрация вставки из буфера обмена
        /// </summary>
        private void PhoneNumberTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));

                // Проверяем весь вставляемый текст
                Regex regex = new Regex(@"^[\d+\-\(\)\s]+$");

                if (!regex.IsMatch(text))
                {
                    e.CancelCommand(); // Отменяем вставку
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}

