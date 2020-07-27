using System;

namespace KassaApp.Models
{
    //класс содержит шаблоны отчётов для сохранения
    class ReportTemplates
    {
        //метод формирует и возвращает х отчёт без гашения
        public string GetXReport()
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                string title = fr.GetTitle("СУТОЧНЫЙ ОТЧ. БЕЗ ГАШ.");
                if (title != null)
                    return $"{title}\r\n" +
                    $"ЧЕКОВ ЗА СМЕНУ: {fr.GetOperRegItem(144).Content}\r\n" +
                    $"ФД ЗА СМЕНУ: {fr.GetOperRegItem(193).Content}\r\n" +
                    $"ЧЕКОВ ПРИХОДА: {fr.GetOperRegItem(148).Content}\r\n{fr.GetOperRegItem(144).Content}   = {fr.GetCashRegItem(121).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {fr.GetCashRegItem(193).Content}\r\n  " +
                        $"КАРТОЙ: {fr.GetCashRegItem(197).Content}\r\n" +
                    $"ЧЕКОВ РАСХОДА: {fr.GetOperRegItem(149).Content}\r\n{fr.GetOperRegItem(145).Content}   = {fr.GetCashRegItem(122).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {fr.GetCashRegItem(194).Content}\r\n  " +
                        $"КАРТОЙ: {fr.GetCashRegItem(198).Content}\r\n" +
                    $"ЧЕКОВ ВОЗВРАТА ПРИХОДА: {fr.GetOperRegItem(150).Content}\r\n{fr.GetOperRegItem(146).Content}   = {fr.GetCashRegItem(123).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {fr.GetCashRegItem(195).Content}\r\n  " +
                        $"КАРТОЙ: {fr.GetCashRegItem(199).Content}\r\n" +
                    $"ЧЕКОВ ВОЗВРАТА РАСХОДА: {fr.GetOperRegItem(151).Content}\r\n{fr.GetOperRegItem(147).Content}   = {fr.GetCashRegItem(124).Content}\r\n  " +
                        $"НАЛИЧНЫМИ: {fr.GetCashRegItem(196).Content}\r\n  " +
                        $"КАРТОЙ: {fr.GetCashRegItem(200).Content}\r\n" +
                    $"ВНЕСЕНИЙ: {fr.GetOperRegItem(155).Content}\r\n{fr.GetOperRegItem(153).Content}   = {fr.GetCashRegItem(242).Content}\r\n" +
                    $"ВЫПЛАТ: {fr.GetOperRegItem(156).Content}\r\n{fr.GetOperRegItem(154).Content}   = {fr.GetCashRegItem(243).Content}\r\n" +
                    $"ЧЕКОВ КОРРЕКЦИИ ПРИХОДА: {fr.GetOperRegItem(202).Content}\r\n" +
                    $"ЧЕКОВ КОРРЕКЦИИ РАСХОДА: {fr.GetOperRegItem(203).Content}\r\n" +
                    $"АНУЛИРОВАННЫХ ЧЕКОВ: {fr.GetOperRegItem(166).Content}\r\n" +
                        $"ПРИХОДА: {fr.GetCashRegItem(249).Content}\r\n" +
                        $"РАСХОДА: {fr.GetCashRegItem(250).Content}\r\n" +
                        $"ВОЗВРАТА ПРИХОДА: {fr.GetCashRegItem(251).Content}\r\n" +
                        $"ВОЗВРАТА РАСХОДА: {fr.GetCashRegItem(252).Content}\r\n" +
                    $"НАЛ. В КАССЕ: {fr.GetCashRegItem(241).Content}\r\n" +
                    $"ВЫРУЧКА: {fr.GetCashRegItem(121).Content - fr.GetCashRegItem(122).Content - fr.GetCashRegItem(123).Content + fr.GetCashRegItem(124).Content}\r\n";
                return null;
            }
        }
        //метод формирует и возвращает х отчёт по секциям
        public string GetXSectionReport()
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                int sectionNum = 1;
                decimal resP = 0, resR = 0, resVP = 0, resVR = 0;
                string title = fr.GetTitle("ОТЧЁТ ПО СЕКЦИЯМ");
                if (title != null)
                {
                    string template = $"{title}\r\n";
                    for (int i = 72; i <= 136; i += 4)
                    {
                        if (fr.GetOperRegItem(i).Content > 0 || fr.GetOperRegItem(i + 1).Content > 0 ||
                            fr.GetOperRegItem(i + 2).Content > 0 || fr.GetOperRegItem(i + 3).Content > 0)
                            template += $"  СЕКЦИЯ {sectionNum}\r\n{fr.GetOperRegItem(i).Content} " +
                                $"ПРИХОД: { fr.GetCashRegItem(121 + 4 * (sectionNum - 1)).Content}\r\n{fr.GetOperRegItem(i + 1).Content} " +
                                $"РАСХОД: { fr.GetCashRegItem(122 + 4 * (sectionNum - 1)).Content}\r\n{fr.GetOperRegItem(i + 2).Content} " +
                                $"ВОЗВРАТ ПРИХОДА: { fr.GetCashRegItem(123 + 4 * (sectionNum - 1)).Content}\r\n{fr.GetOperRegItem(i + 3).Content} " +
                                $"ВОЗВРАТ РАСХОДА: { fr.GetCashRegItem(124 + 4 * (sectionNum - 1)).Content}\r\n";
                        sectionNum++;
                    }
                    resP = fr.GetCashRegItem(193).Content - fr.GetCashRegItem(185).Content + fr.GetCashRegItem(189).Content;
                    resR = fr.GetCashRegItem(194).Content - fr.GetCashRegItem(186).Content + fr.GetCashRegItem(190).Content;
                    resVP = fr.GetCashRegItem(195).Content - fr.GetCashRegItem(187).Content + fr.GetCashRegItem(191).Content;
                    resVR = fr.GetCashRegItem(196).Content - fr.GetCashRegItem(188).Content + fr.GetCashRegItem(192).Content;
                    template += $"  ИТОГ ПО СЕКЦИЯМ\r\n" +
                            $"ПРИХОД: {fr.GetCashRegItem(193).Content}\r\n" +
                            $"РАСХОД: {fr.GetCashRegItem(194).Content}\r\n" +
                            $"ВОЗВРАТ ПРИХОДА: {fr.GetCashRegItem(195).Content}\r\n" +
                            $"ВОЗВРАТ РАСХОДА: {fr.GetCashRegItem(196).Content}\r\n" +
                        $"  СКИДКИ\r\n{fr.GetOperRegItem(136).Content} " +
                            $"ПРИХОД: {fr.GetCashRegItem(185).Content}\r\n{fr.GetOperRegItem(137).Content} " +
                            $"РАСХОД: {fr.GetCashRegItem(186).Content}\r\n{fr.GetOperRegItem(138).Content} " +
                            $"ВОЗВРАТ ПРИХОДА: {fr.GetCashRegItem(187).Content}\r\n{fr.GetOperRegItem(139).Content} " +
                            $"ВОЗВРАТ РАСХОДА: {fr.GetCashRegItem(188).Content}\r\n" +
                        $"  НАДБАВКИ\r\n{fr.GetOperRegItem(140).Content} " +
                            $"ПРИХОД: {fr.GetCashRegItem(189).Content}\r\n{fr.GetOperRegItem(141).Content} " +
                            $"РАСХОД: {fr.GetCashRegItem(190).Content}\r\n{fr.GetOperRegItem(142).Content} " +
                            $"ВОЗВРАТ ПРИХОДА: {fr.GetCashRegItem(191).Content}\r\n{fr.GetOperRegItem(143).Content} " +
                            $"ВОЗВРАТ РАСХОДА: {fr.GetCashRegItem(192).Content}\r\n" +
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
        }
        //метод формирует и возвращает х отчётпо налогам
        public string GetXTaxReport()
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                {
                    string title = fr.GetTitle("ОТЧЁТ ПО НАЛОГАМ");
                    if (title != null)
                    {
                        return $"{title}\r\n" +
                        $"Группа А:\r\n" +
                            $"Оборот по налогу: {fr.GetCashRegItem(209).Content}\r\n" +
                            $"Налог: {fr.GetCashRegItem(225).Content}\r\n" +
                        $"Группа Б\r\n" +
                            $"Оборот по налогу: {fr.GetCashRegItem(213).Content}\r\n" +
                            $"Налог: {fr.GetCashRegItem(229).Content}\r\n" +
                        $"Группа В\r\n" +
                            $"Оборот по налогу: {fr.GetCashRegItem(217).Content}\r\n" +
                            $"Налог: {fr.GetCashRegItem(233).Content}\r\n" +
                        $"Группа Г\r\n" +
                            $"Оборот по налогу: {fr.GetCashRegItem(221).Content}\r\n" +
                            $"Налог: {fr.GetCashRegItem(237).Content}\r\n" +
                        $"Группа Д\r\n" +
                            $"Оборот по налогу: {0}\r\n" +
                            $"Налог: {0}\r\n" +
                        $"Группа Е\r\n" +
                            $"Оборот по налогу: {0}\r\n" +
                            $"Налог: {0}\r\n";
                    }
                }
                return null;
            }
        }
        //метод формирует и возвращает операционные регистры
        public string GetOperationReg()
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                string title = fr.GetTitle("ОПЕРАЦИОННЫЕ РЕГИСТРЫ");
                if (title != null)
                {
                    return $"{title}\r\n" +
                    $"НОМЕР ПРИХОДА: {fr.GetOperRegItem(148).Content}\r\n" +
                    $"НОМЕР РАСХОДА: {fr.GetOperRegItem(149).Content}\r\n" +
                    $"НОМЕР ВОЗВРАТА ПРИХОДА: {fr.GetOperRegItem(150).Content}\r\n" +
                    $"НОМЕР ВОЗВРАТА РАСХОДА: {fr.GetOperRegItem(151).Content}\r\n" +
                    $"НОМЕР ВНЕСЕНИЯ: {fr.GetOperRegItem(155).Content}\r\n" +
                    $"НОМЕР ВЫПЛАТЫ: {fr.GetOperRegItem(156).Content}\r\n" +
                    $"НОМЕР СУТ. ОТЧ. БЕЗ ГАШ.: {fr.GetOperRegItem(158).Content}\r\n" +
                    $"НОМЕР ТЕХНОЛОГ. ТЕСТА: {fr.GetOperRegItem(163).Content}\r\n" +
                    $"НОМЕР ОТМЕН. ДОКУМЕНТОВ: {fr.GetOperRegItem(166).Content}\r\n" +
                    $"НОМЕР ОБЩЕГО ГАШЕНИЯ: {fr.GetOperRegItem(160).Content}\r\n" +
                    $"НОМЕР ОТЧЁТА ПО СЕКЦИЯМ: {fr.GetOperRegItem(165).Content}\r\n" +
                    $"НОМЕР ОТЧЁТА ПО НАЛОГАМ: {fr.GetOperRegItem(178).Content}\r\n" +
                    $"НОМЕР ОТЧЁТА ПО КАССИРАМ: {0}\r\n";
                }
                return null;
            }
        }
        //метод формирует и возвращает отчёт о внесении наличных
        public string GetCashIncomeReport(decimal summ)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                string title = fr.GetTitle("");
                if (title != null)
                    return $"{title}\r\nВНЕСЕНИЕ: {summ}";

                return null;
            }
        }
        //метод формирует и возвращает отчёт о выдачи наличных
        public string GetCashOutcomeReport(decimal summ)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                string title = fr.GetTitle("");
                if (title != null)
                    return $"{title}\r\nВЫПЛАТА: {summ}";

                return null;
            }
        }
    }
}
