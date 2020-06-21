namespace KassaApp
{
    partial class DiscountOnReceipt
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
            this.label1 = new System.Windows.Forms.Label();
            this.discountCardNumberTB = new System.Windows.Forms.TextBox();
            this.discountProcentRB = new System.Windows.Forms.RadioButton();
            this.numberDiscountCardRB = new System.Windows.Forms.RadioButton();
            this.cancelB = new System.Windows.Forms.Button();
            this.enterB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ДК:";
            // 
            // discountCardNumberTB
            // 
            this.discountCardNumberTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountCardNumberTB.Location = new System.Drawing.Point(52, 12);
            this.discountCardNumberTB.Name = "discountCardNumberTB";
            this.discountCardNumberTB.Size = new System.Drawing.Size(349, 26);
            this.discountCardNumberTB.TabIndex = 1;
            // 
            // discountProcentRB
            // 
            this.discountProcentRB.AutoSize = true;
            this.discountProcentRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountProcentRB.Location = new System.Drawing.Point(15, 53);
            this.discountProcentRB.Name = "discountProcentRB";
            this.discountProcentRB.Size = new System.Drawing.Size(150, 24);
            this.discountProcentRB.TabIndex = 2;
            this.discountProcentRB.TabStop = true;
            this.discountProcentRB.Text = "Процент скидки";
            this.discountProcentRB.UseVisualStyleBackColor = true;
            this.discountProcentRB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // numberDiscountCardRB
            // 
            this.numberDiscountCardRB.AutoSize = true;
            this.numberDiscountCardRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberDiscountCardRB.Location = new System.Drawing.Point(180, 53);
            this.numberDiscountCardRB.Name = "numberDiscountCardRB";
            this.numberDiscountCardRB.Size = new System.Drawing.Size(221, 24);
            this.numberDiscountCardRB.TabIndex = 3;
            this.numberDiscountCardRB.TabStop = true;
            this.numberDiscountCardRB.Text = "Номер дисконтной карты";
            this.numberDiscountCardRB.UseVisualStyleBackColor = true;
            // 
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(211, 97);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(101, 49);
            this.cancelB.TabIndex = 43;
            this.cancelB.Text = "[Esc] Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.button6_Click);
            // 
            // enterB
            // 
            this.enterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterB.Location = new System.Drawing.Point(91, 97);
            this.enterB.Name = "enterB";
            this.enterB.Size = new System.Drawing.Size(101, 49);
            this.enterB.TabIndex = 42;
            this.enterB.Text = "[Enter] Ввод";
            this.enterB.UseVisualStyleBackColor = true;
            // 
            // DiscountOnReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 153);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.enterB);
            this.Controls.Add(this.numberDiscountCardRB);
            this.Controls.Add(this.discountProcentRB);
            this.Controls.Add(this.discountCardNumberTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountOnReceipt";
            this.Text = "Скидка на чек";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox discountCardNumberTB;
        private System.Windows.Forms.RadioButton discountProcentRB;
        private System.Windows.Forms.RadioButton numberDiscountCardRB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button enterB;
    }
}