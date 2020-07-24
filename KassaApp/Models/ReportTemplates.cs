using System;

namespace KassaApp.Models
{
    //класс содержит шаблоны отчётов для сохранения
    class ReportTemplates:FiscalRegistrar
    {
        public ReportTemplates()
        {
            //Подключение к ККТ
            Connect();
        }
        ~ReportTemplates()
        {
            //отключение от ККТ
            Disconnect();
        }
        //метод формирует заголовок отчёта
        //с указанием названия отчёта (name)
        private string GetTitle(string name)
        {
            if (CheckConnect() == 0)
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
        //метод формирует и возвращает х отчёт без гашения
        public string GetXReport()
        {
            string title = GetTitle("СУТОЧНЫЙ ОТЧ. БЕЗ ГАШ.");
            if(title != null)
                return $"{title}\r\n" +
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
            return null;
        }
        //метод формирует и возвращает х отчёт по секциям
        public string GetXSectionReport()
        {
            int sectionNum = 1;
            decimal resP = 0, resR = 0, resVP = 0, resVR = 0;
            string title = GetTitle("ОТЧЁТ ПО СЕКЦИЯМ");
            if (title != null)
            {
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
                return template;
            }
            return null;
        }
        //метод формирует и возвращает х отчётпо налогам
        public string GetXTaxReport()
        {
            string title = GetTitle("ОТЧЁТ ПО НАЛОГАМ");
            if (title != null)
            {
                return $"{title}\r\n" +
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
            return null;
        }
        //метод формирует и возвращает операционные регистры
        public string GetOperationReg()
        {
            string title = GetTitle("ОПЕРАЦИОННЫЕ РЕГИСТРЫ");
            if (title != null)
            {
                return $"{title}\r\n" +
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
            return null;
        }
        //метод формирует и возвращает отчёт о внесении наличных
        public string GetCashIncomeReport(decimal summ)
        {
            string title = GetTitle("");
            if (title != null)
                return $"{title}\r\nВНЕСЕНИЕ: {summ}";

            return null;
        }
        //метод формирует и возвращает отчёт о выдачи наличных
        public string GetCashOutcomeReport(decimal summ)
        {
            string title = GetTitle("");
            if (title != null)
                return $"{title}\r\nВЫПЛАТА: {summ}";

            return null;
        }
    }
}
