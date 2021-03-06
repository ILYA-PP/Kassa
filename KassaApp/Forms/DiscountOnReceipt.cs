﻿using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp
{
    /// <summary>
    /// Класс содержит логику работы формы определения скидки на чек.
    /// </summary>
    public partial class DiscountOnReceipt : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы.
        /// </summary>
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
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Ввод.
        /// Отвечает ввод процента скидки или номера дисконтной карты в чек. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отмена.
        /// Вызывает метод Close для формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Метод обрабатывает выбор значения radioButton.
        /// Определяет способ определения скидки.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            if (discountProcentRB.Checked)
                operationL.Text = "Процент:";
            else if(numberDiscountCardRB.Checked)
                operationL.Text = "ДК:";
            discountDataTB.Text = "";
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод дробных чисел, 
        /// если вводится процент скидки, или допускает ввод только целых чисел, 
        /// если вводится номер дисконтной карты.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void discountDataTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(discountProcentRB.Checked)
                TextFormat.TextBoxFormat(sender, e);
            else
                TextFormat.TextBoxDigitFormat(sender, e);
        }
    }
}
