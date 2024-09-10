using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Utils
{
    public class Logger
    {
        public string Source { get; private set; }

        List<Log> logs = new List<Log>();

        public Logger(string source)
        {
            this.Source = source;
        }

        public void LogInfo(string message)
        {
            Log log = new Log(LogType.INFO, Source, message);
            logs.Add(log);
        }

        public void LogConsoleError(string message, DateTime timestamp)
        {
            Log log = new Log(LogType.CONSOLE, Source, message);
            logs.Add(log);
        }

        public void LogError(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
            Log log = new Log(LogType.ERROR, Source, message.Replace("\n", "\n" + new string(' ', 24)));
            logs.Add(log);
        }

        public void LogError(Exception ex)
        {
            LogError(ex.ToString());
        }

        public void ImportLog(Logger logger)
        {
            logs.AddRange(logger.logs);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            logs.OrderBy(log => log.Date)
                .ToList()
                .ForEach(log => builder.AppendLine(log.ToString()));
            return builder.ToString();
        }
    }
}
