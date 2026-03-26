using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using View.ViewModel;

namespace ContactsSecond
{
    public partial class MainWindow : Window
    {
        private MainVM _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            // Создаем и сохраняем ссылку на ViewModel
            _viewModel = new MainVM();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Обработчик закрытия окна - сохраняем данные
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // Сохраняем данные при закрытии приложения
            _viewModel?.SaveData();
        }
    }
}