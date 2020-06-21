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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exchangeSpeedTB = new System.Windows.Forms.TextBox();
            this.comPortTB = new System.Windows.Forms.TextBox();
            this.registrSettingsB = new System.Windows.Forms.Button();
            this.paySrvSettingsB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.driverCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driverCB.FormattingEnabled = true;
            this.driverCB.Items.AddRange(new object[] {
            "ШТРИХ"});
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.registrSettingsB);
            this.groupBox1.Controls.Add(this.comPortTB);
            this.groupBox1.Controls.Add(this.exchangeSpeedTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Регистратор";
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
            // exchangeSpeedTB
            // 
            this.exchangeSpeedTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exchangeSpeedTB.Location = new System.Drawing.Point(157, 61);
            this.exchangeSpeedTB.Name = "exchangeSpeedTB";
            this.exchangeSpeedTB.Size = new System.Drawing.Size(127, 26);
            this.exchangeSpeedTB.TabIndex = 8;
            // 
            // comPortTB
            // 
            this.comPortTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comPortTB.Location = new System.Drawing.Point(157, 30);
            this.comPortTB.Name = "comPortTB";
            this.comPortTB.Size = new System.Drawing.Size(127, 26);
            this.comPortTB.TabIndex = 9;
            // 
            // registrSettingsB
            // 
            this.registrSettingsB.Location = new System.Drawing.Point(290, 30);
            this.registrSettingsB.Name = "registrSettingsB";
            this.registrSettingsB.Size = new System.Drawing.Size(102, 57);
            this.registrSettingsB.TabIndex = 10;
            this.registrSettingsB.Text = "Настройка";
            this.registrSettingsB.UseVisualStyleBackColor = true;
            // 
            // paySrvSettingsB
            // 
            this.paySrvSettingsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paySrvSettingsB.Location = new System.Drawing.Point(12, 441);
            this.paySrvSettingsB.Name = "paySrvSettingsB";
            this.paySrvSettingsB.Size = new System.Drawing.Size(398, 28);
            this.paySrvSettingsB.TabIndex = 11;
            this.paySrvSettingsB.Text = "Настройка СО (сервера оплат)";
            this.paySrvSettingsB.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 481);
            this.Controls.Add(this.paySrvSettingsB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usePasswordCheckB);
            this.Controls.Add(this.driverCB);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}