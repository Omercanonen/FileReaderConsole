using System.IO;
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
