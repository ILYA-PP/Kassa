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
        //обработка горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: cancelB_Click(null, null); break;
                case Keys.Enter: enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //обработка кнопки ВВод
        private void enterB_Click(object sender, EventArgs e)
        {

        }
        //закрытие формы
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            if (discountProcentRB.Checked)
                operationL.Text = "Процент:";
            else if(numberDiscountCardRB.Checked)
                operationL.Text = "ДК:";
        }
    }
}
