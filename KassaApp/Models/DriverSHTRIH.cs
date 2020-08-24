using DrvFRLib;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KassaApp.Models
{
    /// <summary>
	/// Класс содержит функционал для работы с 
    /// фискальными регистраторами фирмы ШТРИХ-М.
	/// </summary>
    class DriverSHTRIH : IFiscalRegistrar
    {
        private int SysAdminPassword = 0; //пароль сис. админа
        private int OperatorPassword = 0; // пароль текущего пользователя
        protected DrvFR Driver { get; set; }
        /// <summary>
        /// Конструктор класса.
        /// Выполняет подключение к фискальному регистратору
        /// и получает пароль сис. админа.
        /// </summary>
        public DriverSHTRIH()
        {
            //подключение к ККТ при создании объекта класса
            Connect();
            //получение пароля сис. админа
            if (CheckConnect() == 0)
            {
                Driver.TableNumber = 2;
                Driver.RowNumber = 30;
                Driver.FieldNumber = 1;
                ExecuteAndHandleError(Driver.ReadTable);
                SysAdminPassword = Driver.ValueOfFieldInteger;
            }
        }
        /// <summary>
		/// Метод выполняет отключение от фискального регистратора при 
        /// удалении объекта.
		/// </summary>
        public void Dispose()
        {
            //отключение от ККТ при удалении объекта класса
            Disconnect();
        }
        /// <summary>
		/// Метод выполняет отключение от фискального регистратора.
		/// </summary>
        protected void Disconnect()
        {
            //Отключение от ККТ
            if(ExecuteAndHandleError(Driver.Disconnect, true) == 0)
                Log.Logger.Info($"Фискальный регистратор отключен");
        }
        /// <summary>
		/// Метод выполняет проверку подключения к фискальному регистратору.
		/// </summary>
        /// <returns>Результат работы метода.</returns>
        public int CheckConnect()
        {
            int res = ExecuteAndHandleError(Driver.CheckConnection);
            if(res == 0)
                Log.Logger.Info($"Есть связь с ККТ");
            else
                Log.Logger.Info($"Нет связи с ККТ");
            return res;
        }
        /// <summary>
		/// Метод выполняет подключение к фискальному регистратору.
		/// </summary>
        protected void Connect()
        {
            var driverData = ConfigurationManager.AppSettings;
            try
            {
                //подключение через сом порт
                //данные для подключения из app.config
                Driver = new DrvFR()
                {
                    ConnectionType = int.Parse(driverData["ConnectionType"]),
                    ComNumber = int.Parse(driverData["ComNumber"]),
                    BaudRate = int.Parse(driverData["BaudRate"]),
                    Timeout = int.Parse(driverData["Timeout"]),
                    Password = int.Parse(driverData["Password"])
                };
                Log.Logger.Info($"Подключение к ККТ: Тип подключения = {Driver.ConnectionType} " +
                    $"COM-порт = {Driver.ComNumber} Скорость обмена = {Driver.BaudRate}");
                ExecuteAndHandleError(Driver.Connect, true);
            }
            catch (Exception ex)
            {
                GetMessage(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
		/// Метод выводит сообщения, возвращаемые фискальным регистратором.
		/// </summary>
        private void GetMessage(string message)
        {
            MessageBox.Show(message, "Фискальный регистратор");
        }
        /// <summary>
		/// Метод выводит описание ошибок, возвращаемых фискальным регистратором.
		/// </summary>
        protected void CheckResult(int code, bool ViewMessage)
        {
            if (ViewMessage && code != 0)
            {
                GetMessage($"Код: {code}\nОшибка: {Driver.ResultCodeDescription}");
                Log.Logger.Error($"ККТ: Код: {code} Ошибка: {Driver.ResultCodeDescription}");
            }
        }
        protected delegate int Func();
        /// <summary>
		/// Метод выполняет функции фискального регистратора.
		/// </summary>
        /// <param name="function">Функция фискального регистратора, 
        /// которую необходимо выполнить.</param>
        /// <param name="ViewMessage">Признак необходимости вывода сообщения с результатом
        /// выполнения метода.</param>
        /// <returns>Результат работы метода.</returns>
        protected int ExecuteAndHandleError(Func function, bool ViewMessage = false)
        {
            while (true)
            {
                var ret = function();
                switch (ret)
                {
                    case 0x50:
                        continue;
                    default:
                        CheckResult(ret, ViewMessage);
                        return ret;
                }
            }
        }
        /// <summary>
		/// Метод выполняет проверку текущего состояния ККТ и при необходимости
        /// открывает/закрывает смену или отменяет открытый чек.
		/// </summary>
        public void PrepareReceipt()
        {
            ExecuteAndHandleError(Driver.WaitForPrinting);
            ExecuteAndHandleError(Driver.GetECRStatus);
            switch (Driver.ECRMode)
            {
                case 3:
                    ExecuteAndHandleError(Driver.WaitForPrinting);
                    //Снятие Z-отчёта, закрытие смены
                    if (MessageBox.Show("24 часа истеки! Зактыть смену?", "Фискальный регистратор", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrintZReport();
                        //Открытие смены
                        if (MessageBox.Show("Смена закрыта! Открыть новую смену?", "Фискальный регистратор", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            PrintOpenSessionReport();
                    }
                    break;
                case 4:
                    //Открытие смены
                    if (MessageBox.Show("Смена закрыта! Открыть новую смену?", "Фискальный регистратор", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        PrintOpenSessionReport();
                    break;
                case 8:
                    //Отмена чека
                    OperatorPassword = Driver.Password;
                    Driver.Password = SysAdminPassword;
                    if (MessageBox.Show("Открыт другой чек! Отменить чек?", "Фискальный регистратор", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Log.Logger.Info($"Отмена открытого чека...");
                        if(ExecuteAndHandleError(Driver.SysAdminCancelCheck, true) == 0)
                            Log.Logger.Info($"Чек отменён");
                    }
                    Driver.Password = OperatorPassword;
                    break;
            }
            ExecuteAndHandleError(Driver.WaitForPrinting);
        }
        /// <summary>
        /// Метод выполняет печать нефискальных документов.
        /// </summary>
        /// <param name="receiptStr">Текст документа.</param>
        /// <param name="receiptName">Название документа.</param>
        /// <param name="Save">Признак необходимости сохранения чека в базу данных.</param>
        /// <returns>Результат работы метода.</returns>
        public int Print(string receiptStr, string receiptName, bool Save = true)
        {
            Log.Logger.Info($"Печать нефискального документа...");
            PrepareReceipt();
            if (receiptStr == null)
                return -1;
            int res = 0;
            var mas = receiptStr.Replace("~S", "^").Split('^');//отделяет чек терминала от его копии
            if(mas.Length > 2)//если чек с копией
            {
                for(int i = 0; i<=1; i++)
                    res = Print(mas[i], receiptName, i != 0 ? false : true);
                return res;
            }
            else
            {
                receiptStr = receiptStr.Replace("~S", "");
                Driver.StringForPrinting = StringFormatForPrint(receiptStr, 1);
                res = ExecuteAndHandleError(Driver.PrintString);
                Thread.Sleep(3000);
            }
            //Ожидание печати чека
            res = ExecuteAndHandleError(Driver.WaitForPrinting, true); 
            while (res != 0)
            {
                Log.Logger.Warn($"Ошибка печати: {Driver.ResultCodeDescription}");
                if (MessageBox.Show("Продолжить печать?", "Фискальный регистратор", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Log.Logger.Info($"Продолжение печати");
                    ExecuteAndHandleError(Driver.PrintString, true);
                }
                else
                {
                    Log.Logger.Info($"Отмена печати");
                    break;
                }
                res = ExecuteAndHandleError(Driver.WaitForPrinting);
            }
            //Отрезка чека
            if (res == 0)
            {
                //отступ после документа
                Driver.StringQuantity = 2;
                Driver.UseReceiptRibbon = true;
                ExecuteAndHandleError(Driver.FeedDocument, true);
                Log.Logger.Info($"Отрезка чека");
                res = ExecuteAndHandleError(Driver.CutCheck, true);
                return res;
            }
            //сохранение отчёта
            if (Save && res == 0)
            {
                Log.Logger.Info($"Сохранение чека...");
                SaveReport(receiptName, receiptStr);
            }
            return res;
        }
        /// <summary>
        /// Метод формирует строку для печати с необходимым выравниванием.
        /// </summary>
        /// <param name="stringForPrint">Строка для форматирования.</param>
        /// <param name="align">Способ выравнивания.</param>
        /// <returns>Результат работы метода.</returns>
        private string StringFormatForPrint(string stringForPrint, int align = 0)
        {
            Log.Logger.Info("Формирование строки для печати нефискального документа");
            //alignment 0 - left, 1 - center, 2 - right, 
            //3 - пробелы внутри строки
            string r, l;
            string res = "";
            if (align == 3)
            {
                if (stringForPrint.Length < 36)
                {
                    var strMas = stringForPrint.Split('\n');
                    l = new string(' ', 36 - strMas[0].Length - strMas[1].Length);
                    stringForPrint = strMas[0] + l + strMas[1];
                }
                return stringForPrint;
            }
            else
            {
                foreach (var str in stringForPrint.Split('\n'))
                {
                    if (str.Length < 36)
                    {
                        l = new string(' ', (36 - str.Length) / 2);
                        if ((36 - str.Length) % 2 == 1)
                            r = l + " ";
                        else
                            r = l;
                        switch (align)
                        {
                            case 0: res += str + r + l; break;
                            case 1: res += l + str + r; break;
                            case 2: res += l + r + str; break;
                        }
                    }
                    else
                        res += str;
                }
                Log.Logger.Info("Строка сформирована");
                return res;
            }
        }
        /// <summary>
        /// Метод выполняет печать фискальных чеков.
        /// </summary>
        /// <param name="receipt">Чек для печати.</param>
        /// <param name="cardName">Имя банковской карты.</param>
        /// <returns>Результат работы метода.</returns>
        public int PrintReceipt(Receipt receipt, string cardName = null)
        {
            Log.Logger.Info($"Печать фискального чека ID = {receipt.Id}...");
            if (CheckConnect() == 0)
            {
                PrepareReceipt();
                decimal sum = 0, discountOnProduct = 0, discountOnReceipt = 0, amountDiscount = 0;
                Driver.CheckType = 0;
                //Открытие чека
                Log.Logger.Info("Открытие фискального чека...");
                if (ExecuteAndHandleError(Driver.OpenCheck, true) != 0)
                    return -1;
                //if (receipt.Phone != null)
                //    Driver.CustomerEmail = receipt.Phone;
                //else if (receipt.Email != null)
                //    Driver.CustomerEmail = receipt.Email;
                ////Передача данных покупателя
                //if(receipt.Phone != null || receipt.Email != null)
                //    ExecuteAndHandleError(Driver.FNSendCustomerEmail);
                foreach (Product p in receipt.Products)
                {
                    //пробитие позиций
                    Driver.CheckType = 0;
                    Driver.StringForPrinting = p.Name;
                    discountOnProduct = Math.Round(p.Price * (decimal)p.Discount / 100, 2);
                    Driver.Price = p.Price - discountOnProduct;
                    discountOnProduct *= p.Quantity;
                    if (receipt.Discount > 0)
                    {
                        discountOnReceipt = Driver.Price * (decimal)receipt.Discount / 100;
                        discountOnProduct += discountOnReceipt;
                        Driver.Price -= discountOnReceipt; 
                    }
                    Driver.Quantity = p.Quantity;
                    sum += (decimal)Driver.Quantity * Driver.Price;
                    Driver.Department = p.Department;
                    Driver.PaymentTypeSign = 4;
                    if (p.Type == 1)
                        Driver.PaymentItemSign = 1;
                    else if (p.Type == 2)
                        Driver.PaymentItemSign = 4;

                    if (p.NDS == 20)
                        Driver.Tax1 = 1;
                    else if (p.NDS == 18)
                        Driver.Tax1 = 2;
                    else if (p.NDS == 0)
                        Driver.Tax1 = 4;
                    Log.Logger.Info($"Фиксация позиции: Товар: {p.Name} Количество: {p.Quantity} " +
                        $"Цена: {p.Price} Скидка: {discountOnProduct}");
                    if (ExecuteAndHandleError(Driver.FNOperation, true) != 0)
                        return -1;
                    if(discountOnProduct > 0)
                    {
                        Driver.StringForPrinting = StringFormatForPrint($"В том числе скидка\n={string.Format("{0:f}", discountOnProduct).Replace(",", ".")}", 3);
                        ExecuteAndHandleError(Driver.PrintString);
                    }    
                    amountDiscount += discountOnProduct;
                    if (p.BarCode != null && p.BarCode != "")
                    {
                        Driver.StringForPrinting = StringFormatForPrint($"ШК: {p.BarCode}");
                        ExecuteAndHandleError(Driver.PrintString);
                    }
                }
                Driver.StringForPrinting = StringFormatForPrint($"Всего\n={string.Format("{0:f}", sum).Replace(",", ".")}",3);
                ExecuteAndHandleError(Driver.PrintString);
                if (amountDiscount > 0 && receipt.Discount > 0)
                {
                    Driver.StringForPrinting = StringFormatForPrint($"Всего скидка\n={string.Format("{0:f}", amountDiscount).Replace(",", ".")}", 3);
                    ExecuteAndHandleError(Driver.PrintString);
                }
                //указание способа оплаты
                if (cardName == null)
                    cardName = "";
                Driver.Summ1 = 0;
                Driver.Summ2 = 0;
                Driver.Summ3 = 0;
                Driver.Summ4 = 0;
                if (receipt.Payment == 1)
                    Driver.Summ1 = receipt.Summa;
                else if (receipt.Payment == 2)
                    switch (cardName.ToLower())
                    {
                        case "мир": 
                            Driver.Summ2 = receipt.Summa; break;
                        case "visa": 
                            Driver.Summ3 = receipt.Summa; break;
                        case "mastercard": 
                            Driver.Summ4 = receipt.Summa; break;
                        default:
                            Driver.Summ2 = receipt.Summa; break;
                    }
                Driver.Summ5 = 0;
                Driver.Summ6 = 0;
                Driver.Summ7 = 0;
                Driver.Summ8 = 0;
                Driver.Summ9 = 0;
                Driver.Summ10 = 0;
                Driver.Summ11 = 0;
                Driver.Summ12 = 0;
                Driver.Summ13 = 0;
                Driver.Summ14 = 0;
                Driver.Summ15 = 0;
                Driver.Summ16 = 0;
                Driver.TaxValue1 = 0;
                Driver.TaxValue2 = 0;
                Driver.TaxValue3 = 0;
                Driver.TaxValue4 = 0;
                Driver.TaxValue5 = 0;
                Driver.TaxValue6 = 0;
                Driver.TaxType = 1;
                //дополнительные данные чека по ДК
                string dkData = $"~~~~~~~~~~~~~~Дисконт~~~~~~~~~~~~~~~\n" +
                                $"ДК: {receipt.DiscountCard}                     \n" +
                                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                                $"Cash Back программа\n" +
                                $"Баланс был: {0}\n" +
                                $"Списано: {0}\n" +
                                $"Доступно: {0}\n" +
                                $"В том числе промо баллы: {0}\n" +
                                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
                if (receipt.DiscountCard != null && receipt.DiscountCard != "")
                {
                    Driver.StringForPrinting = StringFormatForPrint(dkData, 1);
                    ExecuteAndHandleError(Driver.PrintString);
                }
                //формирование итоговой информации чека
                string payment = (receipt.Payment == 1) ? "наличные" : "пласт. карта";
                decimal cardSum = ((receipt.Payment == 2) ? receipt.Summa : 0),
                        cashSum = ((receipt.Payment == 1) ? receipt.Summa : 0);
                string change = receipt.Payment == 1 ? string.Format("{0:f}", cashSum - sum).Replace(",", ".") : "0.00";
                string result = $"Вид оплаты: {payment}\n" +
                                $"Сумма по карте: {string.Format("{0:f}", cardSum).Replace(",", ".")}\n" +
                                $"Сумма наличных: {string.Format("{0:f}", cashSum).Replace(",", ".")}\n" +
                                $"Сдача: {change}\n" +
                                $"Сумма прописью:\n" +
                                $"{RusCurrency.Str((double)receipt.Summa)}";
                Driver.StringForPrinting = StringFormatForPrint(result);
                ExecuteAndHandleError(Driver.PrintString);
                Driver.StringForPrinting = "";
                //Закрытие чека
                Log.Logger.Info("Закрытие чека...");
                return GetReport(Driver.FNCloseCheckEx, "Кассовый чек");   
            }
            return -1;
        }
        /// <summary>
        /// Метод формирует шаблон х-отчёта (без гашения) для сохранения.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintXReport()
        {
            Log.Logger.Info("Формирование отчёта \"СУТОЧНЫЙ ОТЧ. БЕЗ ГАШ.\"...");
            string title = GetTitle("СУТОЧНЫЙ ОТЧ. БЕЗ ГАШ.");
            //получение шаблона отчёта
            string template = $"{title}\r\n" +
                    $"ЧЕКОВ ЗА СМЕНУ: {GetOperRegItem(144).Content}\r\n" +
                    $"ФД ЗА СМЕНУ: {GetOperRegItem(193).Content}\r\n" +
                    $"ЧЕКОВ ПРИХОДА: {GetOperRegItem(148).Content}\r\n{GetOperRegItem(144).Content}   = {GetCashRegItem(121).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {GetCashRegItem(193).Content}\r\n  " +
                        $"КАРТОЙ: {GetCashRegItem(197).Content}\r\n" +
                    $"ЧЕКОВ РАСХОДА: {GetOperRegItem(149).Content}\r\n{GetOperRegItem(145).Content}   = {GetCashRegItem(122).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {GetCashRegItem(194).Content}\r\n  " +
                        $"КАРТОЙ: {GetCashRegItem(198).Content}\r\n" +
                    $"ЧЕКОВ ВОЗВРАТА ПРИХОДА: {GetOperRegItem(150).Content}\r\n{GetOperRegItem(146).Content}   = {GetCashRegItem(123).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {GetCashRegItem(195).Content}\r\n  " +
                        $"КАРТОЙ: {GetCashRegItem(199).Content}\r\n" +
                    $"ЧЕКОВ ВОЗВРАТА РАСХОДА: {GetOperRegItem(151).Content}\r\n{GetOperRegItem(147).Content}   = {GetCashRegItem(124).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {GetCashRegItem(196).Content}\r\n  " +
                        $"КАРТОЙ: {GetCashRegItem(200).Content}\r\n" +
                    $"ВНЕСЕНИЙ: {GetOperRegItem(155).Content}\r\n{GetOperRegItem(153).Content}   = {GetCashRegItem(242).Content}\r\n" +
                    $"ВЫПЛАТ: {GetOperRegItem(156).Content}\r\n{GetOperRegItem(154).Content}   = {GetCashRegItem(243).Content}\r\n" +
                    $"ЧЕКОВ КОРРЕКЦИИ ПРИХОДА: {GetOperRegItem(202).Content}\r\n" +
                    $"ЧЕКОВ КОРРЕКЦИИ РАСХОДА: {GetOperRegItem(203).Content}\r\n" +
                    $"АНУЛИРОВАННЫХ ЧЕКОВ: {GetOperRegItem(166).Content}\r\n" +
                        $"ПРИХОДА: {GetCashRegItem(249).Content}\r\n" +
                        $"РАСХОДА: {GetCashRegItem(250).Content}\r\n" +
                        $"ВОЗВРАТА ПРИХОДА: {GetCashRegItem(251).Content}\r\n" +
                        $"ВОЗВРАТА РАСХОДА: {GetCashRegItem(252).Content}\r\n" +
                    $"НАЛ. В КАССЕ: {GetCashRegItem(241).Content}\r\n" +
                    $"ВЫРУЧКА: {double.Parse(GetCashRegItem(121).Content) - double.Parse(GetCashRegItem(122).Content) - double.Parse(GetCashRegItem(123).Content) + double.Parse(GetCashRegItem(124).Content)}\r\n";
            //печать и сохранение отчёта
            Log.Logger.Info("Печать х-отчёта (без гашения)...");
            return GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)", template);
        }
        /// <summary>
        /// Метод формирует шаблон х-отчёта по секциям для сохранения.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintXSectionReport()
        {
            Log.Logger.Info("Формирование отчёта \"ОТЧЁТ ПО СЕКЦИЯМ\"...");
            //получение шаблона отчёта
            int sectionNum = 1;
            decimal resP = 0, resR = 0, resVP = 0, resVR = 0;
            string title = GetTitle("ОТЧЁТ ПО СЕКЦИЯМ");
            string template = $"{title}\r\n";
            for (int i = 72; i < 136; i += 4)
            {
                if (double.Parse(GetOperRegItem(i).Content) > 0 || double.Parse(GetOperRegItem(i + 1).Content) > 0 ||
                    double.Parse(GetOperRegItem(i + 2).Content) > 0 || double.Parse(GetOperRegItem(i + 3).Content) > 0)
                    template += $"  СЕКЦИЯ {sectionNum}\r\n{GetOperRegItem(i).Content} " +
                        $"ПРИХОД: { GetCashRegItem(121 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 1).Content} " +
                        $"РАСХОД: { GetCashRegItem(122 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 2).Content} " +
                        $"ВОЗВРАТ ПРИХОДА: { GetCashRegItem(123 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 3).Content} " +
                        $"ВОЗВРАТ РАСХОДА: { GetCashRegItem(124 + 4 * (sectionNum - 1)).Content}\r\n";
                sectionNum++;
            }
            resP = decimal.Parse(GetCashRegItem(193).Content) + decimal.Parse(GetCashRegItem(197).Content) + decimal.Parse(GetCashRegItem(201).Content) + decimal.Parse(GetCashRegItem(205).Content);
            resR = decimal.Parse(GetCashRegItem(194).Content) + decimal.Parse(GetCashRegItem(198).Content) + decimal.Parse(GetCashRegItem(202).Content) + decimal.Parse(GetCashRegItem(206).Content);
            resVP = decimal.Parse(GetCashRegItem(195).Content) + decimal.Parse(GetCashRegItem(199).Content) + decimal.Parse(GetCashRegItem(203).Content) + decimal.Parse(GetCashRegItem(207).Content);
            resVR = decimal.Parse(GetCashRegItem(196).Content) + decimal.Parse(GetCashRegItem(200).Content) + decimal.Parse(GetCashRegItem(204).Content) + decimal.Parse(GetCashRegItem(208).Content);
            template += $"  ИТОГ ПО СЕКЦИЯМ\r\n" +
                    $"ПРИХОД: {resP}\r\n" +
                    $"РАСХОД: {resR}\r\n" +
                    $"ВОЗВРАТ ПРИХОДА: {resVP}\r\n" +
                    $"ВОЗВРАТ РАСХОДА: {resVR}\r\n" +
                $"  СКИДКИ\r\n{GetOperRegItem(136).Content} " +
                    $"ПРИХОД: {GetCashRegItem(185).Content}\r\n{GetOperRegItem(137).Content} " +
                    $"РАСХОД: {GetCashRegItem(186).Content}\r\n{GetOperRegItem(138).Content} " +
                    $"ВОЗВРАТ ПРИХОДА: {GetCashRegItem(187).Content}\r\n{GetOperRegItem(139).Content} " +
                    $"ВОЗВРАТ РАСХОДА: {GetCashRegItem(188).Content}\r\n" +
                $"  НАДБАВКИ\r\n{GetOperRegItem(140).Content} " +
                    $"ПРИХОД: {GetCashRegItem(189).Content}\r\n{GetOperRegItem(141).Content} " +
                    $"РАСХОД: {GetCashRegItem(190).Content}\r\n{GetOperRegItem(142).Content} " +
                    $"ВОЗВРАТ ПРИХОДА: {GetCashRegItem(191).Content}\r\n{GetOperRegItem(143).Content} " +
                    $"ВОЗВРАТ РАСХОДА: {GetCashRegItem(192).Content}\r\n" +
                $"  ИТОГО\r\n" +
                    $"ПРИХОД: {resP}\r\n" +
                    $"РАСХОД: {resR}\r\n" +
                    $"ВОЗВРАТ ПРИХОДА: {resVP}\r\n" +
                    $"ВОЗВРАТ РАСХОДА: {resVR}\r\n" +
                $"ВЫРУЧКА: {resP - resR - resVP + resVR}";
            //печать и сохранение отчёта
            Log.Logger.Info("Печать х-отчёта по секциям...");
            return GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям", template);
        }
        /// <summary>
        /// Метод формирует шаблон х-отчёта по налогам для сохранения.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintXTaxReport()
        {
            Log.Logger.Info("Формирование отчёта \"ОТЧЁТ ПО НАЛОГАМ\"...");
            string template = null;
            //получение шаблона отчёта
            string title = GetTitle("ОТЧЁТ ПО НАЛОГАМ");
            if (title != null)
            {
                template = $"{title}\r\n" +
                $"Группа А          НДС 20%:\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(209).Content}\r\n" +
                    $"Налог: {GetCashRegItem(225).Content}\r\n" +
                $"Группа Б          НДС 10%\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(213).Content}\r\n" +
                    $"Налог: {GetCashRegItem(229).Content}\r\n" +
                $"Группа В          НДС 0%\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(217).Content}\r\n" +
                    $"Налог: {GetCashRegItem(233).Content}\r\n" +
                $"Группа Г          БЕЗ НДС\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(221).Content}\r\n" +
                    $"Налог: {GetCashRegItem(237).Content}\r\n" +
                $"Группа Д          НДС 20/120\r\n" +
                    $"Оборот по налогу: {0}\r\n" +
                    $"Налог: {0}\r\n" +
                $"Группа Е          НДС 10/110\r\n" +
                    $"Оборот по налогу: {0}\r\n" +
                    $"Налог: {0}\r\n";
            }
            Log.Logger.Info("Печать х-отчёта по налогам...");
            //печать и сохранение отчёта
            return GetReport(Driver.PrintTaxReport, "X-отчёт по налогам", template);
        }
        /// <summary>
        /// Метод отвечает за открытие смены.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintOpenSessionReport()
        {
            Log.Logger.Error($"Открытие смены ККТ...");
            return GetReport(Driver.OpenSession, "Отчёт об открытии смены");
        }
        /// <summary>
        /// Метод отвечает за закрытие смены.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintZReport()
        {
            Log.Logger.Error($"Закрытие смены ККТ...");
            return GetReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }
        /// <summary>
        /// Метод формирует шаблон операционных регистров для сохранения.
        /// </summary>
        /// <returns>Результат работы метода.</returns>
        public int PrintOperationReg()
        {
            Log.Logger.Info("Формирование отчёта \"ОПЕРАЦИОННЫЕ РЕГИСТРЫ\"...");
            //получение шаблона отчёта
            string template = null;
            string title = GetTitle("ОПЕРАЦИОННЫЕ РЕГИСТРЫ");
            if (title != null)
            {
                template = $"{title}\r\n" +
                $"НОМЕР ПРИХОДА: {GetOperRegItem(148).Content}\r\n" +
                $"НОМЕР РАСХОДА: {GetOperRegItem(149).Content}\r\n" +
                $"НОМЕР ВОЗВРАТА ПРИХОДА: {GetOperRegItem(150).Content}\r\n" +
                $"НОМЕР ВОЗВРАТА РАСХОДА: {GetOperRegItem(151).Content}\r\n" +
                $"НОМЕР ВНЕСЕНИЯ: {GetOperRegItem(155).Content}\r\n" +
                $"НОМЕР ВЫПЛАТЫ: {GetOperRegItem(156).Content}\r\n" +
                $"НОМЕР СУТ. ОТЧ. БЕЗ ГАШ.: {GetOperRegItem(158).Content}\r\n" +
                $"НОМЕР ТЕХНОЛОГ. ТЕСТА: {GetOperRegItem(163).Content}\r\n" +
                $"НОМЕР ОТМЕН. ДОКУМЕНТОВ: {GetOperRegItem(166).Content}\r\n" +
                $"НОМЕР ОБЩЕГО ГАШЕНИЯ: {GetOperRegItem(160).Content}\r\n" +
                $"НОМЕР ОТЧЁТА ПО СЕКЦИЯМ: {GetOperRegItem(165).Content}\r\n" +
                $"НОМЕР ОТЧЁТА ПО НАЛОГАМ: {GetOperRegItem(178).Content}\r\n" +
                $"НОМЕР ОТЧЁТА ПО КАССИРАМ: {GetOperRegItem(187).Content}\r\n";
            }
            Log.Logger.Info("Печать операционных регистров...");
            //печать и сохранение отчёта
            return GetReport(Driver.PrintOperationReg, "Операционные регистры", template);
        }
        /// <summary>
        /// Метод отвечает за внесение наличных.
        /// </summary>
        /// <param name="summ">Сумма внесения.</param>
        /// <returns>Результат работы метода.</returns>
        public int CashIncome(decimal summ)
        {
            Log.Logger.Info($"Внесени наличных: {summ}...");
            //получение шаблона отчёта
            string template = null;
            string title = GetTitle("");
            if (title != null)
                template = $"{title}\r\nВНЕСЕНИЕ: {summ}";
            Driver.Summ1 = summ;
            //печать и сохранение отчёта
            return GetReport(Driver.CashIncome, "Внесение наличных", template);
        }
        /// <summary>
        /// Метод отвечает за выплату наличных.
        /// </summary>
        /// <param name="summ">Сумма выплаты.</param>
        /// <returns>Результат работы метода.</returns>
        public int CashOutcome(decimal summ)
        {
            Log.Logger.Info($"Выдача наличных: {summ}...");
            //получение шаблона отчёта
            string template = null;
            string title = GetTitle("");
            if (title != null)
                template = $"{title}\r\nВЫПЛАТА: {summ}";
            Driver.Summ1 = summ;
            //печать и сохранение отчёта
            return GetReport(Driver.CashOutcome, "Выплата наличных", template);
        }
        /// <summary>
        /// Метод отвечает за вызов печати и сохранения отчётов.
        /// </summary>
        /// <param name="function">Функция печати.</param>
        /// <param name="reportName">Имя отчёта.</param>
        /// <param name="template">Шаблон отчёта.</param>
        /// <returns>Результат работы метода.</returns>
        private int GetReport(Func function, string reportName, string template = null)
        {
            int res = ExecuteAndHandleError(function, true);
            if (function != null && res == 0)
            {
                res = ExecuteAndHandleError(Driver.WaitForPrinting, true);
                //Ожидание печати чека
                while (res != 0)
                {
                    Log.Logger.Warn($"Ошибка печати");
                    if (MessageBox.Show("Продолжить печать?", "Фискальный регистратор", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        Log.Logger.Info($"Продолжение печати");
                        ExecuteAndHandleError(Driver.ContinuePrint, true);
                    }

                    res = ExecuteAndHandleError(Driver.WaitForPrinting);
                }
                //Отрезка чека
                if (res == 0)
                {
                    Log.Logger.Info($"Отрезка чека");
                    res = ExecuteAndHandleError(Driver.CutCheck, true);//отрезка отчёта
                    Log.Logger.Info($"Сохранение отчёта \"{reportName}\"...");
                    SaveReport(reportName, template);//сохранение отчёта
                }
            }
            return res;
        }
        /// <summary>
        /// Метод отвечает сохранение отчётов в базу данных.
        /// </summary>
        /// <param name="reportName">Имя отчёта.</param>
        /// <param name="template">Шаблон отчёта.</param>
        private void SaveReport(string reportName, string template = null)
        {
            //получить статус ккт
            ExecuteAndHandleError(Driver.FNGetStatus);
            //получить текст отчёта
            if (template != null || ExecuteAndHandleError(Driver.FNGetDocumentAsString, true) == 0)
            {
                try
                {
                    using (var db = new KassaDBContext())
                    {
                        string d = null;
                        //сохранение шаблона
                        //иначе готовый отчёт
                        if (template != null)
                            d = template;
                        else if (Driver.StringForPrinting != null)
                            d = Driver.StringForPrinting;
                        if (d != null)
                        {
                            byte[] data = Encoding.Default.GetBytes(d);//перевод отчёта в байты
                            Report report = new Report()
                            {
                                Name = reportName,
                                ReportData = data,
                                Date = DateTime.Now
                            };
                            db.Report.Add(report);//добавление отчёта
                            db.SaveChanges();//сохранение отчёта
                            GetMessage($"Отчёт \"{reportName}\" сохранён!");
                            Log.Logger.Info($"Отчёт \"{reportName}\" сохранён!");
                        }
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            GetMessage($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                            Log.Logger.Error($"Ошибка при работе с таблицей Report " +
                                $"базы данных. Свойство: {validationError.PropertyName} " +
                                $"Ошибка: {validationError.ErrorMessage}");
                        }
                }
            }
        }
        /// <summary>
        /// Метод получает данные строки операционного регистра.
        /// </summary>
        /// <param name="number">Номер строки.</param>
        /// <returns>Данные строки операционного регистра.</returns>
        public RegistrerItem GetOperRegItem(int number)
        {
            Driver.RegisterNumber = number;
            if (ExecuteAndHandleError(Driver.GetOperationReg) == 0)
                return new RegistrerItem()
                {
                    Number = number,
                    Name = Driver.NameOperationReg,
                    Content = string.Format("{0:d4}",Driver.ContentsOfOperationRegister)
                };
            return null;
        }
        /// <summary>
        /// Метод получает данные строки денежного регистра.
        /// </summary>
        /// <param name="number">Номер строки.</param>
        /// <returns>Данные строки денежного регистра.</returns>
        public RegistrerItem GetCashRegItem(int number)
        {
            Driver.RegisterNumber = number;
            if (ExecuteAndHandleError(Driver.GetCashReg) == 0)
                return new RegistrerItem()
                {
                    Number = number,
                    Name = Driver.NameCashReg,
                    Content = Driver.ContentsOfCashRegister.ToString()
                };
            return null;
        }
        /// <summary>
        /// Метод формирует заголовок отчёта.
        /// </summary>
        /// <param name="reportName">Имя отчёта.</param>
        /// <returns>Заголовок отчёта.</returns>
        public string GetTitle(string reportName)
        {
            Log.Logger.Info($"Формирование заголовка отчёта...");
            if (CheckConnect() == 0)
            {
                if (reportName != "")
                    reportName += "\r\n";
                ExecuteAndHandleError(Driver.GetECRStatus);
                var znkkt = Driver.SerialNumber;
                Driver.TableNumber = 2;
                Driver.RowNumber = Driver.OperatorNumber;
                Driver.FieldNumber = 2;
                ExecuteAndHandleError(Driver.ReadTable);
                ExecuteAndHandleError(Driver.FNGetSerial);
                ExecuteAndHandleError(Driver.FNGetFiscalizationResult);
                return $"ЗН ККТ: {znkkt}\r\n" +
                    $"ИНН: {Driver.INN}\r\n" +
                    $"ДАТА: {DateTime.Now}\r\n" +
                    $"Кассир: {Driver.ValueOfFieldString}\r\n" +
                    $"{reportName}" +
                    $"РН ККТ: {Driver.KKTRegistrationNumber}\r\n" +
                    $"ФН: {Driver.SerialNumber}\r\n" +
                    $"СМЕНА: {Driver.SessionNumber + 1}\r\n";
            }
            return null;
        }
    }
}
