using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Task t1 = Task.Factory.StartNew(() =>
            {
                FiscalRegistrar Driver = new FiscalRegistrar();
                Driver.Connect();
                if (Driver.CheckConnect() == 0)
                {
                    Driver.prepareCheque();
                    Driver.Disconnect();
                }
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
            });
        }
        //переход на главную форму
        private void регистрацияПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Main().Show();
        }
        //переход на форму настройки связи
        private void настройкаСвязиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        private void отчётыПоБанковскимКартамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Terminal terminal = new Terminal();
            if (terminal.IsEnabled())
            {
                terminal.CloseDay();
                //печать через фискальник
                MessageBox.Show(terminal.GetCheque());
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }

        private void zотчётсГашениемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintZReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётПоНалогамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXTaxReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётПоСекциямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXSectionReport();
                fr.Disconnect();
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }

        private void хотчётбезГашенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                fr.PrintXReport();
                fr.Cut
                fr.Disconnect();
            }
            else
                MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
        }
    }
}
