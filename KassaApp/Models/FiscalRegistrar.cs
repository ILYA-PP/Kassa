using DrvFRLib;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    class FiscalRegistrar: IDisposable
    {
        private int SysAdminPassword = 0;
        private int OperatorPassword = 0;
        protected DrvFR Driver { get; set; }
        public FiscalRegistrar()
        {
            Connect();
            if(CheckConnect() == 0)
            {
                Driver.TableNumber = 2;
                Driver.RowNumber = 30;
                Driver.FieldNumber = 1;
                executeAndHandleError(Driver.ReadTable);
                SysAdminPassword = Driver.ValueOfFieldInteger;
            }
        }
        public void Dispose()
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
                        GetFiscReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
                        //Открытие смены
                        GetFiscReport(Driver.OpenSession, "Отчёт об открытии смены");
                    } 
                    break;
                case 4:
                    //Открытие смены
                    if (MessageBox.Show("Смена закрыта! Открыть новую смену?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        GetFiscReport(Driver.OpenSession, "Отчёт об открытии смены"); 
                    break;
                case 8:
                    //Отмена чека
                    OperatorPassword = Driver.Password;
                    Driver.Password = SysAdminPassword;
                    if (MessageBox.Show("Открыт другой чек! Отменить чек?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        executeAndHandleError(Driver.SysAdminCancelCheck, true);
                    Driver.Password = OperatorPassword;
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
            int res = executeAndHandleError(Driver.PrintString, true);
            res = executeAndHandleError(Driver.WaitForPrinting);
            //Ожидание печати чека
            while (res != 0)
            {
                if (MessageBox.Show("Продолжить печать?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    executeAndHandleError(Driver.PrintString, true);
                }
                res = executeAndHandleError(Driver.WaitForPrinting);
            }
            //Отрезка чека
            if (res == 0)
            {
                res = executeAndHandleError(Driver.CutCheck, true);
                return res;
            }
            return res;
        }

        public int CheckConnect()
        {
            return executeAndHandleError(Driver.Connect);
        }
        //подключение к фискальному регистратору
        protected void Connect()
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
        protected void CheckResult(int code, string n, bool ViewMessage)
        {
            if(ViewMessage)
                if (code != 0 )
                    MessageBox.Show($"Ошибка: {Driver.ResultCodeDescription} Код: {code} ");
                else
                    Console.Write($"Метод {n}: Успешно ");
        }

        protected delegate int Func();
        //проверка результата работы метода драйвера ККТ
        protected int executeAndHandleError(Func f, bool ViewMessage = false)
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
        public int PrintCheque(Receipt cheque, string cardName = null)
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
                        Driver.Summ3 = 0;
                        Driver.Summ4 = 0;
                    }
                    else if (cheque.Payment == 2)
                    {
                        switch (cardName)
                        {
                            case "МИР": 
                                Driver.Summ2 = cheque.Summa; 
                                Driver.Summ3 = 0;
                                Driver.Summ4 = 0; break;
                            case "Visa": 
                                Driver.Summ3 = cheque.Summa; 
                                Driver.Summ2 = 0;
                                Driver.Summ4 = 0; break;
                            case "Mastercard": 
                                Driver.Summ4 = cheque.Summa; 
                                Driver.Summ3 = 0;
                                Driver.Summ2 = 0; break;
                            default:
                                Driver.Summ2 = cheque.Summa;
                                Driver.Summ3 = 0;
                                Driver.Summ4 = 0; break;
                        }
                        Driver.Summ1 = 0;
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
                    Driver.DiscountOnCheck = cheque.Discount;
                    //Закрытие чека
                    int res = executeAndHandleError(Driver.FNCloseCheckEx, true);
                    if (res == 0)
                    {
                        res = executeAndHandleError(Driver.WaitForPrinting);
                        //Ожидание печати чека
                        while (res != 0)
                        {
                            if (MessageBox.Show("Продолжить печать?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                executeAndHandleError(Driver.ContinuePrint, true);
                            res = executeAndHandleError(Driver.WaitForPrinting);
                        }
                        //Отрезка чека
                        res = executeAndHandleError(Driver.CutCheck, true);
                        return res;
                    }
                }
                else
                    MessageBox.Show("Закройте текущую смену и откройте новую!");
            }
            else
                AddLog("Нет подключения");
            return -1;
        }

        public void PrintXReport()
        {
            string template = new ReportTemplates().GetXReport();
            GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)", template);
        }
        public void PrintXSectionReport()
        {
            string template = new ReportTemplates().GetXSectionReport();
            GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям", template);
        }
        public void PrintXTaxReport()
        {
            string template = new ReportTemplates().GetXTaxReport();
            GetReport(Driver.PrintTaxReport, "X-отчёт по налогам", template);
        }
        public void PrintZReport()
        {
            GetFiscReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }
        public void PrintOperationReg()
        {
            string template = new ReportTemplates().GetOperationReg();
            GetReport(Driver.PrintOperationReg, "Операционные регистры", template);
        }

        public int CashIncome(decimal summ)
        {
            string template = new ReportTemplates().GetCashIncomeReport(summ);
            Driver.Summ1 = summ;
            return GetReport(Driver.CashIncome, "Внесение наличных", template);
        }

        public int CashOutcome(decimal summ)
        {
            string template = new ReportTemplates().GetCashOutcomeReport(summ);
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
            if (m != null && executeAndHandleError(m, true) == 0)
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
                    using (var db = new KassaDBContext())
                    {
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

        public RegistrerItem GetOperRegItem(int num)
        {
            Driver.RegisterNumber = num;
            if (executeAndHandleError(Driver.GetOperationReg) == 0)
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
            if (executeAndHandleError(Driver.GetCashReg) == 0)
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
