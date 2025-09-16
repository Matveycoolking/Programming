namespace AirPlan.View.usercontrols
{
    partial class MainSong
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
            this.AirplaneInformation = new System.Windows.Forms.GroupBox();
            this.departureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FlyingComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeinFlyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FinalyBox = new System.Windows.Forms.TextBox();
            this.FirstPlaceBox = new System.Windows.Forms.TextBox();
            this.AirplaneInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // AirplaneInformation
            // 
            this.AirplaneInformation.Controls.Add(this.departureDateTimePicker);
            this.AirplaneInformation.Controls.Add(this.label5);
            this.AirplaneInformation.Controls.Add(this.FlyingComboBox);
            this.AirplaneInformation.Controls.Add(this.label4);
            this.AirplaneInformation.Controls.Add(this.TimeinFlyBox);
            this.AirplaneInformation.Controls.Add(this.label3);
            this.AirplaneInformation.Controls.Add(this.label2);
            this.AirplaneInformation.Controls.Add(this.label1);
            this.AirplaneInformation.Controls.Add(this.FinalyBox);
            this.AirplaneInformation.Controls.Add(this.FirstPlaceBox);
            this.AirplaneInformation.Location = new System.Drawing.Point(83, 54);
            this.AirplaneInformation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AirplaneInformation.Name = "AirplaneInformation";
            this.AirplaneInformation.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AirplaneInformation.Size = new System.Drawing.Size(549, 443);
            this.AirplaneInformation.TabIndex = 6;
            this.AirplaneInformation.TabStop = false;
            this.AirplaneInformation.Text = "Airplane Information";
            // 
            // departureDateTimePicker
            // 
            this.departureDateTimePicker.Location = new System.Drawing.Point(177, 144);
            this.departureDateTimePicker.Name = "departureDateTimePicker";
            this.departureDateTimePicker.Size = new System.Drawing.Size(305, 26);
            this.departureDateTimePicker.TabIndex = 22;
            this.departureDateTimePicker.ValueChanged += new System.EventHandler(this.departureDateTimePicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Type flying";
            // 
            // FlyingComboBox
            // 
            this.FlyingComboBox.FormattingEnabled = true;
            this.FlyingComboBox.Items.AddRange(new object[] {
            "international",
            "domestic"});
            this.FlyingComboBox.Location = new System.Drawing.Point(177, 242);
            this.FlyingComboBox.Name = "FlyingComboBox";
            this.FlyingComboBox.Size = new System.Drawing.Size(305, 28);
            this.FlyingComboBox.TabIndex = 20;
            this.FlyingComboBox.SelectedIndexChanged += new System.EventHandler(this.FlyingComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Time in fly";
            // 
            // TimeinFlyBox
            // 
            this.TimeinFlyBox.Location = new System.Drawing.Point(177, 190);
            this.TimeinFlyBox.Name = "TimeinFlyBox";
            this.TimeinFlyBox.Size = new System.Drawing.Size(305, 26);
            this.TimeinFlyBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Time start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Finaly place";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "First Place";
            // 
            // FinalyBox
            // 
            this.FinalyBox.Location = new System.Drawing.Point(177, 94);
            this.FinalyBox.Name = "FinalyBox";
            this.FinalyBox.Size = new System.Drawing.Size(305, 26);
            this.FinalyBox.TabIndex = 13;
            // 
            // FirstPlaceBox
            // 
            this.FirstPlaceBox.BackColor = System.Drawing.Color.White;
            this.FirstPlaceBox.Location = new System.Drawing.Point(177, 46);
            this.FirstPlaceBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FirstPlaceBox.Name = "FirstPlaceBox";
            this.FirstPlaceBox.ReadOnly = true;
            this.FirstPlaceBox.Size = new System.Drawing.Size(305, 26);
            this.FirstPlaceBox.TabIndex = 12;
            this.FirstPlaceBox.TextChanged += new System.EventHandler(this.FirstPlaceBox_TextChanged);
            // 
            // MainSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AirplaneInformation);
            this.Name = "MainSong";
            this.Size = new System.Drawing.Size(745, 658);
            this.AirplaneInformation.ResumeLayout(false);
            this.AirplaneInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AirplaneInformation;
        private System.Windows.Forms.DateTimePicker departureDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox FlyingComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TimeinFlyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FinalyBox;
        private System.Windows.Forms.TextBox FirstPlaceBox;
    }
}
