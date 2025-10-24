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
            IdtextBoxc = new TextBox();
            FullNametextBoxc = new TextBox();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            IsPriorityCheckBox = new CheckBox();
            panel5 = new Panel();
            addressControl1 = new ObjectOrientedPractics.View.Controls.AddressControl();
            panel4 = new Panel();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // Customerlabel
            // 
            Customerlabel.AutoSize = true;
            Customerlabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Customerlabel.Location = new Point(3, 0);
            Customerlabel.Name = "Customerlabel";
            Customerlabel.Size = new Size(101, 25);
            Customerlabel.TabIndex = 0;
            Customerlabel.Text = "Customers";
            // 
            // CustomerslistBox
            // 
            CustomerslistBox.Dock = DockStyle.Fill;
            CustomerslistBox.FormattingEnabled = true;
            CustomerslistBox.Location = new Point(3, 36);
            CustomerslistBox.Name = "CustomerslistBox";
            CustomerslistBox.Size = new Size(330, 530);
            CustomerslistBox.TabIndex = 1;
            CustomerslistBox.SelectedIndexChanged += CustomerslistBox_SelectedIndexChanged_1;
            // 
            // AddbuttonC
            // 
            AddbuttonC.Location = new Point(3, 3);
            AddbuttonC.Name = "AddbuttonC";
            AddbuttonC.Size = new Size(133, 33);
            AddbuttonC.TabIndex = 2;
            AddbuttonC.Text = "Add";
            AddbuttonC.UseVisualStyleBackColor = true;
            AddbuttonC.Click += AddbuttonC_Click_1;
            // 
            // Removebuttonc
            // 
            Removebuttonc.Location = new Point(142, 3);
            Removebuttonc.Name = "Removebuttonc";
            Removebuttonc.Size = new Size(142, 36);
            Removebuttonc.TabIndex = 3;
            Removebuttonc.Text = "Remove";
            Removebuttonc.UseVisualStyleBackColor = true;
            Removebuttonc.Click += Removebuttonc_Click_1;
            // 
            // SelectedCustomerlabel
            // 
            SelectedCustomerlabel.AutoSize = true;
            SelectedCustomerlabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SelectedCustomerlabel.Location = new Point(339, 0);
            SelectedCustomerlabel.Name = "SelectedCustomerlabel";
            SelectedCustomerlabel.Size = new Size(170, 25);
            SelectedCustomerlabel.TabIndex = 4;
            SelectedCustomerlabel.Text = "Selected Customer";
            // 
            // Idlabelc
            // 
            Idlabelc.AutoSize = true;
            Idlabelc.Location = new Point(21, 18);
            Idlabelc.Name = "Idlabelc";
            Idlabelc.Size = new Size(34, 25);
            Idlabelc.TabIndex = 5;
            Idlabelc.Text = "ID:";
            // 
            // FullNamelabelc
            // 
            FullNamelabelc.AutoSize = true;
            FullNamelabelc.Location = new Point(21, 63);
            FullNamelabelc.Name = "FullNamelabelc";
            FullNamelabelc.Size = new Size(95, 25);
            FullNamelabelc.TabIndex = 6;
            FullNamelabelc.Text = "Full Name:";
            // 
            // IdtextBoxc
            // 
            IdtextBoxc.Location = new Point(132, 18);
            IdtextBoxc.Name = "IdtextBoxc";
            IdtextBoxc.ReadOnly = true;
            IdtextBoxc.Size = new Size(195, 31);
            IdtextBoxc.TabIndex = 8;
            // 
            // FullNametextBoxc
            // 
            FullNametextBoxc.Dock = DockStyle.Fill;
            FullNametextBoxc.Location = new Point(0, 0);
            FullNametextBoxc.Name = "FullNametextBoxc";
            FullNametextBoxc.Size = new Size(581, 31);
            FullNametextBoxc.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(AddbuttonC);
            panel2.Controls.Add(Removebuttonc);
            panel2.Location = new Point(3, 572);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 39);
            panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.4606743F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.53933F));
            tableLayoutPanel1.Controls.Add(Customerlabel, 0, 0);
            tableLayoutPanel1.Controls.Add(SelectedCustomerlabel, 1, 0);
            tableLayoutPanel1.Controls.Add(CustomerslistBox, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(splitContainer1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.9130435F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.08696F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.Size = new Size(1068, 616);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(339, 36);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Size = new Size(726, 530);
            splitContainer1.SplitterDistance = 429;
            splitContainer1.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Controls.Add(IsPriorityCheckBox);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(FullNamelabelc);
            panel1.Controls.Add(Idlabelc);
            panel1.Controls.Add(IdtextBoxc);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(726, 429);
            panel1.TabIndex = 13;
            // 
            // IsPriorityCheckBox
            // 
            IsPriorityCheckBox.AutoSize = true;
            IsPriorityCheckBox.Location = new Point(21, 114);
            IsPriorityCheckBox.Name = "IsPriorityCheckBox";
            IsPriorityCheckBox.Size = new Size(113, 29);
            IsPriorityCheckBox.TabIndex = 14;
            IsPriorityCheckBox.Text = "Is priority";
            IsPriorityCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(addressControl1);
            panel5.Location = new Point(9, 149);
            panel5.Name = "panel5";
            panel5.Size = new Size(714, 359);
            panel5.TabIndex = 13;
            // 
            // addressControl1
            // 
            addressControl1.AutoValidate = AutoValidate.Disable;
            addressControl1.Dock = DockStyle.Fill;
            addressControl1.Location = new Point(0, 0);
            addressControl1.Name = "addressControl1";
            addressControl1.Size = new Size(714, 359);
            addressControl1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(FullNametextBoxc);
            panel4.Location = new Point(125, 63);
            panel4.Name = "panel4";
            panel4.Size = new Size(581, 38);
            panel4.TabIndex = 12;
            // 
            // CustomersTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "CustomersTab";
            Size = new Size(1068, 616);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label Customerlabel;
        private ListBox CustomerslistBox;
        private Button AddbuttonC;
        private Button Removebuttonc;
        private Label SelectedCustomerlabel;
        private Label Idlabelc;
        private Label FullNamelabelc;
        private TextBox IdtextBoxc;
        private TextBox FullNametextBoxc;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel4;
        private SplitContainer splitContainer1;
        private Controls.AddressControl addressControl1;
        private Panel panel5;
        private CheckBox IsPriorityCheckBox;
    }
}
