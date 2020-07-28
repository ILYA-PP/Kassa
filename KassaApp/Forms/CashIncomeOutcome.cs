using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class CashIncomeOutcome : Form
    {
        private bool IsCashIncome; //указывает назначение формы, Внесение или же Выплата
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
        //обработка нажатия кнопки Ввод
        private void enterB_Click(object sender, EventArgs e)
        {
            decimal summ, res;
            if(summaTB.Text != "")
            {
                summ = decimal.Parse(summaTB.Text);
                if (summ > 0)
                {
                    using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                    {
                        if (fr.CheckConnect() == 0)
                        {
                            //Вненение или Выплата, относительно назначения формы
                            if (IsCashIncome)
                                res = fr.CashIncome(summ);
                            else
                                res = fr.CashOutcome(summ);
                            Close();
                        }
                        else
                            MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
                    }
                }
                else
                    MessageBox.Show("Сумма должна быть больше 0!");
            }
            else
                MessageBox.Show("Введите сумму!");
        }
        //обработка нажатия кнопки Отмена
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void summaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //приведение вводимого текста к числовому формату
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
    }
}
