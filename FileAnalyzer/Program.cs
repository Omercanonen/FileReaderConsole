using FileAnalyzer.Core;
using FileAnalyzer.Core.Enums;
using FileAnalyzer.Services;
using FileAnalyzer.Services.Logging;
using System;
using System.Windows.Forms;

namespace FileAnalyzer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please Select a File:\n");

                    foreach (FileType type in Enum.GetValues(typeof(FileType)))
                    {
                        Console.WriteLine(
                            $"{(int)type} - {type} ({type.GetExtension()})"
                        );
                    }

                    Console.WriteLine("E - Exit");

                    Console.Write("\nSecim: ");
                    string input = Console.ReadLine();


                    if (input.Equals("e", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    Console.WriteLine("\nStarting Analysis");

                    if (!int.TryParse(input, out int secim) ||
                        !Enum.IsDefined(typeof(FileType), secim))
                    {
                        Console.WriteLine("Invalid Selection.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue; // başa dön
                    }

                    FileType selectedType = (FileType)secim;

                    string filePath = string.Empty;

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        string ext = selectedType.GetExtension();
                        string extName = ext.TrimStart('.').ToUpper();

                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter =
                            $"{extName} files (*{ext})|*{ext}";

                        openFileDialog.FilterIndex = 1;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = openFileDialog.FileName;
                        }
                        else
                        {
                            Console.WriteLine("Cannot Select File");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue; // başa dön
                        }
                    }

                    var reader = FileReader.GetReader(filePath);

                    string content = reader.ReadFile(filePath);

                    logger.Log($"Okunan Dosya: {filePath}");

                    var analyzer = new TextAnalyzer();

                    var result = analyzer.Analyze(content);

                    Console.WriteLine($"\nTotal Words: {result.TotalWords}");
                    Console.WriteLine($"Repeating: {result.RepeatingWords}");
                    Console.WriteLine($"Total Punctuations: {result.PuntactionCnt.Count}");

                    foreach (var kv in result.PuntactionCnt)
                    {
                        Console.WriteLine($"{kv.Key}: {kv.Value}");
                    }

                    foreach (var kv in result.RepeatingWordsList)
                    {
                        Console.WriteLine($"{kv.Key}: {kv.Value}");
                    }

                    Console.WriteLine("\nAnalysis Completed");
                    Console.WriteLine("Press E to Exit, Any Key to Continue");

                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.E)
                    {
                        break;
                    }
                    Console.ReadKey();
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                    logger.LogError("This file type is not supported.", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occurred");
                    logger.LogError("Error", ex);
                }
            }

            Console.WriteLine("\nShutting down");
            
        }
    }
}

