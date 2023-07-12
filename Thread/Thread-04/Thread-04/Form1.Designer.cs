namespace Thread_04
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Param_btn = new System.Windows.Forms.Button();
            this.Non_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Param_btn
            // 
            this.Param_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Param_btn.Location = new System.Drawing.Point(12, 12);
            this.Param_btn.Name = "Param_btn";
            this.Param_btn.Size = new System.Drawing.Size(112, 45);
            this.Param_btn.TabIndex = 0;
            this.Param_btn.Text = "Parameter";
            this.Param_btn.UseVisualStyleBackColor = true;
            this.Param_btn.Click += new System.EventHandler(this.Para_btn_Click);
            // 
            // Non_btn
            // 
            this.Non_btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Non_btn.Location = new System.Drawing.Point(196, 12);
            this.Non_btn.Name = "Non_btn";
            this.Non_btn.Size = new System.Drawing.Size(117, 45);
            this.Non_btn.TabIndex = 1;
            this.Non_btn.Text = "Non Parameter";
            this.Non_btn.UseVisualStyleBackColor = true;
            this.Non_btn.Click += new System.EventHandler(this.Non_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 220);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 295);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Non_btn);
            this.Controls.Add(this.Param_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Param_btn;
        private System.Windows.Forms.Button Non_btn;
        private System.Windows.Forms.TextBox textBox1;
    }
}

