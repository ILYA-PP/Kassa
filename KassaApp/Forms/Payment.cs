using KassaApp.Models;
using System;
using System.Linq;
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
        //обработка нажатия кнопки Банковская карта
        private void nonCashB_Click(object sender, EventArgs e)
        {
            try
            {
                messageL.Text = "Идёт процесс оплаты через терминал";
                this.Enabled = false; //блокировка формы
                panel1.Visible = true; //показать панель сообщений
                using (var terminal = new Terminal())
                {
                    if (terminal.IsEnabled())
                    {
                        //если оплата через терминал успешна
                        if (terminal.Purchase(CurrentReceipt.Summa) == 0)
                        {
                            using (var fr = new FiscalRegistrar())
                            {
                                if (fr.CheckConnect() == 0)
                                {
                                    messageL.Text = "Печать чеков";
                                    //если печать чека терминала успешна
                                    if (terminal.GetCheque() != "" && fr.Print(terminal.GetCheque()) == 0)
                                    {
                                        CurrentReceipt.Payment = 2;
                                        //печать товарного чека
                                        if (fr.PrintCheque(CurrentReceipt, terminal.GetCardName()) == 0)
                                        {
                                            MarkAsPaid();
                                            Close();
                                        }
                                        else
                                        {
                                            //????????????????????????
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
                        }
                    }
                    else
                        MessageBox.Show("Ошибка! Нет связи с терминалом.");
                }
                panel1.Visible = false;//убрать панель сообщений
                this.Enabled = true;//разблокировать форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //обработка нажатия кнопки Наличные
        private void cashB_Click(object sender, EventArgs e)
        {
            decimal tempSum = 0;//сохранение суммы по чеку
            if (decimal.Parse(moneyTB.Text) < CurrentReceipt.Summa)
            {
                MessageBox.Show("Вносимая сумма не может быть меньше суммы по чеку!");
                return;
            }
            try
            {
                messageL.Text = "Оплата наличными";
                this.Enabled = false; //блокировка формы
                panel1.Visible = true; //показать панель сообщений
                using (FiscalRegistrar fr = new FiscalRegistrar())
                {
                    if (fr.CheckConnect() == 0)
                    {
                        messageL.Text = "Печать чека";
                        CurrentReceipt.Payment = 1;
                        tempSum = CurrentReceipt.Summa;
                        //замена суммы по чеку на сумму вносимых наличных
                        CurrentReceipt.Summa = decimal.Parse(moneyTB.Text);
                        //печать товарного чека
                        if (fr.PrintCheque(CurrentReceipt) == 0)
                        {
                            CurrentReceipt.Summa = tempSum;
                            MarkAsPaid();
                            Close();
                        }
                    }
                    else
                        MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
                }
                panel1.Visible = false;//убрать панель сообщений
                this.Enabled = true;//разблокировать форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //отметить чек в БД в таблице Receipt, как оплаченый
        private void MarkAsPaid()
        {
            try
            {
                using (var db = new KassaDBContext())
                {
                    var rec = db.Receipt.Where(r => r.Id == CurrentReceipt.Id).FirstOrDefault();
                    rec.Paid = true; //признак оплаты чека
                    rec.Discount = CurrentReceipt.Discount; //скидка на чек
                    rec.Summa = CurrentReceipt.Summa; //сумма по чеку
                    rec.Payment = CurrentReceipt.Payment; //способ оплаты
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //действие при закрытии формы
        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                //если в диалоговом окне выбрано Нет
                if (MessageBox.Show("Продолжить работу с этими позициями?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    ((Main)Owner).receipt = new Receipt();
                    ((Main)Owner).receiptDGV.Rows.Clear(); //очистка таблицы на главной форме
                    var r = db.Receipt.Where(p => p.Id == CurrentReceipt.Id && p.Paid == false).FirstOrDefault();
                    if (r != null)
                        CountController.Reconciliation(CurrentReceipt); //сверка остатков
                    db.Receipt.Add(((Main)Owner).receipt);//добавление нового чека
                    db.SaveChanges();
                }
            }
        }
    }
}
