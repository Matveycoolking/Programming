using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.Services;


namespace ObjectOrientedPractics.View.Controls
{
    public partial class AddressControl : UserControl
    {
            private Address _address = new Address();

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Address Address
            {
                get => _address;
                set
                {
                    _address = value;
                    UpdateTextProperty();
                }
            }

            public AddressControl()
            {
                InitializeComponent();
        }

        // <summary>
        // Обновляет данные в полях ввода
        // </summary>
        private void UpdateTextProperty()
        {
            try
            {
                // Добавьте отладку
                Console.WriteLine($"UpdateTextProperty called: Index={_address.Index}, Country={_address.Country}");

                IndexTextBox.Text = _address.Index.ToString();
                CountryTextBox.Text = _address.Country;
                CityTextBox.Text = _address.City;
                StreetTextBox.Text = _address.Street;
                BuildingTextBox.Text = _address.Building;
                ApartmentTextBox.Text = _address.Apartment;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateTextProperty: {ex.Message}");
            }
        }

        private void IndexTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Index = Convert.ToInt32(IndexTextBox.Text);
                IndexTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                IndexTextBox.BackColor = AppColors.ErrorInput;
            }
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Country = CountryTextBox.Text;
                CountryTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                CountryTextBox.BackColor = AppColors.ErrorInput;
            }
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Street = StreetTextBox.Text;
                StreetTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                StreetTextBox.BackColor = AppColors.ErrorInput;
            }
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Building = BuildingTextBox.Text;
                BuildingTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                BuildingTextBox.BackColor = AppColors.ErrorInput;
            }
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.City = CityTextBox.Text;
                CityTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                CityTextBox.BackColor = AppColors.ErrorInput;
            }
        }

        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Apartment = ApartmentTextBox.Text;
                ApartmentTextBox.BackColor = AppColors.BaseInput;
            }
            catch
            {
                ApartmentTextBox.BackColor = AppColors.ErrorInput;
            }
        }
    }
}
