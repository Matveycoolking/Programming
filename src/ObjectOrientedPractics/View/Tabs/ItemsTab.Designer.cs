namespace ObjectOrientedPractics.View.Tabs
{
    partial class ItemsTab
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
            SelectedItemLabel = new Label();
            Idlabel = new Label();
            Costlabel = new Label();
            IdtextBox = new TextBox();
            CosttextBox = new TextBox();
            NametextBox = new TextBox();
            DescriptiontextBox = new TextBox();
            Namelabel = new Label();
            Descriptionlabel = new Label();
            ItemsLabel = new Label();
            ItemsListBox = new ListBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            RemoveButton = new Button();
            panel6 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            AddButton = new Button();
            panel4 = new Panel();
            panel9 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // SelectedItemLabel
            // 
            SelectedItemLabel.AutoSize = true;
            SelectedItemLabel.BackColor = SystemColors.Control;
            SelectedItemLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SelectedItemLabel.Location = new Point(460, 0);
            SelectedItemLabel.Name = "SelectedItemLabel";
            SelectedItemLabel.Size = new Size(128, 24);
            SelectedItemLabel.TabIndex = 4;
            SelectedItemLabel.Text = "Selected Item";
            // 
            // Idlabel
            // 
            Idlabel.AutoSize = true;
            Idlabel.Location = new Point(21, 18);
            Idlabel.Name = "Idlabel";
            Idlabel.Size = new Size(34, 25);
            Idlabel.TabIndex = 5;
            Idlabel.Text = "ID:";
            // 
            // Costlabel
            // 
            Costlabel.AutoSize = true;
            Costlabel.Location = new Point(18, 59);
            Costlabel.Name = "Costlabel";
            Costlabel.Size = new Size(52, 25);
            Costlabel.TabIndex = 6;
            Costlabel.Text = "Cost:";
            // 
            // IdtextBox
            // 
            IdtextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            IdtextBox.Location = new Point(0, 0);
            IdtextBox.Name = "IdtextBox";
            IdtextBox.ReadOnly = true;
            IdtextBox.Size = new Size(206, 31);
            IdtextBox.TabIndex = 7;
            // 
            // CosttextBox
            // 
            CosttextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CosttextBox.Location = new Point(0, 0);
            CosttextBox.Name = "CosttextBox";
            CosttextBox.Size = new Size(206, 31);
            CosttextBox.TabIndex = 8;
            // 
            // NametextBox
            // 
            NametextBox.Dock = DockStyle.Fill;
            NametextBox.Location = new Point(0, 0);
            NametextBox.Multiline = true;
            NametextBox.Name = "NametextBox";
            NametextBox.Size = new Size(406, 93);
            NametextBox.TabIndex = 9;
            // 
            // DescriptiontextBox
            // 
            DescriptiontextBox.Dock = DockStyle.Fill;
            DescriptiontextBox.Location = new Point(0, 0);
            DescriptiontextBox.Multiline = true;
            DescriptiontextBox.Name = "DescriptiontextBox";
            DescriptiontextBox.Size = new Size(406, 100);
            DescriptiontextBox.TabIndex = 10;
            // 
            // Namelabel
            // 
            Namelabel.AutoSize = true;
            Namelabel.Location = new Point(21, 104);
            Namelabel.Name = "Namelabel";
            Namelabel.Size = new Size(63, 25);
            Namelabel.TabIndex = 11;
            Namelabel.Text = "Name:";
            // 
            // Descriptionlabel
            // 
            Descriptionlabel.AutoSize = true;
            Descriptionlabel.Location = new Point(18, 240);
            Descriptionlabel.Name = "Descriptionlabel";
            Descriptionlabel.Size = new Size(106, 25);
            Descriptionlabel.TabIndex = 12;
            Descriptionlabel.Text = "Description:";
            // 
            // ItemsLabel
            // 
            ItemsLabel.AutoSize = true;
            ItemsLabel.BackColor = SystemColors.Control;
            ItemsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ItemsLabel.Location = new Point(3, 0);
            ItemsLabel.Name = "ItemsLabel";
            ItemsLabel.Size = new Size(59, 24);
            ItemsLabel.TabIndex = 1;
            ItemsLabel.Text = "Items";
            // 
            // ItemsListBox
            // 
            ItemsListBox.Dock = DockStyle.Fill;
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(0, 0);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(451, 459);
            ItemsListBox.TabIndex = 0;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(915, 560);
            panel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(SelectedItemLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(ItemsLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(panel9, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.058366F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.9416351F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(915, 560);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(ItemsListBox);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(451, 459);
            panel2.TabIndex = 21;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(148, 3);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(141, 41);
            RemoveButton.TabIndex = 3;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.Controls.Add(Namelabel);
            panel6.Controls.Add(Idlabel);
            panel6.Controls.Add(Costlabel);
            panel6.Controls.Add(Descriptionlabel);
            panel6.Controls.Add(panel3);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(460, 27);
            panel6.Name = "panel6";
            panel6.Size = new Size(452, 459);
            panel6.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(IdtextBox);
            panel3.Location = new Point(76, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(206, 38);
            panel3.TabIndex = 17;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(CosttextBox);
            panel5.Location = new Point(76, 59);
            panel5.Name = "panel5";
            panel5.Size = new Size(206, 37);
            panel5.TabIndex = 18;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(NametextBox);
            panel7.Location = new Point(18, 132);
            panel7.Name = "panel7";
            panel7.Size = new Size(406, 93);
            panel7.TabIndex = 19;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(DescriptiontextBox);
            panel8.Location = new Point(21, 268);
            panel8.Name = "panel8";
            panel8.Size = new Size(406, 100);
            panel8.TabIndex = 20;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(3, 3);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(139, 41);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(915, 0);
            panel4.TabIndex = 16;
            // 
            // panel9
            // 
            panel9.Controls.Add(AddButton);
            panel9.Controls.Add(RemoveButton);
            panel9.Location = new Point(3, 492);
            panel9.Name = "panel9";
            panel9.Size = new Size(300, 65);
            panel9.TabIndex = 22;
            // 
            // ItemsTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ItemsTab";
            Size = new Size(915, 560);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label SelectedItemLabel;
        private Label Idlabel;
        private Label Costlabel;
        private TextBox IdtextBox;
        private TextBox CosttextBox;
        private TextBox NametextBox;
        private TextBox DescriptiontextBox;
        private Label Namelabel;
        private Label Descriptionlabel;
        private Label ItemsLabel;
        private ListBox ItemsListBox;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel6;
        private Panel panel2;
        private Panel panel8;
        private Panel panel7;
        private Button RemoveButton;
        private Button AddButton;
        private Panel panel9;
    }
}
