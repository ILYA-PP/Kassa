﻿using DrvFRLib;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    //класс для работы с драйвером ККТ ШТРИХ-М
    class DriverSHTRIH: IFiscalRegistrar
    {
        private int SysAdminPassword = 0; //пароль сис. админа
        private int OperatorPassword = 0; // пароль текущего пользователя
        protected DrvFR Driver { get; set; }
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
        public void Dispose()
        {
            //отключение от ККТ при удалении объекта класса
            Disconnect();
        }
        protected void Disconnect()
        {
            //Отключение от ККТ
            ExecuteAndHandleError(Driver.Disconnect, true);
        }
        //проверка связи с ККТ
        public int CheckConnect()
        {
            return ExecuteAndHandleError(Driver.Connect);
        }
        //подключение к фискальному регистратору
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
                ExecuteAndHandleError(Driver.Connect);
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
            if (ViewMessage)
                if (code != 0)
                    MessageBox.Show($"Ошибка: {Driver.ResultCodeDescription} Код: {code} ");
                else
                    Console.Write($"Метод {n}: Успешно ");
        }

        protected delegate int Func();
        //проверка результата работы метода драйвера ККТ
        protected int ExecuteAndHandleError(Func f, bool ViewMessage = false)
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
        //проверка состояния ККТ перед печатью
        private void PrepareCheque()
        {
            ExecuteAndHandleError(Driver.WaitForPrinting);
            ExecuteAndHandleError(Driver.GetECRStatus);
            switch (Driver.ECRMode)
            {
                case 3:
                    //Снятие Z-отчёта
                    ExecuteAndHandleError(Driver.WaitForPrinting);
                    if(MessageBox.Show("24 часа истеки! Зактыть смену и открыть новую смену?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        GetFiscReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
                        //Открытие смены
                        GetFiscReport(Driver.OpenSession, "Отчёт об открытии смены");
                    } 
                    break;
                case 4:
                    //Открытие смены
                    MessageBox.Show("Смена закрыта! Открытие новой смены");
                    GetFiscReport(Driver.OpenSession, "Отчёт об открытии смены"); 
                    break;
                case 8:
                    //Отмена чека
                    OperatorPassword = Driver.Password;
                    Driver.Password = SysAdminPassword;
                    if (MessageBox.Show("Открыт другой чек! Отменить чек?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ExecuteAndHandleError(Driver.SysAdminCancelCheck, true);
                    Driver.Password = OperatorPassword;
                    break;
            }
            ExecuteAndHandleError(Driver.WaitForPrinting);
        }
        //метод печати нефискальных документов
        //s - строка для печати
        public int Print(string s)
        {
            PrepareCheque();
            Driver.StringForPrinting = s;
            //печать документа
            int res = ExecuteAndHandleError(Driver.PrintString, true);
            //Ожидание печати чека
            res = ExecuteAndHandleError(Driver.WaitForPrinting); 
            while (res != 0)
            {
                if (MessageBox.Show("Продолжить печать?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    ExecuteAndHandleError(Driver.PrintString, true);

                res = ExecuteAndHandleError(Driver.WaitForPrinting);
            }
            //отступ после документа
            Driver.StringQuantity = 5;
            Driver.UseReceiptRibbon = true;
            ExecuteAndHandleError(Driver.FeedDocument, true);
            //Отрезка чека
            if (res == 0)
            {
                res = ExecuteAndHandleError(Driver.CutCheck, true);
                return res;
            }
            return res;
        }
        //печать фискального чека
        public int PrintCheque(Receipt cheque, string cardName = null)
        {
            if (CheckConnect() == 0)
            {
                PrepareCheque();
                Driver.GetECRStatus();
                int state = Driver.ECRMode;
                if (state == 2 || state == 4 || state == 7 || state == 9)
                {
                    Driver.CheckType = 0;
                    //Открытие чека
                    if (ExecuteAndHandleError(Driver.OpenCheck, true) != 0)
                        return -1;
                    //if (cheque.Phone != null)
                    //    Driver.CustomerEmail = cheque.Phone;
                    //else if (cheque.Email != null)
                    //    Driver.CustomerEmail = cheque.Email;
                    ////Передача данных покупателя
                    //if(cheque.Phone != null || cheque.Email != null)
                    //    ExecuteAndHandleError(Driver.FNSendCustomerEmail);
                    foreach (Product p in cheque.Products)
                    {
                        //пробитие позиций
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
                        if (ExecuteAndHandleError(Driver.FNOperation, true) != 0)
                            return -1;
                    }
                    Driver.StringForPrinting = "";
                    //указание способа оплаты
                    if (cheque.Payment == 1)
                    {
                        Driver.Summ1 = cheque.Summa;
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
                    Driver.DiscountOnCheck = cheque.Discount/100;
                    //Закрытие чека
                    int res = ExecuteAndHandleError(Driver.FNCloseCheckEx, true);
                    if (res == 0)
                    {
                        res = ExecuteAndHandleError(Driver.WaitForPrinting);
                        //Ожидание печати чека
                        while (res != 0)
                        {
                            if (MessageBox.Show("Продолжить печать?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                ExecuteAndHandleError(Driver.ContinuePrint, true);

                            res = ExecuteAndHandleError(Driver.WaitForPrinting);
                        }
                        //Отрезка чека
                        res = ExecuteAndHandleError(Driver.CutCheck, true);
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
        //печать х отчёта без гашения
        public int PrintXReport()
        {
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
                    $"ВЫРУЧКА: {GetCashRegItem(121).Content - GetCashRegItem(122).Content - GetCashRegItem(123).Content + GetCashRegItem(124).Content}\r\n";
            //печать и сохранение отчёта
            return GetReport(Driver.PrintReportWithoutCleaning, "X-отчёт (без гашения)", template);
        }
        //печать х отчёта по секциям
        public int PrintXSectionReport()
        {
            //получение шаблона отчёта
            int sectionNum = 1;
            decimal resP = 0, resR = 0, resVP = 0, resVR = 0;
            string title = GetTitle("ОТЧЁТ ПО СЕКЦИЯМ");
                string template = $"{title}\r\n";
                for (int i = 72; i <= 136; i += 4)
                {
                    if (GetOperRegItem(i).Content > 0 || GetOperRegItem(i + 1).Content > 0 ||
                        GetOperRegItem(i + 2).Content > 0 || GetOperRegItem(i + 3).Content > 0)
                        template += $"  СЕКЦИЯ {sectionNum}\r\n{GetOperRegItem(i).Content} " +
                            $"ПРИХОД: { GetCashRegItem(121 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 1).Content} " +
                            $"РАСХОД: { GetCashRegItem(122 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 2).Content} " +
                            $"ВОЗВРАТ ПРИХОДА: { GetCashRegItem(123 + 4 * (sectionNum - 1)).Content}\r\n{GetOperRegItem(i + 3).Content} " +
                            $"ВОЗВРАТ РАСХОДА: { GetCashRegItem(124 + 4 * (sectionNum - 1)).Content}\r\n";
                    sectionNum++;
                }
                resP = GetCashRegItem(193).Content - GetCashRegItem(185).Content + GetCashRegItem(189).Content;
                resR = GetCashRegItem(194).Content - GetCashRegItem(186).Content + GetCashRegItem(190).Content;
                resVP = GetCashRegItem(195).Content - GetCashRegItem(187).Content + GetCashRegItem(191).Content;
                resVR = GetCashRegItem(196).Content - GetCashRegItem(188).Content + GetCashRegItem(192).Content;
                template += $"  ИТОГ ПО СЕКЦИЯМ\r\n" +
                        $"ПРИХОД: {GetCashRegItem(193).Content}\r\n" +
                        $"РАСХОД: {GetCashRegItem(194).Content}\r\n" +
                        $"ВОЗВРАТ ПРИХОДА: {GetCashRegItem(195).Content}\r\n" +
                        $"ВОЗВРАТ РАСХОДА: {GetCashRegItem(196).Content}\r\n" +
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
                return GetReport(Driver.PrintDepartmentReport, "X-отчёт по секциям", template);
        }
        //печать х отчёта по налогам
        public int PrintXTaxReport()
        {
            string template = null;
            //получение шаблона отчёта
            string title = GetTitle("ОТЧЁТ ПО НАЛОГАМ");
            if (title != null)
            {
                template = $"{title}\r\n" +
                $"Группа А:\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(209).Content}\r\n" +
                    $"Налог: {GetCashRegItem(225).Content}\r\n" +
                $"Группа Б\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(213).Content}\r\n" +
                    $"Налог: {GetCashRegItem(229).Content}\r\n" +
                $"Группа В\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(217).Content}\r\n" +
                    $"Налог: {GetCashRegItem(233).Content}\r\n" +
                $"Группа Г\r\n" +
                    $"Оборот по налогу: {GetCashRegItem(221).Content}\r\n" +
                    $"Налог: {GetCashRegItem(237).Content}\r\n" +
                $"Группа Д\r\n" +
                    $"Оборот по налогу: {0}\r\n" +
                    $"Налог: {0}\r\n" +
                $"Группа Е\r\n" +
                    $"Оборот по налогу: {0}\r\n" +
                    $"Налог: {0}\r\n";
            }
            //печать и сохранение отчёта
            return GetReport(Driver.PrintTaxReport, "X-отчёт по налогам", template);
        }
        //печать z отчёта с гашением
        public int PrintZReport()
        {
            return GetFiscReport(Driver.PrintReportWithCleaning, "Z-отчёт (c гашением)");
        }
        //печать операционных регистров
        public int PrintOperationReg()
        {
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
                $"НОМЕР ОТЧЁТА ПО КАССИРАМ: {0}\r\n";
            }
            //печать и сохранение отчёта
            return GetReport(Driver.PrintOperationReg, "Операционные регистры", template);
        }
        //внесение наличных
        public int CashIncome(decimal summ)
        {
            //получение шаблона отчёта
            string template = null;
            string title = GetTitle("");
            if (title != null)
                template = $"{title}\r\nВНЕСЕНИЕ: {summ}";
            Driver.Summ1 = summ;
            //печать и сохранение отчёта
            return GetReport(Driver.CashIncome, "Внесение наличных", template);
        }
        //выдача ниличных
        public int CashOutcome(decimal summ)
        {
            //получение шаблона отчёта
            string template = null;
            string title = GetTitle("");
            if (title != null)
                template = $"{title}\r\nВЫПЛАТА: {summ}";
            Driver.Summ1 = summ;
            //печать и сохранение отчёта
            return GetReport(Driver.CashOutcome, "Выдача наличных", template);
        }
        //проверка состояния ккт и выполнение печати нефискального отчёта
        private int GetReport(Func m, string name, string template = null)
        {
            ExecuteAndHandleError(Driver.GetECRStatus);
            int state = Driver.ECRMode, res = 0;
            if (state == 3 || state == 4 || state == 8)
                PrepareCheque();
            res = ExecuteAndHandleError(m, true);
            if (m != null && res == 0)
            {
                ExecuteAndHandleError(Driver.CutCheck);//отрезка отчёта
                SaveReport(name, template);//сохранение отчёта
            }
            return res;
        }
        //выполнение печати фискального отчёта
        private int GetFiscReport(Func m, string name, string template = null)
        {
            var res = ExecuteAndHandleError(m, true);
            if (m != null && res == 0)
            {
                res = ExecuteAndHandleError(Driver.CutCheck);//отрезка отчёта
                SaveReport(name, template);//сохранение отчёта
            }
            return res;
        }
        //сохранение отчётов в бд
        private void SaveReport(string name, string template = null)
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
                                Name = name,
                                ReportData = data,
                                Date = DateTime.Now
                            };
                            db.Report.Add(report);//добавление отчёта
                            db.SaveChanges();//сохранение отчёта
                            MessageBox.Show("Отчёт сохранён!");
                        }
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
        //получить строку операционного регистра
        public RegistrerItem GetOperRegItem(int num)
        {
            Driver.RegisterNumber = num;
            if (ExecuteAndHandleError(Driver.GetOperationReg) == 0)
                return new RegistrerItem()
                {
                    Number = num,
                    Name = Driver.NameOperationReg,
                    Content = Driver.ContentsOfOperationRegister
                };
            return null;
        }
        //получить строку денежного регистра
        public RegistrerItem GetCashRegItem(int num)
        {
            Driver.RegisterNumber = num;
            if (ExecuteAndHandleError(Driver.GetCashReg) == 0)
                return new RegistrerItem()
                {
                    Number = num,
                    Name = Driver.NameCashReg,
                    Content = Driver.ContentsOfCashRegister
                };
            return null;
        }
        //метод формирует заголовок отчёта
        //с указанием названия отчёта (name)
        public string GetTitle(string name)
        {
            if (CheckConnect() == 0)
            {
                if (name != "")
                    name += "\r\n";
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
                    $"{name}" +
                    $"РН ККТ: {Driver.KKTRegistrationNumber}\r\n" +
                    $"ФН: {Driver.SerialNumber}\r\n" +
                    $"СМЕНА: {Driver.SessionNumber + 1}\r\n";
            }
            return null;
        }
    }
}