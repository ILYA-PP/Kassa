using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    /// <summary>
    /// Класс предоставляющий функционал для определения
    /// формата при вводе значений в textBox и выводе сообщений.
    /// </summary>
    class TextFormat
    {
        /// <summary>
        /// Метод допускает ввод дробных чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
        /// <summary>
        /// Метод допускает ввод только целых чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        public static void TextBoxDigitFormat(object sender, KeyPressEventArgs e)
        {
            //ввод только чисел и удаление
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = '\0';
        }
        /// <summary>
        /// Метод унифицирует формат вывода сообщений о возникающих исключениях.
        /// </summary>
        /// <param name="ex">Исключение, сообщение которого необходимо вывести.</param>
        /// <returns>Строка в изменённом формате.</returns>
        public static string GetExceptionMessage(Exception ex)
        {
            return $"{ex.Message}\n    {ex.GetBaseException().Message}";
        }
    }
}
