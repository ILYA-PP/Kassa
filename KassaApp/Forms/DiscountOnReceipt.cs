using KassaApp.Models;
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
            Log.Logger.Info("Открытие окна Установки скидки на чек...");
            InitializeComponent();
        }
        /// <summary>
        /// Метод отвечает за обработку нажатия горячих клавиш.
        /// </summary>
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
                        if (CurrentReceipt.Receipt != null)
                        {
                            //скидка указывается в текущем чеке     
                            CurrentReceipt.Receipt.Discount = double.Parse(discountDataTB.Text);
                            CurrentReceipt.Receipt.CalculateSumm();
                            ((Main)Owner).DGV_Refresh();
                            Log.Logger.Info($"Установлен процент скидки в размере {discountDataTB.Text}%");
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
                        if (CurrentReceipt.Receipt != null)
                        {
                            CurrentReceipt.Receipt.DiscountCard = discountDataTB.Text;
                            ((Main)Owner).DGV_Refresh();
                            Log.Logger.Info($"Установлен номер дисконтной карты {discountDataTB.Text}");
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
            Log.Logger.Info("Закрытие окна Установки скидки на чек...");
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
        /// Допускает ввод дробных чисел, если вводится процент скидки, 
        /// или допускает ввод только целых чисел, если вводится номер дисконтной карты.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void discountDataTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(discountProcentRB.Checked)
                TextFormat.TextBoxDoubleFormat(sender, e);
            else
                TextFormat.TextBoxDigitFormat(sender, e);
        }
    }
}
