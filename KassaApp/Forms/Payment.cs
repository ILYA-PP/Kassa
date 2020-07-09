using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Payment : Form
    {
        private Receipt CurrentReceipt;
        public Payment(Receipt receipt)
        {
            InitializeComponent();
            CurrentReceipt = receipt;
            resultL.Text = $"Сумма по чеку: {CurrentReceipt.Summa}";
            moneyTB.Text = CurrentReceipt.Summa.ToString();
        }
        //ограничение вводимых значений в текстбоксы
        private void priceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
        //расчёт сдачи при вводе суммы вносимых наличных
        private void moneyTB_TextChanged(object sender, EventArgs e)
        {
            if (moneyTB.Text != "")
                changeTB.Text = (Math.Round(double.Parse(moneyTB.Text) - CurrentReceipt.Summa, 2)).ToString();
            else
                changeTB.Text = "";
        }
        //обработка горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:; break;
                case Keys.Escape: cancelB_Click(null, null); break;
                case Keys.F6:; break;
                case Keys.F1:; break;
                case Keys.Enter: cashB_Click(null, null); break;
                case Keys.Multiply: nonCashB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //закрытие формы
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nonCashB_Click(object sender, EventArgs e)
        {
            try
            {
                messageL.Text = "Идёт процесс оплаты через терминал";
                this.Enabled = false;
                panel1.Visible = true;
                Terminal terminal = new Terminal();
                if (terminal.IsEnabled())
                {
                    terminal.Purchase(CurrentReceipt.Summa);
                    FiscalRegistrar Driver = new FiscalRegistrar();
                    Driver.Connect();
                    if (Driver.CheckConnect() == 0)
                    {
                        if (Driver.Print(terminal.GetCheque()) == 0)
                        {
                            messageL.Text = "Печать чеков";
                            CurrentReceipt.Payment = 2;
                            Driver.PrintCheque(CurrentReceipt);
                            ((Main)Owner).receiptDGV.Rows.Clear();
                            MarkAsPaid();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Чек терминала не напечатан! Отмена операции.");
                            terminal.CancelTransaction();
                        }
                    }
                    else
                        MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
                }
                else
                    MessageBox.Show("Ошибка! Нет связи с терминалом.");
                panel1.Visible = false;
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cashB_Click(object sender, EventArgs e)
        {
            try
            {
                messageL.Text = "Оплата наличными";
                this.Enabled = false;
                panel1.Visible = true;
                FiscalRegistrar Driver = new FiscalRegistrar();
                Driver.Connect();
                if (Driver.CheckConnect() == 0)
                {
                    messageL.Text = "Печать чека";
                    CurrentReceipt.Payment = 1;
                    CurrentReceipt.Summa = double.Parse(moneyTB.Text);
                    Driver.PrintCheque(CurrentReceipt);
                    ((Main)Owner).receiptDGV.Rows.Clear();
                    MarkAsPaid();
                    Close();
                }
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
                panel1.Visible = false;
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarkAsPaid()
        {
            try
            {
                var db = new KassaDBContext();
                foreach (Product p in CurrentReceipt.Products)
                {
                    int id = db.Product.Where(pr => pr.Name == p.Name).FirstOrDefault().Id;
                    var purchase = db.Purchase.Where(pur => pur.ProductId == id).FirstOrDefault();
                    purchase.Paid = true;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Продолжить работу с этими позициями?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                ((Main)Owner).receipt = new Receipt();
                ((Main)Owner).receiptDGV.Rows.Clear();
                CountController.Reconciliation();
            }
            else
            {
                var db = new KassaDBContext();
                var mas = db.Purchase.Where(p => p.Paid == false);
                foreach (Purchase p in mas)
                    db.Purchase.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
