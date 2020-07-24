using System;

namespace KassaApp.Models
{
    interface IFiscalRegistrar:IDisposable
    {
        int CheckConnect();
        int Print(string s);
        int PrintCheque(Receipt cheque, string cardName = null);
        void PrintXReport();
        void PrintXSectionReport();
        void PrintXTaxReport();
        void PrintZReport();
        void PrintOperationReg();
        int CashIncome(decimal summ);
        int CashOutcome(decimal summ);
        RegistrerItem GetOperRegItem(int num);
        RegistrerItem GetCashRegItem(int num);
    }
}
