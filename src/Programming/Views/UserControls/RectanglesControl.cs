using Programming.Models;
using Programming.Models.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = Programming.Models.Rectangle;

namespace Programming.Views.UserControls
{
    public partial class RectanglesControl : UserControl
    {
        private Rectangle _currentRectangle;
        public RectanglesControl()
        {
            InitializeComponent();
            RectanglesBox.DataSource = Rectangle.Rectangles;
        }
       /// <summary>
       /// выбранный индекс
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void RectanglesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _currentRectangle = RectanglesBox.SelectedItem as Rectangle;
                UpdatePropertyTextBox();
            }
            catch
            {
            }
            
        }
       /// <summary>
       /// повтор текст боксов
       /// </summary>
        private void UpdatePropertyTextBox()
        {
            if (RectanglesBox.SelectedItem != null)
            {
                UpdateRectangleInfo(_currentRectangle);
            }
            else
            {
                ClearRectangleInfo();
            }

        }
       /// <summary>
       /// повторение информации об прямоугольниках
       /// </summary>
       /// <param name="rectangle"></param>
        private void UpdateRectangleInfo(Rectangle rectangle)
        {
            WidthTextBox.Text = _currentRectangle.Width.ToString();
            LenghtTextBox.Text = _currentRectangle.Height.ToString();
            ColorTextBox.Text = _currentRectangle.Color.ToString();
            XTextBox.Text = _currentRectangle.Center.X.ToString();
            YTextBox.Text = _currentRectangle.Center.Y.ToString();
            IdTextBox.Text = _currentRectangle.Id.ToString();
        }
        /// <summary>
        /// обнуление информации об прямоугольниках
        /// </summary>
        private void ClearRectangleInfo()
        {
            WidthTextBox.Text = string.Empty;
            LenghtTextBox.Text = string.Empty;
            ColorTextBox.Text = string.Empty;
            XTextBox.Text = string.Empty;
            YTextBox.Text = string.Empty;
            IdTextBox.Text = string.Empty;
        }
       /// <summary>
       /// изменен ие длинны текстбоксов
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void LenghtTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (RectanglesBox.SelectedItem as Rectangle).Height = Convert.ToInt32(LenghtTextBox.Text);
                LenghtTextBox.BackColor = AppColors.BaseInput;

            }
            catch
            {
                LenghtTextBox.BackColor = AppColors.ErrorInput;
            }
        }
        /// <summary>
        /// изменение ширины текстбокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (RectanglesBox.SelectedItem as Rectangle).Width = Convert.ToInt32(WidthTextBox.Text);
                WidthTextBox.BackColor = AppColors.BaseInput;

            }
            catch
            {
                WidthTextBox.BackColor = AppColors.ErrorInput;
            }
        }
        /// <summary>
        /// изменение цвета текстбокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Models.Enums.Color)Enum.Parse(typeof(Models.Enums.Color), ColorTextBox.Text) != null)
                {
                    (RectanglesBox.SelectedItem as Rectangle).Color = ColorTextBox.Text;
                    ColorTextBox.BackColor = AppColors.BaseInput;
                }
            }
            catch
            {
                ColorTextBox.BackColor = AppColors.ErrorInput;
            }
        }
       /// <summary>
       /// нахождение максимальной длины ширины прямоугольника
       /// </summary>
       /// <param name="Rectangles"></param>
       /// <returns></returns>
        private int FindRectangleWithMaxWidth(List<Rectangle> Rectangles)
        {
            double maxWidth = 0;
            int Index = 0;
            for (int i = 0; i < Rectangles.Count; i++)
            {
                if (Rectangles[i].Width > maxWidth)
                {
                    maxWidth = Rectangles[i].Width;
                    Index = i;
                }
            }
            return Index;
        }
       /// <summary>
       /// нахождение прямоугольника
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void FindRectangleButton_Click(object sender, EventArgs e)
        {
            RectanglesBox.SelectedIndex = FindRectangleWithMaxWidth(Rectangle.Rectangles);
            _currentRectangle = RectanglesBox.SelectedItem as Rectangle;
        }
        /// <summary>
        /// вставить дату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputData(object sender, KeyPressEventArgs e)
        {
            Validator.InterdictionInputData(sender, e);
        }
    }
}
