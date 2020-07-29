using KassaApp.Models;
using System;
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
            if (discountDataTB.Text != "")
            {
                //если выбрано указание процента скидки
                if (discountProcentRB.Checked)
                {
                    if (double.Parse(discountDataTB.Text) <= 99.99)
                    {
                        if (((Main)Owner).receipt != null)
                        {
                            //скидка указывается в текущем чеке     
                            ((Main)Owner).receipt.Discount = double.Parse(discountDataTB.Text);
                            ((Main)Owner).receipt.CalculateSumm();
                            ((Main)Owner).DGV_Refresh();
                            MessageBox.Show("Скидка на чек установлена!");
                            Close();
                        }
                    }
                    else
                        MessageBox.Show("Скидка не может превышать 99.99%");
                }
                //если выбрано указание номера дисконтной карты
                else if (numberDiscountCardRB.Checked)
                {
                    if (discountDataTB.Text.Length == 11)
                    {
                        if (((Main)Owner).receipt != null)
                        {
                            ((Main)Owner).receipt.DiscountCard = discountDataTB.Text;
                            ((Main)Owner).DGV_Refresh();
                            MessageBox.Show("Дисконтная карта установлена!");
                            Close();
                        }
                    }
                    else
                        MessageBox.Show("Номер дисконтной карты должен состоять из 11 символов!");
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
            discountDataTB.Text = "";
        }

        private void discountDataTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(discountProcentRB.Checked)
                GeneralCodeForForms.TextBoxFormat(sender, e);
            else
                GeneralCodeForForms.TextBoxDigitFormat(sender, e);
        }
    }
}
