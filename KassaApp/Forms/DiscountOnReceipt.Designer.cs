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
            this.operationL = new System.Windows.Forms.Label();
            this.discountDataTB = new System.Windows.Forms.TextBox();
            this.discountProcentRB = new System.Windows.Forms.RadioButton();
            this.numberDiscountCardRB = new System.Windows.Forms.RadioButton();
            this.cancelB = new System.Windows.Forms.Button();
            this.enterB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operationL
            // 
            this.operationL.AutoSize = true;
            this.operationL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationL.Location = new System.Drawing.Point(11, 15);
            this.operationL.Name = "operationL";
            this.operationL.Size = new System.Drawing.Size(35, 20);
            this.operationL.TabIndex = 0;
            this.operationL.Text = "ДК:";
            // 
            // discountDataTB
            // 
            this.discountDataTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountDataTB.Location = new System.Drawing.Point(91, 12);
            this.discountDataTB.Name = "discountDataTB";
            this.discountDataTB.Size = new System.Drawing.Size(310, 26);
            this.discountDataTB.TabIndex = 1;
            // 
            // discountProcentRB
            // 
            this.discountProcentRB.AutoSize = true;
            this.discountProcentRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountProcentRB.Location = new System.Drawing.Point(15, 53);
            this.discountProcentRB.Name = "discountProcentRB";
            this.discountProcentRB.Size = new System.Drawing.Size(150, 24);
            this.discountProcentRB.TabIndex = 2;
            this.discountProcentRB.Text = "Процент скидки";
            this.discountProcentRB.UseVisualStyleBackColor = true;
            this.discountProcentRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // numberDiscountCardRB
            // 
            this.numberDiscountCardRB.AutoSize = true;
            this.numberDiscountCardRB.Checked = true;
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
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
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
            this.enterB.Click += new System.EventHandler(this.enterB_Click);
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
            this.Controls.Add(this.discountDataTB);
            this.Controls.Add(this.operationL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountOnReceipt";
            this.ShowIcon = false;
            this.Text = "Скидка на чек";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label operationL;
        private System.Windows.Forms.TextBox discountDataTB;
        private System.Windows.Forms.RadioButton discountProcentRB;
        private System.Windows.Forms.RadioButton numberDiscountCardRB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button enterB;
    }
}