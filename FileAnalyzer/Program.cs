using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAnalyzer.Core;
using FileAnalyzer.Model;
using FileAnalyzer.Services;
using FileAnalyzer.Services.Logging;

namespace FileAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ilogger logger = new FileLogger();

            try
            {
                string filePath = @"C:\Users\omerc\OneDrive\Belgeler\FileReader\Deneme.pdf";

                var reader = FileReader.GetReader(filePath);
                string content = reader.ReadFile(filePath);
                logger.log($"okunan dosya: {filePath}");

                var analyzer = new TextAnalyzer();
                var result = analyzer.Analyze(content);

                Console.WriteLine($"toplam kelime: {result.TotalWords}");
                Console.WriteLine($"tekrar eden: {result.RepeatingWords}");
                foreach (var kv in result.RepeatingWordsList)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                }
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                logger.logError("bu dosya türü desteklenmiyor", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("hata oluştu");
                logger.logError(" hata", ex);
            }

            Console.ReadKey();
        }
    }
}

