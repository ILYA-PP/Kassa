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
    public partial class CashIncomeOutcome : Form
    {
        private bool IsCashIncome;
        public CashIncomeOutcome(bool operation)
        {
            InitializeComponent();
            IsCashIncome = operation;
            if (IsCashIncome)
                operationL.Text = "Внесение наличных";
            else
                operationL.Text = "Выплата наличных";
        }
        //обработка горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: cancelB_Click(null, null); break;
                case Keys.Enter: enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void enterB_Click(object sender, EventArgs e)
        {
            decimal summ = 0, res;
            if(summaTB.Text != "")
            {
                summ = decimal.Parse(summaTB.Text);
                if (summ > 0)
                {
                    FiscalRegistrar fr = new FiscalRegistrar();
                    if (fr.CheckConnect() == 0)
                    {
                        if (IsCashIncome)
                           res = fr.CashIncome(summ);
                        else
                           res = fr.CashOutcome(summ);
                        if (res == 0)
                            MessageBox.Show("Успешно!");
                        summaTB.Text = "";
                    }
                    else
                        MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
                }
                else
                    MessageBox.Show("Сумма должна быть больше 0!");
            }
            else
                MessageBox.Show("Введите сумму!");
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void summaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
    }
}
