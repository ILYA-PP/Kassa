using SBRFSRV;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    class Terminal
    {
        public static Server Server { get; set; }
        private enum Operations
        {
            Purchase = 4000, // Покупка
            PinPadEnabled = 13, //статус пинпада
            Return = 4002, // Возврат покупки
            Cancel = 6004, // Отмена транзакции
            Total = 6000 // Итоги дня 
        }
        public Terminal()
        {
            if (Server == null)
                Server = new Server();
        }
        //получить чек операции
        public string GetCheque()
        {
            try
            {
                string cheque = Server.GParamString("Cheque");
                return cheque;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return ""; 
            }
        }
        //проверка, подключен ли пинпад
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
        public void Purchase(double sum)
        {
            try
            {
                Server.Clear();
                Server.SParam("Amount", sum * 100);
                int result = Server.NFun((int)Operations.Purchase);
                if (result == 0)
                {
                    MessageBox.Show("Успешно!");
                }
                else
                    MessageBox.Show($"Операция НЕ выполнена. Код ошибки: {result}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                    MessageBox.Show($"День НЕ закрыт. Код ошибки: {result}");
                else
                {
                    MessageBox.Show("День закрыт");
                    SaveStringReport(GetCheque());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void SaveStringReport(string d)
        {
            if (d != "")
            {
                try
                {
                    var db = new KassaDBContext();
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
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }
    }
}
