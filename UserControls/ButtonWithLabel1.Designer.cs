namespace UserControls
{
    partial class ButtonWithLabel1
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
            this.Label = new System.Windows.Forms.Label();
            this.Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(3, 13);
            this.Label.Margin = new System.Windows.Forms.Padding(3);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(33, 13);
            this.Label.TabIndex = 0;
            this.Label.Text = "Label";
            // 
            // Button
            // 
            this.Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button.Location = new System.Drawing.Point(43, 7);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(76, 25);
            this.Button.TabIndex = 1;
            this.Button.Text = "Button";
            this.Button.UseVisualStyleBackColor = true;
            // 
            // ButtonWithLabel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Button);
            this.Controls.Add(this.Label);
            this.Name = "ButtonWithLabel1";
            this.Size = new System.Drawing.Size(122, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label;
        public System.Windows.Forms.Button Button;
    }
}
