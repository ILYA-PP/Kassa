using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            driverCB.SelectedIndex = 0;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                comPortTB.Text = config.AppSettings.Settings["ComNumber"].Value;
                exchangeSpeedTB.Text = config.AppSettings.Settings["BaudRate"].Value;
                if (config.AppSettings.Settings["UsedPassword"].Value == "1")
                    usePasswordCheckB.Checked = true;
                else
                    usePasswordCheckB.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registrSettingsB_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (comPortTB.Text != "" && exchangeSpeedTB.Text != "")
            {
                config.AppSettings.Settings["ComNumber"].Value = comPortTB.Text;
                config.AppSettings.Settings["BaudRate"].Value = exchangeSpeedTB.Text;
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public void TB_TextChange(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxDigitFormat(sender, e);
        }

        private void checkConnectB_Click(object sender, EventArgs e)
        {
            using (FiscalRegistrar fr = new FiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    MessageBox.Show("Подключено!");
                else
                    MessageBox.Show("Подключение отсутствует!");
            }
        }

        private void usePasswordCheckB_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (usePasswordCheckB.Checked)
                config.AppSettings.Settings["UsedPassword"].Value = "1";
            else
                config.AppSettings.Settings["UsedPassword"].Value = "0";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
