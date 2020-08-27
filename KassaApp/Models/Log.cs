using NLog;

namespace KassaApp.Models
{
    /// <summary>
	/// Класс предоставляет доступ к объекту Logger для ведения лога.
	/// </summary>
    class Log
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
