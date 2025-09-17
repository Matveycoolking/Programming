namespace ObjectOrientedPractics.View.Tabs
{
    partial class CustomersTab
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
            Customerlabel = new Label();
            CustomerslistBox = new ListBox();
            AddbuttonC = new Button();
            Removebuttonc = new Button();
            SelectedCustomerlabel = new Label();
            Idlabelc = new Label();
            FullNamelabelc = new Label();
            Addresslabelc = new Label();
            IdtextBoxc = new TextBox();
            FullNametextBoxc = new TextBox();
            AddresstextBoxc = new TextBox();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // Customerlabel
            // 
            Customerlabel.AutoSize = true;
            Customerlabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Customerlabel.Location = new Point(39, 32);
            Customerlabel.Name = "Customerlabel";
            Customerlabel.Size = new Size(101, 25);
            Customerlabel.TabIndex = 0;
            Customerlabel.Text = "Customers";
            // 
            // CustomerslistBox
            // 
            CustomerslistBox.FormattingEnabled = true;
            CustomerslistBox.Location = new Point(39, 60);
            CustomerslistBox.Name = "CustomerslistBox";
            CustomerslistBox.Size = new Size(286, 479);
            CustomerslistBox.TabIndex = 1;
            CustomerslistBox.SelectedIndexChanged += CustomerslistBox_SelectedIndexChanged;
            // 
            // AddbuttonC
            // 
            AddbuttonC.Location = new Point(39, 571);
            AddbuttonC.Name = "AddbuttonC";
            AddbuttonC.Size = new Size(112, 34);
            AddbuttonC.TabIndex = 2;
            AddbuttonC.Text = "Add";
            AddbuttonC.UseVisualStyleBackColor = true;
            AddbuttonC.Click += AddbuttonC_Click;
            // 
            // Removebuttonc
            // 
            Removebuttonc.Location = new Point(173, 571);
            Removebuttonc.Name = "Removebuttonc";
            Removebuttonc.Size = new Size(112, 34);
            Removebuttonc.TabIndex = 3;
            Removebuttonc.Text = "Remove";
            Removebuttonc.UseVisualStyleBackColor = true;
            Removebuttonc.Click += Removebuttonc_Click;
            // 
            // SelectedCustomerlabel
            // 
            SelectedCustomerlabel.AutoSize = true;
            SelectedCustomerlabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SelectedCustomerlabel.Location = new Point(434, 32);
            SelectedCustomerlabel.Name = "SelectedCustomerlabel";
            SelectedCustomerlabel.Size = new Size(170, 25);
            SelectedCustomerlabel.TabIndex = 4;
            SelectedCustomerlabel.Text = "Selected Customer";
            // 
            // Idlabelc
            // 
            Idlabelc.AutoSize = true;
            Idlabelc.Location = new Point(418, 78);
            Idlabelc.Name = "Idlabelc";
            Idlabelc.Size = new Size(34, 25);
            Idlabelc.TabIndex = 5;
            Idlabelc.Text = "ID:";
            // 
            // FullNamelabelc
            // 
            FullNamelabelc.AutoSize = true;
            FullNamelabelc.Location = new Point(421, 123);
            FullNamelabelc.Name = "FullNamelabelc";
            FullNamelabelc.Size = new Size(95, 25);
            FullNamelabelc.TabIndex = 6;
            FullNamelabelc.Text = "Full Name:";
            // 
            // Addresslabelc
            // 
            Addresslabelc.AutoSize = true;
            Addresslabelc.Location = new Point(418, 167);
            Addresslabelc.Name = "Addresslabelc";
            Addresslabelc.Size = new Size(81, 25);
            Addresslabelc.TabIndex = 7;
            Addresslabelc.Text = "Address:";
            // 
            // IdtextBoxc
            // 
            IdtextBoxc.Location = new Point(515, 78);
            IdtextBoxc.Name = "IdtextBoxc";
            IdtextBoxc.ReadOnly = true;
            IdtextBoxc.Size = new Size(252, 31);
            IdtextBoxc.TabIndex = 8;
            // 
            // FullNametextBoxc
            // 
            FullNametextBoxc.Location = new Point(522, 123);
            FullNametextBoxc.Name = "FullNametextBoxc";
            FullNametextBoxc.Size = new Size(529, 31);
            FullNametextBoxc.TabIndex = 9;
            // 
            // AddresstextBoxc
            // 
            AddresstextBoxc.Location = new Point(522, 167);
            AddresstextBoxc.Multiline = true;
            AddresstextBoxc.Name = "AddresstextBoxc";
            AddresstextBoxc.Size = new Size(529, 130);
            AddresstextBoxc.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Location = new Point(376, 290);
            panel2.Name = "panel2";
            panel2.Size = new Size(675, 315);
            panel2.TabIndex = 11;
            panel2.Paint += panel2_Paint;
            // 
            // CustomersTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(AddresstextBoxc);
            Controls.Add(FullNametextBoxc);
            Controls.Add(IdtextBoxc);
            Controls.Add(Addresslabelc);
            Controls.Add(FullNamelabelc);
            Controls.Add(Idlabelc);
            Controls.Add(SelectedCustomerlabel);
            Controls.Add(Removebuttonc);
            Controls.Add(AddbuttonC);
            Controls.Add(CustomerslistBox);
            Controls.Add(Customerlabel);
            Name = "CustomersTab";
            Size = new Size(1068, 616);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Customerlabel;
        private ListBox CustomerslistBox;
        private Button AddbuttonC;
        private Button Removebuttonc;
        private Label SelectedCustomerlabel;
        private Label Idlabelc;
        private Label FullNamelabelc;
        private Label Addresslabelc;
        private TextBox IdtextBoxc;
        private TextBox FullNametextBoxc;
        private TextBox AddresstextBoxc;
        private Panel panel2;
    }
}
