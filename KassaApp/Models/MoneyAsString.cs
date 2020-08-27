using System;
using System.Text;

namespace KassaApp.Models
{
    /// <summary>
    /// Класс содержит функцинал для формирования прописи суммы.
    /// </summary>
    class MoneyAsString
    {
        //наименования сотен
        private static string[] hunds =
        {
            "", "сто ", "двести ", "триста ", "четыреста ",
            "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };
        //наименование десятков
        private static string[] tens =
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };
        /// <summary>
        /// Метод преобразует число в пропись.
        /// </summary>
        /// <param name="val">Число, которое необходимо преобразовать.</param>
        /// <param name="male">Род для тысяч.</param>
        /// <param name="one">Склонение числа один.</param>
        /// <param name="two">Склонение чисел от двух до четырёх.</param>
        /// <param name="five">Склонение чисел от пяти до девяти.</param>
        /// <returns>Пропись числа.</returns>
        public static string Str(int val, bool male, string one, string two, string five)
        {
            //наименование единиц и десятков
            string[] frac20 =
            {
                "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
                "семь ", "восемь ", "девять ", "десять ", "одиннадцать ",
                "двенадцать ", "тринадцать ", "четырнадцать ", "пятнадцать ",
                "шестнадцать ", "семнадцать ", "восемнадцать ", "девятнадцать "
            };

            int num = val % 1000;
            if (0 == num) return "";
            if (num < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");
            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            StringBuilder r = new StringBuilder(hunds[num / 100]);

            if (num % 100 < 20)
            {
                r.Append(frac20[num % 100]);
            }
            else
            {
                r.Append(tens[num % 100 / 10]);
                r.Append(frac20[num % 10]);
            }

            r.Append(Case(num, one, two, five));

            if (r.Length != 0) r.Append(" ");
            return r.ToString();
        }
        /// <summary>
        /// Метод определяет склонение для разряда.
        /// </summary>
        /// <param name="val">Число, у которого необходимо определить склонение.</param>
        /// <param name="one">Склонение числа один.</param>
        /// <param name="two">Склонение чисел от двух до четырёх.</param>
        /// <param name="five">Склонение чисел от пяти до девяти.</param>
        /// <returns>Пропись числа.</returns>
        public static string Case(int val, string one, string two, string five)
        {
            int t = (val % 100 > 20) ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return one;
                case 2: case 3: case 4: return two;
                default: return five;
            }
        }
    };
    /// <summary>
    /// Класс содержит функционал для преобразование прописи числа
    /// в пропись с использованием наименования денежной валюты.
    /// </summary>
    public class RusCurrency
    {

        public static string Str(double val)
        {
            Log.Logger.Info($"Формирование прописи суммы: {val}...");
            return Str(val, true,
                "рубль", "рубля", "рублей",
                "копейка", "копейки", "копеек");
        }
        /// <summary>
        /// Метод преобразует число в пропись с валютой.
        /// </summary>
        /// <param name="val">Число, которое необходимо преобразовать.</param>
        /// <param name="male">Род для тысяч.</param>
        /// <param name="seniorOne">Старшее наименование валюты для числа один</param>
        /// <param name="seniorTwo">Старшее наименование валюты для чисел от двух до четырёх.</param>
        /// <param name="seniorFive">Старшее наименование валюты для чисел от пяти до девяти.</param>
        /// <param name="juniorOne">Младшее наименование валюты для числа один.</param>
        /// <param name="juniorTwo">Младшее наименование валюты для чисел от двух до четырёх.</param>
        /// <param name="juniorFive">Младшее наименование валюты для чисел от пяти до девяти.</param>
        /// <returns>Пропись денежной суммы.</returns>
        public static string Str(double val, bool male,
            string seniorOne, string seniorTwo, string seniorFive,
            string juniorOne, string juniorTwo, string juniorFive)
        {
            bool minus = false;
            if (val < 0) { val = -val; minus = true; }

            int n = (int)val;
            int remainder = (int)((val - n + 0.005) * 100);

            StringBuilder r = new StringBuilder();

            if (0 == n) r.Append("0 ");
            if (n % 1000 != 0)
                r.Append(MoneyAsString.Str(n, male, seniorOne, seniorTwo, seniorFive));
            else
                r.Append(seniorFive);

            n /= 1000;

            r.Insert(0, MoneyAsString.Str(n, false, "тысяча", "тысячи", "тысяч"));
            n /= 1000;

            r.Insert(0, MoneyAsString.Str(n, true, "миллион", "миллиона", "миллионов"));
            n /= 1000;

            r.Insert(0, MoneyAsString.Str(n, true, "миллиард", "миллиарда", "миллиардов"));
            n /= 1000;

            r.Insert(0, MoneyAsString.Str(n, true, "триллион", "триллиона", "триллионов"));
            n /= 1000;

            r.Insert(0, MoneyAsString.Str(n, true, "триллиард", "триллиарда", "триллиардов"));
            if (minus) r.Insert(0, "минус ");

            r.Append(remainder.ToString("00 "));
            r.Append(MoneyAsString.Case(remainder, juniorOne, juniorTwo, juniorFive));

            //Делаем первую букву заглавной
            r[0] = char.ToUpper(r[0]);
            Log.Logger.Info($"Пропись сформирована: {r}");
            return r.ToString();
        }
    }
}
