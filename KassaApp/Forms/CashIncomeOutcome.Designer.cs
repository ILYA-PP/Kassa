namespace KassaApp.Forms
{
    partial class CashIncomeOutcome
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
            this.summaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enterB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operationL
            // 
            this.operationL.AutoSize = true;
            this.operationL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationL.Location = new System.Drawing.Point(12, 9);
            this.operationL.Name = "operationL";
            this.operationL.Size = new System.Drawing.Size(0, 25);
            this.operationL.TabIndex = 0;
            // 
            // summaTB
            // 
            this.summaTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summaTB.Location = new System.Drawing.Point(80, 52);
            this.summaTB.Name = "summaTB";
            this.summaTB.Size = new System.Drawing.Size(327, 26);
            this.summaTB.TabIndex = 4;
            this.summaTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.summaTB_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сумма:";
            // 
            // enterB
            // 
            this.enterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterB.Location = new System.Drawing.Point(118, 97);
            this.enterB.Name = "enterB";
            this.enterB.Size = new System.Drawing.Size(91, 52);
            this.enterB.TabIndex = 6;
            this.enterB.Text = "[Enter] Ввод";
            this.enterB.UseVisualStyleBackColor = true;
            this.enterB.Click += new System.EventHandler(this.enterB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(215, 97);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(91, 52);
            this.cancelB.TabIndex = 7;
            this.cancelB.Text = "[Esc] Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // CashIncomeOutcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 161);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.enterB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.summaTB);
            this.Controls.Add(this.operationL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashIncomeOutcome";
            this.ShowIcon = false;
            this.Text = "Внесение/Выплата наличных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label operationL;
        private System.Windows.Forms.TextBox summaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enterB;
        private System.Windows.Forms.Button cancelB;
    }
}