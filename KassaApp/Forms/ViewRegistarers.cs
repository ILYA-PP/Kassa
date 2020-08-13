using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы показаний регистров.
    /// </summary>
    public partial class ViewRegistarers : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы.
        /// </summary>
        public ViewRegistarers()
        {
            Log.Logger.Info("Открытие окна Просмотра регистров...");
            InitializeComponent();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Прочитать операционные регистры.
        /// Отвечает за вывод операционных регистров в список формы. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void readOperationRegB_Click(object sender, EventArgs e)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                {
                    int i = 1;
                    RegistrerItem ri; //объект строки регистра
                    operationRegLB.Items.Clear();
                    //читать регистры пока не прочитаны все
                    while (true)
                    {
                        ri = fr.GetOperRegItem(i);
                        if (ri != null)
                        {
                            //добавление записи в поле на форме
                            operationRegLB.Items.Add($"{ri.Number}. {ri.Name} : {ri.Content}");
                            i++;
                        }
                        else
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Прочитать денежные регистры.
        /// Отвечает за вывод денежных регистров в список формы. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void readCashRegB_Click(object sender, EventArgs e)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                {
                    int i = 1;
                    RegistrerItem ri;//объект строки регистра
                    cashRegLB.Items.Clear();
                    //читать регистры пока не прочитаны все
                    while (true)
                    {
                        ri = fr.GetCashRegItem(i);
                        if (ri != null)
                        {
                            //добавление записи в поле на форме
                            cashRegLB.Items.Add($"{ri.Number}. {ri.Name} : {ri.Content}");
                            i++;
                        }
                        else
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопкипечать операционных регистров.
        /// Отвечает за печать и сохранение операционных регистров ККТ. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void printOperationRegB_Click(object sender, EventArgs e)
        {
            using (IFiscalRegistrar fr = CurrentHardware.GetFiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                    fr.PrintOperationReg(); //Печать операционных регистров
            }
        }

        private void ViewRegistarers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Просмотра регистров...");
        }
    }
}
