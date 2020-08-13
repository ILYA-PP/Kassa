using KassaApp.Forms;
using KassaApp.Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KassaApp
{
    /// <summary>
    /// Класс содержит логику работы формы главного меню.
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы, устанавливает путь к рабочей папке
        /// и вызывает метод проверси состояния ККТ.
        /// </summary>
        public Menu()
        {
            Log.Logger.Info("Открытие окна Меню...");
            InitializeComponent();
            //путь к рабочей папке
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrepareReceipt();
            }
        }
        /// <summary>
        /// Метод отвечает за переход на форму регистрации продаж. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void регистрацияПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проверка пароля
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            new Main().Show();
        }
        /// <summary>
        /// Метод отвечает за переход на форму настройки связи. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void настройкаСвязиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проверка пароля
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            new Settings().Show();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отчет по банковским картам.
        /// Отвечает за печать и сохранение z-отчёта по банковским картам. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void отчётыПоБанковскимКартамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (ITerminal terminal = CurrentHardware.GetTerminal())
            {
                using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                {
                    //проверка связи с терминалом
                    if (terminal.IsEnabled())
                    {
                        //проверка связи с фискальным регистратором
                        if (fr.CheckConnect() == 0)
                        {
                            //формирование отчета
                            terminal.CloseDay();
                            fr.Print(terminal.GetReceipt(), terminal.GetReceiptName());//печать чека терминала
                        }
                    }
                    else
                        MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Z-отчёт (с гашением).
        /// Отвечает за печать и сохранение z-отчёта ККТ. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void zотчётсГашениемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrintZReport();
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки х-отчёт По Налогам.
        /// Отвечает за печать и сохранение х-отчёта По Налогам ККТ. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void хотчётПоНалогамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrintXTaxReport();
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки х-отчёт По Секциям.
        /// Отвечает за печать и сохранение х-отчёта По Секциям ККТ. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void хотчётПоСекциямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrintXSectionReport();
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки х-отчёт без Гашения.
        /// Отвечает за печать и сохранение х-отчёта без Гашения ККТ. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void хотчётбезГашенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrintXReport();
            }
        }
        /// <summary>
        /// Метод отвечает за проверку пароля, 
        /// если в настройках установлен соответствующий параметр. 
        /// </summary>
        /// <returns>Признак корректности пароля</returns>
        private bool CheckPassword()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var usePass = config.AppSettings.Settings["UsedPassword"].Value;
            //если установлена галочка Использовать пароль доступа
            if (usePass == "1" && usePass == passwordTB.Text)
                return true;
            if (usePass == "0")
                return true;
            return false;
        }
        /// <summary>
        /// Метод отвечает за переход на форму просмотра отчётов. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void просмотрОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            //переход на форму просмотра отчётов
            new ViewReports().ShowDialog();
        }
        /// <summary>
        /// Метод отвечает за переход на форму внесения/выдачи наличных.
        /// Указывает, что назначение формы Внесение 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void внесениеНаличныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            //переход на форму внесения/выплаты наличных
            new CashIncomeOutcome(true).ShowDialog();
        }
        /// <summary>
        /// Метод отвечает за переход на форму внесения/выдачи наличных.
        /// Указывает, что назначение формы Выплата
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void выплатаНаличныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            //переход на форму внесения/выплаты наличных
            new CashIncomeOutcome(false).ShowDialog();
        }
        /// <summary>
        /// Метод отвечает за переход на форму показаний регистров.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void показанияОегистровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            //переход на форму просмотра регистров
            new ViewRegistarers().ShowDialog();           
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки х-отчёт по банковским картам.
        /// Отвечает за печать и сохранение х-отчёта по банковским картам. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            using (ITerminal terminal = CurrentHardware.GetTerminal())
            {
                using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                {
                    //проверка связи с терминалом
                    if (terminal.IsEnabled())
                    {
                        //проверка связи с фискальным регистратором
                        if (fr.CheckConnect() == 0)
                        {
                            //формирование отчета
                            terminal.GetXReport();
                            fr.Print(terminal.GetReceipt(), terminal.GetReceiptName());//печать чека терминала
                        }
                    }
                    else
                        MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
                }
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Меню...");
        }
    }
}
