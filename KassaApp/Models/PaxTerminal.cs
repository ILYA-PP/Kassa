using SBRFSRV;
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
        public string ReceiptName { get; set; }
        public string CardName { get; set; }
        private enum Operations
        {
            Purchase = 4000, // Покупка
            PinPadEnabled = 13, //статус пинпада
            Return = 4002, // Возврат покупки
            Cancel = 6004, // Отмена транзакции
            Total = 6000,// Итоги дня 
            UnconfirmedTransaction = 6003,//"Неподверждённая" транзакция
            ConfirmedTransaction = 6001,//"Подверждённая" транзакция
            XReport = 6002//получение х-отчёта по картам
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
        //вывод, возвращаемых терминалом сообщений
        private void GetMessage(string message)
        {
            MessageBox.Show(message, "Терминал");
        }
        //получить чек операции
        public string GetReceipt()
        {
            return ReceiptStr;
        }
        //получить имя документа
        public string GetReceiptName()
        {
            return ReceiptName;
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
                GetMessage(TextFormat.GetExceptionMessage(ex));
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
                    ReceiptName = "Чек терминала";
                    CardName = Server.GParamString("CardName");
                    return result;
                }
                else
                    GetMessage($"Операция НЕ выполнена. Код ошибки: {result}");
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
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
                    GetMessage($"Операция НЕ отменена. Код ошибки: {result}");
                else
                    GetMessage("Операция отменена");
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        //отмена транзакции
        public void Confirmed()
        {
            try
            {
                int result = Server.NFun((int)Operations.ConfirmedTransaction);
                if (result != 0)
                    GetMessage($"Транзакция не переведена в режим \"Подтверждённая\". Код ошибки: {result}");
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        //отмена транзакции
        public void Unconfirmed()
        {
            try
            {
                int result = Server.NFun((int)Operations.UnconfirmedTransaction);
                if (result != 0)
                    GetMessage($"Транзакция не переведена в режим \"Неподтверждённая\". Код ошибки: {result}");
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        //возврат средств
        public void Return()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.Return);
                if (result != 0)
                    GetMessage($"Средства НЕ возвращены. Код ошибки: {result}");
                else
                    GetMessage("Средства возвращены");
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        //операция закрытия дня
        public void CloseDay()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.Total);
                if (result != 0)
                    GetMessage($"День терминала НЕ закрыт. Код ошибки: {result}");
                else
                {
                    ReceiptStr = Server.GParamString("Cheque");
                    ReceiptName = "Z-отчёт по банковским картам";
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        public void GetXReport()
        {
            try
            {
                Server.Clear();
                int result = Server.NFun((int)Operations.XReport);
                if (result != 0)
                    GetMessage($"X-отчёт не получен. Код ошибки: {result}");
                else
                {
                    ReceiptStr = Server.GParamString("Cheque");
                    ReceiptName = "X-отчёт по банковским картам";
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        //действие при удалении объекта класса
        public void Dispose()
        {
            Server.Clear();
        }
    }
}
