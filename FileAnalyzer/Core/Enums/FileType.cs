using System.ComponentModel;

namespace FileAnalyzer.Core.Enums
{
    public enum FileType
    {
        [Description(".txt")]
        TxtFormat = 0,

        [Description(".docx")]
        DocxFormat = 1,

        [Description(".pdf")]
        PdfFormat = 2
    }
}
