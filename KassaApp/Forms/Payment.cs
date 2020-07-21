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
                changeTB.Text = (Math.Round(double.Parse(moneyTB.Text) - (double)CurrentReceipt.Summa, 2)).ToString();
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
                    terminal.Purchase((double)CurrentReceipt.Summa);
                    FiscalRegistrar Driver = new FiscalRegistrar();
                    if (Driver.CheckConnect() == 0)
                    {
                        messageL.Text = "Печать чеков";
                        if (Driver.Print(terminal.GetCheque()) == 0)
                        {
                            CurrentReceipt.Payment = 2;
                            if (Driver.PrintCheque(CurrentReceipt) == 0)
                            {
                                MarkAsPaid();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Товарный чек не напечатан! Отмена транзакции.");
                                terminal.CancelTransaction();
                            }
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
            if (decimal.Parse(moneyTB.Text) < CurrentReceipt.Summa)
            {
                MessageBox.Show("Вносимая сумма не может быть меньше суммы по чеку!");
                return;
            }
            try
            {
                messageL.Text = "Оплата наличными";
                this.Enabled = false;
                panel1.Visible = true;
                FiscalRegistrar Driver = new FiscalRegistrar();
                if (Driver.CheckConnect() == 0)
                {
                    messageL.Text = "Печать чека";
                    CurrentReceipt.Payment = 1;
                    CurrentReceipt.Summa = decimal.Parse(moneyTB.Text);
                    if(Driver.PrintCheque(CurrentReceipt) == 0)
                    {
                        MarkAsPaid();
                        Close();
                    }
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
                var rec = db.Receipt.Where(r => r.Id == CurrentReceipt.Id).FirstOrDefault();
                rec.Paid = true;
                rec.Discount = CurrentReceipt.Discount;
                rec.Summa = CurrentReceipt.Summa;
                rec.Payment = CurrentReceipt.Payment;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            var db = new KassaDBContext();
            if (MessageBox.Show("Продолжить работу с этими позициями?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                ((Main)Owner).receipt = new Receipt();
                ((Main)Owner).receiptDGV.Rows.Clear();
                var r = db.Receipt.Where(p => p.Id == CurrentReceipt.Id && p.Paid == false).FirstOrDefault();
                if(r != null)
                    CountController.Reconciliation(CurrentReceipt);
                db.Receipt.Add(((Main)Owner).receipt);
                db.SaveChanges();
            }
        }
    }
}
