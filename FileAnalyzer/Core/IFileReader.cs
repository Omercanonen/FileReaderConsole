using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer.Core
{
    public interface IFileReader
    {
        string SupportedExtension { get; }
        string ReadFile(string filePath);
    }
}
