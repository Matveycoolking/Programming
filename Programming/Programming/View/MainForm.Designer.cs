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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EnumListbox = new System.Windows.Forms.ListBox();
            this.VaulueListBox = new System.Windows.Forms.ListBox();
            this.Lable1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 374);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ValueBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Lable1);
            this.tabPage1.Controls.Add(this.VaulueListBox);
            this.tabPage1.Controls.Add(this.EnumListbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enums";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(236, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EnumListbox
            // 
            this.EnumListbox.FormattingEnabled = true;
            this.EnumListbox.ItemHeight = 20;
            this.EnumListbox.Location = new System.Drawing.Point(6, 50);
            this.EnumListbox.Name = "EnumListbox";
            this.EnumListbox.Size = new System.Drawing.Size(139, 124);
            this.EnumListbox.TabIndex = 0;
            this.EnumListbox.SelectedIndexChanged += new System.EventHandler(this.EnumListbox_SelectedIndexChanged);
            // 
            // VaulueListBox
            // 
            this.VaulueListBox.FormattingEnabled = true;
            this.VaulueListBox.ItemHeight = 20;
            this.VaulueListBox.Location = new System.Drawing.Point(185, 50);
            this.VaulueListBox.Name = "VaulueListBox";
            this.VaulueListBox.Size = new System.Drawing.Size(126, 124);
            this.VaulueListBox.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Value:";
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(375, 38);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(168, 26);
            this.ValueBox.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
    }
}

