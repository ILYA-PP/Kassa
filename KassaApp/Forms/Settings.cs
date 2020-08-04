using KassaApp.Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            //заполнение данных формы текущими настройками
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
        //обработка нажатия кнопки Настройка
        private void registrSettingsB_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (comPortTB.Text != "" && exchangeSpeedTB.Text != "")
                {
                    config.AppSettings.Settings["ComNumber"].Value = comPortTB.Text; //изменение сом порта
                    config.AppSettings.Settings["BaudRate"].Value = exchangeSpeedTB.Text; // изменение скорости обмена
                    config.Save();
                    ConfigurationManager.RefreshSection("appSettings");//сохранение изменений
                    MessageBox.Show("Настройки сохранены!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //действие при изменении значений текстовых полей
        public void TB_TextChange(object sender, KeyPressEventArgs e)
        {
            //формат строк, только целые числа
            TextFormat.TextBoxDigitFormat(sender, e);
        }
        //проверка связи с фискальным регистратором
        private void checkConnectB_Click(object sender, EventArgs e)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    MessageBox.Show("Фискальный регистратор подключен!");
            }
        }
        //обработка изменения метки Использовать пароль доступа
        private void usePasswordCheckB_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (usePasswordCheckB.Checked)
                config.AppSettings.Settings["UsedPassword"].Value = "1"; //использовать
            else
                config.AppSettings.Settings["UsedPassword"].Value = "0"; //не использовать
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void checkTermlConnectB_Click(object sender, EventArgs e)
        {
            using (ITerminal terminal = CurrentHardware.GetTerminal())
            {
                if (terminal.IsEnabled())
                    MessageBox.Show("Терминал подключен!");
                else
                    MessageBox.Show("Подключение отсутствует!");
            }
        }
    }
}
