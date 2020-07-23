using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class ViewRegistarers : Form
    {
        public ViewRegistarers()
        {
            InitializeComponent();
        }
        //обработка нажатия кнопки Прочитать операционные регистры
        private void readOperationRegB_Click(object sender, EventArgs e)
        {
            using (FiscalRegistrar fr = new FiscalRegistrar())
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
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
            }
        }
        //обработка нажатия кнопки Прочитать денежные регистры
        private void readCashRegB_Click(object sender, EventArgs e)
        {
            using (FiscalRegistrar fr = new FiscalRegistrar())
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
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
            }
        }
        //обработка нажатия кнопки Печать операционных регистров
        private void printOperationRegB_Click(object sender, EventArgs e)
        {
            using (FiscalRegistrar fr = new FiscalRegistrar())
            {
                if (fr.CheckConnect() == 0)
                {
                    fr.PrintOperationReg(); //Печать операционных регистров
                }
                else
                    MessageBox.Show("Фискальный регистратор не подключен! Проверьте подключение и повторите попытку.");
            }
        }
    }
}
