namespace KassaApp
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.priceTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.countNUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addProductB = new System.Windows.Forms.Button();
            this.receiptDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultL = new System.Windows.Forms.Label();
            this.payB = new System.Windows.Forms.Button();
            this.saleTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ndsTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование товара/услуги";
            // 
            // nameTB
            // 
            this.nameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTB.Location = new System.Drawing.Point(12, 32);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(385, 26);
            this.nameTB.TabIndex = 1;
            // 
            // priceTB
            // 
            this.priceTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTB.Location = new System.Drawing.Point(12, 154);
            this.priceTB.Name = "priceTB";
            this.priceTB.Size = new System.Drawing.Size(341, 26);
            this.priceTB.TabIndex = 3;
            this.priceTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество";
            // 
            // countNUD
            // 
            this.countNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countNUD.Location = new System.Drawing.Point(12, 93);
            this.countNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countNUD.Name = "countNUD";
            this.countNUD.Size = new System.Drawing.Size(344, 26);
            this.countNUD.TabIndex = 5;
            this.countNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(362, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "шт.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(359, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "руб.";
            // 
            // addProductB
            // 
            this.addProductB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductB.Location = new System.Drawing.Point(541, 152);
            this.addProductB.Name = "addProductB";
            this.addProductB.Size = new System.Drawing.Size(117, 30);
            this.addProductB.TabIndex = 8;
            this.addProductB.Text = "Добавить";
            this.addProductB.UseVisualStyleBackColor = true;
            this.addProductB.Click += new System.EventHandler(this.addProductB_Click);
            // 
            // receiptDGV
            // 
            this.receiptDGV.AllowUserToAddRows = false;
            this.receiptDGV.AllowUserToDeleteRows = false;
            this.receiptDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.receiptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.countCol,
            this.priceCol,
            this.saleCol,
            this.ndsCol});
            this.receiptDGV.Location = new System.Drawing.Point(12, 208);
            this.receiptDGV.Name = "receiptDGV";
            this.receiptDGV.ReadOnly = true;
            this.receiptDGV.RowHeadersVisible = false;
            this.receiptDGV.Size = new System.Drawing.Size(777, 193);
            this.receiptDGV.TabIndex = 9;
            this.receiptDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.receiptDGV_RowsAdded);
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Наименование";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // countCol
            // 
            this.countCol.HeaderText = "Количество";
            this.countCol.Name = "countCol";
            this.countCol.ReadOnly = true;
            // 
            // priceCol
            // 
            this.priceCol.HeaderText = "Цена";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // saleCol
            // 
            this.saleCol.HeaderText = "Скидка";
            this.saleCol.Name = "saleCol";
            this.saleCol.ReadOnly = true;
            // 
            // ndsCol
            // 
            this.ndsCol.HeaderText = "НДС";
            this.ndsCol.Name = "ndsCol";
            this.ndsCol.ReadOnly = true;
            // 
            // resultL
            // 
            this.resultL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultL.Location = new System.Drawing.Point(12, 413);
            this.resultL.Name = "resultL";
            this.resultL.Size = new System.Drawing.Size(628, 20);
            this.resultL.TabIndex = 11;
            this.resultL.Text = "ИТОГО: 0 руб.";
            this.resultL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // payB
            // 
            this.payB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payB.Location = new System.Drawing.Point(671, 408);
            this.payB.Name = "payB";
            this.payB.Size = new System.Drawing.Size(117, 30);
            this.payB.TabIndex = 12;
            this.payB.Text = "Оплата";
            this.payB.UseVisualStyleBackColor = true;
            this.payB.Click += new System.EventHandler(this.payB_Click);
            // 
            // saleTB
            // 
            this.saleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saleTB.Location = new System.Drawing.Point(419, 32);
            this.saleTB.Name = "saleTB";
            this.saleTB.Size = new System.Drawing.Size(341, 26);
            this.saleTB.TabIndex = 14;
            this.saleTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.saleTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(419, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Скидка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(766, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "%";
            // 
            // ndsTB
            // 
            this.ndsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ndsTB.Location = new System.Drawing.Point(419, 93);
            this.ndsTB.Name = "ndsTB";
            this.ndsTB.Size = new System.Drawing.Size(341, 26);
            this.ndsTB.TabIndex = 17;
            this.ndsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ndsTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(419, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "НДС";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(765, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "%";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ndsTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.saleTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.payB);
            this.Controls.Add(this.resultL);
            this.Controls.Add(this.receiptDGV);
            this.Controls.Add(this.addProductB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox priceTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown countNUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addProductB;
        private System.Windows.Forms.DataGridView receiptDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.Label resultL;
        private System.Windows.Forms.Button payB;
        private System.Windows.Forms.TextBox saleTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ndsTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}