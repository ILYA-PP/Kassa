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
        public FiscalRegistrar()
        {
            Connect();
        }
        ~FiscalRegistrar()
        {
            Disconnect();
        }
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
                    if(MessageBox.Show("24 часа истеки! Зактыть смену и открыть новую смену?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        GetFiscReport(null, "Z-отчёт (c гашением)");
                        //Открытие смены
                        GetFiscReport(null, "Отчёт об открытии смены");
                    } 
                    break;
                case 4:
                    //Открытие смены
                    if (MessageBox.Show("Смена закрыта! Открыть новую смену?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        GetReport(null, "Отчёт об открытии смены"); 
                    break;
                case 8:
                    //Отмена чека
                    if (MessageBox.Show("Открыт другой чек! Отменить чек?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        executeAndHandleError(Driver.SysAdminCancelCheck, true);
                    break;
            }
            executeAndHandleError(Driver.WaitForPrinting);
        }
        private void Disconnect()
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
        private void Connect()
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
                    if (executeAndHandleError(Driver.OpenCheck, true) != 0)
                        return -1;
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
                        Driver.Department = p.Department;
                        Driver.PaymentTypeSign = 4;
                        if (p.Type == 1)
                            Driver.PaymentItemSign = 1;
                        else if (p.Type == 2)
                            Driver.PaymentItemSign = 4;
                        Driver.Tax1 = 0;
                        if (p.NDS == 20)
                            Driver.Tax1 = 1;
                        else if (p.NDS == 18)
                            Driver.Tax1 = 2;
                        if (executeAndHandleError(Driver.FNOperation, true) != 0)
                            return -1;
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
                    Driver.DiscountOnCheck = cheque.Discount;
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
                    MessageBox.Show("Закройте текущую смену и откройте новую!");
            }
            else
                AddLog("Нет подключения");
            return 1;
        }

        private string GetTitle(string name)
        {
            if (name != "")
                name += "\r\n";
            executeAndHandleError(Driver.GetECRStatus);
            var znkkt = Driver.SerialNumber;
            Driver.TableNumber = 2;
            Driver.RowNumber = Driver.OperatorNumber;
            Driver.FieldNumber = 2;
            executeAndHandleError(Driver.ReadTable);
            executeAndHandleError(Driver.FNGetSerial);
            executeAndHandleError(Driver.FNGetFiscalizationResult);
            return $"ЗН ККТ: {znkkt}\r\nИНН: {Driver.INN}\r\nДАТА: {DateTime.Now}\r\nКассир: {Driver.ValueOfFieldString}\r\n{name}РН ККТ: {Driver.KKTRegistrationNumber}\r\nФН: {Driver.SerialNumber}\r\nСМЕНА: {Driver.SessionNumber}\r\n";
        }

        public void PrintXReport()
        {
            string template = $"{GetTitle("СУТОЧНЫЙ ОТЧ. БЕЗ ГАШ.")}\r\nЧЕКОВ ЗА СМЕНУ: {GetOperationRegItem(144).Content}\r\nФД ЗА СМЕНУ: {0}\r\nЧЕКОВ ПРИХОДА: {GetOperationRegItem(0).Content}\r\nЧЕКОВ РАСХОДА: {GetOperationRegItem(0).Content}\r\n" +
                $"ЧЕКОВ ВОЗВРАТА ПРИХОДА: {GetOperationRegItem(0).Content}\r\nЧЕКОВ ВОЗВРАТА РАСХОДА: {GetOperationRegItem(0).Content}\r\nВНЕСЕНИЙ: {GetOperationRegItem(0).Content}\r\nВЫПЛАТ: {GetOperationRegItem(0).Content}\r\n" +
                $"ЧЕКОВ КОРРЕКЦИИ ПРИХОДА: {GetOperationRegItem(0).Content}\r\nЧЕКОВ КОРРЕКЦИИ РАСХОДА: {GetOperationRegItem(0).Content}\r\nАНУЛИРОВАННЫХ ЧЕКОВ: {GetOperationRegItem(0).Content}\r\nПРИХОДА: {GetCashRegItem(0).Content}\r\n" +
                $"РАСХОДА: {GetCashRegItem(0).Content}\r\nВОЗВРАТА ПРИХОДА: {GetCashRegItem(0).Content}\r\nВОЗВРАТА РАСХОДА: {GetCashRegItem(0).Content}\r\n" +
                $"НАЛ. В КАССЕ: {GetCashRegItem(0).Content}\r\nВЫРУЧКА: {GetCashRegItem(0).Content}\r\n";
            GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)", template);
        }
        public void PrintXSectionReport()
        {
            string template = $"{GetTitle("ОТЧЁТ ПО СЕКЦИЯМ")}\r\nСЕКЦИЯ {1}\r\nПРИХОД: {GetCashRegItem(209).Content}\r\nРАСХОД: {GetCashRegItem(210).Content}\r\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(211).Content}\r\nВОЗВРАТ РАСХОДА: {GetCashRegItem(212).Content}\r\n" +
                $"ИТОГ ПО СЕКЦИИ\r\nПРИХОД: {0}\r\nРАСХОД: {GetCashRegItem(0).Content}\r\nВОЗВРАТ ПРИХОДА: {0}\r\nВОЗВРАТ РАСХОДА: {0}\r\n" +
                $"СКИДКИ\r\nПРИХОД: {GetCashRegItem(185).Content}\r\nРАСХОД: {GetCashRegItem(186).Content}\r\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(187).Content}\r\nВОЗВРАТ РАСХОДА: {GetCashRegItem(188).Content}\r\n" +
                $"НАДБАВКИ\r\nПРИХОД: {GetCashRegItem(189).Content}\r\nРАСХОД: {GetCashRegItem(190).Content}\r\nВОЗВРАТ ПРИХОДА: {GetCashRegItem(191).Content}\r\nВОЗВРАТ РАСХОДА: {GetCashRegItem(192).Content}\r\n" +
                $"ИТОГО\r\nПРИХОД: {0}\r\nРАСХОД: {0}\r\nВОЗВРАТ ПРИХОДА: {0}\r\nВОЗВРАТ РАСХОДА: {0}\r\n" +
                $"ВЫРУЧКА: {0}";
            GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям", template);
        }
        public void PrintXTaxReport()
        {
            string template = $"{GetTitle("ОТЧЁТ ПО НАЛОГАМ")}\r\nГруппа А:\r\nОборот по налогу: {GetCashRegItem(209).Content}\r\nНалог: {GetCashRegItem(225).Content}\r\n" +
                $"Группа Б\r\nОборот по налогу: {GetCashRegItem(213).Content}\r\nНалог: {GetCashRegItem(229).Content}\r\n" +
                $"Группа В\r\nОборот по налогу: {GetCashRegItem(217).Content}\r\nНалог: {GetCashRegItem(233).Content}\r\n" +
                $"Группа Г\r\nОборот по налогу: {GetCashRegItem(221).Content}\r\nНалог: {GetCashRegItem(237).Content}\r\n" +
                $"Группа Д\r\nОборот по налогу: {0}\r\nНалог: {0}\r\n" +
                $"Группа Е\r\nОборот по налогу: {0}\r\nНалог: {0}\r\n";
            GetReport(Driver.PrintTaxReport, "X-отчёт по налогам", template);
        }
        public void PrintZReport()
        {
            GetFiscReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }
        public void PrintOperationReg()
        {
            string template = $"{GetTitle("ОПЕРАЦИОННЫЕ РЕГИСТРЫ")}\r\nНОМЕР ПРИХОДА: {GetOperationRegItem(148).Content}\r\nНОМЕР РАСХОДА: {GetOperationRegItem(149).Content}\r\nНОМЕР ВОЗВРАТА ПРИХОДА: {GetOperationRegItem(150).Content}\r\nНОМЕР ВОЗВРАТА РАСХОДА: {GetOperationRegItem(151).Content}\r\n" +
                $"НОМЕР ВНЕСЕНИЯ: {GetOperationRegItem(155).Content}\r\nНОМЕР ВЫПЛАТЫ: {GetOperationRegItem(156).Content}\r\nНОМЕР СУТ. ОТЧ. БЕЗ ГАШ.: {GetOperationRegItem(158).Content}\r\nНОМЕР ТЕХНОЛОГ. ТЕСТА: {GetOperationRegItem(163).Content}\r\n" +
                $"НОМЕР ОТМЕН. ДОКУМЕНТОВ: {GetOperationRegItem(166).Content}\r\nНОМЕР ОБЩЕГО ГАШЕНИЯ: {GetOperationRegItem(160).Content}\r\nНОМЕР ОТЧЁТА ПО СЕКЦИЯМ: {GetOperationRegItem(165).Content}\r\n" +
                $"НОМЕР ОТЧЁТА ПО НАЛОГАМ: {GetOperationRegItem(178).Content}\r\nНОМЕР ОТЧЁТА ПО КАССИРАМ: {0}\r\n";
            GetReport(Driver.PrintOperationReg, "Операционные регистры", template);
        }

        public int CashIncome(decimal summ)
        {
            string template = $"{GetTitle("")}\r\nВНЕСЕНИЕ: {summ}";
            Driver.Summ1 = summ;
            return GetReport(Driver.CashIncome, "Внесение наличных", template);
        }

        public int CashOutcome(decimal summ)
        {
            string template = $"{GetTitle("")}\r\nВЫПЛАТА: {summ}";
            Driver.Summ1 = summ;
            return GetReport(Driver.CashOutcome, "Выдача наличных", template);
        }

        private int GetReport(Func m, string name, string template = null)
        {
            executeAndHandleError(Driver.GetECRStatus);
            int state = Driver.ECRMode, res = 0;
            if (state == 3 || state == 4 || state == 8)
            {
                MessageBox.Show("Закройте текущую смену и/или откройте новую!");
                return -1;
            }
            res = executeAndHandleError(m, true);
            if (m == null || res == 0)
            {
                executeAndHandleError(Driver.CutCheck);
                SaveReport(name, template);
            }
            return res;
        }
        private void GetFiscReport(Func m, string name, string template = null)
        {
            if (m == null || executeAndHandleError(m, true) == 0)
            {
                executeAndHandleError(Driver.CutCheck);
                SaveReport(name, template);
            }
        }

        public void OpenProperties()
        {
            executeAndHandleError(Driver.ShowProperties, true);
        }

        private void SaveReport(string name, string template = null)
        {
            executeAndHandleError(Driver.FNGetStatus);
            if (executeAndHandleError(Driver.FNGetDocumentAsString, true) == 0)
            {
                try
                {
                    var db = new KassaDBContext();
                    string d = null;
                    if (template != null)
                        d = template;
                    else if (Driver.StringForPrinting != null)
                        d = Driver.StringForPrinting;
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
