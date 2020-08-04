namespace KassaApp
{
    partial class Menu
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
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.регистрацияПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хотчётбезГашенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хотчётПоСекциямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хотчётПоНалогамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zотчётсГашениемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.отчётыПоБанковскимКартамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.показанияОегистровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.просмотрОтчётовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.внесениеВыплатаНаличныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.внесениеНаличныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выплатаНаличныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительныеОперацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналОперацийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.именаИПаролиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаПараметровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаСвязиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTB.Location = new System.Drawing.Point(88, 12);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(176, 26);
            this.passwordTB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пароль:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.регистрацияПродажToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.внесениеВыплатаНаличныхToolStripMenuItem,
            this.дополнительныеОперацииToolStripMenuItem,
            this.журналОперацийToolStripMenuItem,
            this.именаИПаролиToolStripMenuItem,
            this.настройкаПараметровToolStripMenuItem,
            this.настройкаСвязиToolStripMenuItem,
            this.сервисToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(15, 41);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(262, 225);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // регистрацияПродажToolStripMenuItem
            // 
            this.регистрацияПродажToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.регистрацияПродажToolStripMenuItem.Name = "регистрацияПродажToolStripMenuItem";
            this.регистрацияПродажToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.регистрацияПродажToolStripMenuItem.Text = "Регистрация продаж";
            this.регистрацияПродажToolStripMenuItem.Click += new System.EventHandler(this.регистрацияПродажToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хотчётбезГашенияToolStripMenuItem,
            this.хотчётПоСекциямToolStripMenuItem,
            this.хотчётПоНалогамToolStripMenuItem,
            this.toolStripSeparator1,
            this.zотчётсГашениемToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.отчётыПоБанковскимКартамToolStripMenuItem,
            this.toolStripSeparator3,
            this.показанияОегистровToolStripMenuItem,
            this.toolStripSeparator4,
            this.просмотрОтчётовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // хотчётбезГашенияToolStripMenuItem
            // 
            this.хотчётбезГашенияToolStripMenuItem.Name = "хотчётбезГашенияToolStripMenuItem";
            this.хотчётбезГашенияToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.хотчётбезГашенияToolStripMenuItem.Text = "Х-отчёт (без гашения)";
            this.хотчётбезГашенияToolStripMenuItem.Click += new System.EventHandler(this.хотчётбезГашенияToolStripMenuItem_Click);
            // 
            // хотчётПоСекциямToolStripMenuItem
            // 
            this.хотчётПоСекциямToolStripMenuItem.Name = "хотчётПоСекциямToolStripMenuItem";
            this.хотчётПоСекциямToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.хотчётПоСекциямToolStripMenuItem.Text = "Х-отчёт по секциям";
            this.хотчётПоСекциямToolStripMenuItem.Click += new System.EventHandler(this.хотчётПоСекциямToolStripMenuItem_Click);
            // 
            // хотчётПоНалогамToolStripMenuItem
            // 
            this.хотчётПоНалогамToolStripMenuItem.Name = "хотчётПоНалогамToolStripMenuItem";
            this.хотчётПоНалогамToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.хотчётПоНалогамToolStripMenuItem.Text = "Х-отчёт по налогам";
            this.хотчётПоНалогамToolStripMenuItem.Click += new System.EventHandler(this.хотчётПоНалогамToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(310, 6);
            // 
            // zотчётсГашениемToolStripMenuItem
            // 
            this.zотчётсГашениемToolStripMenuItem.Name = "zотчётсГашениемToolStripMenuItem";
            this.zотчётсГашениемToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.zотчётсГашениемToolStripMenuItem.Text = "Z-отчёт (с гашением)";
            this.zотчётсГашениемToolStripMenuItem.Click += new System.EventHandler(this.zотчётсГашениемToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(310, 6);
            // 
            // отчётыПоБанковскимКартамToolStripMenuItem
            // 
            this.отчётыПоБанковскимКартамToolStripMenuItem.Name = "отчётыПоБанковскимКартамToolStripMenuItem";
            this.отчётыПоБанковскимКартамToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.отчётыПоБанковскимКартамToolStripMenuItem.Text = "Z-отчёт по банковским картам";
            this.отчётыПоБанковскимКартамToolStripMenuItem.Click += new System.EventHandler(this.отчётыПоБанковскимКартамToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(310, 6);
            // 
            // показанияОегистровToolStripMenuItem
            // 
            this.показанияОегистровToolStripMenuItem.Name = "показанияОегистровToolStripMenuItem";
            this.показанияОегистровToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.показанияОегистровToolStripMenuItem.Text = "Показания регистров";
            this.показанияОегистровToolStripMenuItem.Click += new System.EventHandler(this.показанияОегистровToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(310, 6);
            // 
            // просмотрОтчётовToolStripMenuItem
            // 
            this.просмотрОтчётовToolStripMenuItem.Name = "просмотрОтчётовToolStripMenuItem";
            this.просмотрОтчётовToolStripMenuItem.Size = new System.Drawing.Size(313, 24);
            this.просмотрОтчётовToolStripMenuItem.Text = "Просмотр отчётов";
            this.просмотрОтчётовToolStripMenuItem.Click += new System.EventHandler(this.просмотрОтчётовToolStripMenuItem_Click);
            // 
            // внесениеВыплатаНаличныхToolStripMenuItem
            // 
            this.внесениеВыплатаНаличныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.внесениеНаличныхToolStripMenuItem,
            this.выплатаНаличныхToolStripMenuItem});
            this.внесениеВыплатаНаличныхToolStripMenuItem.Name = "внесениеВыплатаНаличныхToolStripMenuItem";
            this.внесениеВыплатаНаличныхToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.внесениеВыплатаНаличныхToolStripMenuItem.Text = "Внесение/Выплата наличных";
            // 
            // внесениеНаличныхToolStripMenuItem
            // 
            this.внесениеНаличныхToolStripMenuItem.Name = "внесениеНаличныхToolStripMenuItem";
            this.внесениеНаличныхToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.внесениеНаличныхToolStripMenuItem.Text = "Внесение наличных";
            this.внесениеНаличныхToolStripMenuItem.Click += new System.EventHandler(this.внесениеНаличныхToolStripMenuItem_Click);
            // 
            // выплатаНаличныхToolStripMenuItem
            // 
            this.выплатаНаличныхToolStripMenuItem.Name = "выплатаНаличныхToolStripMenuItem";
            this.выплатаНаличныхToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.выплатаНаличныхToolStripMenuItem.Text = "Выплата наличных";
            this.выплатаНаличныхToolStripMenuItem.Click += new System.EventHandler(this.выплатаНаличныхToolStripMenuItem_Click);
            // 
            // дополнительныеОперацииToolStripMenuItem
            // 
            this.дополнительныеОперацииToolStripMenuItem.Enabled = false;
            this.дополнительныеОперацииToolStripMenuItem.Name = "дополнительныеОперацииToolStripMenuItem";
            this.дополнительныеОперацииToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.дополнительныеОперацииToolStripMenuItem.Text = "Дополнительные операции";
            // 
            // журналОперацийToolStripMenuItem
            // 
            this.журналОперацийToolStripMenuItem.Enabled = false;
            this.журналОперацийToolStripMenuItem.Name = "журналОперацийToolStripMenuItem";
            this.журналОперацийToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.журналОперацийToolStripMenuItem.Text = "Журнал операций";
            // 
            // именаИПаролиToolStripMenuItem
            // 
            this.именаИПаролиToolStripMenuItem.Enabled = false;
            this.именаИПаролиToolStripMenuItem.Name = "именаИПаролиToolStripMenuItem";
            this.именаИПаролиToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.именаИПаролиToolStripMenuItem.Text = "Имена и пароли";
            // 
            // настройкаПараметровToolStripMenuItem
            // 
            this.настройкаПараметровToolStripMenuItem.Enabled = false;
            this.настройкаПараметровToolStripMenuItem.Name = "настройкаПараметровToolStripMenuItem";
            this.настройкаПараметровToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.настройкаПараметровToolStripMenuItem.Text = "Настройка параметров";
            // 
            // настройкаСвязиToolStripMenuItem
            // 
            this.настройкаСвязиToolStripMenuItem.Name = "настройкаСвязиToolStripMenuItem";
            this.настройкаСвязиToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.настройкаСвязиToolStripMenuItem.Text = "Настройка связи";
            this.настройкаСвязиToolStripMenuItem.Click += new System.EventHandler(this.настройкаСвязиToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.Enabled = false;
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(313, 24);
            this.toolStripMenuItem1.Text = "X-отчёт по банковским картам";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 271);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.ShowIcon = false;
            this.Text = "Меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem регистрацияПродажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внесениеВыплатаНаличныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дополнительныеОперацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналОперацийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem именаИПаролиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаПараметровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаСвязиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хотчётбезГашенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хотчётПоСекциямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хотчётПоНалогамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zотчётсГашениемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыПоБанковскимКартамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показанияОегистровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внесениеНаличныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выплатаНаличныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem просмотрОтчётовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}