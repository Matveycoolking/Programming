using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Controls
{
    public partial class AddressControl : UserControl
    {
        private Address _address = new Address();
        private ErrorProvider errorProvider = new ErrorProvider();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get 
            {
                UpdateAddressFromControls();
                return _address; 
            }
            set
            {
                _address = value;
                UpdateControlsFromAddress();
            }
        }

        public AddressControl()
        {
            InitializeComponent();
            InitializeErrorProvider();
            InitializeEvents();
        }

        /// <summary>
        /// Настройка ErrorProvider
        /// </summary>
        private void InitializeErrorProvider()
        {
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
        }

        private void InitializeEvents()
        {
            // Валидация при потере фокуса
            PostIndexTextBox.Validating += ValidatePostIndex;
            CountryTextBox.Validating += ValidateCountry;
            CityTextBox.Validating += ValidateCity;
            StreetTextBox.Validating += ValidateStreet;
            BuildingTextBox.Validating += ValidateBuilding;
            ApartmentTextBox.Validating += ValidateApartment;

            // Сброс ошибки при начале редактирования
            PostIndexTextBox.TextChanged += (s, e) => ClearError(PostIndexTextBox);
            CountryTextBox.TextChanged += (s, e) => ClearError(CountryTextBox);
            CityTextBox.TextChanged += (s, e) => ClearError(CityTextBox);
            StreetTextBox.TextChanged += (s, e) => ClearError(StreetTextBox);
            BuildingTextBox.TextChanged += (s, e) => ClearError(BuildingTextBox);
            ApartmentTextBox.TextChanged += (s, e) => ClearError(ApartmentTextBox);
        }

        /// <summary>
        /// Валидация почтового индекса
        /// </summary>
        private void ValidatePostIndex(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (!int.TryParse(textBox.Text, out int index))
            {
                SetError(textBox, "Индекс должен быть числом");
                e.Cancel = true;
                return;
            }

            if (index < 100000 || index > 999999)
            {
                SetError(textBox, "Индекс должен быть шестизначным числом");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Валидация страны
        /// </summary>
        private void ValidateCountry(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetError(textBox, "Страна не может быть пустой");
                e.Cancel = true;
                return;
            }

            if (textBox.Text.Length > 50)
            {
                SetError(textBox, "Название страны не должно превышать 50 символов");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Валидация города
        /// </summary>
        private void ValidateCity(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetError(textBox, "Город не может быть пустым");
                e.Cancel = true;
                return;
            }

            if (textBox.Text.Length > 50)
            {
                SetError(textBox, "Название города не должно превышать 50 символов");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Валидация улицы
        /// </summary>
        private void ValidateStreet(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetError(textBox, "Улица не может быть пустой");
                e.Cancel = true;
                return;
            }

            if (textBox.Text.Length > 100)
            {
                SetError(textBox, "Название улицы не должно превышать 100 символов");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Валидация номера дома
        /// </summary>
        private void ValidateBuilding(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetError(textBox, "Номер дома не может быть пустым");
                e.Cancel = true;
                return;
            }

            if (textBox.Text.Length > 10)
            {
                SetError(textBox, "Номер дома не должен превышать 10 символов");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Валидация номера квартиры
        /// </summary>
        private void ValidateApartment(object sender, CancelEventArgs e)
        {
            var textBox = (WinForms.TextBox)sender;
            ClearError(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetError(textBox, "Номер квартиры не должен превышать 10 символов");
                e.Cancel = true;
                return;
            }

            if (textBox.Text.Length > 10)
            {
                SetError(textBox, "Номер квартиры не должен превышать 10 символов");
                e.Cancel = true;
            }
                
        }

        /// <summary>
        /// Установка ошибки для контрола
        /// </summary>
        private void SetError(Control control, string message)
        {
            errorProvider.SetError(control, message);
            control.BackColor = Color.LightPink; // Подсветка красным
        }

        /// <summary>
        /// Очистка ошибки для контрола
        /// </summary>
        private void ClearError(Control control)
        {
            errorProvider.SetError(control, "");
            control.BackColor = SystemColors.Window; // Возвращаем стандартный цвет
        }

        private void UpdateControlsFromAddress()
        {
            if (_address == null) return;

            // Временно отключаем валидацию
            PostIndexTextBox.Validating -= ValidatePostIndex;
            CountryTextBox.Validating -= ValidateCountry;
            CityTextBox.Validating -= ValidateCity;
            StreetTextBox.Validating -= ValidateStreet;
            BuildingTextBox.Validating -= ValidateBuilding;
            ApartmentTextBox.Validating -= ValidateApartment;

            PostIndexTextBox.Text = _address.Index.ToString();
            CountryTextBox.Text = _address.Country;
            CityTextBox.Text = _address.City;
            StreetTextBox.Text = _address.Street;
            BuildingTextBox.Text = _address.Building;
            ApartmentTextBox.Text = _address.Apartment ?? "";

            // Очищаем ошибки при обновлении данных
            ClearAllErrors();

            // Включаем валидацию обратно
            InitializeEvents();
        }
        public bool ValidateAddress()
        {
            return ValidateChildren(ValidationConstraints.Enabled);
        }
        public bool TryGetAddress(out Address address)
        {
            if (ValidateChildren()) // Проверяем валидацию всех контролов
            {
                UpdateAddressFromControls();
                address = _address;
                return true;
            }
            else
            {
                address = null;
                return false;
            }
        }

        private void UpdateAddressFromControls()
        {
            if (_address == null)
                _address = new Address();

            try
            {
                // Временно отключаем валидацию чтобы не блокировать обновление
                this.SuspendLayout();

                if (int.TryParse(PostIndexTextBox.Text, out int index))
                {
                    _address.Index = index;
                }
                else
                {
                    _address.Index = 100000; // Значение по умолчанию при ошибке
                }

                _address.Country = CountryTextBox.Text ?? "";
                _address.City = CityTextBox.Text ?? "";
                _address.Street = StreetTextBox.Text ?? "";
                _address.Building = BuildingTextBox.Text ?? "";
                _address.Apartment = string.IsNullOrEmpty(ApartmentTextBox.Text) ? null : ApartmentTextBox.Text;
            }
            catch (Exception ex)
            {
                // Логируем ошибку, но не прерываем выполнение
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления адреса: {ex.Message}");
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }

        /// <summary>
        /// Очистка всех ошибок
        /// </summary>
        private void ClearAllErrors()
        {
            ClearError(PostIndexTextBox);
            ClearError(CountryTextBox);
            ClearError(CityTextBox);
            ClearError(StreetTextBox);
            ClearError(BuildingTextBox);
            ClearError(ApartmentTextBox);
        }
    }
}
