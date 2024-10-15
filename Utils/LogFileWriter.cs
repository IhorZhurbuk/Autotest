using System;
using System.IO;

namespace Autotest.Utils
{
    public static class LogFileWriter
    {
        public static void CreateLogFile(Logger logger)
        {
            CreateLogDirectory();
            string pathToFile = Path.Combine(CreateLogDirectory(), "RunLog.txt");
            using (StreamWriter sw = new StreamWriter(pathToFile, false))
            {
                sw.WriteLine(logger.ToString());
            }
        }

        public static void CreateLogFile(TestResult result)
        {
            CreateLogDirectory();
            string pathToFile = Path.Combine(CreateLogDirectory(), $"{result.Issue}.TCMLog");
            using (StreamWriter sw = new StreamWriter(pathToFile, false))
            {
                sw.WriteLine(result.GetXmlLog());
            }
        }

        private static string CreateLogDirectory()
        {
            string logDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOGS");
            if (!Directory.Exists(logDirPath)) Directory.CreateDirectory(logDirPath);
            return logDirPath;
        }
    }
}
