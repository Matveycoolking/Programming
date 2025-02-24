using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Choose_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// добавляет элементы в листбокс
        /// </summary>
        /// <param name="enumType">сами элементы</param>
        void AddToValues(Type enumType)
        {
            VaulueListBox.Items.Clear();
            Array array = Enum.GetValues(enumType);
            foreach (var element in array)
            {
                VaulueListBox.Items.Add(element);
            }
        }
        private void EnumListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
