using FileAnalyzer.Core;
using System;
using System.IO;

namespace FileAnalyzer.Services.Logging
{
    public class FileLogger : Ilogger
    {
        private readonly string _logFilePath;

        public FileLogger()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            _logFilePath = Path.Combine(folder, "app_log.txt");
        }

        public void log(string message)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: INFO - {message}{Environment.NewLine}");
        }


        public void logError(string message, Exception ex)
        {
            string logMsg = $"{DateTime.Now}: ERROR - {message} | Details: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(_logFilePath, logMsg);
        }

        
    }
}
