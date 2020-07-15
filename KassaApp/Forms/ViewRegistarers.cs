using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class ViewRegistarers : Form
    {
        public ViewRegistarers()
        {
            InitializeComponent();
        }

        private void readOperationRegB_Click(object sender, EventArgs e)
        {
            FiscalRegistrar fr = new FiscalRegistrar();
            fr.Connect();
            if (fr.CheckConnect() == 0)
            {
                int i = 1;
                RegistrerItem ri;
                operationRegLB.Items.Clear();
                while(true)
                {
                    ri = fr.GetOperationRegItem(i);
                    if (ri != null)
                        operationRegLB.Items.Add($"{ri.Number}. {ri.Name} : {ri.Content}");
                    else
                        break;
                }
                fr.Disconnect();
            }
            else
                MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
        }
    }
}
