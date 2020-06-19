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
    public partial class Main : Form
    {
        private double totalForReceipt = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
            }
            if(e.KeyChar == ',')
            {
                if(((TextBox)sender).Text.Contains(','))
                    e.KeyChar = '\0';
            }
        }

        private void addProductB_Click(object sender, EventArgs e)
        {
            if (nameTB.Text != "" && countNUD.Value != 0 && priceTB.Text != ""
                && saleTB.Text != "" && ndsTB.Text != "")
            {
                receiptDGV.Rows.Add(nameTB.Text, countNUD.Value, priceTB.Text, saleTB.Text, ndsTB.Text);
                ClearContent();
            }
            else
                MessageBox.Show("Заполните все данные о товаре!");
        }

        private void receiptDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double result = 0, sum = 0;
            foreach (DataGridViewRow r in receiptDGV.Rows)
            {
                sum = double.Parse(r.Cells["countCol"].Value.ToString()) *
                    double.Parse(r.Cells["priceCol"].Value.ToString());
                result += sum - sum * double.Parse(r.Cells["saleCol"].Value.ToString()) / 100;
            }
            totalForReceipt = Math.Round(result, 2);
            resultL.Text = $"ИТОГО: {totalForReceipt} руб.";
        }

        private void ClearContent()
        {
            nameTB.Text = ""; 
            countNUD.Value = 1; 
            priceTB.Text = ""; 
            saleTB.Text = ""; 
            ndsTB.Text = "";
        }

        private void payB_Click(object sender, EventArgs e)
        {
            new Payment(totalForReceipt).ShowDialog();
        }
    }
}
