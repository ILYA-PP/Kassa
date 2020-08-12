using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы внесения/выплаты наличных.
    /// </summary>
    public partial class CashIncomeOutcome : Form
    {
        private bool IsCashIncome; //указывает назначение формы, Внесение или же Выплата
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и определяет её назначение (внесение или выплата).
        /// </summary>
        /// <param name="isCashIncome">Назначение формы: true - внесение, false - выплата.</param>
        public CashIncomeOutcome(bool isCashIncome)
        {
            InitializeComponent();
            Log.Logger.Info($"Открытие окна Внесение/Выплата наличных...");
            IsCashIncome = isCashIncome;
            if (IsCashIncome)
                operationL.Text = "Внесение наличных";
            else
                operationL.Text = "Выплата наличных";
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
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Ввод.
        /// Отвечает за фиксирование внесения или выплаты указанной суммы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void enterB_Click(object sender, EventArgs e)
        {
            Log.Logger.Info($"Начало операции: {operationL.Text}...");
            decimal summ, res;
            if(summaTB.Text != "")
            {
                summ = decimal.Parse(summaTB.Text);
                if (summ > 0)
                {
                    using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
                    {
                        if (fr.CheckConnect() == 0)
                        {
                            //Вненение или Выплата, относительно назначения формы
                            if (IsCashIncome)
                                res = fr.CashIncome(summ);
                            else
                                res = fr.CashOutcome(summ);
                            if(res == 0)
                                Log.Logger.Info($"Успех операции: {operationL.Text}...");
                            Close();
                        }
                    }
                }
                else
                    MessageBox.Show("Сумма должна быть больше 0!");
            }
            else
                MessageBox.Show("Введите сумму!");
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отмена.
        /// Вызывает метод Close для формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void cancelB_Click(object sender, EventArgs e)
        {
            Log.Logger.Info("Закрытие формы...");
            Close();
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод дробных чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void summaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //приведение вводимого текста к числовому формату
            TextFormat.TextBoxFormat(sender, e);
        }
    }
}
