namespace UserControls
{
    partial class ButtonWithLabel2
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
            this.Button = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(3, 20);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(76, 25);
            this.Button.TabIndex = 3;
            this.Button.Text = "Button";
            this.Button.UseVisualStyleBackColor = true;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(0, 4);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(33, 13);
            this.Label.TabIndex = 2;
            this.Label.Text = "Label";
            // 
            // ButtonWithLabel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Button);
            this.Controls.Add(this.Label);
            this.Name = "ButtonWithLabel2";
            this.Size = new System.Drawing.Size(85, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Button;
        public System.Windows.Forms.Label Label;
    }
}
