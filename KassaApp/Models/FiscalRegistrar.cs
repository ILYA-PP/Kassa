﻿using DrvFRLib;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
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
                    executeAndHandleError(Driver.PrintReportWithCleaning);
                    executeAndHandleError(Driver.WaitForPrinting);
                    executeAndHandleError(Driver.PrintReportWithCleaning);
                    GetReport(null, "Z-отчёт (c гашением)");
                    //Открытие смены
                    executeAndHandleError(Driver.OpenSession);
                    GetReport(null, "Отчёт об открытии смены"); break;
                case 4:
                    //Открытие смены
                    executeAndHandleError(Driver.OpenSession);
                    GetReport(null, "Отчёт об открытии смены"); break;
                case 8:
                    //Отмена чека
                    executeAndHandleError(Driver.SysAdminCancelCheck);
                    break;
            }
            executeAndHandleError(Driver.WaitForPrinting);
        }
        public void Disconnect()
        {
            //Отключение от ККТ
            executeAndHandleError(Driver.Disconnect);
        }
        public int Print(string s)
        {
            prepareCheque();
            Driver.StringForPrinting = s;
            return executeAndHandleError(Driver.PrintString);
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
        private void CheckResult(int code, string n)
        {
            if (code != 0)
                MessageBox.Show($"Метод: {n} Ошибка: {Driver.ResultCodeDescription} Код: {code} ");
            else
                Console.Write($"Метод {n}: Успешно ");
            Console.WriteLine($"Статус: {Driver.ECRModeDescription}");
        }

        private delegate int Func();
        //проверка результата работы метода драйвера ККТ
        private int executeAndHandleError(Func f)
        {
            while (true)
            {
                var ret = f();
                switch (ret)
                {
                    case 0x50:
                        continue;
                    default:
                        CheckResult(ret, f.Method.Name);
                        return ret;
                }
            }
        }
        //печать чека
        public void PrintCheque(Receipt cheque)
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
                    executeAndHandleError(Driver.OpenCheck);
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
                        executeAndHandleError(Driver.FNOperation);
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
                    if (executeAndHandleError(Driver.FNCloseCheckEx) == 0)
                    {
                        //Ожидание печати чека
                        executeAndHandleError(Driver.WaitForPrinting);
                        //Отрезка чека
                        executeAndHandleError(Driver.CutCheck);
                    }
                }
                else
                    Console.WriteLine($"ККМ в режиме {state}. Печать не доступна");
            }
            else
                AddLog("Нет подключения");
        }

        public void PrintXReport()
        {
            GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)");
        }
        public void PrintXSectionReport()
        {
            GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям");
        }
        public void PrintXTaxReport()
        {
            GetReport(Driver.PrintTaxReport, "X-отчёт по налогам");
        }
        public void PrintZReport()
        {
            GetReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }

        private void GetReport(Func m, string name)
        {
            executeAndHandleError(Driver.GetECRStatus);
            int state = Driver.ECRMode;
            if(state == 2 || state == 3 || state == 4 || state == 8)
                prepareCheque();
            if (m == null || executeAndHandleError(m) == 0)
            {
                executeAndHandleError(Driver.CutCheck);
                GetStringReport(name);
            }
        }

        public void OpenProperties()
        {
            executeAndHandleError(Driver.ShowProperties);
        }

        public void GetStringReport(string name)
        {
            executeAndHandleError(Driver.FNGetStatus);
            if (executeAndHandleError(Driver.FNGetDocumentAsString) == 0)
            {
                try
                {
                    var db = new KassaDBContext();
                    if (Driver.StringForPrinting != null)
                    {
                        byte[] data = Encoding.Default.GetBytes(Driver.StringForPrinting);
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

        public void CashIncome(decimal summ)
        {
            Driver.Summ1 = summ;
            GetReport(Driver.CashIncome, "Внесение наличных");
        }

        public void CashOutcome(decimal summ)
        {
            Driver.Summ1 = summ;
            GetReport(Driver.CashOutcome, "Выдача наличных");
        }
    }
}
