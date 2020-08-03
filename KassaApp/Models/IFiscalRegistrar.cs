using System;

namespace KassaApp.Models
{
    interface IFiscalRegistrar:IDisposable
    {
        int CheckConnect();
        int Print(string s, bool Save = true);
        int PrintReceipt(Receipt cheque, string cardName = null);
        int PrintXReport();
        int PrintXSectionReport();
        int PrintXTaxReport();
        int PrintZReport();
        int PrintOpenSessionReport();
        int PrintOperationReg();
        int CashIncome(decimal summ);
        int CashOutcome(decimal summ);
        RegistrerItem GetOperRegItem(int num);
        RegistrerItem GetCashRegItem(int num);
        string GetTitle(string name);
    }
}
