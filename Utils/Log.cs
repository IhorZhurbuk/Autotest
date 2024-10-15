using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Utils
{
    public class Log
    {
        public string Date { get; set; }

        public LogType Type { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }

        public Log(LogType type, string source, string message)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); ;
            Type = type;
            Source = source;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Date} {Type} \"{Source}\"- {Message}";
        }
    }

    public enum LogType
    {
        INFO = 1,
        ERROR = 2,
    }
}
