using FileAnalyzer.Core.Enums;

namespace FileAnalyzer.Core
{
    public interface IFileReader
    {
        FileType FileType { get; }
        string ReadFile(string filePath);
    }
}
