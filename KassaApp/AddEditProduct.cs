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
    public partial class AddEditProduct : Form
    {
        public AddEditProduct()
        {
            InitializeComponent();
        }
        //private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.KeyChar = '\0';
        //    }
        //    if (e.KeyChar == ',')
        //    {
        //        if (((TextBox)sender).Text.Contains(','))
        //            e.KeyChar = '\0';
        //    }
        //}

        //private void addProductB_Click(object sender, EventArgs e)
        //{
        //    if (nameTB.Text != "" && countNUD.Value != 0 && priceTB.Text != ""
        //        && saleTB.Text != "" && ndsTB.Text != "")
        //    {
        //        receiptDGV.Rows.Add(nameTB.Text, countNUD.Value, priceTB.Text, saleTB.Text, ndsTB.Text);
        //        ClearContent();
        //    }
        //    else
        //        MessageBox.Show("Заполните все данные о товаре!");
        //}

        //private void receiptDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{

        //}

        //private void ClearContent()
        //{
        //    nameTB.Text = "";
        //    countNUD.Value = 1;
        //    priceTB.Text = "";
        //    saleTB.Text = "";
        //    ndsTB.Text = "";
        //}
    }
}
