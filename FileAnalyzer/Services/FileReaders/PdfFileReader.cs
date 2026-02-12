using FileAnalyzer.Core;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace FileAnalyzer.Services.FileReaders
{
    public class PdfFileReader : IFileReader
    {
        public string SupportedExtension => ".pdf";

        public string ReadFile(string filePath)
        {
            using (var document = PdfDocument.Open(filePath))
            {
                StringBuilder text = new StringBuilder();
                foreach (Page page in document.GetPages())
                {
                    text.AppendLine(page.Text);
                }
                return text.ToString();

            }
        }
    }
}
