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
            ItemsListBox = new ListBox();
            ItemsLabel = new Label();
            AddButton = new Button();
            RemoveButton = new Button();
            SelectedItemLabel = new Label();
            Idlabel = new Label();
            Costlabel = new Label();
            IdtextBox = new TextBox();
            CosttextBox = new TextBox();
            NametextBox = new TextBox();
            DescriptiontextBox = new TextBox();
            Namelabel = new Label();
            Descriptionlabel = new Label();
            SuspendLayout();
            // 
            // ItemsListBox
            // 
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(22, 38);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(292, 429);
            ItemsListBox.TabIndex = 0;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            // 
            // ItemsLabel
            // 
            ItemsLabel.AutoSize = true;
            ItemsLabel.BackColor = SystemColors.Control;
            ItemsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ItemsLabel.Location = new Point(22, 10);
            ItemsLabel.Name = "ItemsLabel";
            ItemsLabel.Size = new Size(59, 25);
            ItemsLabel.TabIndex = 1;
            ItemsLabel.Text = "Items";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(22, 492);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(112, 34);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(140, 492);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(112, 34);
            RemoveButton.TabIndex = 3;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // SelectedItemLabel
            // 
            SelectedItemLabel.AutoSize = true;
            SelectedItemLabel.BackColor = SystemColors.Control;
            SelectedItemLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SelectedItemLabel.Location = new Point(369, 10);
            SelectedItemLabel.Name = "SelectedItemLabel";
            SelectedItemLabel.Size = new Size(128, 25);
            SelectedItemLabel.TabIndex = 4;
            SelectedItemLabel.Text = "Selected Item";
            // 
            // Idlabel
            // 
            Idlabel.AutoSize = true;
            Idlabel.Location = new Point(369, 38);
            Idlabel.Name = "Idlabel";
            Idlabel.Size = new Size(34, 25);
            Idlabel.TabIndex = 5;
            Idlabel.Text = "ID:";
            // 
            // Costlabel
            // 
            Costlabel.AutoSize = true;
            Costlabel.Location = new Point(369, 76);
            Costlabel.Name = "Costlabel";
            Costlabel.Size = new Size(52, 25);
            Costlabel.TabIndex = 6;
            Costlabel.Text = "Cost:";
            // 
            // IdtextBox
            // 
            IdtextBox.Location = new Point(435, 38);
            IdtextBox.Name = "IdtextBox";
            IdtextBox.ReadOnly = true;
            IdtextBox.Size = new Size(150, 31);
            IdtextBox.TabIndex = 7;
            // 
            // CosttextBox
            // 
            CosttextBox.Location = new Point(435, 76);
            CosttextBox.Name = "CosttextBox";
            CosttextBox.Size = new Size(150, 31);
            CosttextBox.TabIndex = 8;
            // 
            // NametextBox
            // 
            NametextBox.Location = new Point(369, 145);
            NametextBox.Multiline = true;
            NametextBox.Name = "NametextBox";
            NametextBox.Size = new Size(492, 114);
            NametextBox.TabIndex = 9;
            // 
            // DescriptiontextBox
            // 
            DescriptiontextBox.Location = new Point(369, 314);
            DescriptiontextBox.Multiline = true;
            DescriptiontextBox.Name = "DescriptiontextBox";
            DescriptiontextBox.Size = new Size(492, 168);
            DescriptiontextBox.TabIndex = 10;
            // 
            // Namelabel
            // 
            Namelabel.AutoSize = true;
            Namelabel.Location = new Point(367, 116);
            Namelabel.Name = "Namelabel";
            Namelabel.Size = new Size(63, 25);
            Namelabel.TabIndex = 11;
            Namelabel.Text = "Name:";
            // 
            // Descriptionlabel
            // 
            Descriptionlabel.AutoSize = true;
            Descriptionlabel.Location = new Point(371, 286);
            Descriptionlabel.Name = "Descriptionlabel";
            Descriptionlabel.Size = new Size(106, 25);
            Descriptionlabel.TabIndex = 12;
            Descriptionlabel.Text = "Description:";
            // 
            // ItemsTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Descriptionlabel);
            Controls.Add(Namelabel);
            Controls.Add(DescriptiontextBox);
            Controls.Add(NametextBox);
            Controls.Add(CosttextBox);
            Controls.Add(IdtextBox);
            Controls.Add(Costlabel);
            Controls.Add(Idlabel);
            Controls.Add(SelectedItemLabel);
            Controls.Add(RemoveButton);
            Controls.Add(AddButton);
            Controls.Add(ItemsLabel);
            Controls.Add(ItemsListBox);
            Name = "ItemsTab";
            Size = new Size(878, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ItemsListBox;
        private Label ItemsLabel;
        private Button AddButton;
        private Button RemoveButton;
        private Label SelectedItemLabel;
        private Label Idlabel;
        private Label Costlabel;
        private TextBox IdtextBox;
        private TextBox CosttextBox;
        private TextBox NametextBox;
        private TextBox DescriptiontextBox;
        private Label Namelabel;
        private Label Descriptionlabel;
    }
}
