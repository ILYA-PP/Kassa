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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.receiptDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountOnReceiptB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nonDiscountTB = new System.Windows.Forms.TextBox();
            this.discountTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameL = new System.Windows.Forms.Label();
            this.summL = new System.Windows.Forms.Label();
            this.additDataL = new System.Windows.Forms.Label();
            this.shtrihB = new System.Windows.Forms.Button();
            this.nameB = new System.Windows.Forms.Button();
            this.priceB = new System.Windows.Forms.Button();
            this.svPriceB = new System.Windows.Forms.Button();
            this.searchB = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.boxB = new System.Windows.Forms.Button();
            this.paymentB = new System.Windows.Forms.Button();
            this.editB = new System.Windows.Forms.Button();
            this.reserveB = new System.Windows.Forms.Button();
            this.additInfoB = new System.Windows.Forms.Button();
            this.departmentL = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resultL = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.timeTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
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
            this.receiptDGV.Location = new System.Drawing.Point(3, 190);
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
            this.receiptDGV.Size = new System.Drawing.Size(1083, 295);
            this.receiptDGV.TabIndex = 9;
            this.receiptDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.receiptDGV_CellValueChanged);
            this.receiptDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.receiptDGV_RowsAdded);
            this.receiptDGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.receiptDGV_RowsRemoved);
            this.receiptDGV.SelectionChanged += new System.EventHandler(this.receiptDGV_SelectionChanged);
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
            // 
            // sumCol
            // 
            this.sumCol.HeaderText = "Сумма";
            this.sumCol.Name = "sumCol";
            this.sumCol.ReadOnly = true;
            // 
            // discountOnReceiptB
            // 
            this.discountOnReceiptB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discountOnReceiptB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountOnReceiptB.Location = new System.Drawing.Point(3, 3);
            this.discountOnReceiptB.Name = "discountOnReceiptB";
            this.discountOnReceiptB.Size = new System.Drawing.Size(208, 46);
            this.discountOnReceiptB.TabIndex = 19;
            this.discountOnReceiptB.Text = "[F10]  Скидка на чек";
            this.discountOnReceiptB.UseVisualStyleBackColor = true;
            this.discountOnReceiptB.Click += new System.EventHandler(this.discountOnReceiptB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Без скидки:";
            // 
            // nonDiscountTB
            // 
            this.nonDiscountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nonDiscountTB.Location = new System.Drawing.Point(3, 26);
            this.nonDiscountTB.Name = "nonDiscountTB";
            this.nonDiscountTB.ReadOnly = true;
            this.nonDiscountTB.Size = new System.Drawing.Size(180, 22);
            this.nonDiscountTB.TabIndex = 21;
            this.nonDiscountTB.Text = "0.00";
            this.nonDiscountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discountTB
            // 
            this.discountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountTB.Location = new System.Drawing.Point(3, 26);
            this.discountTB.Name = "discountTB";
            this.discountTB.ReadOnly = true;
            this.discountTB.Size = new System.Drawing.Size(180, 22);
            this.discountTB.TabIndex = 23;
            this.discountTB.Text = "0.00";
            this.discountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Скидка:";
            // 
            // nameL
            // 
            this.nameL.AutoSize = true;
            this.nameL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameL.Location = new System.Drawing.Point(3, 0);
            this.nameL.Name = "nameL";
            this.nameL.Size = new System.Drawing.Size(0, 16);
            this.nameL.TabIndex = 24;
            // 
            // summL
            // 
            this.summL.AutoSize = true;
            this.summL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summL.Location = new System.Drawing.Point(3, 30);
            this.summL.Name = "summL";
            this.summL.Size = new System.Drawing.Size(0, 16);
            this.summL.TabIndex = 25;
            // 
            // additDataL
            // 
            this.additDataL.AutoSize = true;
            this.additDataL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additDataL.Location = new System.Drawing.Point(3, 60);
            this.additDataL.Name = "additDataL";
            this.additDataL.Size = new System.Drawing.Size(0, 16);
            this.additDataL.TabIndex = 26;
            // 
            // shtrihB
            // 
            this.shtrihB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shtrihB.Enabled = false;
            this.shtrihB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shtrihB.Location = new System.Drawing.Point(3, 3);
            this.shtrihB.Name = "shtrihB";
            this.shtrihB.Size = new System.Drawing.Size(114, 52);
            this.shtrihB.TabIndex = 28;
            this.shtrihB.Text = "[F1]  Штрих-код";
            this.shtrihB.UseVisualStyleBackColor = true;
            // 
            // nameB
            // 
            this.nameB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameB.Location = new System.Drawing.Point(123, 3);
            this.nameB.Name = "nameB";
            this.nameB.Size = new System.Drawing.Size(114, 52);
            this.nameB.TabIndex = 29;
            this.nameB.Text = "[F3]  Название";
            this.nameB.UseVisualStyleBackColor = true;
            // 
            // priceB
            // 
            this.priceB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceB.Location = new System.Drawing.Point(243, 3);
            this.priceB.Name = "priceB";
            this.priceB.Size = new System.Drawing.Size(114, 52);
            this.priceB.TabIndex = 30;
            this.priceB.Text = "[F4]  Цена";
            this.priceB.UseVisualStyleBackColor = true;
            // 
            // svPriceB
            // 
            this.svPriceB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.svPriceB.Enabled = false;
            this.svPriceB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.svPriceB.Location = new System.Drawing.Point(363, 3);
            this.svPriceB.Name = "svPriceB";
            this.svPriceB.Size = new System.Drawing.Size(114, 52);
            this.svPriceB.TabIndex = 31;
            this.svPriceB.Text = "[F5]  Св. цена";
            this.svPriceB.UseVisualStyleBackColor = true;
            // 
            // searchB
            // 
            this.searchB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchB.Location = new System.Drawing.Point(483, 3);
            this.searchB.Name = "searchB";
            this.searchB.Size = new System.Drawing.Size(114, 52);
            this.searchB.TabIndex = 32;
            this.searchB.Text = "[F6]  Поиск";
            this.searchB.UseVisualStyleBackColor = true;
            this.searchB.Click += new System.EventHandler(this.searchB_Click);
            // 
            // deleteB
            // 
            this.deleteB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteB.Location = new System.Drawing.Point(723, 3);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(114, 52);
            this.deleteB.TabIndex = 33;
            this.deleteB.Text = "[Del]  Удалить";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // boxB
            // 
            this.boxB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxB.Enabled = false;
            this.boxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boxB.Location = new System.Drawing.Point(843, 3);
            this.boxB.Name = "boxB";
            this.boxB.Size = new System.Drawing.Size(114, 52);
            this.boxB.TabIndex = 34;
            this.boxB.Text = "[F11]  Ящик";
            this.boxB.UseVisualStyleBackColor = true;
            // 
            // paymentB
            // 
            this.paymentB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paymentB.Location = new System.Drawing.Point(963, 3);
            this.paymentB.Name = "paymentB";
            this.paymentB.Size = new System.Drawing.Size(117, 52);
            this.paymentB.TabIndex = 35;
            this.paymentB.Text = "[F12]  Оплата";
            this.paymentB.UseVisualStyleBackColor = true;
            this.paymentB.Click += new System.EventHandler(this.paymentB_Click);
            // 
            // editB
            // 
            this.editB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editB.Location = new System.Drawing.Point(603, 3);
            this.editB.Name = "editB";
            this.editB.Size = new System.Drawing.Size(114, 52);
            this.editB.TabIndex = 36;
            this.editB.Text = "[F9] Изменить";
            this.editB.UseVisualStyleBackColor = true;
            this.editB.Click += new System.EventHandler(this.editB_Click);
            // 
            // reserveB
            // 
            this.reserveB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reserveB.Enabled = false;
            this.reserveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reserveB.Location = new System.Drawing.Point(3, 3);
            this.reserveB.Name = "reserveB";
            this.reserveB.Size = new System.Drawing.Size(115, 55);
            this.reserveB.TabIndex = 37;
            this.reserveB.Text = "[Ins]  Резерв";
            this.reserveB.UseVisualStyleBackColor = true;
            // 
            // additInfoB
            // 
            this.additInfoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additInfoB.Enabled = false;
            this.additInfoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additInfoB.Location = new System.Drawing.Point(124, 3);
            this.additInfoB.Name = "additInfoB";
            this.additInfoB.Size = new System.Drawing.Size(116, 55);
            this.additInfoB.TabIndex = 38;
            this.additInfoB.Text = "[F8] Доп.инф.";
            this.additInfoB.UseVisualStyleBackColor = true;
            // 
            // departmentL
            // 
            this.departmentL.AutoSize = true;
            this.departmentL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentL.Location = new System.Drawing.Point(180, 30);
            this.departmentL.Name = "departmentL";
            this.departmentL.Size = new System.Drawing.Size(0, 16);
            this.departmentL.TabIndex = 39;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.resultL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.receiptDGV, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.940397F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.35762F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.72848F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.602649F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1089, 654);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // resultL
            // 
            this.resultL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultL.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultL.Location = new System.Drawing.Point(3, 0);
            this.resultL.Name = "resultL";
            this.resultL.Size = new System.Drawing.Size(1083, 129);
            this.resultL.TabIndex = 13;
            this.resultL.Text = "0.00";
            this.resultL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.82628F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.79003F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.38368F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.discountOnReceiptB, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 132);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1083, 52);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.nonDiscountTB, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(217, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(500, 46);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.discountTB, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(723, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(357, 46);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.41367F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.34534F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 491);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1083, 96);
            this.tableLayoutPanel5.TabIndex = 15;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.timeTB, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(840, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.66667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(243, 96);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.additInfoB, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.reserveB, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(243, 61);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // timeTB
            // 
            this.timeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeTB.Location = new System.Drawing.Point(3, 3);
            this.timeTB.Name = "timeTB";
            this.timeTB.ReadOnly = true;
            this.timeTB.Size = new System.Drawing.Size(237, 24);
            this.timeTB.TabIndex = 1;
            this.timeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.departmentL, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.nameL, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.summL, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.additDataL, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(354, 90);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 9;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel9.Controls.Add(this.paymentB, 8, 0);
            this.tableLayoutPanel9.Controls.Add(this.shtrihB, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.nameB, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.priceB, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.svPriceB, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.searchB, 4, 0);
            this.tableLayoutPanel9.Controls.Add(this.editB, 5, 0);
            this.tableLayoutPanel9.Controls.Add(this.boxB, 7, 0);
            this.tableLayoutPanel9.Controls.Add(this.deleteB, 6, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 593);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1083, 58);
            this.tableLayoutPanel9.TabIndex = 16;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1089, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Главная";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.receiptDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button discountOnReceiptB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nonDiscountTB;
        private System.Windows.Forms.TextBox discountTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nameL;
        private System.Windows.Forms.Label summL;
        private System.Windows.Forms.Label additDataL;
        private System.Windows.Forms.Button shtrihB;
        private System.Windows.Forms.Button nameB;
        private System.Windows.Forms.Button priceB;
        private System.Windows.Forms.Button svPriceB;
        private System.Windows.Forms.Button searchB;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button boxB;
        private System.Windows.Forms.Button paymentB;
        private System.Windows.Forms.Button editB;
        private System.Windows.Forms.Button reserveB;
        private System.Windows.Forms.Button additInfoB;
        private System.Windows.Forms.Label departmentL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label resultL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        public System.Windows.Forms.DataGridView receiptDGV;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox timeTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCol;
    }
}