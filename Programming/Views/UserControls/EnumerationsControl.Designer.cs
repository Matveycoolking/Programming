namespace Programming.Views.UserControls
{
    partial class EnumerationsControl
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
            this.EnumValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ValueListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EnumListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnumValue
            // 
            this.EnumValue.BackColor = System.Drawing.Color.White;
            this.EnumValue.Location = new System.Drawing.Point(530, 51);
            this.EnumValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnumValue.Name = "EnumValue";
            this.EnumValue.ReadOnly = true;
            this.EnumValue.Size = new System.Drawing.Size(148, 26);
            this.EnumValue.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Int value:";
            // 
            // ValueListBox
            // 
            this.ValueListBox.FormattingEnabled = true;
            this.ValueListBox.ItemHeight = 20;
            this.ValueListBox.Location = new System.Drawing.Point(280, 51);
            this.ValueListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ValueListBox.Name = "ValueListBox";
            this.ValueListBox.Size = new System.Drawing.Size(206, 304);
            this.ValueListBox.TabIndex = 8;
            this.ValueListBox.SelectedIndexChanged += new System.EventHandler(this.ValueListBox_SelectedIndexChanged);
            this.ValueListBox.SelectedValueChanged += new System.EventHandler(this.ValueListBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Choose value:";
            // 
            // EnumListBox
            // 
            this.EnumListBox.FormattingEnabled = true;
            this.EnumListBox.ItemHeight = 20;
            this.EnumListBox.Items.AddRange(new object[] {
            "Color",
            "FormStudyStudent",
            "Genre",
            "Season",
            "SmartphoneManufacturers",
            "WeekDay"});
            this.EnumListBox.Location = new System.Drawing.Point(21, 51);
            this.EnumListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnumListBox.Name = "EnumListBox";
            this.EnumListBox.Size = new System.Drawing.Size(206, 304);
            this.EnumListBox.TabIndex = 6;
            this.EnumListBox.SelectedIndexChanged += new System.EventHandler(this.EnumListBox_SelectedIndexChanged);
            this.EnumListBox.SelectedValueChanged += new System.EventHandler(this.EnumListBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose enumaration:";
            // 
            // EnumerationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EnumValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValueListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnumListBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EnumerationsControl";
            this.Size = new System.Drawing.Size(696, 374);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EnumValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ValueListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox EnumListBox;
        private System.Windows.Forms.Label label1;
    }
}
