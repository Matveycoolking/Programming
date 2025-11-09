using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class DiscountsTab : UserControl
    {
        private PointsDiscount _pointsDiscount;
        private List<Item> _cartItems;

        public DiscountsTab()
        {
            InitializeComponent();
            _pointsDiscount = new PointsDiscount(100); // Начальные баллы: 100
            _cartItems = new List<Item>();
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            // Обновляем информацию о баллах
            label2.Text = _pointsDiscount.Info;

            // Обновляем количество товаров
            label4.Text = _cartItems.Count.ToString();

            // Обновляем доступную скидку
            double discount = _pointsDiscount.Calculate(_cartItems);
            label6.Text = discount.ToString("F2");
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // Просто рассчитываем скидку и обновляем отображение
            double discount = _pointsDiscount.Calculate(_cartItems);
            label6.Text = discount.ToString("F2");

            MessageBox.Show($"Рассчитанная скидка: {discount:F2} руб", "Расчет скидки");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Добавьте товары для применения скидки");
                return;
            }

            // Применяем скидку и списываем баллы
            double appliedDiscount = _pointsDiscount.Apply(_cartItems);

            // Обновляем отображение
            UpdateDisplay();

            MessageBox.Show($"Скидка применена: {appliedDiscount:F2} руб\nБаллы списаны", "Скидка применена");
        }

        private void UppdateButton_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Добавьте товары для начисления баллов");
                return;
            }

            // Начисляем баллы за покупку
            _pointsDiscount.Update(_cartItems);

            // Обновляем отображение
            UpdateDisplay();

            MessageBox.Show("Баллы начислены за покупку", "Баллы обновлены");
        }
    }
}
