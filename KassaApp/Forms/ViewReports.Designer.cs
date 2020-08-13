namespace KassaApp.Forms
{
    partial class ViewReports
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateSearchDTP = new System.Windows.Forms.DateTimePicker();
            this.reportTB = new System.Windows.Forms.TextBox();
            this.dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportsDGV = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.typeCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 37);
            this.label2.TabIndex = 49;
            this.label2.Text = "Дата:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateSearchDTP
            // 
            this.dateSearchDTP.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateSearchDTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateSearchDTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateSearchDTP.Location = new System.Drawing.Point(73, 3);
            this.dateSearchDTP.Name = "dateSearchDTP";
            this.dateSearchDTP.Size = new System.Drawing.Size(350, 26);
            this.dateSearchDTP.TabIndex = 50;
            this.dateSearchDTP.ValueChanged += new System.EventHandler(this.dateSearchDTP_ValueChanged);
            // 
            // reportTB
            // 
            this.reportTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportTB.Location = new System.Drawing.Point(441, 3);
            this.reportTB.Multiline = true;
            this.reportTB.Name = "reportTB";
            this.reportTB.ReadOnly = true;
            this.reportTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reportTB.Size = new System.Drawing.Size(432, 432);
            this.reportTB.TabIndex = 51;
            // 
            // dateCol
            // 
            this.dateCol.HeaderText = "Дата";
            this.dateCol.Name = "dateCol";
            this.dateCol.ReadOnly = true;
            // 
            // dataCol
            // 
            this.dataCol.HeaderText = "Отчёт";
            this.dataCol.Name = "dataCol";
            this.dataCol.ReadOnly = true;
            this.dataCol.Visible = false;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Наименование";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // reportsDGV
            // 
            this.reportsDGV.AllowUserToAddRows = false;
            this.reportsDGV.AllowUserToDeleteRows = false;
            this.reportsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.reportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.dataCol,
            this.dateCol});
            this.reportsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportsDGV.Location = new System.Drawing.Point(3, 83);
            this.reportsDGV.Name = "reportsDGV";
            this.reportsDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.reportsDGV.Size = new System.Drawing.Size(426, 346);
            this.reportsDGV.TabIndex = 52;
            this.reportsDGV.SelectionChanged += new System.EventHandler(this.reportsDGV_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.reportTB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 438);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.reportsDGV, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 432);
            this.tableLayoutPanel2.TabIndex = 52;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateSearchDTP, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.typeCB, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(426, 74);
            this.tableLayoutPanel3.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 37);
            this.label3.TabIndex = 51;
            this.label3.Text = "Тип:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // typeCB
            // 
            this.typeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Items.AddRange(new object[] {
            "",
            "X-отчёт (без гашения)",
            "X-отчёт по секциям",
            "X-отчёт по налогам",
            "Z-отчёт (c гашением)",
            "Операционные регистры",
            "Внесение наличных",
            "Выплата наличных",
            "Кассовый чек",
            "Чек терминала"});
            this.typeCB.Location = new System.Drawing.Point(73, 40);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(350, 28);
            this.typeCB.TabIndex = 52;
            this.typeCB.SelectedIndexChanged += new System.EventHandler(this.typeCB_SelectedIndexChanged);
            // 
            // ViewReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(876, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewReports";
            this.ShowIcon = false;
            this.Text = "Просмотр отчётов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewReports_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.reportsDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateSearchDTP;
        private System.Windows.Forms.TextBox reportTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridView reportsDGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeCB;
    }
}