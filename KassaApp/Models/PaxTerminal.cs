﻿using SBRFSRV;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    //класс для работы терминалом через драйвер SBRFSRV
    class PaxTerminal: ITerminal
    {
        private Server Server { get; set; }
        public string ReceiptStr { get; set; }
        public string CardName { get; set; }
        private enum Operations
        {
            Purchase = 4000, // Покупка
            PinPadEnabled = 13, //статус пинпада
            Return = 4002, // Возврат покупки
            Cancel = 6004, // Отмена транзакции
            Total = 6000,// Итоги дня 
            UnconfirmedTransaction = 6003,//"Неподверждённая" транзакция
            ConfirmedTransaction = 6001//"Подверждённая" транзакция
        }
        public PaxTerminal()
        {
            Server = new Server();
        }
        //получить имя карты
        public string GetCardName()
        {
            return CardName;
        }
        //получить чек операции
        public string GetReceipt()
        {
            return ReceiptStr;
        }
        //проверка, подключен ли терминал
        public bool IsEnabled()
        {
            try
            {
                if (Server.NFun((int)Operations.PinPadEnabled) == 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        //операция покупки
        public int Purchase(decimal sum)
        {
            try
            {
                Server.Clear();
                Server.SParam("Amount", sum * 100);
                int result = Server.NFun((int)Operations.Purchase);
                if (result == 0)
                {
                    ReceiptStr = Server.GParamString("Cheque");
                    CardName = Server.GParamString("CardName");
                    return result;
                }
                else
                    MessageBox.Show($"Операция НЕ выполнена. Код ошибки: {result}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return -1;
        }
        //отмена транзакции
        public void CancelTransaction()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.Cancel);
                if (result != 0)
                    MessageBox.Show($"Операция НЕ отменена. Код ошибки: {result}");
                else
                    MessageBox.Show("Операция отменена");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //отмена транзакции
        public void Confirmed()
        {
            try
            {
                int result = Server.NFun((int)Operations.ConfirmedTransaction);
                if (result != 0)
                    MessageBox.Show($"Транзакция не переведена в режим \"Подтверждённая\". Код ошибки: {result}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //отмена транзакции
        public void Unconfirmed()
        {
            try
            {
                int result = Server.NFun((int)Operations.UnconfirmedTransaction);
                if (result != 0)
                    MessageBox.Show($"Транзакция не переведена в режим \"Неподтверждённая\". Код ошибки: {result}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //возврат средств
        public void Return()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.Return);
                if (result != 0)
                    MessageBox.Show($"Средства НЕ возвращены. Код ошибки: {result}");
                else
                    MessageBox.Show("Средства возвращены");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //операция закрытия дня
        public void CloseDay()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.Total);
                if (result != 0)
                    MessageBox.Show($"День терминала НЕ закрыт. Код ошибки: {result}");
                else
                {
                    MessageBox.Show("День терминала закрыт");
                    SaveStringReport(GetReceipt());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //сохранение отчёта по банковским картам
        public void SaveStringReport(string d)
        {
            if (d != "")
            {
                try
                {
                    using (var db = new KassaDBContext())
                    {
                        byte[] data = Encoding.Default.GetBytes(d);
                        Report report = new Report()
                        {
                            Name = "Отчёт по банковским картам",
                            ReportData = data,
                            Date = DateTime.Now
                        };
                        db.Report.Add(report);
                        db.SaveChanges();
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        foreach (var validationError in validationErrors.ValidationErrors)
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                }
            }
        }
        //действие при удалении объекта класса
        public void Dispose()
        {
            Server.Clear();
        }
    }
}
