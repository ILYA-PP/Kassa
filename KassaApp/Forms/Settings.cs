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
        /// Выполняет инициализацию формы и установку текущих настроек
        /// для восстановления.
        /// </summary>
        public Settings()
        {
            Log.Logger.Info("Открытие окна Настройки связи...");
            InitializeComponent();
            driverCB.SelectedIndex = 0;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int baudRate;
            try
            {
                comPortTB.Text = config.AppSettings.Settings["ComNumber"].Value;
                switch (config.AppSettings.Settings["BaudRate"].Value)
                {
                    case "0": baudRate = 2400; break;
                    case "1": baudRate = 4800; break;
                    case "2": baudRate = 9600; break;
                    case "3": baudRate = 19200; break;
                    case "4": baudRate = 38400; break;
                    case "5": baudRate = 57600; break;
                    case "6": baudRate = 115200; break;
                    default:
                        MessageBox.Show("Неверное значение скорости обмена! Установлено значение по умолчанию: 115200");
                        baudRate = 115200; break;
                }
                exchangeSpeedTB.Text = baudRate.ToString();
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
                int baudRate;
                if (comPortTB.Text != "" && exchangeSpeedTB.Text != "")
                {
                    config.AppSettings.Settings["ComNumber"].Value = comPortTB.Text; //изменение сом порта
                    switch (exchangeSpeedTB.Text)
                    {
                        case "2400": baudRate = 0; break;
                        case "4800": baudRate = 1; break;
                        case "9600": baudRate = 2; break;
                        case "19200": baudRate = 3; break;
                        case "38400": baudRate = 4; break;
                        case "57600": baudRate = 5; break;
                        case "115200": baudRate = 6; break;
                        default:
                            MessageBox.Show("Неверное значение скорости обмена! Установлено значение по умолчанию: 115200");
                            exchangeSpeedTB.Text = "115200";
                            baudRate = 6; break;
                    }
                    config.AppSettings.Settings["BaudRate"].Value = baudRate.ToString(); // изменение скорости обмена
                    config.Save();
                    ConfigurationManager.RefreshSection("appSettings");//сохранение изменений
                    MessageBox.Show("Настройки сохранены!");
                }
                else
                    MessageBox.Show("Заполните все поля!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
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
        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// Отвечает за запись информации о закрытии окна в лог.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Открытие окна Настройки связи...");
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод только целых чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFormat.TextBoxDigitFormat(sender, e);
        }
    }
}
