﻿namespace KassaApp.Forms
{
    partial class ChooseProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.productsDGV = new System.Windows.Forms.DataGridView();
            this.cancelB = new System.Windows.Forms.Button();
            this.enterB = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.departmentNUD = new System.Windows.Forms.NumericUpDown();
            this.countNUD = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.barCodeL = new System.Windows.Forms.Label();
            this.infoL = new System.Windows.Forms.Label();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productsDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchTB
            // 
            this.searchTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTB.Location = new System.Drawing.Point(176, 5);
            this.searchTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(1012, 35);
            this.searchTB.TabIndex = 1;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // productsDGV
            // 
            this.productsDGV.AllowUserToAddRows = false;
            this.productsDGV.AllowUserToDeleteRows = false;
            this.productsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.productsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.nameCol,
            this.countCol,
            this.priceCol,
            this.discountCol,
            this.ndsCol,
            this.sumCol});
            this.productsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsDGV.Location = new System.Drawing.Point(4, 113);
            this.productsDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.productsDGV.MultiSelect = false;
            this.productsDGV.Name = "productsDGV";
            this.productsDGV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.productsDGV.RowHeadersWidth = 62;
            this.productsDGV.Size = new System.Drawing.Size(1192, 466);
            this.productsDGV.TabIndex = 0;
            this.productsDGV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.productsDGV_Scroll);
            this.productsDGV.SelectionChanged += new System.EventHandler(this.productsDGV_SelectionChanged);
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelB.Location = new System.Drawing.Point(1046, 5);
            this.cancelB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(142, 72);
            this.cancelB.TabIndex = 45;
            this.cancelB.Text = "[Esc] Отмена";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // enterB
            // 
            this.enterB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterB.Location = new System.Drawing.Point(896, 5);
            this.enterB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enterB.Name = "enterB";
            this.enterB.Size = new System.Drawing.Size(142, 72);
            this.enterB.TabIndex = 44;
            this.enterB.Text = "[Enter] Ввод";
            this.enterB.UseVisualStyleBackColor = true;
            this.enterB.Click += new System.EventHandler(this.enterB_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.productsDGV, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 768);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.departmentNUD, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.countNUD, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 59);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1192, 44);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 49);
            this.label2.TabIndex = 46;
            this.label2.Text = "Количество:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(356, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 49);
            this.label3.TabIndex = 48;
            this.label3.Text = "Отдел:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // departmentNUD
            // 
            this.departmentNUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentNUD.Location = new System.Drawing.Point(528, 5);
            this.departmentNUD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.departmentNUD.Size = new System.Drawing.Size(172, 35);
            this.departmentNUD.TabIndex = 49;
            this.departmentNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.departmentNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // countNUD
            // 
            this.countNUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countNUD.Location = new System.Drawing.Point(176, 5);
            this.countNUD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.countNUD.Size = new System.Drawing.Size(172, 35);
            this.countNUD.TabIndex = 47;
            this.countNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.searchTB, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1192, 44);
            this.tableLayoutPanel4.TabIndex = 43;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.enterB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cancelB, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 681);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1192, 82);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.barCodeL, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.infoL, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 589);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1192, 82);
            this.tableLayoutPanel3.TabIndex = 44;
            // 
            // barCodeL
            // 
            this.barCodeL.AutoSize = true;
            this.barCodeL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCodeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barCodeL.Location = new System.Drawing.Point(7, 3);
            this.barCodeL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.barCodeL.Name = "barCodeL";
            this.barCodeL.Size = new System.Drawing.Size(1178, 36);
            this.barCodeL.TabIndex = 30;
            this.barCodeL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoL
            // 
            this.infoL.AutoSize = true;
            this.infoL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoL.Location = new System.Drawing.Point(7, 42);
            this.infoL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoL.Name = "infoL";
            this.infoL.Size = new System.Drawing.Size(1178, 37);
            this.infoL.TabIndex = 31;
            this.infoL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idCol
            // 
            this.idCol.HeaderText = "ИД";
            this.idCol.MinimumWidth = 8;
            this.idCol.Name = "idCol";
            this.idCol.ReadOnly = true;
            this.idCol.Visible = false;
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nameCol.HeaderText = "Наименование";
            this.nameCol.MinimumWidth = 8;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 225;
            // 
            // countCol
            // 
            this.countCol.HeaderText = "Количество";
            this.countCol.MinimumWidth = 8;
            this.countCol.Name = "countCol";
            this.countCol.ReadOnly = true;
            // 
            // priceCol
            // 
            this.priceCol.HeaderText = "Цена";
            this.priceCol.MinimumWidth = 8;
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // discountCol
            // 
            this.discountCol.HeaderText = "Скидка";
            this.discountCol.MinimumWidth = 8;
            this.discountCol.Name = "discountCol";
            this.discountCol.ReadOnly = true;
            this.discountCol.Visible = false;
            // 
            // ndsCol
            // 
            this.ndsCol.HeaderText = "НДС";
            this.ndsCol.MinimumWidth = 8;
            this.ndsCol.Name = "ndsCol";
            this.ndsCol.ReadOnly = true;
            this.ndsCol.Visible = false;
            // 
            // sumCol
            // 
            this.sumCol.HeaderText = "Сумма";
            this.sumCol.MinimumWidth = 8;
            this.sumCol.Name = "sumCol";
            this.sumCol.ReadOnly = true;
            this.sumCol.Visible = false;
            // 
            // ChooseProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(1200, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "ChooseProduct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Выбрать продукт";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.productsDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.DataGridView productsDGV;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button enterB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown countNUD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown departmentNUD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label barCodeL;
        private System.Windows.Forms.Label infoL;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCol;
    }
}