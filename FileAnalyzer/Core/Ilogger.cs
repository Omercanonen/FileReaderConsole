using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer.Core
{
    public interface Ilogger
    {
        void log(string message);
        void logError(string message, Exception ex);
    }
}
