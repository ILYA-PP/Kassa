namespace KassaApp.Forms
{
    partial class Recovery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.totalL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.receiptDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.paidB = new System.Windows.Forms.Button();
            this.notPaidB = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.totalL, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.receiptDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalL.Location = new System.Drawing.Point(3, 220);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(702, 30);
            this.totalL.TabIndex = 12;
            this.totalL.Text = "Итог по чеку:";
            this.totalL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Данный чек не был отмечен, как оплаченный! Чек оплачен?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // receiptDGV
            // 
            this.receiptDGV.AllowUserToAddRows = false;
            this.receiptDGV.AllowUserToDeleteRows = false;
            this.receiptDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.receiptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.countCol,
            this.priceCol,
            this.discountCol,
            this.ndsCol,
            this.sumCol});
            this.receiptDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptDGV.Location = new System.Drawing.Point(3, 33);
            this.receiptDGV.Name = "receiptDGV";
            this.receiptDGV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.receiptDGV.Size = new System.Drawing.Size(702, 184);
            this.receiptDGV.TabIndex = 10;
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
            this.ndsCol.Visible = false;
            // 
            // sumCol
            // 
            this.sumCol.HeaderText = "Сумма";
            this.sumCol.Name = "sumCol";
            this.sumCol.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.paidB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.notPaidB, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 253);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(702, 44);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // paidB
            // 
            this.paidB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paidB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paidB.Location = new System.Drawing.Point(465, 3);
            this.paidB.Name = "paidB";
            this.paidB.Size = new System.Drawing.Size(114, 38);
            this.paidB.TabIndex = 0;
            this.paidB.Text = "Оплачен";
            this.paidB.UseVisualStyleBackColor = true;
            this.paidB.Click += new System.EventHandler(this.paidB_Click);
            // 
            // notPaidB
            // 
            this.notPaidB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notPaidB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notPaidB.Location = new System.Drawing.Point(585, 3);
            this.notPaidB.Name = "notPaidB";
            this.notPaidB.Size = new System.Drawing.Size(114, 38);
            this.notPaidB.TabIndex = 1;
            this.notPaidB.Text = "Не оплачен";
            this.notPaidB.UseVisualStyleBackColor = true;
            this.notPaidB.Click += new System.EventHandler(this.notPaidB_Click);
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "Recovery";
            this.ShowInTaskbar = false;
            this.Text = "Восстановление";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView receiptDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCol;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button paidB;
        private System.Windows.Forms.Button notPaidB;
    }
}