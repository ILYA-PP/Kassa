using System.IO;

namespace KassaApp.Models
{
    class CurrentHardware
    {
        public static ITerminal GetTerminal()
        {
            return new PaxTerminal();
        }
        public static IFiscalRegistrar GetFiscalRegistrar()
        {
            return new DriverSHTRIH();
        }
    }
}
