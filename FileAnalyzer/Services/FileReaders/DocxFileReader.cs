using DocumentFormat.OpenXml.Packaging;
using FileAnalyzer.Core;
using FileAnalyzer.Core.Enums;
using System.Text;

namespace FileAnalyzer.Services.FileReaders
{
    public class DocxFileReader : IFileReader
    {
        public FileType FileType => FileType.DocxFormat;
        public string ReadFile(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;
                if (body != null)
                {
                    text.Append(body.InnerText);
                }
            }
            return text.ToString();
        }
    }
}
