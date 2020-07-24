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
    public partial class DiscountOnReceipt : Form
    {
        public DiscountOnReceipt()
        {
            InitializeComponent();
        }
        //обработка нажатия горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: cancelB_Click(null, null); break;
                case Keys.Enter: enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //обработка кнопки Ввод
        private void enterB_Click(object sender, EventArgs e)
        {
            double discount = 0;
            if (discountDataTB.Text != "")
            {
                //если выбрано указание процента скидки
                if (discountProcentRB.Checked)
                {
                    discount = double.Parse(discountDataTB.Text);
                    if(((Main)Owner).receipt != null)
                    {
                        //скидка указывается в текущем чеке
                        ((Main)Owner).receipt.Discount = discount;
                        MessageBox.Show("Скидка на чек установлена!");
                        ((Main)Owner).DGV_Refresh();
                        Close();
                    }
                }
                //если выбрано указание номера дисконтной карты
                else if (numberDiscountCardRB.Checked)
                {
                    MessageBox.Show("Функционал находится в разработке");
                }
            }
            else
                MessageBox.Show("Заполните поле!");
        }
        //обработка нажатия кнопки Отмена
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
        //обработка изменение выбора способа указания скидки
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            if (discountProcentRB.Checked)
                operationL.Text = "Процент:";
            else if(numberDiscountCardRB.Checked)
                operationL.Text = "ДК:";
        }
    }
}
