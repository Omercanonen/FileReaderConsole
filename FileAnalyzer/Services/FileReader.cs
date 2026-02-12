using FileAnalyzer.Core;
using FileAnalyzer.Services.FileReaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileAnalyzer.Services
{
    public class FileReader
    {
        private static List<IFileReader> _readers = new List<IFileReader>
        {
            new TxtFileReader(),
            new DocxFileReader(),
            new PdfFileReader()
        };

        public static IFileReader GetReader(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            var reader = _readers.FirstOrDefault(r => r.SupportedExtension == extension);

            if (reader == null)
                throw new NotSupportedException($"Dosya Uzantisi Desteklenmiyor: {extension}");

            return reader;
        }
    }
}
