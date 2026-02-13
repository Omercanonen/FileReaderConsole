using FileAnalyzer.Core;
using FileAnalyzer.Core.Enums;
using System.IO;

namespace FileAnalyzer.Services.FileReaders
{
    public class TxtFileReader : IFileReader
    {
        //public string SupportedExtension => ".txt";
        public FileType FileType => FileType.TxtFormat;

        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
