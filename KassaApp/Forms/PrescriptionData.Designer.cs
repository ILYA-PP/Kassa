
namespace KassaApp.Forms
{
    partial class PrescriptionData
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
            this.seriesTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numberTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.cancelB = new System.Windows.Forms.Button();
            this.editProductB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // seriesTB
            // 
            this.seriesTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriesTB.Location = new System.Drawing.Point(13, 48);
            this.seriesTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.seriesTB.Name = "seriesTB";
            this.seriesTB.Size = new System.Drawing.Size(460, 35);
            this.seriesTB.TabIndex = 31;
            this.seriesTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(13, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 29);
            this.label8.TabIndex = 30;
            this.label8.Text = "Серия";
            // 
            // numberTB
            // 
            this.numberTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTB.Location = new System.Drawing.Point(13, 142);
            this.numberTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numberTB.Name = "numberTB";
            this.numberTB.Size = new System.Drawing.Size(460, 35);
            this.numberTB.TabIndex = 33;
            this.numberTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = "Номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "Дата";
            // 
            // dateDTP
            // 
            this.dateDTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateDTP.Location = new System.Drawing.Point(13, 249);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(460, 35);
            this.dateDTP.TabIndex = 35;
            // 
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(243, 307);
            this.cancelB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(176, 46);
            this.cancelB.TabIndex = 43;
            this.cancelB.Text = "Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // editProductB
            // 
            this.editProductB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProductB.Location = new System.Drawing.Point(59, 307);
            this.editProductB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editProductB.Name = "editProductB";
            this.editProductB.Size = new System.Drawing.Size(176, 46);
            this.editProductB.TabIndex = 42;
            this.editProductB.Text = "Ввод";
            this.editProductB.UseVisualStyleBackColor = true;
            this.editProductB.Click += new System.EventHandler(this.editProductB_Click);
            // 
            // PrescriptionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 367);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.editProductB);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seriesTB);
            this.Controls.Add(this.label8);
            this.Name = "PrescriptionData";
            this.ShowIcon = false;
            this.Text = "Данные рецепта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox seriesTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numberTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDTP;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button editProductB;
    }
}