using KassaApp.Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KassaApp
{
    /// <summary>
    /// Класс содержит логику работы формы настройки связи.
    /// </summary>
    public partial class Settings : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и установку текущих настроек.
        /// для восстановления.
        /// </summary>
        public Settings()
        {
            Log.Logger.Info("Открытие окна Настройки связи...");
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
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Настройка.
        /// Устанавливает настройки для фискального регистратора. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод обрабатывает ввод текста в textBox.
        /// Допускает ввод только целых чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        public void TB_TextChange(object sender, KeyPressEventArgs e)
        {
            TextFormat.TextBoxDigitFormat(sender, e);
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Проверка связи фискального регистратора.
        /// Отвечает за проверку связи с фискальным регистратором. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void checkConnectB_Click(object sender, EventArgs e)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    MessageBox.Show("Фискальный регистратор подключен!");
            }
        }
        /// <summary>
        /// Метод обрабатывает изменение выбора Использовать пароль доступа.
        /// Отвечает за сохранения настройки использования пароля. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Проверка связи терминала.
        /// Отвечает за проверку связи с терминалом. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Открытие окна Настройки связи...");
        }
    }
}
