namespace ObjectOrientedPractics.View.Tabs
{
    partial class CartsTab
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
            tableLayoutPanel1 = new TableLayoutPanel();
            ItemsListBox = new ListBox();
            panel2 = new Panel();
            AddToCartbutton1 = new Button();
            panel3 = new Panel();
            CustomersComboBox = new ComboBox();
            CustomerLable1 = new Label();
            panel4 = new Panel();
            DiscountAmountLabel = new Label();
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            CartlistBox = new ListBox();
            Pricelabel = new Label();
            Clearbutton = new Button();
            Removebutton = new Button();
            Createbutton1 = new Button();
            Amountlabel1 = new Label();
            Cartlabel1 = new Label();
            panel1 = new Panel();
            itemslabel1 = new Label();
            panel5 = new Panel();
            lable3 = new Label();
            TotalLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.7330666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.2669334F));
            tableLayoutPanel1.Controls.Add(ItemsListBox, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.5809126F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.41909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayoutPanel1.Size = new Size(1024, 537);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // ItemsListBox
            // 
            ItemsListBox.Dock = DockStyle.Fill;
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(3, 54);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(421, 430);
            ItemsListBox.TabIndex = 2;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(AddToCartbutton1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 490);
            panel2.Name = "panel2";
            panel2.Size = new Size(421, 44);
            panel2.TabIndex = 3;
            // 
            // AddToCartbutton1
            // 
            AddToCartbutton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            AddToCartbutton1.Location = new Point(3, 3);
            AddToCartbutton1.Name = "AddToCartbutton1";
            AddToCartbutton1.Size = new Size(131, 38);
            AddToCartbutton1.TabIndex = 0;
            AddToCartbutton1.Text = "Add To Cart";
            AddToCartbutton1.UseVisualStyleBackColor = true;
            AddToCartbutton1.Click += AddToCartbutton1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(CustomersComboBox);
            panel3.Controls.Add(CustomerLable1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(430, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(591, 45);
            panel3.TabIndex = 4;
            // 
            // CustomersComboBox
            // 
            CustomersComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CustomersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CustomersComboBox.FormattingEnabled = true;
            CustomersComboBox.Location = new Point(113, 8);
            CustomersComboBox.Name = "CustomersComboBox";
            CustomersComboBox.Size = new Size(475, 33);
            CustomersComboBox.TabIndex = 1;
            CustomersComboBox.SelectedIndexChanged += CustomersComboBox_SelectedIndexChanged;
            // 
            // CustomerLable1
            // 
            CustomerLable1.AutoSize = true;
            CustomerLable1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CustomerLable1.Location = new Point(3, 11);
            CustomerLable1.Name = "CustomerLable1";
            CustomerLable1.Size = new Size(93, 25);
            CustomerLable1.TabIndex = 0;
            CustomerLable1.Text = "Customer";
            // 
            // panel4
            // 
            panel4.Controls.Add(DiscountAmountLabel);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(checkedListBox1);
            panel4.Controls.Add(CartlistBox);
            panel4.Controls.Add(Pricelabel);
            panel4.Controls.Add(Clearbutton);
            panel4.Controls.Add(Removebutton);
            panel4.Controls.Add(Createbutton1);
            panel4.Controls.Add(Amountlabel1);
            panel4.Controls.Add(Cartlabel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(430, 54);
            panel4.Name = "panel4";
            panel4.Size = new Size(591, 430);
            panel4.TabIndex = 5;
            // 
            // DiscountAmountLabel
            // 
            DiscountAmountLabel.AutoSize = true;
            DiscountAmountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DiscountAmountLabel.Location = new Point(488, 334);
            DiscountAmountLabel.Name = "DiscountAmountLabel";
            DiscountAmountLabel.Size = new Size(86, 25);
            DiscountAmountLabel.TabIndex = 10;
            DiscountAmountLabel.Text = "Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(408, 309);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 9;
            label1.Text = "Discount Amount:";
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 300);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(316, 116);
            checkedListBox1.TabIndex = 8;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // CartlistBox
            // 
            CartlistBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CartlistBox.FormattingEnabled = true;
            CartlistBox.Location = new Point(25, 41);
            CartlistBox.Name = "CartlistBox";
            CartlistBox.Size = new Size(540, 129);
            CartlistBox.TabIndex = 7;
            // 
            // Pricelabel
            // 
            Pricelabel.AutoSize = true;
            Pricelabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Pricelabel.Location = new Point(459, 208);
            Pricelabel.Name = "Pricelabel";
            Pricelabel.Size = new Size(35, 41);
            Pricelabel.TabIndex = 6;
            Pricelabel.Text = "0";
            // 
            // Clearbutton
            // 
            Clearbutton.Location = new Point(462, 260);
            Clearbutton.Name = "Clearbutton";
            Clearbutton.Size = new Size(126, 34);
            Clearbutton.TabIndex = 5;
            Clearbutton.Text = "Clear Cart";
            Clearbutton.UseVisualStyleBackColor = true;
            Clearbutton.Click += Clearbutton_Click;
            // 
            // Removebutton
            // 
            Removebutton.Location = new Point(315, 260);
            Removebutton.Name = "Removebutton";
            Removebutton.Size = new Size(141, 34);
            Removebutton.TabIndex = 4;
            Removebutton.Text = "Remove Item";
            Removebutton.UseVisualStyleBackColor = true;
            Removebutton.Click += Removebutton_Click;
            // 
            // Createbutton1
            // 
            Createbutton1.Location = new Point(3, 260);
            Createbutton1.Name = "Createbutton1";
            Createbutton1.Size = new Size(126, 34);
            Createbutton1.TabIndex = 3;
            Createbutton1.Text = "Create Order";
            Createbutton1.UseVisualStyleBackColor = true;
            Createbutton1.Click += Createbutton1_Click;
            // 
            // Amountlabel1
            // 
            Amountlabel1.AutoSize = true;
            Amountlabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Amountlabel1.Location = new Point(477, 186);
            Amountlabel1.Name = "Amountlabel1";
            Amountlabel1.Size = new Size(86, 25);
            Amountlabel1.TabIndex = 2;
            Amountlabel1.Text = "Amount:";
            // 
            // Cartlabel1
            // 
            Cartlabel1.AutoSize = true;
            Cartlabel1.Location = new Point(25, 4);
            Cartlabel1.Name = "Cartlabel1";
            Cartlabel1.Size = new Size(48, 25);
            Cartlabel1.TabIndex = 0;
            Cartlabel1.Text = "Cart:";
            // 
            // panel1
            // 
            panel1.Controls.Add(itemslabel1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(88, 36);
            panel1.TabIndex = 1;
            // 
            // itemslabel1
            // 
            itemslabel1.AutoSize = true;
            itemslabel1.Dock = DockStyle.Fill;
            itemslabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            itemslabel1.Location = new Point(0, 0);
            itemslabel1.Name = "itemslabel1";
            itemslabel1.Size = new Size(59, 25);
            itemslabel1.TabIndex = 0;
            itemslabel1.Text = "Items";
            // 
            // panel5
            // 
            panel5.Controls.Add(lable3);
            panel5.Controls.Add(TotalLabel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(430, 490);
            panel5.Name = "panel5";
            panel5.Size = new Size(591, 44);
            panel5.TabIndex = 6;
            // 
            // lable3
            // 
            lable3.AutoSize = true;
            lable3.Dock = DockStyle.Right;
            lable3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lable3.Location = new Point(425, 0);
            lable3.Name = "lable3";
            lable3.Size = new Size(72, 25);
            lable3.TabIndex = 11;
            lable3.Text = "TOTAL:";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Dock = DockStyle.Right;
            TotalLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            TotalLabel.Location = new Point(497, 0);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(94, 25);
            TotalLabel.TabIndex = 10;
            TotalLabel.Text = "AMOUNT";
            // 
            // CartsTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanel1);
            Name = "CartsTab";
            Size = new Size(1024, 537);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label itemslabel1;
        private ListBox ItemsListBox;
        private Panel panel2;
        private Button AddToCartbutton1;
        private Panel panel3;
        private Label CustomerLable1;
        private ComboBox CustomersComboBox;
        private Panel panel4;
        private Label Amountlabel1;
        private Label Cartlabel1;
        private Label Pricelabel;
        private Button Clearbutton;
        private Button Removebutton;
        private Button Createbutton1;
        private ListBox CartlistBox;
        private CheckedListBox checkedListBox1;
        private Label DiscountAmountLabel;
        private Label label1;
        private Panel panel5;
        private Label lable3;
        private Label TotalLabel;
    }
}
