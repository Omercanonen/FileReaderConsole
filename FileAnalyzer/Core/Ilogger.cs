using System;

namespace FileAnalyzer.Core
{
    public interface Ilogger
    {
        void log(string message);
        void logError(string message, Exception ex);
    }
}
