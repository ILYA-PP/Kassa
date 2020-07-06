namespace KassaApp
{
    partial class Payment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyTB = new System.Windows.Forms.TextBox();
            this.changeTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cashB = new System.Windows.Forms.Button();
            this.nonCashB = new System.Windows.Forms.Button();
            this.specPayB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.additOpB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.noteB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultL
            // 
            this.resultL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultL.Location = new System.Drawing.Point(12, 9);
            this.resultL.Name = "resultL";
            this.resultL.Size = new System.Drawing.Size(425, 48);
            this.resultL.TabIndex = 2;
            this.resultL.Text = "Сумма по чеку";
            this.resultL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Внесено:";
            // 
            // moneyTB
            // 
            this.moneyTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moneyTB.Location = new System.Drawing.Point(97, 60);
            this.moneyTB.Name = "moneyTB";
            this.moneyTB.Size = new System.Drawing.Size(340, 26);
            this.moneyTB.TabIndex = 8;
            this.moneyTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moneyTB.TextChanged += new System.EventHandler(this.moneyTB_TextChanged);
            this.moneyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTB_KeyPress);
            // 
            // changeTB
            // 
            this.changeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeTB.Location = new System.Drawing.Point(96, 97);
            this.changeTB.Name = "changeTB";
            this.changeTB.ReadOnly = true;
            this.changeTB.Size = new System.Drawing.Size(341, 26);
            this.changeTB.TabIndex = 11;
            this.changeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Сдача:";
            // 
            // cashB
            // 
            this.cashB.BackgroundImage = global::KassaApp.Properties.Resources.нал;
            this.cashB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cashB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cashB.Location = new System.Drawing.Point(443, 12);
            this.cashB.Name = "cashB";
            this.cashB.Size = new System.Drawing.Size(175, 207);
            this.cashB.TabIndex = 12;
            this.cashB.Text = "[Enter] Наличные";
            this.cashB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cashB.UseVisualStyleBackColor = true;
            this.cashB.Click += new System.EventHandler(this.cashB_Click);
            // 
            // nonCashB
            // 
            this.nonCashB.BackgroundImage = global::KassaApp.Properties.Resources.безнал;
            this.nonCashB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.nonCashB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nonCashB.Location = new System.Drawing.Point(443, 225);
            this.nonCashB.Name = "nonCashB";
            this.nonCashB.Size = new System.Drawing.Size(175, 209);
            this.nonCashB.TabIndex = 13;
            this.nonCashB.Text = "[*] Банковская карта";
            this.nonCashB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nonCashB.UseVisualStyleBackColor = true;
            this.nonCashB.Click += new System.EventHandler(this.nonCashB_Click);
            // 
            // specPayB
            // 
            this.specPayB.Enabled = false;
            this.specPayB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.specPayB.Location = new System.Drawing.Point(50, 331);
            this.specPayB.Name = "specPayB";
            this.specPayB.Size = new System.Drawing.Size(73, 61);
            this.specPayB.TabIndex = 14;
            this.specPayB.Text = "[F5] Спец. оплата";
            this.specPayB.UseVisualStyleBackColor = true;
            // 
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(129, 331);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(73, 61);
            this.cancelB.TabIndex = 15;
            this.cancelB.Text = "[Esc] Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // additOpB
            // 
            this.additOpB.Enabled = false;
            this.additOpB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additOpB.Location = new System.Drawing.Point(208, 331);
            this.additOpB.Name = "additOpB";
            this.additOpB.Size = new System.Drawing.Size(73, 61);
            this.additOpB.TabIndex = 16;
            this.additOpB.Text = "[F6]  Доп.оп.";
            this.additOpB.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 398);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 26);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // noteB
            // 
            this.noteB.Enabled = false;
            this.noteB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noteB.Location = new System.Drawing.Point(326, 381);
            this.noteB.Name = "noteB";
            this.noteB.Size = new System.Drawing.Size(111, 53);
            this.noteB.TabIndex = 18;
            this.noteB.Text = "[F1]  Примечание";
            this.noteB.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.messageL);
            this.panel1.Location = new System.Drawing.Point(18, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 100);
            this.panel1.TabIndex = 19;
            this.panel1.Visible = false;
            // 
            // messageL
            // 
            this.messageL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageL.Location = new System.Drawing.Point(0, 0);
            this.messageL.Name = "messageL";
            this.messageL.Size = new System.Drawing.Size(597, 100);
            this.messageL.TabIndex = 0;
            this.messageL.Text = "Идёт процесс оплаты через терминал";
            this.messageL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.noteB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.additOpB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.specPayB);
            this.Controls.Add(this.nonCashB);
            this.Controls.Add(this.cashB);
            this.Controls.Add(this.changeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.moneyTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.ShowIcon = false;
            this.Text = "Оплата";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label resultL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moneyTB;
        private System.Windows.Forms.TextBox changeTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cashB;
        private System.Windows.Forms.Button nonCashB;
        private System.Windows.Forms.Button specPayB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button additOpB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button noteB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label messageL;
    }
}