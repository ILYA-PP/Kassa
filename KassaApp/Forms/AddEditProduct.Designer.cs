namespace KassaApp
{
    partial class AddEditProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ndsTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.discountTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addProductB = new System.Windows.Forms.Button();
            this.countNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.priceTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.countB = new System.Windows.Forms.Button();
            this.discountB = new System.Windows.Forms.Button();
            this.priceB = new System.Windows.Forms.Button();
            this.ndsB = new System.Windows.Forms.Button();
            this.departmentB = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.receiptDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ndsTB
            // 
            this.ndsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ndsTB.Location = new System.Drawing.Point(295, 156);
            this.ndsTB.Name = "ndsTB";
            this.ndsTB.Size = new System.Drawing.Size(173, 26);
            this.ndsTB.TabIndex = 32;
            this.ndsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ndsTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(295, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "НДС";
            // 
            // discountTB
            // 
            this.discountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountTB.Location = new System.Drawing.Point(12, 156);
            this.discountTB.Name = "discountTB";
            this.discountTB.Size = new System.Drawing.Size(173, 26);
            this.discountTB.TabIndex = 29;
            this.discountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discountTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Скидка";
            // 
            // addProductB
            // 
            this.addProductB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductB.Location = new System.Drawing.Point(162, 367);
            this.addProductB.Name = "addProductB";
            this.addProductB.Size = new System.Drawing.Size(117, 30);
            this.addProductB.TabIndex = 27;
            this.addProductB.Text = "Ввод";
            this.addProductB.UseVisualStyleBackColor = true;
            this.addProductB.Click += new System.EventHandler(this.addProductB_Click);
            // 
            // countNUD
            // 
            this.countNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countNUD.Location = new System.Drawing.Point(12, 91);
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
            this.countNUD.Size = new System.Drawing.Size(173, 26);
            this.countNUD.TabIndex = 24;
            this.countNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество";
            // 
            // priceTB
            // 
            this.priceTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTB.Location = new System.Drawing.Point(295, 91);
            this.priceTB.Name = "priceTB";
            this.priceTB.Size = new System.Drawing.Size(173, 26);
            this.priceTB.TabIndex = 22;
            this.priceTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(295, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Цена";
            // 
            // nameTB
            // 
            this.nameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTB.Location = new System.Drawing.Point(12, 35);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(456, 26);
            this.nameTB.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Наименование товара/услуги";
            // 
            // countB
            // 
            this.countB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countB.Location = new System.Drawing.Point(192, 82);
            this.countB.Name = "countB";
            this.countB.Size = new System.Drawing.Size(97, 45);
            this.countB.TabIndex = 33;
            this.countB.Text = "[*] Количество";
            this.countB.UseVisualStyleBackColor = true;
            // 
            // discountB
            // 
            this.discountB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountB.Location = new System.Drawing.Point(192, 148);
            this.discountB.Name = "discountB";
            this.discountB.Size = new System.Drawing.Size(97, 45);
            this.discountB.TabIndex = 34;
            this.discountB.Text = "[F10] Скидка";
            this.discountB.UseVisualStyleBackColor = true;
            // 
            // priceB
            // 
            this.priceB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceB.Location = new System.Drawing.Point(474, 82);
            this.priceB.Name = "priceB";
            this.priceB.Size = new System.Drawing.Size(97, 45);
            this.priceB.TabIndex = 35;
            this.priceB.Text = "[F8] Цена";
            this.priceB.UseVisualStyleBackColor = true;
            // 
            // ndsB
            // 
            this.ndsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ndsB.Location = new System.Drawing.Point(474, 148);
            this.ndsB.Name = "ndsB";
            this.ndsB.Size = new System.Drawing.Size(97, 45);
            this.ndsB.TabIndex = 36;
            this.ndsB.Text = "[F7] НДС";
            this.ndsB.UseVisualStyleBackColor = true;
            // 
            // departmentB
            // 
            this.departmentB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentB.Location = new System.Drawing.Point(192, 215);
            this.departmentB.Name = "departmentB";
            this.departmentB.Size = new System.Drawing.Size(97, 45);
            this.departmentB.TabIndex = 39;
            this.departmentB.Text = "[F9] Отдел";
            this.departmentB.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(12, 224);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(173, 26);
            this.numericUpDown1.TabIndex = 38;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Отдел";
            // 
            // receiptDGV
            // 
            this.receiptDGV.AllowUserToAddRows = false;
            this.receiptDGV.AllowUserToDeleteRows = false;
            this.receiptDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.receiptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.countCol,
            this.priceCol,
            this.saleCol,
            this.ndsCol,
            this.sumCol});
            this.receiptDGV.Location = new System.Drawing.Point(12, 266);
            this.receiptDGV.Name = "receiptDGV";
            this.receiptDGV.ReadOnly = true;
            this.receiptDGV.RowHeadersVisible = false;
            this.receiptDGV.Size = new System.Drawing.Size(552, 84);
            this.receiptDGV.TabIndex = 40;
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
            // sumCol
            // 
            this.sumCol.HeaderText = "Сумма";
            this.sumCol.Name = "sumCol";
            this.sumCol.ReadOnly = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(297, 367);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 30);
            this.button6.TabIndex = 41;
            this.button6.Text = "Отмена";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AddEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 410);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.receiptDGV);
            this.Controls.Add(this.departmentB);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ndsB);
            this.Controls.Add(this.priceB);
            this.Controls.Add(this.discountB);
            this.Controls.Add(this.countB);
            this.Controls.Add(this.ndsTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.discountTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addProductB);
            this.Controls.Add(this.countNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label1);
            this.Name = "AddEditProduct";
            this.Text = "Добавить/Изменить позицию";
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ndsTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox discountTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addProductB;
        private System.Windows.Forms.NumericUpDown countNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox priceTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button countB;
        private System.Windows.Forms.Button discountB;
        private System.Windows.Forms.Button priceB;
        private System.Windows.Forms.Button ndsB;
        private System.Windows.Forms.Button departmentB;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView receiptDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCol;
        private System.Windows.Forms.Button button6;
    }
}