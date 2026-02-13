using System;

namespace FileAnalyzer.Core
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message, Exception ex);
    }
}
