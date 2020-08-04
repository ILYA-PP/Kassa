using System;

namespace KassaApp.Models
{
    interface ITerminal:IDisposable
    {
        string GetCardName();
        string GetReceipt();
        string GetReceiptName();
        bool IsEnabled();
        int Purchase(decimal sum);
        void CancelTransaction();
        void Unconfirmed();
        void Confirmed();
        void Return();
        void CloseDay();
        void GetXReport();
    }
}
