using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    //класс содержит методы, используемые на нескольких формах
    class TextFormat
    {
        //формат текста для чисел с плавающей точкой
        public static void TextBoxFormat(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            //ввод только чисел, точек и удаление 
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
                return;
            }
            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(','))
            {
                e.KeyChar = '\0';
                return;
            }
            if (tb.Text.Split(',').Length == 2 && tb.Text != "0,00" && e.KeyChar != (char)Keys.Back)
                if (tb.Text.Split(',')[1].Length == 2)
                    tb.Text = String.Format("{0:f}", double.Parse(tb.Text));
        }
        //формат текста для целых чисел
        public static void TextBoxDigitFormat(object sender, KeyPressEventArgs e)
        {
            //ввод только чисел и удаление
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = '\0';
        }
        //метод унифицирующий формат вывода сообщений
        //о возникающих исключениях
        public static string GetExceptionMessage(Exception ex)
        {
            return $"{ex.Message}\n    {ex.GetBaseException().Message}";
        }
    }
}
