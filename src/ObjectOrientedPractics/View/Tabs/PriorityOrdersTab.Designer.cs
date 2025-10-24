namespace ObjectOrientedPractics.View.Tabs
{
    partial class PriorityOrdersTab
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
            StatusComboBox = new ComboBox();
            CreatedTextBox = new TextBox();
            IdTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            addressControl1 = new ObjectOrientedPractics.View.Controls.AddressControl();
            ItemsListBox = new ListBox();
            label6 = new Label();
            PriceLabel = new Label();
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            DeliveryTimeComboBox = new ComboBox();
            AddButton = new Button();
            Removebutton = new Button();
            Clearbutton = new Button();
            SuspendLayout();
            // 
            // StatusComboBox
            // 
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(108, 114);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(182, 33);
            StatusComboBox.TabIndex = 11;
            // 
            // CreatedTextBox
            // 
            CreatedTextBox.Location = new Point(108, 80);
            CreatedTextBox.Name = "CreatedTextBox";
            CreatedTextBox.Size = new Size(182, 31);
            CreatedTextBox.TabIndex = 10;
            // 
            // IdTextBox
            // 
            IdTextBox.Location = new Point(108, 43);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.Size = new Size(182, 31);
            IdTextBox.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 114);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 9;
            label5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 78);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 8;
            label4.Text = "Created:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 43);
            label3.Name = "label3";
            label3.Size = new Size(34, 25);
            label3.TabIndex = 7;
            label3.Text = "ID:";
            // 
            // addressControl1
            // 
            addressControl1.AutoValidate = AutoValidate.Disable;
            addressControl1.Location = new Point(-4, 165);
            addressControl1.Name = "addressControl1";
            addressControl1.Size = new Size(639, 256);
            addressControl1.TabIndex = 12;
            // 
            // ItemsListBox
            // 
            ItemsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(25, 461);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(513, 104);
            ItemsListBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(25, 424);
            label6.Name = "label6";
            label6.Size = new Size(113, 25);
            label6.TabIndex = 13;
            label6.Text = "Order Items";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            PriceLabel.Location = new Point(432, 598);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(35, 41);
            PriceLabel.TabIndex = 16;
            PriceLabel.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.Location = new Point(436, 568);
            label7.Name = "label7";
            label7.Size = new Size(102, 30);
            label7.TabIndex = 15;
            label7.Text = "Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(25, 15);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 17;
            label1.Text = "Selected Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(345, 15);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 18;
            label2.Text = "Priority Options";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(345, 49);
            label8.Name = "label8";
            label8.Size = new Size(122, 25);
            label8.TabIndex = 19;
            label8.Text = "Delivery Time:";
            // 
            // DeliveryTimeComboBox
            // 
            DeliveryTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DeliveryTimeComboBox.FormattingEnabled = true;
            DeliveryTimeComboBox.Location = new Point(489, 49);
            DeliveryTimeComboBox.Name = "DeliveryTimeComboBox";
            DeliveryTimeComboBox.Size = new Size(182, 33);
            DeliveryTimeComboBox.TabIndex = 20;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(25, 673);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(139, 41);
            AddButton.TabIndex = 22;
            AddButton.Text = "Add item";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // Removebutton
            // 
            Removebutton.Location = new Point(170, 673);
            Removebutton.Name = "Removebutton";
            Removebutton.Size = new Size(139, 41);
            Removebutton.TabIndex = 23;
            Removebutton.Text = "Remove item";
            Removebutton.UseVisualStyleBackColor = true;
            Removebutton.Click += Removebutton_Click;
            // 
            // Clearbutton
            // 
            Clearbutton.Location = new Point(419, 673);
            Clearbutton.Name = "Clearbutton";
            Clearbutton.Size = new Size(139, 41);
            Clearbutton.TabIndex = 24;
            Clearbutton.Text = "Clear Order";
            Clearbutton.UseVisualStyleBackColor = true;
            Clearbutton.Click += Clearbutton_Click;
            // 
            // PriorityOrdersTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Clearbutton);
            Controls.Add(Removebutton);
            Controls.Add(AddButton);
            Controls.Add(DeliveryTimeComboBox);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PriceLabel);
            Controls.Add(label7);
            Controls.Add(ItemsListBox);
            Controls.Add(label6);
            Controls.Add(addressControl1);
            Controls.Add(StatusComboBox);
            Controls.Add(CreatedTextBox);
            Controls.Add(IdTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Name = "PriorityOrdersTab";
            Size = new Size(728, 776);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox StatusComboBox;
        private TextBox CreatedTextBox;
        private TextBox IdTextBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Controls.AddressControl addressControl1;
        private ListBox ItemsListBox;
        private Label label6;
        private Label PriceLabel;
        private Label label7;
        private Label label1;
        private Label label2;
        private Label label8;
        private ComboBox DeliveryTimeComboBox;
        private Button AddButton;
        private Button Removebutton;
        private Button Clearbutton;
    }
}
