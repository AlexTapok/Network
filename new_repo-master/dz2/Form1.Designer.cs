namespace dz2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxMoney = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxPercent = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnReadLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Money";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Percent";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxMoney
            // 
            this.tbxMoney.Location = new System.Drawing.Point(69, 8);
            this.tbxMoney.Name = "tbxMoney";
            this.tbxMoney.Size = new System.Drawing.Size(200, 20);
            this.tbxMoney.TabIndex = 4;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(69, 67);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(200, 20);
            this.tbxName.TabIndex = 5;
            // 
            // tbxPercent
            // 
            this.tbxPercent.Location = new System.Drawing.Point(69, 123);
            this.tbxPercent.Name = "tbxPercent";
            this.tbxPercent.Size = new System.Drawing.Size(200, 20);
            this.tbxPercent.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(333, 177);
            this.textBox1.TabIndex = 7;
            // 
            // btnReadLog
            // 
            this.btnReadLog.Location = new System.Drawing.Point(141, 160);
            this.btnReadLog.Name = "btnReadLog";
            this.btnReadLog.Size = new System.Drawing.Size(128, 32);
            this.btnReadLog.TabIndex = 8;
            this.btnReadLog.Text = "Read";
            this.btnReadLog.UseVisualStyleBackColor = true;
            this.btnReadLog.Click += new System.EventHandler(this.btnReadLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 197);
            this.Controls.Add(this.btnReadLog);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbxPercent);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.tbxMoney);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxMoney;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxPercent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnReadLog;
    }
}

