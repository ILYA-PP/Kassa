namespace KassaApp
{
    partial class EditProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.discountTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.editProductB = new System.Windows.Forms.Button();
            this.countNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.countB = new System.Windows.Forms.Button();
            this.discountB = new System.Windows.Forms.Button();
            this.departmentB = new System.Windows.Forms.Button();
            this.departmentNUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.receiptDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // discountTB
            // 
            this.discountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountTB.Location = new System.Drawing.Point(12, 187);
            this.discountTB.Name = "discountTB";
            this.discountTB.Size = new System.Drawing.Size(173, 26);
            this.discountTB.TabIndex = 29;
            this.discountTB.Text = "0.00";
            this.discountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discountTB.TextChanged += new System.EventHandler(this.textBoxs_TextChange);
            this.discountTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigit_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Скидка";
            // 
            // editProductB
            // 
            this.editProductB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProductB.Location = new System.Drawing.Point(216, 244);
            this.editProductB.Name = "editProductB";
            this.editProductB.Size = new System.Drawing.Size(117, 30);
            this.editProductB.TabIndex = 27;
            this.editProductB.Text = "Ввод";
            this.editProductB.UseVisualStyleBackColor = true;
            this.editProductB.Click += new System.EventHandler(this.EditProductB_Click);
            // 
            // countNUD
            // 
            this.countNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countNUD.Location = new System.Drawing.Point(12, 122);
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
            this.countNUD.ValueChanged += new System.EventHandler(this.textBoxs_TextChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество";
            // 
            // countB
            // 
            this.countB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countB.Location = new System.Drawing.Point(192, 113);
            this.countB.Name = "countB";
            this.countB.Size = new System.Drawing.Size(97, 45);
            this.countB.TabIndex = 33;
            this.countB.Text = "[*] Количество";
            this.countB.UseVisualStyleBackColor = true;
            // 
            // discountB
            // 
            this.discountB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountB.Location = new System.Drawing.Point(192, 179);
            this.discountB.Name = "discountB";
            this.discountB.Size = new System.Drawing.Size(97, 45);
            this.discountB.TabIndex = 34;
            this.discountB.Text = "[F10] Скидка";
            this.discountB.UseVisualStyleBackColor = true;
            // 
            // departmentB
            // 
            this.departmentB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentB.Location = new System.Drawing.Point(578, 123);
            this.departmentB.Name = "departmentB";
            this.departmentB.Size = new System.Drawing.Size(97, 45);
            this.departmentB.TabIndex = 39;
            this.departmentB.Text = "[F9] Отдел";
            this.departmentB.UseVisualStyleBackColor = true;
            // 
            // departmentNUD
            // 
            this.departmentNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentNUD.Location = new System.Drawing.Point(399, 132);
            this.departmentNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.departmentNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.departmentNUD.Name = "departmentNUD";
            this.departmentNUD.Size = new System.Drawing.Size(173, 26);
            this.departmentNUD.TabIndex = 38;
            this.departmentNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.departmentNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(398, 109);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.discountCol,
            this.ndsCol,
            this.sumCol});
            this.receiptDGV.Location = new System.Drawing.Point(12, 12);
            this.receiptDGV.Name = "receiptDGV";
            this.receiptDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.receiptDGV.RowHeadersVisible = false;
            this.receiptDGV.Size = new System.Drawing.Size(663, 84);
            this.receiptDGV.TabIndex = 40;
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nameCol.HeaderText = "Наименование";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 147;
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
            // discountCol
            // 
            this.discountCol.HeaderText = "Скидка";
            this.discountCol.Name = "discountCol";
            this.discountCol.ReadOnly = true;
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
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(339, 244);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(117, 30);
            this.cancelB.TabIndex = 41;
            this.cancelB.Text = "Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(687, 287);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.receiptDGV);
            this.Controls.Add(this.departmentB);
            this.Controls.Add(this.departmentNUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.discountB);
            this.Controls.Add(this.countB);
            this.Controls.Add(this.discountTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editProductB);
            this.Controls.Add(this.countNUD);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProduct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменить позицию";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditProduct_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox discountTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button editProductB;
        private System.Windows.Forms.NumericUpDown countNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button countB;
        private System.Windows.Forms.Button discountB;
        private System.Windows.Forms.Button departmentB;
        private System.Windows.Forms.NumericUpDown departmentNUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView receiptDGV;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCol;
    }
}