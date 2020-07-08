using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Models
{
    class GeneralCodeForForms
    {
        public static void TextBoxFormat(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
                return;
            }
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.KeyChar = '\0';
                return;
            }
            if (tb.Text.Split('.').Length == 2 && tb.Text != "0.00" && e.KeyChar != (char)Keys.Back)
                if (tb.Text.Split('.')[1].Length == 2)
                    tb.Text = String.Format("{0:f}", double.Parse(tb.Text));
        }

        public static void TextBoxDigitFormat(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = '\0';
        }
    }
}
