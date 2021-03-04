using KassaApp.Models;
using System;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class PrescriptionData : Form
    {
        public PrescriptionData()
        {
            InitializeComponent();
        }
        private void cancelB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void editProductB_Click(object sender, EventArgs e)
        {
            if (CurrentReceipt.Receipt != null) 
            {
                CurrentReceipt.Receipt.PrescriptionInfo.Series = seriesTB.Text;
                CurrentReceipt.Receipt.PrescriptionInfo.Number = numberTB.Text;
                CurrentReceipt.Receipt.PrescriptionInfo.Date = dateDTP.Value;
            }

            if (!string.IsNullOrEmpty(seriesTB.Text) && !string.IsNullOrEmpty(numberTB.Text))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            
            Close();
        }
    }
}
