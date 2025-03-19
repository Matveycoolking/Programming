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
            this.FilmBox4 = new System.Windows.Forms.GroupBox();
            this.FindFilmButton = new System.Windows.Forms.Button();
            this.AddFilmBox = new System.Windows.Forms.Button();
            this.Duration = new System.Windows.Forms.Label();
            this.DurabiltyBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RatingBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.YearBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FilmBox = new System.Windows.Forms.ListBox();
            this.GenerateReactArray = new System.Windows.Forms.Button();
            this.CountOfRectangle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FindMaxbutton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.ColorBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.W = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.Height = new System.Windows.Forms.Label();
            this.ListOfRectangles = new System.Windows.Forms.ListBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.GenreBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.FilmBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.FilmBox4);
            this.tabPage2.Controls.Add(this.GenerateReactArray);
            this.tabPage2.Controls.Add(this.CountOfRectangle);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(897, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Classes";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // FilmBox4
            // 
            this.FilmBox4.Controls.Add(this.FindFilmButton);
            this.FilmBox4.Controls.Add(this.AddFilmBox);
            this.FilmBox4.Controls.Add(this.Duration);
            this.FilmBox4.Controls.Add(this.DurabiltyBox);
            this.FilmBox4.Controls.Add(this.label9);
            this.FilmBox4.Controls.Add(this.RatingBox);
            this.FilmBox4.Controls.Add(this.label8);
            this.FilmBox4.Controls.Add(this.NameBox);
            this.FilmBox4.Controls.Add(this.label7);
            this.FilmBox4.Controls.Add(this.YearBox);
            this.FilmBox4.Controls.Add(this.label6);
            this.FilmBox4.Controls.Add(this.textBox1);
            this.FilmBox4.Controls.Add(this.GenreBox);
            this.FilmBox4.Controls.Add(this.FilmBox);
            this.FilmBox4.Location = new System.Drawing.Point(511, 186);
            this.FilmBox4.Name = "FilmBox4";
            this.FilmBox4.Size = new System.Drawing.Size(428, 272);
            this.FilmBox4.TabIndex = 10;
            this.FilmBox4.TabStop = false;
            this.FilmBox4.Text = "Film";
            this.FilmBox4.Enter += new System.EventHandler(this.FilmBox4_Enter);
            // 
            // FindFilmButton
            // 
            this.FindFilmButton.Location = new System.Drawing.Point(31, 233);
            this.FindFilmButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FindFilmButton.Name = "FindFilmButton";
            this.FindFilmButton.Size = new System.Drawing.Size(112, 38);
            this.FindFilmButton.TabIndex = 17;
            this.FindFilmButton.Text = "Find";
            this.FindFilmButton.UseVisualStyleBackColor = true;
            this.FindFilmButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddFilmBox
            // 
            this.AddFilmBox.Location = new System.Drawing.Point(31, 188);
            this.AddFilmBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddFilmBox.Name = "AddFilmBox";
            this.AddFilmBox.Size = new System.Drawing.Size(112, 35);
            this.AddFilmBox.TabIndex = 16;
            this.AddFilmBox.Text = "Add";
            this.AddFilmBox.UseVisualStyleBackColor = true;
            this.AddFilmBox.Click += new System.EventHandler(this.AddFilmBox_Click);
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Location = new System.Drawing.Point(300, 217);
            this.Duration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(70, 20);
            this.Duration.TabIndex = 15;
            this.Duration.Text = "Duration";
            // 
            // DurabiltyBox
            // 
            this.DurabiltyBox.Location = new System.Drawing.Point(175, 214);
            this.DurabiltyBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DurabiltyBox.Name = "DurabiltyBox";
            this.DurabiltyBox.Size = new System.Drawing.Size(117, 26);
            this.DurabiltyBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Rating";
            // 
            // RatingBox
            // 
            this.RatingBox.Location = new System.Drawing.Point(175, 178);
            this.RatingBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RatingBox.Name = "RatingBox";
            this.RatingBox.Size = new System.Drawing.Size(117, 26);
            this.RatingBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(175, 142);
            this.NameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(117, 26);
            this.NameBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Year";
            // 
            // YearBox
            // 
            this.YearBox.Location = new System.Drawing.Point(175, 106);
            this.YearBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(117, 26);
            this.YearBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Genre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 26);
            this.textBox1.TabIndex = 2;
            // 
            // FilmBox
            // 
            this.FilmBox.FormattingEnabled = true;
            this.FilmBox.ItemHeight = 20;
            this.FilmBox.Location = new System.Drawing.Point(22, 56);
            this.FilmBox.Name = "FilmBox";
            this.FilmBox.Size = new System.Drawing.Size(132, 124);
            this.FilmBox.TabIndex = 0;
            // 
            // GenerateReactArray
            // 
            this.GenerateReactArray.Location = new System.Drawing.Point(475, 105);
            this.GenerateReactArray.Name = "GenerateReactArray";
            this.GenerateReactArray.Size = new System.Drawing.Size(124, 30);
            this.GenerateReactArray.TabIndex = 9;
            this.GenerateReactArray.Text = "Generate";
            this.GenerateReactArray.UseVisualStyleBackColor = true;
            this.GenerateReactArray.Click += new System.EventHandler(this.GenerateReactArray_Click);
            // 
            // CountOfRectangle
            // 
            this.CountOfRectangle.Location = new System.Drawing.Point(475, 62);
            this.CountOfRectangle.Name = "CountOfRectangle";
            this.CountOfRectangle.Size = new System.Drawing.Size(127, 26);
            this.CountOfRectangle.TabIndex = 9;
            this.CountOfRectangle.TextChanged += new System.EventHandler(this.CountOfRectangle_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Generate Rectangles";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FindMaxbutton);
            this.groupBox3.Controls.Add(this.AcceptButton);
            this.groupBox3.Controls.Add(this.ColorBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.WidthBox);
            this.groupBox3.Controls.Add(this.W);
            this.groupBox3.Controls.Add(this.HeightBox);
            this.groupBox3.Controls.Add(this.Height);
            this.groupBox3.Controls.Add(this.ListOfRectangles);
            this.groupBox3.Location = new System.Drawing.Point(6, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 361);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ListOfRectangles";
            // 
            // FindMaxbutton
            // 
            this.FindMaxbutton.Location = new System.Drawing.Point(235, 309);
            this.FindMaxbutton.Name = "FindMaxbutton";
            this.FindMaxbutton.Size = new System.Drawing.Size(137, 30);
            this.FindMaxbutton.TabIndex = 8;
            this.FindMaxbutton.Text = "Find Max Width";
            this.FindMaxbutton.UseVisualStyleBackColor = true;
            this.FindMaxbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(235, 260);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(137, 30);
            this.AcceptButton.TabIndex = 7;
            this.AcceptButton.Text = "Change Params";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(235, 219);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(100, 26);
            this.ColorBox.TabIndex = 6;
            this.ColorBox.TextChanged += new System.EventHandler(this.ColorBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Color";
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(235, 144);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(100, 26);
            this.WidthBox.TabIndex = 4;
            this.WidthBox.TextChanged += new System.EventHandler(this.WidthBox_TextChanged);
            // 
            // W
            // 
            this.W.AutoSize = true;
            this.W.Location = new System.Drawing.Point(237, 111);
            this.W.Name = "W";
            this.W.Size = new System.Drawing.Size(54, 20);
            this.W.TabIndex = 3;
            this.W.Text = "Width:";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(235, 66);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(100, 26);
            this.HeightBox.TabIndex = 2;
            this.HeightBox.TextChanged += new System.EventHandler(this.HeightBox_TextChanged);
            // 
            // Height
            // 
            this.Height.AutoSize = true;
            this.Height.Location = new System.Drawing.Point(231, 42);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(60, 20);
            this.Height.TabIndex = 1;
            this.Height.Text = "Height:";
            // 
            // ListOfRectangles
            // 
            this.ListOfRectangles.FormattingEnabled = true;
            this.ListOfRectangles.ItemHeight = 20;
            this.ListOfRectangles.Location = new System.Drawing.Point(6, 42);
            this.ListOfRectangles.Name = "ListOfRectangles";
            this.ListOfRectangles.Size = new System.Drawing.Size(179, 204);
            this.ListOfRectangles.TabIndex = 0;
            this.ListOfRectangles.SelectedIndexChanged += new System.EventHandler(this.ListOfRectangles_SelectedIndexChanged);
            // 
            // GenreBox
            // 
            this.GenreBox.FormattingEnabled = true;
            this.GenreBox.Items.AddRange(new object[] {
            "BlockBuster",
            "Comedy",
            "Thriller",
            "Drama",
            "Action"});
            this.GenreBox.Location = new System.Drawing.Point(175, 25);
            this.GenreBox.Name = "GenreBox";
            this.GenreBox.Size = new System.Drawing.Size(205, 28);
            this.GenreBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 630);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.FilmBox4.ResumeLayout(false);
            this.FilmBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Height;
        private System.Windows.Forms.ListBox ListOfRectangles;
        private System.Windows.Forms.TextBox ColorBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.Label W;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Button FindMaxbutton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox FilmBox4;
        private System.Windows.Forms.ListBox FilmBox;
        private System.Windows.Forms.Button GenerateReactArray;
        private System.Windows.Forms.TextBox CountOfRectangle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox DurabiltyBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RatingBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox YearBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button FindFilmButton;
        private System.Windows.Forms.Button AddFilmBox;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.ComboBox GenreBox;
    }
}

