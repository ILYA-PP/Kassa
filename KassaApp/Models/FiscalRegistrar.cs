using DrvFRLib;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    class FiscalRegistrar
    {
        private DrvFR Driver { get; set; }
        //проверка состояния ККТ перед печатью
        public void prepareCheque()
        {
            executeAndHandleError(Driver.WaitForPrinting);
            executeAndHandleError(Driver.GetECRStatus);
            switch (Driver.ECRMode)
            {
                case 3:
                    //Снятие Z-отчёта
                    executeAndHandleError(Driver.WaitForPrinting);
                    executeAndHandleError(Driver.PrintReportWithCleaning, true);
                    GetReport(null, "Z-отчёт (c гашением)");
                    //Открытие смены
                    executeAndHandleError(Driver.OpenSession, true);
                    GetReport(null, "Отчёт об открытии смены"); break;
                case 4:
                    //Открытие смены
                    executeAndHandleError(Driver.OpenSession, true);
                    GetReport(null, "Отчёт об открытии смены"); break;
                case 8:
                    //Отмена чека
                    executeAndHandleError(Driver.SysAdminCancelCheck, true);
                    break;
            }
            executeAndHandleError(Driver.WaitForPrinting);
        }
        public void Disconnect()
        {
            //Отключение от ККТ
            executeAndHandleError(Driver.Disconnect, true);
        }
        public int Print(string s)
        {
            prepareCheque();
            Driver.StringForPrinting = s;
            return executeAndHandleError(Driver.PrintString, true);
        }

        public int CheckConnect()
        {
            return executeAndHandleError(Driver.Connect);
        }
        //подключение к фискальному регистратору
        public void Connect()
        {
            var driverData = ConfigurationManager.AppSettings;
            try
            {
                Driver = new DrvFR()
                {
                    ConnectionType = int.Parse(driverData["ConnectionType"]),
                    ComNumber = int.Parse(driverData["ComNumber"]),
                    BaudRate = int.Parse(driverData["BaudRate"]),
                    Timeout = int.Parse(driverData["Timeout"]),
                    Password = int.Parse(driverData["Password"])
                };
                executeAndHandleError(Driver.Connect);
                Driver.WaitForPrintingDelay = 20;
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }
        //вывод, возвращаемых фискальником сообщений
        private void AddLog(string mes)
        {
            MessageBox.Show(mes + " ");
        }
        //вывод возникающих ошибок
        private void CheckResult(int code, string n, bool ViewMessage)
        {
            if(ViewMessage)
                if (code != 0 )
                    MessageBox.Show($"Метод: {n} Ошибка: {Driver.ResultCodeDescription} Код: {code} ");
                else
                    Console.Write($"Метод {n}: Успешно ");
        }

        private delegate int Func();
        //проверка результата работы метода драйвера ККТ
        private int executeAndHandleError(Func f, bool ViewMessage = false)
        {
            while (true)
            {
                var ret = f();
                switch (ret)
                {
                    case 0x50:
                        continue;
                    default:
                        CheckResult(ret, f.Method.Name, ViewMessage);
                        return ret;
                }
            }
        }
        //печать чека
        public int PrintCheque(Receipt cheque)
        {
            if (CheckConnect() == 0)
            {
                prepareCheque();
                Driver.GetECRStatus();
                int state = Driver.ECRMode;
                if (state == 2 || state == 4 || state == 7 || state == 9)
                {
                    Driver.CheckType = 0;
                    //Открытие чека
                    executeAndHandleError(Driver.OpenCheck, true);
                    //if (cheque.Phone != null)
                    //    Driver.CustomerEmail = cheque.Phone;
                    //else if (cheque.Email != null)
                    //    Driver.CustomerEmail = cheque.Email;
                    ////Передача данных покупателя
                    //if(cheque.Phone != null || cheque.Email != null)
                    //    executeAndHandleError(Driver.FNSendCustomerEmail);
                    foreach (Product p in cheque.Products)
                    {
                        //add product
                        Driver.CheckType = 0;
                        Driver.StringForPrinting = p.Name;
                        Driver.Price = (decimal)(p.Price - Math.Round(p.Price * (decimal)p.Discount / 100, 2));
                        Driver.Quantity = p.Quantity;
                        //Driver.TaxValueEnabled = false;
                        Driver.Department = p.Department;
                        Driver.PaymentTypeSign = 4;
                        if (p.Type == 1)
                            Driver.PaymentItemSign = 1;
                        else if (p.Type == 2)
                            Driver.PaymentItemSign = 4;
                        Driver.Tax1 = 0;
                        if (p.NDS == 20)
                            Driver.Tax1 = 1;
                        else if (p.NDS == 10)
                            Driver.Tax1 = 2;
                        Driver.Tax2 = 0;
                        Driver.Tax3 = 0;
                        Driver.Tax4 = 0;
                        executeAndHandleError(Driver.FNOperation, true);
                    }
                    if (cheque.Payment == 1)
                    {
                        Driver.Summ1 = (decimal)cheque.Summa;
                        Driver.Summ2 = 0;
                    }
                    else if (cheque.Payment == 2)
                    {
                        Driver.Summ2 = (decimal)cheque.Summa;
                        Driver.Summ1 = 0;
                    }
                    Driver.Summ3 = 0;
                    Driver.Summ4 = 0;
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
                    //Закрытие чека
                    int res = executeAndHandleError(Driver.FNCloseCheckEx, true);
                    if (res == 0)
                    {
                        //Ожидание печати чека
                        executeAndHandleError(Driver.WaitForPrinting);
                        //Отрезка чека
                        executeAndHandleError(Driver.CutCheck, true);
                        return res;
                    }
                }
                else
                    Console.WriteLine($"ККМ в режиме {state}. Печать не доступна");
            }
            else
                AddLog("Нет подключения");
            return 1;
        }

        public void PrintXReport()
        {
            string template = $"ЧЕКОВ ЗА СМЕНУ: {GetOperationRegItem(0).Content}\nФД ЗА СМЕНУ: {GetOperationRegItem(0).Content}\nЧЕКОВ ПРИХОДА: {GetOperationRegItem(0).Content}\nЧЕКОВ РАСХОДА: {GetOperationRegItem(0).Content}\n" +
                $"ЧЕКОВ ВОЗВРАТА ПРИХОДА: {GetOperationRegItem(0).Content}\nЧЕКОВ ВОЗВРАТА РАСХОДА: {GetOperationRegItem(0).Content}\nВНЕСЕНИЙ: {GetOperationRegItem(0).Content}\nВЫПЛАТ: {GetOperationRegItem(0).Content}\n" +
                $"ЧЕКОВ КОРРЕКЦИИ ПРИХОДА: {GetOperationRegItem(0).Content}\nЧЕКОВ КОРРЕКЦИИ РАСХОДА: {GetOperationRegItem(0).Content}\nАНУЛИРОВАННЫХ ЧЕКОВ: {GetOperationRegItem(0).Content}\nПРИХОДА: {GetCashRegItem(0).Content}\n" +
                $"РАСХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТА ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТА РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"НАЛ. В КАССЕ: {GetCashRegItem(0).Content}\nВЫРУЧКА: {GetCashRegItem(0).Content}\n";
            GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)");
        }
        public void PrintXSectionReport()
        {
            string template = $"СЕКЦИЯ {1}\nПРИХОД: {GetCashRegItem(0).Content}\nРАСХОД: {GetCashRegItem(0).Content}\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТ РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"ИТОГ ПО СЕКЦИИ\nПРИХОД: {GetCashRegItem(0).Content}\nРАСХОД: {GetCashRegItem(0).Content}\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТ РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"СКИДКИ\nПРИХОД: {GetCashRegItem(0).Content}\nРАСХОД: {GetCashRegItem(0).Content}\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТ РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"НАДБАВКИ\nПРИХОД: {GetCashRegItem(0).Content}\nРАСХОД: {GetCashRegItem(0).Content}\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТ РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"ИТОГО\nПРИХОД: {GetCashRegItem(0).Content}\nРАСХОД: {GetCashRegItem(0).Content}\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(0).Content}\nВОЗВРАТ РАСХОДА: {GetCashRegItem(0).Content}\n" +
                $"ВЫРУЧКА: {0}";
            GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям", template);
        }
        public void PrintXTaxReport()
        {
            //string title = $"ЗН ККТ: {}\nИНН: {Driver.INN}\nДАТА: {DateTime.Now}\nКассир: {}\nОТЧЁТ ПО НАЛОГАМ\nРН ККТ: {Driver.KKTRegistrationNumber}\ФН: {Driver.FN}\n";
            string template = $"Группа А: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n" +
                $"Группа Б: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n" +
                $"Группа В: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n" +
                $"Группа Г: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n" +
                $"Группа Д: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n" +
                $"Группа Е: {GetCashRegItem(0).Content}\n   Оборот по налогу: {GetCashRegItem(0).Content}\n   Налог: {GetCashRegItem(0).Content}\n";
            GetReport(Driver.PrintTaxReport, "X-отчёт по налогам", template);
        }
        public void PrintZReport()
        {
            GetReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }
        public void PrintOperationReg()
        {
            string template = $"НОМЕР ПРИХОДА: {GetOperationRegItem(0).Content}\nНОМЕР РАСХОДА: {GetOperationRegItem(0).Content}\nНОМЕР ВОЗВРАТА ПРИХОДА: {GetOperationRegItem(0).Content}\nНОМЕР ВОЗВРАТА РАСХОДА: {GetOperationRegItem(0).Content}\n" +
                $"НОМЕР ВНЕСЕНИЯ: {GetOperationRegItem(0).Content}\nНОМЕР ВЫПЛАТЫ: {GetOperationRegItem(0).Content}\nНОМЕР СУТ. ОТЧ. БЕЗ ГАШ.: {GetOperationRegItem(0).Content}\nНОМЕР ТЕХНОЛОГ. ТЕСТА: {GetOperationRegItem(0).Content}\n" +
                $"НОМЕР ОТМЕН. ДОКУМЕНТОВ: {GetOperationRegItem(0).Content}\nНОМЕР ОБЩЕГО ГАШЕНИЯ: {GetOperationRegItem(0).Content}\nНОМЕР ОТЧЁТА ПО СЕКЦИЯМ: {GetOperationRegItem(0).Content}\n" +
                $"НОМЕР ОТЧЁТА ПО НАЛОГАМ: {GetOperationRegItem(0).Content}\nНОМЕР ОТЧЁТА ПО КАССИРАМ: {GetOperationRegItem(0).Content}\n";
            GetReport(Driver.PrintOperationReg, "Операционные регистры");
        }

        public void CashIncome(decimal summ)
        {
            string template = $"ВНЕСЕНИЕ: {GetCashRegItem(242).Content}";
            Driver.Summ1 = summ;
            GetReport(Driver.CashIncome, "Внесение наличных", template);
        }

        public void CashOutcome(decimal summ)
        {
            string template = $"ВЫПЛАТА: {GetCashRegItem(243).Content}";
            Driver.Summ1 = summ;
            GetReport(Driver.CashOutcome, "Выдача наличных");
        }

        private void GetReport(Func m, string name, string template = null)
        {
            executeAndHandleError(Driver.GetECRStatus);
            int state = Driver.ECRMode;
            if(state == 2 || state == 3 || state == 4 || state == 8)
                prepareCheque();
            if (m == null || executeAndHandleError(m, true) == 0)
            {
                executeAndHandleError(Driver.CutCheck);
                GetStringReport(name, template);
            }
        }

        public void OpenProperties()
        {
            executeAndHandleError(Driver.ShowProperties, true);
        }

        private void GetStringReport(string name, string template = null)
        {
            executeAndHandleError(Driver.FNGetStatus);
            if (executeAndHandleError(Driver.FNGetDocumentAsString, true) == 0)
            {
                try
                {
                    var db = new KassaDBContext();
                    string d = null;
                    if (Driver.StringForPrinting != null)
                        d = Driver.StringForPrinting;
                    else if (template != null)
                        d = template;
                    if (d != null)
                    {
                        byte[] data = Encoding.Default.GetBytes(d);
                        Report report = new Report()
                        {
                            Name = name,
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
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }

        public RegistrerItem GetOperationRegItem(int num)
        {
            Driver.RegisterNumber = num;
            if (executeAndHandleError(Driver.GetOperationReg, true) == 0)
                return new RegistrerItem()
                {
                    Number = num,
                    Name = Driver.NameOperationReg,
                    Content = Driver.ContentsOfOperationRegister
                };
            return null;
        }
        public RegistrerItem GetCashRegItem(int num)
        {
            Driver.RegisterNumber = num;
            if (executeAndHandleError(Driver.GetCashReg, true) == 0)
                return new RegistrerItem()
                {
                    Number = num,
                    Name = Driver.NameCashReg,
                    Content = Driver.ContentsOfCashRegister
                };
            return null;
        }
    }
}
