using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    /// <summary>
    /// Класс содержит логику работы формы оплаты.
    /// </summary>
    public partial class Payment : Form
    {
        private Receipt CurrentReceipt;
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и установку первичных хначений формы.
        /// </summary>
        /// <param name="receipt">Чек, сформированный на главной форме.</param>
        public Payment(Receipt receipt)
        {
            Log.Logger.Info("Открытие окна Оплаты...");
            InitializeComponent();
            CurrentReceipt = receipt;
            resultL.Text = $"Сумма по чеку: {CurrentReceipt.Summa}";
            moneyTB.Text = CurrentReceipt.Summa.ToString();
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод дробных чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void priceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFormat.TextBoxFormat(sender, e);
        }
        /// <summary>
        /// Метод обрабатывает ввод текста в textBox.
        /// отвечает за расчёт сдачи при вводе суммы вносимых наличных.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
                case Keys.Escape: if (!cancelB.Focused) cancelB_Click(null, null); break;
                case Keys.F6:; break;
                case Keys.F1:; break;
                case Keys.Enter: if (!cashB.Focused) cashB_Click(null, null); break;
                case Keys.Multiply: if (!nonCashB.Focused) nonCashB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отмена.
        /// Вызывает метод Close для формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Банковская карта.
        /// Отвечает за оплату покупки по банковской карте.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void nonCashB_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Logger.Info($"Оплата через терминал сумма = {CurrentReceipt.Summa}");
                messageL.Text = "Идёт процесс оплаты через терминал";
                this.Enabled = false; //блокировка формы
                panel1.Visible = true; //показать панель сообщений
                using (ITerminal terminal = CurrentHardware.GetTerminal())
                {
                    using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                    {
                        if (terminal.IsEnabled())
                        {
                            if (fr.CheckConnect() == 0)
                            {
                                //если оплата через терминал успешна
                                if (terminal.Purchase(CurrentReceipt.Summa) == 0)
                                {                                
                                    messageL.Text = "Оплата успешно!";
                                    terminal.Unconfirmed();
                                    //если печать чека терминала успешна
                                    if (terminal.GetReceipt() != null && fr.Print(terminal.GetReceipt(), terminal.GetReceiptName()) == 0)
                                    {
                                        messageL.Text = "Печать чеков";
                                        CurrentReceipt.Payment = 2;
                                        InsertData();
                                        //печать товарного чека
                                        if (fr.PrintReceipt(CurrentReceipt, null) == 0)
                                        {
                                            messageL.Text = "Успешно";
                                            terminal.Confirmed();
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
                            }
                        }
                        else
                            MessageBox.Show("Терминал не подключен! Проверьте подключение и повторите попытку.");
                    }
                }
                panel1.Visible = false;//убрать панель сообщений
                this.Enabled = true;//разблокировать форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Наличные.
        /// Отвечает за оплату покупки наличными.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void cashB_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(moneyTB.Text) < CurrentReceipt.Summa)
            {
                MessageBox.Show("Вносимая сумма не может быть меньше суммы по чеку!");
                return;
            }
            try
            {
                Log.Logger.Info($"Оплата наличными сумма = {CurrentReceipt.Summa}");
                messageL.Text = "Оплата наличными";
                this.Enabled = false; //блокировка формы
                panel1.Visible = true; //показать панель сообщений
                using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                {
                    if (fr.CheckConnect() == 0)
                    {
                        messageL.Text = "Печать чека";
                        CurrentReceipt.Payment = 1;
                        InsertData();
                        //замена суммы по чеку на сумму вносимых наличных
                        CurrentReceipt.Summa = decimal.Parse(moneyTB.Text);
                        //печать товарного чека
                        if (fr.PrintReceipt(CurrentReceipt) == 0)
                        {
                            messageL.Text = "Успешно";
                            MarkAsPaid();
                            Close();
                        }
                    }
                }
                panel1.Visible = false;//убрать панель сообщений
                this.Enabled = true;//разблокировать форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод отвечает за отметку чека, как оплаченного, в базе данных.
        /// </summary>
        private void MarkAsPaid()
        {
            try
            {
                using (var db = new KassaDBContext())
                {
                    var rec = db.Receipt.Where(r => r.Id == CurrentReceipt.Id).FirstOrDefault();
                    rec.Paid = true; //признак оплаты чека
                    db.SaveChanges();
                    Log.Logger.Info($"Чек с ID = {rec.Id} отмечен, как Оплаченный");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод отвечает сохранение данных по чеку в базе данных.
        /// </summary>
        private void InsertData()
        {
            try
            {
                using (var db = new KassaDBContext())
                {
                    var rec = db.Receipt.Where(r => r.Id == CurrentReceipt.Id).FirstOrDefault();
                    rec.Discount = CurrentReceipt.Discount; //скидка на чек
                    rec.Summa = CurrentReceipt.Summa; //сумма по чеку
                    rec.Payment = CurrentReceipt.Payment;//способ оплаты
                    rec.DiscountCard = CurrentReceipt.DiscountCard;//дк
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// Отвечает за удаление старого и создание нового чека
        /// при отказе работать с текущими позициями. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Меню...");
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
