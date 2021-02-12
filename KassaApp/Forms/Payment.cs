using Dapper;
using KassaApp.Models;
using KassaApp.Models.Connection;
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
        private Receipt _CurrentReceipt;
        private bool IsPaid = false;
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и установку первичных хначений формы.
        /// </summary>
        /// <param name="receipt">Чек, сформированный на главной форме.</param>
        public Payment(Receipt receipt)
        {
            Log.Logger.Info("Открытие окна Оплаты...");
            InitializeComponent();
            _CurrentReceipt = receipt;
            resultL.Text = $"Сумма по чеку: {_CurrentReceipt.Summa}";
            moneyTB.Text = _CurrentReceipt.Summa.ToString();
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод дробных чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void priceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFormat.TextBoxDoubleFormat(sender, e);
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
                changeTB.Text = (Math.Round(double.Parse(moneyTB.Text) - (double)_CurrentReceipt.Summa, 2)).ToString();
            else
                changeTB.Text = "";
        }
        /// <summary>
        /// Метод отвечает за обработку нажатия горячих клавиш.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:; break;
                case Keys.Escape: if (!cancelB.Focused) cancelB_Click(null, null); break;
                case Keys.F6:; break;
                case Keys.F1: if (!noteTB.Focused) noteB_Click(null, null); break;
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
                Log.Logger.Info($"Оплата через терминал сумма = {_CurrentReceipt.Summa}");
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
                                _CurrentReceipt.Payment = 2;
                                InsertData();
                                //если оплата через терминал успешна
                                if (terminal.Purchase(_CurrentReceipt.Summa) == 0)
                                {                                
                                    messageL.Text = "Оплата успешно!";
                                    //если печать чека терминала успешна
                                    messageL.Text = "Печать чеков";
                                    if (terminal.GetReceipt() != null && fr.Print(terminal.GetReceipt(), terminal.GetReceiptName()) == 0)
                                    {
                                        //печать товарного чека
                                        if (fr.PrintReceipt(_CurrentReceipt, null) == 0)
                                        {
                                            messageL.Text = "Успешно";
                                            terminal.Confirmed();
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
            if (decimal.Parse(moneyTB.Text) >= _CurrentReceipt.Summa)
                try
                {
                    Log.Logger.Info($"Оплата наличными сумма = {_CurrentReceipt.Summa}");
                    messageL.Text = "Оплата наличными";
                    this.Enabled = false; //блокировка формы
                    panel1.Visible = true; //показать панель сообщений
                    using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                    {
                        if (fr.CheckConnect() == 0)
                        {
                            messageL.Text = "Печать чека";
                            _CurrentReceipt.Payment = 1;
                            InsertData();
                            //замена суммы по чеку на сумму вносимых наличных
                            _CurrentReceipt.Summa = decimal.Parse(moneyTB.Text);
                            //печать товарного чека
                            if (fr.PrintReceipt(_CurrentReceipt) == 0)
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
            else
                MessageBox.Show("Вносимая сумма не может быть меньше суммы по чеку!");
        }
        /// <summary>
        /// Метод отвечает за отметку чека, как оплаченного, в базе данных.
        /// </summary>
        private void MarkAsPaid()
        {
            try
            {
                using (var db = ConnectionFactory.GetConnection())
                {
                    var rec = db.Query<Receipt>(SQLHelper.Select<Receipt>($"WHERE Id = {_CurrentReceipt.Id}")).FirstOrDefault();
                    rec.Paid = true; //признак оплаты чека
                    rec.Summa = _CurrentReceipt.Summa; //сумма по чеку
                    db.Execute(SQLHelper.Update(rec));
                    IsPaid = true;
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
                using (var db = ConnectionFactory.GetConnection())
                {
                    var rec = db.Query<Receipt>(SQLHelper.Select<Receipt>($"WHERE Id = {_CurrentReceipt.Id}")).FirstOrDefault();
                    rec.Discount = _CurrentReceipt.Discount; //скидка на чек
                    rec.Payment = _CurrentReceipt.Payment;//способ оплаты
                    rec.DiscountCard = _CurrentReceipt.DiscountCard;//дк
                    rec.Note = noteTB.Text;
                    Log.Logger.Info($"Вставка данных о чеке: Скидка: {rec.Discount} Сумма: {rec.Summa} Способ оплаты: {rec.Payment} ДК: {rec.DiscountCard}");
                    db.Execute(SQLHelper.Update(rec));
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
        private async void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Меню...");
            using (var db = ConnectionFactory.GetConnection())
            {
                //если в диалоговом окне выбрано Нет
                if (IsPaid)
                {
                    CurrentReceipt.Receipt = new Receipt();
                    ((Main)Owner).receiptDGV.Rows.Clear(); //очистка таблицы на главной форме
                    var r = db.Query<Receipt>(SQLHelper.Select<Receipt>($"WHERE Id = {_CurrentReceipt.Id} AND Paid = 0")).FirstOrDefault();
                    if (r != null)
                        await CountController.Reconciliation(_CurrentReceipt); //сверка остатков
                    db.Execute(SQLHelper.Insert(CurrentReceipt.Receipt));//добавление нового чека
                    CurrentReceipt.Receipt.Id = db.Query<int>("SELECT MAX(Id) FROM Receipt;").FirstOrDefault();
                    //Log.Logger.Info($"Создан чек (ID = {((Main)Owner).receipt.Id})");
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает событие нажатия кнопки Примечание.
        /// Отвечает за установку фокуса на поле Примечание.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void noteB_Click(object sender, EventArgs e)
        {
            noteTB.Focus();
        }
    }
}
