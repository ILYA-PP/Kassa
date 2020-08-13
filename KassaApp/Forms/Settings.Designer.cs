namespace KassaApp
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.driverCB = new System.Windows.Forms.ComboBox();
            this.usePasswordCheckB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkFRConnectB = new System.Windows.Forms.Button();
            this.registrSettingsB = new System.Windows.Forms.Button();
            this.comPortTB = new System.Windows.Forms.TextBox();
            this.exchangeSpeedTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paySrvSettingsB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkTermlConnectB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Драйвер:";
            // 
            // driverCB
            // 
            this.driverCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driverCB.FormattingEnabled = true;
            this.driverCB.Items.AddRange(new object[] {
            "ШТРИХ-М"});
            this.driverCB.Location = new System.Drawing.Point(95, 12);
            this.driverCB.Name = "driverCB";
            this.driverCB.Size = new System.Drawing.Size(315, 28);
            this.driverCB.TabIndex = 3;
            // 
            // usePasswordCheckB
            // 
            this.usePasswordCheckB.AutoSize = true;
            this.usePasswordCheckB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usePasswordCheckB.Location = new System.Drawing.Point(12, 46);
            this.usePasswordCheckB.Name = "usePasswordCheckB";
            this.usePasswordCheckB.Size = new System.Drawing.Size(262, 24);
            this.usePasswordCheckB.TabIndex = 4;
            this.usePasswordCheckB.Text = "Использовать пароль доступа";
            this.usePasswordCheckB.UseVisualStyleBackColor = true;
            this.usePasswordCheckB.CheckedChanged += new System.EventHandler(this.usePasswordCheckB_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkFRConnectB);
            this.groupBox1.Controls.Add(this.registrSettingsB);
            this.groupBox1.Controls.Add(this.comPortTB);
            this.groupBox1.Controls.Add(this.exchangeSpeedTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Регистратор";
            // 
            // checkFRConnectB
            // 
            this.checkFRConnectB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkFRConnectB.Location = new System.Drawing.Point(10, 93);
            this.checkFRConnectB.Name = "checkFRConnectB";
            this.checkFRConnectB.Size = new System.Drawing.Size(382, 28);
            this.checkFRConnectB.TabIndex = 12;
            this.checkFRConnectB.Text = "Проверка связи";
            this.checkFRConnectB.UseVisualStyleBackColor = true;
            this.checkFRConnectB.Click += new System.EventHandler(this.checkConnectB_Click);
            // 
            // registrSettingsB
            // 
            this.registrSettingsB.Location = new System.Drawing.Point(290, 30);
            this.registrSettingsB.Name = "registrSettingsB";
            this.registrSettingsB.Size = new System.Drawing.Size(102, 57);
            this.registrSettingsB.TabIndex = 10;
            this.registrSettingsB.Text = "Настройка";
            this.registrSettingsB.UseVisualStyleBackColor = true;
            this.registrSettingsB.Click += new System.EventHandler(this.registrSettingsB_Click);
            // 
            // comPortTB
            // 
            this.comPortTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comPortTB.Location = new System.Drawing.Point(157, 30);
            this.comPortTB.Name = "comPortTB";
            this.comPortTB.Size = new System.Drawing.Size(127, 26);
            this.comPortTB.TabIndex = 9;
            // 
            // exchangeSpeedTB
            // 
            this.exchangeSpeedTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exchangeSpeedTB.Location = new System.Drawing.Point(157, 61);
            this.exchangeSpeedTB.Name = "exchangeSpeedTB";
            this.exchangeSpeedTB.Size = new System.Drawing.Size(127, 26);
            this.exchangeSpeedTB.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Скорость обмена:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "СОМ-порт:";
            // 
            // paySrvSettingsB
            // 
            this.paySrvSettingsB.Enabled = false;
            this.paySrvSettingsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paySrvSettingsB.Location = new System.Drawing.Point(12, 441);
            this.paySrvSettingsB.Name = "paySrvSettingsB";
            this.paySrvSettingsB.Size = new System.Drawing.Size(398, 28);
            this.paySrvSettingsB.TabIndex = 11;
            this.paySrvSettingsB.Text = "Настройка СО (сервера оплат)";
            this.paySrvSettingsB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkTermlConnectB);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 75);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Терминал";
            // 
            // checkTermlConnectB
            // 
            this.checkTermlConnectB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkTermlConnectB.Location = new System.Drawing.Point(6, 37);
            this.checkTermlConnectB.Name = "checkTermlConnectB";
            this.checkTermlConnectB.Size = new System.Drawing.Size(382, 28);
            this.checkTermlConnectB.TabIndex = 12;
            this.checkTermlConnectB.Text = "Проверка связи";
            this.checkTermlConnectB.UseVisualStyleBackColor = true;
            this.checkTermlConnectB.Click += new System.EventHandler(this.checkTermlConnectB_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.paySrvSettingsB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usePasswordCheckB);
            this.Controls.Add(this.driverCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox driverCB;
        private System.Windows.Forms.CheckBox usePasswordCheckB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button registrSettingsB;
        private System.Windows.Forms.TextBox comPortTB;
        private System.Windows.Forms.TextBox exchangeSpeedTB;
        private System.Windows.Forms.Button paySrvSettingsB;
        private System.Windows.Forms.Button checkFRConnectB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button checkTermlConnectB;
    }
}