using KassaApp.Forms;
using KassaApp.Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            //путь к рабочей папке
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrepareReceipt();
            }
        }
        //переход на главную форму
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
        //переход на форму настройки связи
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
        //обработка нажатия кнопки отчет по банковским картам
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
        //обработка нажатия кнопки z-отчёт с Гашением
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
        //обработка нажатия кнопки х-отчёт По Налогам
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
        //обработка нажатия кнопки х-отчёт По Секциям
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
        //обработка нажатия кнопки х-отчёт без Гашения
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
        //проверка пароля
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
        //обработка нажатия кнопки просмотр Отчётов
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
        //обработка нажатия кнопки внесение Наличных
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
        //обработка нажатия кнопки выплата Наличных
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
        //обработка нажатия кнопки показания регистров
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
    }
}
