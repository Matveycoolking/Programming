namespace ObjectOrientedPractics.View.Tabs
{
    partial class OrdersTab
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
            panel3 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            OrderItemsListBox = new ListBox();
            Pricelabel8 = new Label();
            label7 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            addressControl1 = new ObjectOrientedPractics.View.Controls.AddressControl();
            panel2 = new Panel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Created = new DataGridViewTextBoxColumn();
            OrderStatus = new DataGridViewTextBoxColumn();
            CustomerFullName = new DataGridViewTextBoxColumn();
            DeliveryAddress = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.18625F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.813755F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.66355133F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.33645F));
            tableLayoutPanel1.Size = new Size(1396, 771);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 35);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 0;
            label2.Text = "Orders";
            // 
            // panel1
            // 
            panel1.Controls.Add(OrderItemsListBox);
            panel1.Controls.Add(Pricelabel8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(addressControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(913, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 706);
            panel1.TabIndex = 0;
            // 
            // OrderItemsListBox
            // 
            OrderItemsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OrderItemsListBox.FormattingEnabled = true;
            OrderItemsListBox.Location = new Point(27, 385);
            OrderItemsListBox.Name = "OrderItemsListBox";
            OrderItemsListBox.Size = new Size(432, 104);
            OrderItemsListBox.TabIndex = 10;
            // 
            // Pricelabel8
            // 
            Pricelabel8.AutoSize = true;
            Pricelabel8.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Pricelabel8.Location = new Point(390, 558);
            Pricelabel8.Name = "Pricelabel8";
            Pricelabel8.Size = new Size(35, 41);
            Pricelabel8.TabIndex = 9;
            Pricelabel8.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.Location = new Point(428, 528);
            label7.Name = "label7";
            label7.Size = new Size(102, 30);
            label7.TabIndex = 8;
            label7.Text = "Amount:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(27, 357);
            label6.Name = "label6";
            label6.Size = new Size(113, 25);
            label6.TabIndex = 6;
            label6.Text = "Order Items";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(110, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 52);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(182, 31);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 15);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(182, 31);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 86);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 3;
            label5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 50);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 2;
            label4.Text = "Created:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 15);
            label3.Name = "label3";
            label3.Size = new Size(34, 25);
            label3.TabIndex = 1;
            label3.Text = "ID:";
            // 
            // addressControl1
            // 
            addressControl1.AutoValidate = AutoValidate.Disable;
            addressControl1.Location = new Point(0, 114);
            addressControl1.Name = "addressControl1";
            addressControl1.Size = new Size(639, 256);
            addressControl1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(913, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 53);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Selected Order";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Created, OrderStatus, CustomerFullName, DeliveryAddress, TotalAmount });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 62);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.Size = new Size(904, 706);
            dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Created
            // 
            Created.HeaderText = "Created";
            Created.MinimumWidth = 8;
            Created.Name = "Created";
            Created.ReadOnly = true;
            // 
            // OrderStatus
            // 
            OrderStatus.HeaderText = "Order Status";
            OrderStatus.MinimumWidth = 8;
            OrderStatus.Name = "OrderStatus";
            OrderStatus.ReadOnly = true;
            // 
            // CustomerFullName
            // 
            CustomerFullName.HeaderText = "Customer Full Name";
            CustomerFullName.MinimumWidth = 8;
            CustomerFullName.Name = "CustomerFullName";
            CustomerFullName.ReadOnly = true;
            // 
            // DeliveryAddress
            // 
            DeliveryAddress.HeaderText = "Delivery Address";
            DeliveryAddress.MinimumWidth = 8;
            DeliveryAddress.Name = "DeliveryAddress";
            DeliveryAddress.ReadOnly = true;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.MinimumWidth = 8;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.ReadOnly = true;
            // 
            // OrdersTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "OrdersTab";
            Size = new Size(1396, 771);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Controls.AddressControl addressControl1;
        private Panel panel3;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Created;
        private DataGridViewTextBoxColumn OrderStatus;
        private DataGridViewTextBoxColumn CustomerFullName;
        private Label label6;
        private Label Pricelabel8;
        private Label label7;
        private ListBox OrderItemsListBox;
        private DataGridViewTextBoxColumn DeliveryAddress;
        private DataGridViewTextBoxColumn TotalAmount;
    }
}
