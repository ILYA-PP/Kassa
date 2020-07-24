using System;

namespace KassaApp.Models
{
    interface ITerminal:IDisposable
    {
        string GetCardName();
        string GetCheque();
        bool IsEnabled();
        int Purchase(decimal sum);
        void CancelTransaction();
        void Return();
        void CloseDay();
        void SaveStringReport(string d);
    }
}
