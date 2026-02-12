namespace FileAnalyzer.Core
{
    public interface IFileReader
    {
        string SupportedExtension { get; }
        string ReadFile(string filePath);
    }
}
