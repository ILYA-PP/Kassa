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
            if (((TextBox)sender).Text.Split('.').Length == 2 && ((TextBox)sender).Text != "0.00" && e.KeyChar != (char)Keys.Back)
                if (((TextBox)sender).Text.Split('.')[1].Length == 2)
                    e.KeyChar = '\0';
        }
    }
}
