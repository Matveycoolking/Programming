namespace ObjectOrientedPractics
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            OrdersTabPage = new TabPage();
            ordersTab1 = new ObjectOrientedPractics.View.Tabs.OrdersTab();
            CartsTab = new TabPage();
            cartsTab1 = new ObjectOrientedPractics.View.Tabs.CartsTab();
            CustomresTab = new TabPage();
            customersTab1 = new ObjectOrientedPractics.View.Tabs.CustomersTab();
            tabControl1 = new TabControl();
            itemsTab1 = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            tabPage1 = new TabPage();
            OrdersTabPage.SuspendLayout();
            CartsTab.SuspendLayout();
            CustomresTab.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // OrdersTabPage
            // 
            OrdersTabPage.Controls.Add(ordersTab1);
            OrdersTabPage.Location = new Point(4, 34);
            OrdersTabPage.Name = "OrdersTabPage";
            OrdersTabPage.Padding = new Padding(3);
            OrdersTabPage.Size = new Size(1138, 665);
            OrdersTabPage.TabIndex = 3;
            OrdersTabPage.Text = "Orders";
            OrdersTabPage.UseVisualStyleBackColor = true;
            // 
            // ordersTab1
            // 
            ordersTab1.Dock = DockStyle.Fill;
            ordersTab1.Location = new Point(3, 3);
            ordersTab1.Name = "ordersTab1";
            ordersTab1.Size = new Size(1132, 659);
            ordersTab1.TabIndex = 0;
            // 
            // CartsTab
            // 
            CartsTab.Controls.Add(cartsTab1);
            CartsTab.Location = new Point(4, 34);
            CartsTab.Name = "CartsTab";
            CartsTab.Padding = new Padding(3);
            CartsTab.Size = new Size(1138, 665);
            CartsTab.TabIndex = 2;
            CartsTab.Text = "Carts";
            CartsTab.UseVisualStyleBackColor = true;
            // 
            // cartsTab1
            // 
            cartsTab1.AutoSize = true;
            cartsTab1.Dock = DockStyle.Fill;
            cartsTab1.Location = new Point(3, 3);
            cartsTab1.Name = "cartsTab1";
            cartsTab1.Size = new Size(1132, 659);
            cartsTab1.TabIndex = 0;
            // 
            // CustomresTab
            // 
            CustomresTab.Controls.Add(customersTab1);
            CustomresTab.Location = new Point(4, 34);
            CustomresTab.Name = "CustomresTab";
            CustomresTab.Padding = new Padding(3);
            CustomresTab.Size = new Size(1138, 665);
            CustomresTab.TabIndex = 1;
            CustomresTab.Text = "Customers";
            CustomresTab.UseVisualStyleBackColor = true;
            // 
            // customersTab1
            // 
            customersTab1.AutoValidate = AutoValidate.Disable;
            customersTab1.Dock = DockStyle.Fill;
            customersTab1.Location = new Point(3, 3);
            customersTab1.Name = "customersTab1";
            customersTab1.Size = new Size(1132, 659);
            customersTab1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(CustomresTab);
            tabControl1.Controls.Add(CartsTab);
            tabControl1.Controls.Add(OrdersTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1146, 703);
            tabControl1.TabIndex = 0;
            // 
            // itemsTab1
            // 
            itemsTab1.AutoValidate = AutoValidate.Disable;
            itemsTab1.Dock = DockStyle.Fill;
            itemsTab1.Location = new Point(3, 3);
            itemsTab1.Name = "itemsTab1";
            itemsTab1.Size = new Size(1132, 659);
            itemsTab1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(itemsTab1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1138, 665);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Items";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 703);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Object Oriented Practics";
            OrdersTabPage.ResumeLayout(false);
            CartsTab.ResumeLayout(false);
            CartsTab.PerformLayout();
            CustomresTab.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage OrdersTabPage;
        private View.Tabs.OrdersTab ordersTab1;
        private TabPage CartsTab;
        private View.Tabs.CartsTab cartsTab1;
        private TabPage CustomresTab;
        private View.Tabs.CustomersTab customersTab1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private View.Tabs.ItemsTab itemsTab1;
    }
}
