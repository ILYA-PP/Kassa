using System.IO;

namespace KassaApp.Models
{
    class CurrentHardware
    {
        public static ITerminal Terminal = new PaxTerminal();
        public static IFiscalRegistrar FiscalRegistrar = new DriverSHTRIH();
    }
}
