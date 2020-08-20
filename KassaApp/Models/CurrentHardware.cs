using System.Configuration;
using System.IO;

namespace KassaApp.Models
{
    /// <summary>
	/// Класс устанавливает работу с классами текущего оборудования.
	/// </summary>
    class CurrentHardware
    {
        /// <summary>
		/// Метод возвращает объект, представляющий класс для работы
        /// с терминалом, реализующий интерфейс ITerminal.
		/// </summary>
		/// <returns>Используемый терминал.</returns>
        public static ITerminal GetTerminal()
        {
            return new PaxTerminal();
        }
        /// <summary>
		/// Метод возвращает объект, представляющий класс для работы
        /// с фискальным регистратором, реализующий интерфейс IFiscalRegistrar.
		/// </summary>
		/// <returns>Используемый фискальный регистратор.</returns>
        public static IFiscalRegistrar GetFiscalRegistrar()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var driverName = config.AppSettings.Settings["FRDriverName"].Value;
            IFiscalRegistrar driver;
            switch (driverName)
            {
                case "ШТРИХ-М": driver = new DriverSHTRIH(); break;
                default: driver = new DriverSHTRIH(); break;
            }
            return driver;
        }
    }
}
