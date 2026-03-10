using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    public class SaveCommand : ICommand
    {
        /// <summary>
        /// Ссылка на ViewModel, чтобы получить данные контакта
        /// </summary>
        private readonly MainVM _mainVM;

        /// <summary>
        /// Конструктор команды сохранения
        /// </summary>
        /// <param name="mainVM">Ссылка на главную ViewModel</param>
        public SaveCommand(MainVM mainVM)
        {
            _mainVM = mainVM;
        }

        /// <summary>
        /// Определяет, может ли команда выполниться в текущем состоянии
        /// Всегда возвращает true, так как сохранять можно всегда
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет сохранение контакта в файл
        /// </summary>
        public void Execute(object parameter)
        {
            Contact contactToSave = new Contact
            {
                Name = _mainVM.Name,
                PhoneNumber = _mainVM.PhoneNumber,
                Email = _mainVM.Email
            };

            bool result = ContactSerializer.SaveContact(contactToSave);

            if (result)
            {
                System.Windows.MessageBox.Show("Контакт успешно сохранен!",
                    "Сохранение",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("Ошибка при сохранении контакта!",
                    "Ошибка",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Событие, которое возникает при изменении возможности выполнения команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
