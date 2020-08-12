using SBRFSRV;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    /// <summary>
	/// Класс содержит функционал для работы с 
    /// терминалом Pax через драйвер SBRF.
	/// </summary>
    class PaxTerminal : ITerminal
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
        /// <summary>
        /// Конструктор класса.
        /// Выполняет создание объекта сервера.
        /// </summary>
        public PaxTerminal()
        {
            Log.Logger.Info($"Подключение к терминалу");
            Server = new Server();
        }
        /// <summary>
        /// Метод возвращает имя банковской карты.
        /// </summary>
        /// <returns>Имя банквской карты.</returns>
        public string GetCardName()
        {
            return CardName;
        }
        /// <summary>
        /// Метод выводит сообщения, возвращаемые терминалом.
        /// </summary>
        private void GetMessage(string message)
        {
            MessageBox.Show(message, "Терминал");
        }
        /// <summary>
        /// Метод возвращает чек, сформированный терминалом.
        /// </summary>
        /// <returns>Чек терминала.</returns>
        public string GetReceipt()
        {
            return ReceiptStr;
        }
        /// <summary>
        /// Метод возвращает имя документа.
        /// </summary>
        /// <returns>Имя документа.</returns>
        public string GetReceiptName()
        {
            return ReceiptName;
        }
        /// <summary>
        /// Метод проверяет связь с терминалом.
        /// </summary>
        /// <returns>Призвак подключения терминала.</returns>
        public bool IsEnabled()
        {
            Log.Logger.Info($"Проверка связи с терминалом");
            try
            {
                if (Server.NFun((int)Operations.PinPadEnabled) == 0)
                    return true;
                Log.Logger.Info($"Есть связь с терминалом");
            }
            catch (Exception ex)
            {
                Log.Logger.Info($"Нет связи с терминалом");
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
            return false;
        }
        /// <summary>
        /// Метод выполняет операцию покупки.
        /// </summary>
        /// <param name="sum">Сумма покупки (в рублях).</param>
        /// <returns>Результат работы метода.</returns>
        public int Purchase(decimal sum)
        {
            try
            {
                Log.Logger.Info($"Оплата покупки через терминал: {sum} руб.");
                Server.Clear();
                Server.SParam("Amount", sum * 100);
                int result = Server.NFun((int)Operations.Purchase);
                if (result == 0)
                {
                    Log.Logger.Info($"Получение чека");
                    ReceiptStr = Server.GParamString("Cheque");
                    ReceiptName = "Чек терминала";
                    Log.Logger.Info($"Получение имени карты");
                    CardName = Server.GParamString("CardName");
                    Log.Logger.Info($"Оплата: Успешно");
                    return result;
                }
                else
                {
                    Log.Logger.Error($"Ошибка оплаты. Код ошибки: {result}");
                    GetMessage($"Операция НЕ выполнена. Код ошибки: {result}");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
            return -1;
        }
        /// <summary>
        /// Метод выполняет отмену транзакции.
        /// </summary>
        public void CancelTransaction()
        {
            try
            {
                Log.Logger.Info($"Отмена транзакции...");
                Server.Clear();
                int result = Server.NFun((int)Operations.Cancel);
                if (result != 0)
                {
                    Log.Logger.Error($"Транзакция не отменена. Код ошибки: {result}");
                    GetMessage($"Операция НЕ отменена. Код ошибки: {result}");
                }
                else
                {
                    Log.Logger.Info($"Транзакция отменена");
                    GetMessage("Операция отменена");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод переводит транзакцию в режим "Подтверждённая".
        /// </summary>
        public void Confirmed()
        {
            try
            {
                Log.Logger.Info($"Перевод транзакции в режим \"Подтверждённая\"");
                int result = Server.NFun((int)Operations.ConfirmedTransaction);
                if (result != 0)
                {
                    Log.Logger.Error($"Транзакция не переведена в режим \"Подтверждённая\". Код ошибки: {result}");
                    GetMessage($"Транзакция не переведена в режим \"Подтверждённая\". Код ошибки: {result}");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод переводит транзакцию в режим "Неподтверждённая".
        /// </summary>
        public void Unconfirmed()
        {
            try
            {
                Log.Logger.Info($"Перевод транзакции в режим \"Неподтверждённая\"");
                int result = Server.NFun((int)Operations.UnconfirmedTransaction);
                if (result != 0)
                {
                    Log.Logger.Error($"Транзакция не переведена в режим \"Неподтверждённая\". Код ошибки: {result}");
                    GetMessage($"Транзакция не переведена в режим \"Неподтверждённая\". Код ошибки: {result}");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод выполняет операцию возврата средств.
        /// </summary>
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
        /// <summary>
        /// Метод выполняет операцию закрытия дня.
        /// </summary>
        public void CloseDay()
        {
            try
            {
                Log.Logger.Info($"Закрытие дня терминала...");
                Server.Clear();
                int result = Server.NFun((int)Operations.Total);
                if (result != 0)
                {
                    Log.Logger.Error($"День терминала НЕ закрыт. Код ошибки: {result}");
                    GetMessage($"День терминала НЕ закрыт. Код ошибки: {result}");
                }
                else
                {
                    Log.Logger.Info($"Получение отчёта о закрытии дня...");
                    ReceiptStr = Server.GParamString("Cheque");
                    ReceiptName = "Z-отчёт по банковским картам";
                    Log.Logger.Info($"Отчёт получен");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод получает x-отчёт по банковским картам.
        /// </summary>
        public void GetXReport()
        {
            try
            {
                Log.Logger.Info($"Получение X-отчёта по банковским картам...");
                Server.Clear();
                int result = Server.NFun((int)Operations.XReport);
                if (result != 0)
                {
                    Log.Logger.Error($"X-отчёт не получен. Код ошибки: {result}");
                    GetMessage($"X-отчёт не получен. Код ошибки: {result}");
                }
                else
                {
                    ReceiptStr = Server.GParamString("Cheque");
                    ReceiptName = "X-отчёт по банковским картам";
                    Log.Logger.Info($"Отчёт получен");
                }
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
		/// Метод выполняет очистку сервера при удалении объекта.
		/// </summary>
        public void Dispose()
        {
            Log.Logger.Info($"Отключение от терминала");
            Server.Clear();
        }
    }
}
