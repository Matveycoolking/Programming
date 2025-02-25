namespace Programming
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SeasoncomboBox1 = new System.Windows.Forms.ComboBox();
            this.SeasonButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextOfTheDay = new System.Windows.Forms.Label();
            this.ParseButton = new System.Windows.Forms.Button();
            this.ParseBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lable1 = new System.Windows.Forms.Label();
            this.VaulueListBox = new System.Windows.Forms.ListBox();
            this.EnumListbox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ValueBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Lable1);
            this.tabPage1.Controls.Add(this.VaulueListBox);
            this.tabPage1.Controls.Add(this.EnumListbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(897, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enums";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SeasoncomboBox1);
            this.groupBox2.Controls.Add(this.SeasonButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(361, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 170);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Season Handle";
            // 
            // SeasoncomboBox1
            // 
            this.SeasoncomboBox1.FormattingEnabled = true;
            this.SeasoncomboBox1.Items.AddRange(new object[] {
            "Spring",
            "Autumm",
            "Winter",
            "Summer"});
            this.SeasoncomboBox1.Location = new System.Drawing.Point(0, 58);
            this.SeasoncomboBox1.Name = "SeasoncomboBox1";
            this.SeasoncomboBox1.Size = new System.Drawing.Size(192, 28);
            this.SeasoncomboBox1.TabIndex = 3;
            this.SeasoncomboBox1.SelectedIndexChanged += new System.EventHandler(this.SeasoncomboBox1_SelectedIndexChanged);
            // 
            // SeasonButton
            // 
            this.SeasonButton.Location = new System.Drawing.Point(211, 45);
            this.SeasonButton.Name = "SeasonButton";
            this.SeasonButton.Size = new System.Drawing.Size(106, 39);
            this.SeasonButton.TabIndex = 2;
            this.SeasonButton.Text = "Go";
            this.SeasonButton.UseVisualStyleBackColor = true;
            this.SeasonButton.Click += new System.EventHandler(this.SeasonButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choose Season";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextOfTheDay);
            this.groupBox1.Controls.Add(this.ParseButton);
            this.groupBox1.Controls.Add(this.ParseBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 161);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weekday";
            // 
            // TextOfTheDay
            // 
            this.TextOfTheDay.AutoSize = true;
            this.TextOfTheDay.Location = new System.Drawing.Point(6, 102);
            this.TextOfTheDay.Name = "TextOfTheDay";
            this.TextOfTheDay.Size = new System.Drawing.Size(37, 20);
            this.TextOfTheDay.TabIndex = 8;
            this.TextOfTheDay.Text = "Day";
            this.TextOfTheDay.Click += new System.EventHandler(this.label3_Click);
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(178, 45);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(93, 39);
            this.ParseButton.TabIndex = 7;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // ParseBox
            // 
            this.ParseBox.Location = new System.Drawing.Point(10, 58);
            this.ParseBox.Name = "ParseBox";
            this.ParseBox.Size = new System.Drawing.Size(147, 26);
            this.ParseBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type value for parsing";
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(375, 38);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(168, 26);
            this.ValueBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Value:";
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(3, 27);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(161, 20);
            this.Lable1.TabIndex = 2;
            this.Lable1.Text = "Choose enumaration:";
            this.Lable1.Click += new System.EventHandler(this.Choose_Click);
            // 
            // VaulueListBox
            // 
            this.VaulueListBox.FormattingEnabled = true;
            this.VaulueListBox.ItemHeight = 20;
            this.VaulueListBox.Location = new System.Drawing.Point(185, 50);
            this.VaulueListBox.Name = "VaulueListBox";
            this.VaulueListBox.Size = new System.Drawing.Size(126, 124);
            this.VaulueListBox.TabIndex = 1;
            this.VaulueListBox.SelectedIndexChanged += new System.EventHandler(this.VaulueListBox_SelectedIndexChanged);
            // 
            // EnumListbox
            // 
            this.EnumListbox.FormattingEnabled = true;
            this.EnumListbox.ItemHeight = 20;
            this.EnumListbox.Items.AddRange(new object[] {
            "Colors",
            "Genre",
            "Eduaction",
            "TimeOfYear",
            "WeekDay",
            "TypeOfSmartphone"});
            this.EnumListbox.Location = new System.Drawing.Point(6, 50);
            this.EnumListbox.Name = "EnumListbox";
            this.EnumListbox.Size = new System.Drawing.Size(139, 124);
            this.EnumListbox.TabIndex = 0;
            this.EnumListbox.SelectedIndexChanged += new System.EventHandler(this.EnumListbox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(897, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 525);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox EnumListbox;
        private System.Windows.Forms.Label Lable1;
        private System.Windows.Forms.ListBox VaulueListBox;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ParseButton;
        private System.Windows.Forms.TextBox ParseBox;
        private System.Windows.Forms.Label TextOfTheDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SeasonButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SeasoncomboBox1;
    }
}

