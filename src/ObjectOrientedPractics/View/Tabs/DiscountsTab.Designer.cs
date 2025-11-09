namespace ObjectOrientedPractics.View.Tabs
{
    partial class DiscountsTab
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
            UppdateButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ApplyButton = new Button();
            CalculateButton = new Button();
            SuspendLayout();
            // 
            // UppdateButton
            // 
            UppdateButton.Location = new Point(291, 165);
            UppdateButton.Name = "UppdateButton";
            UppdateButton.Size = new Size(112, 34);
            UppdateButton.TabIndex = 3;
            UppdateButton.Text = "Uppdate";
            UppdateButton.UseVisualStyleBackColor = true;
            UppdateButton.Click += UppdateButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(55, 125);
            label2.Name = "label2";
            label2.Size = new Size(275, 25);
            label2.TabIndex = 4;
            label2.Text = "Info: Накопительная - баллов";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(627, 107);
            label3.Name = "label3";
            label3.Size = new Size(166, 25);
            label3.TabIndex = 5;
            label3.Text = "Products Amount:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(627, 146);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(627, 311);
            label5.Name = "label5";
            label5.Size = new Size(166, 25);
            label5.TabIndex = 7;
            label5.Text = "Discount Amount:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(627, 348);
            label6.Name = "label6";
            label6.Size = new Size(63, 25);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(173, 165);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(112, 34);
            ApplyButton.TabIndex = 9;
            ApplyButton.Text = "Apply";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(55, 165);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(112, 34);
            CalculateButton.TabIndex = 10;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // DiscountsTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CalculateButton);
            Controls.Add(ApplyButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(UppdateButton);
            Name = "DiscountsTab";
            Size = new Size(810, 486);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button UppdateButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button ApplyButton;
        private Button CalculateButton;
    }
}
