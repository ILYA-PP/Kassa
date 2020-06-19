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
            this.cashRB = new System.Windows.Forms.RadioButton();
            this.nonCashRB = new System.Windows.Forms.RadioButton();
            this.resultL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.moneyTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changeTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.payB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cashRB
            // 
            this.cashRB.AutoSize = true;
            this.cashRB.Checked = true;
            this.cashRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashRB.Location = new System.Drawing.Point(12, 86);
            this.cashRB.Name = "cashRB";
            this.cashRB.Size = new System.Drawing.Size(113, 24);
            this.cashRB.TabIndex = 0;
            this.cashRB.TabStop = true;
            this.cashRB.Text = "Наличный";
            this.cashRB.UseVisualStyleBackColor = true;
            this.cashRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // nonCashRB
            // 
            this.nonCashRB.AutoSize = true;
            this.nonCashRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nonCashRB.Location = new System.Drawing.Point(12, 120);
            this.nonCashRB.Name = "nonCashRB";
            this.nonCashRB.Size = new System.Drawing.Size(141, 24);
            this.nonCashRB.TabIndex = 1;
            this.nonCashRB.Text = "Безналичный";
            this.nonCashRB.UseVisualStyleBackColor = true;
            // 
            // resultL
            // 
            this.resultL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultL.Location = new System.Drawing.Point(12, 9);
            this.resultL.Name = "resultL";
            this.resultL.Size = new System.Drawing.Size(328, 48);
            this.resultL.TabIndex = 2;
            this.resultL.Text = "руб.";
            this.resultL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Внесено:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(322, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "руб.";
            // 
            // moneyTB
            // 
            this.moneyTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moneyTB.Location = new System.Drawing.Point(91, 175);
            this.moneyTB.Name = "moneyTB";
            this.moneyTB.Size = new System.Drawing.Size(225, 26);
            this.moneyTB.TabIndex = 8;
            this.moneyTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moneyTB.TextChanged += new System.EventHandler(this.moneyTB_TextChanged);
            this.moneyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(321, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "руб.";
            // 
            // changeTB
            // 
            this.changeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeTB.Location = new System.Drawing.Point(90, 212);
            this.changeTB.Name = "changeTB";
            this.changeTB.ReadOnly = true;
            this.changeTB.Size = new System.Drawing.Size(225, 26);
            this.changeTB.TabIndex = 11;
            this.changeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Сдача:";
            // 
            // payB
            // 
            this.payB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payB.Location = new System.Drawing.Point(127, 260);
            this.payB.Name = "payB";
            this.payB.Size = new System.Drawing.Size(117, 30);
            this.payB.TabIndex = 13;
            this.payB.Text = "Оплатить";
            this.payB.UseVisualStyleBackColor = true;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 302);
            this.Controls.Add(this.payB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.moneyTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultL);
            this.Controls.Add(this.nonCashRB);
            this.Controls.Add(this.cashRB);
            this.Name = "Payment";
            this.Text = "Оплата";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cashRB;
        private System.Windows.Forms.RadioButton nonCashRB;
        private System.Windows.Forms.Label resultL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox moneyTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox changeTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button payB;
    }
}