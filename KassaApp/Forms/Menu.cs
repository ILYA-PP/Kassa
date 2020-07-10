using KassaApp.Forms;
using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        //переход на главную форму
        private void регистрацияПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            new Settings().Show();
        }

        private void отчётыПоБанковскимКартамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            Terminal terminal = new Terminal();
            if (terminal.IsEnabled())
            {
                terminal.CloseDay();
                FiscalRegistrar fr = new FiscalRegistrar();
                fr.Connect();
                if (fr.CheckConnect() == 0)
                {
                    fr.Print(terminal.GetCheque());
                    fr.Disconnect();
                }
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }

        private void zотчётсГашениемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintZReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётПоНалогамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXTaxReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётПоСекциямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXSectionReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётбезГашенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXReport();

                fr.Disconnect();
            }
            else
                MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
        }
        private bool CheckPassword()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["UsedPassword"].Value == "1"
                && config.AppSettings.Settings["Password"].Value == passwordTB.Text)
                    return true;
            if (config.AppSettings.Settings["UsedPassword"].Value == "0")
                return true;
            return false;
        }

        private void просмотрОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewReports().ShowDialog();
        }
    }
}
