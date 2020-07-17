namespace KassaApp.Forms
{
    partial class ViewRegistarers
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cashRegLB = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationRegLB = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.readOperationRegB = new System.Windows.Forms.Button();
            this.readCashRegB = new System.Windows.Forms.Button();
            this.printOperationRegB = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(817, 483);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cashRegLB);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Денежные регистры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cashRegLB
            // 
            this.cashRegLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashRegLB.FormattingEnabled = true;
            this.cashRegLB.ItemHeight = 20;
            this.cashRegLB.Location = new System.Drawing.Point(3, 3);
            this.cashRegLB.Name = "cashRegLB";
            this.cashRegLB.Size = new System.Drawing.Size(803, 444);
            this.cashRegLB.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.operationRegLB);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Операционные регистры";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // operationRegLB
            // 
            this.operationRegLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationRegLB.FormattingEnabled = true;
            this.operationRegLB.ItemHeight = 20;
            this.operationRegLB.Location = new System.Drawing.Point(3, 3);
            this.operationRegLB.Name = "operationRegLB";
            this.operationRegLB.Size = new System.Drawing.Size(803, 444);
            this.operationRegLB.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.888889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(823, 537);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.readOperationRegB, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.readCashRegB, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.printOperationRegB, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 492);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(817, 42);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // readOperationRegB
            // 
            this.readOperationRegB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readOperationRegB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readOperationRegB.Location = new System.Drawing.Point(547, 3);
            this.readOperationRegB.Name = "readOperationRegB";
            this.readOperationRegB.Size = new System.Drawing.Size(267, 36);
            this.readOperationRegB.TabIndex = 0;
            this.readOperationRegB.Text = "Прочитать операционные регистры";
            this.readOperationRegB.UseVisualStyleBackColor = true;
            this.readOperationRegB.Click += new System.EventHandler(this.readOperationRegB_Click);
            // 
            // readCashRegB
            // 
            this.readCashRegB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readCashRegB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readCashRegB.Location = new System.Drawing.Point(275, 3);
            this.readCashRegB.Name = "readCashRegB";
            this.readCashRegB.Size = new System.Drawing.Size(266, 36);
            this.readCashRegB.TabIndex = 1;
            this.readCashRegB.Text = "Прочитать денежные регистры";
            this.readCashRegB.UseVisualStyleBackColor = true;
            this.readCashRegB.Click += new System.EventHandler(this.readCashRegB_Click);
            // 
            // printOperationRegB
            // 
            this.printOperationRegB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printOperationRegB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printOperationRegB.Location = new System.Drawing.Point(3, 3);
            this.printOperationRegB.Name = "printOperationRegB";
            this.printOperationRegB.Size = new System.Drawing.Size(266, 36);
            this.printOperationRegB.TabIndex = 2;
            this.printOperationRegB.Text = "Печать операционных регистров";
            this.printOperationRegB.UseVisualStyleBackColor = true;
            this.printOperationRegB.Click += new System.EventHandler(this.printOperationRegB_Click);
            // 
            // ViewRegistarers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewRegistarers";
            this.ShowIcon = false;
            this.Text = "Показания регистров";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button readOperationRegB;
        private System.Windows.Forms.Button readCashRegB;
        private System.Windows.Forms.Button printOperationRegB;
        private System.Windows.Forms.ListBox cashRegLB;
        private System.Windows.Forms.ListBox operationRegLB;
    }
}