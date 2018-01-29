namespace Delegates
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.PerformOpButton = new System.Windows.Forms.Button();
            this.tbA = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.tbOp = new System.Windows.Forms.TextBox();
            this.tbRes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PerformOpButton
            // 
            this.PerformOpButton.Location = new System.Drawing.Point(102, 195);
            this.PerformOpButton.Name = "PerformOpButton";
            this.PerformOpButton.Size = new System.Drawing.Size(106, 41);
            this.PerformOpButton.TabIndex = 0;
            this.PerformOpButton.Text = "Perform the operation";
            this.PerformOpButton.UseVisualStyleBackColor = true;
            this.PerformOpButton.Click += new System.EventHandler(this.Button1Click);
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(102, 105);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(100, 20);
            this.tbA.TabIndex = 1;
            this.tbA.Text = "0";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(102, 157);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(100, 20);
            this.tbB.TabIndex = 2;
            this.tbB.Text = "0";
            // 
            // tbOp
            // 
            this.tbOp.Location = new System.Drawing.Point(102, 131);
            this.tbOp.Name = "tbOp";
            this.tbOp.Size = new System.Drawing.Size(100, 20);
            this.tbOp.TabIndex = 3;
            this.tbOp.Text = "+";
            // 
            // tbRes
            // 
            this.tbRes.Location = new System.Drawing.Point(102, 251);
            this.tbRes.Name = "tbRes";
            this.tbRes.Size = new System.Drawing.Size(100, 20);
            this.tbRes.TabIndex = 4;
            this.tbRes.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 440);
            this.Controls.Add(this.tbRes);
            this.Controls.Add(this.tbOp);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.PerformOpButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PerformOpButton;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.TextBox tbOp;
        private System.Windows.Forms.TextBox tbRes;
    }
}

