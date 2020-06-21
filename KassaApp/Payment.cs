using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Payment : Form
    {
        private double Sum = 0;
        public Payment(double s)
        {
            InitializeComponent();
            resultL.Text = $"Сумма по чеку: {s}";
            Sum = s;
            moneyTB.Text = s.ToString();
        }

        private void priceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
            }
            if (e.KeyChar == ',')
            {
                if (((TextBox)sender).Text.Contains(','))
                    e.KeyChar = '\0';
            }
        }

        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            //if (cashRB.Checked)
            //    moneyTB.Enabled = true;
            //else
            //{
            //    moneyTB.Enabled = false;
            //    changeTB.Text = "";
            //    moneyTB.Text = "";
            //}
        }

        private void moneyTB_TextChanged(object sender, EventArgs e)
        {
            if (moneyTB.Text != "")
                changeTB.Text = (Math.Round(double.Parse(moneyTB.Text) - Sum, 2)).ToString();
            else
                changeTB.Text = "";
        }
    }
}
