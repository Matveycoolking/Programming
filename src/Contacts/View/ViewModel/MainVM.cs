using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model;

namespace View.ViewModel
{
        public class MainVM : INotifyPropertyChanged
        {
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Модель контакта, где хранятся все данные
        /// </summary>
        private Contact _contact;

            /// <summary>
            /// Конструктор по умолчанию
            /// </summary>
            public MainVM() 
            {
           _contact = new Contact("Смирнов Юрий", "+79234065501", "yuri.smirnov@inbox.ru");

            SaveCommand = new SaveCommand(this);
            LoadCommand = new LoadCommand(this);
            }

            /// <summary>
            /// Имя контакта
            /// </summary>
            public string Name
            {
                get { return _contact.Name; }
                set
                {
                    if (_contact.Name != value)
                    {
                        _contact.Name = value;
                        OnPropertyChanged();
                    }
                }
            }

            /// <summary>
            /// Номер телефона контакта
            /// </summary>
            public string PhoneNumber
            {
                get { return _contact.PhoneNumber; }
                set
                {
                    if (_contact.PhoneNumber != value)
                    {
                        _contact.PhoneNumber = value;
                        OnPropertyChanged();
                    }
                }
            }

            /// <summary>
            /// Электронная почта контакта
            /// </summary>
            public string Email
            {
                get { return _contact.Email; }
                set
                {
                    if (_contact.Email != value)
                    {
                        _contact.Email = value;
                        OnPropertyChanged();
                    }
                }
            }

            /// <summary>
            /// Событие, необходимое для интерфейса INotifyPropertyChanged
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Метод для вызова события PropertyChanged
            /// </summary>
            /// <param name="prop">Имя свойства, которое изменилось</param>
            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
