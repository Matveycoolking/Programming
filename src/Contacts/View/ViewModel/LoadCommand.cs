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
    public class LoadCommand : ICommand
    {
        /// <summary>
        /// Ссылка на ViewModel, чтобы обновить данные контакта
        /// </summary>
        private readonly MainVM _mainVM;

        /// <summary>
        /// Конструктор команды загрузки
        /// </summary>
        /// <param name="mainVM">Ссылка на главную ViewModel</param>
        public LoadCommand(MainVM mainVM)
        {
            _mainVM = mainVM;
        }

        /// <summary>
        /// Определяет, может ли команда выполниться в текущем состоянии
        /// Всегда возвращает true, так как загружать можно всегда
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true; // Всегда можно попытаться загрузить
        }

        /// <summary>
        /// Выполняет загрузку контакта из файла
        /// </summary>
        public void Execute(object parameter)
        {
            // Загружаем контакт через сериализатор
            Contact loadedContact = ContactSerializer.LoadContact();

            // Обновляем данные в ViewModel
            _mainVM.Name = loadedContact.Name;
            _mainVM.PhoneNumber = loadedContact.PhoneNumber;
            _mainVM.Email = loadedContact.Email;

            System.Windows.MessageBox.Show("Контакт успешно загружен!",
                "Загрузка",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
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
