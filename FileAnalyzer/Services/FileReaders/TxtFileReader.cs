using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAnalyzer.Core;

namespace FileAnalyzer.Services.FileReaders
{
    public class TxtFileReader : IFileReader
    {
        public string SupportedExtension => ".txt";

        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
