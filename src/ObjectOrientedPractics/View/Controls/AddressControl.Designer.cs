namespace ObjectOrientedPractics.View.Controls
{
    partial class AddressControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            IndexTextBox = new TextBox();
            CountryTextBox = new TextBox();
            StreetTextBox = new TextBox();
            BuildingTextBox = new TextBox();
            ApartmentTextBox = new TextBox();
            CityTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(29, 18);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 0;
            label1.Text = "Delivery Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 64);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 1;
            label2.Text = "Post Index:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 99);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 2;
            label3.Text = "Country:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 136);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 3;
            label4.Text = "Street:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 185);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 4;
            label5.Text = "Building:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 185);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 5;
            label6.Text = "Apartment:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(388, 99);
            label7.Name = "label7";
            label7.Size = new Size(46, 25);
            label7.TabIndex = 6;
            label7.Text = "City:";
            // 
            // IndexTextBox
            // 
            IndexTextBox.Location = new Point(133, 61);
            IndexTextBox.Name = "IndexTextBox";
            IndexTextBox.Size = new Size(163, 31);
            IndexTextBox.TabIndex = 7;
            // 
            // CountryTextBox
            // 
            CountryTextBox.Location = new Point(133, 99);
            CountryTextBox.Name = "CountryTextBox";
            CountryTextBox.Size = new Size(222, 31);
            CountryTextBox.TabIndex = 8;
            // 
            // StreetTextBox
            // 
            StreetTextBox.Location = new Point(133, 142);
            StreetTextBox.Name = "StreetTextBox";
            StreetTextBox.Size = new Size(497, 31);
            StreetTextBox.TabIndex = 9;
            // 
            // BuildingTextBox
            // 
            BuildingTextBox.Location = new Point(133, 182);
            BuildingTextBox.Name = "BuildingTextBox";
            BuildingTextBox.Size = new Size(102, 31);
            BuildingTextBox.TabIndex = 10;
            // 
            // ApartmentTextBox
            // 
            ApartmentTextBox.Location = new Point(388, 185);
            ApartmentTextBox.Name = "ApartmentTextBox";
            ApartmentTextBox.Size = new Size(108, 31);
            ApartmentTextBox.TabIndex = 11;
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(440, 99);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(190, 31);
            CityTextBox.TabIndex = 12;
            // 
            // AddressControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CityTextBox);
            Controls.Add(ApartmentTextBox);
            Controls.Add(BuildingTextBox);
            Controls.Add(StreetTextBox);
            Controls.Add(CountryTextBox);
            Controls.Add(IndexTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddressControl";
            Size = new Size(665, 320);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox IndexTextBox;
        private TextBox CountryTextBox;
        private TextBox StreetTextBox;
        private TextBox BuildingTextBox;
        private TextBox ApartmentTextBox;
        private TextBox CityTextBox;
    }
}
