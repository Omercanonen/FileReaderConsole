using FileAnalyzer.Core;
using FileAnalyzer.Model;
using FileAnalyzer.Services;
using FileAnalyzer.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAnalyzer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Ilogger logger = new FileLogger();

            try
            {
                //string filePath = @"C:\Users\omerc\OneDrive\Belgeler\FileReader\Xss_DOMPurify_Rapor.pdf";

                string filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter =
                        "Text files (*.txt)|*.txt|" +
                        "Word files (*.docx)|*.docx|" +
                        "PDF files (*.pdf)|*.pdf|" +
                        "All files (*.*)|*.*";

                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                    else
                    {
                        Console.WriteLine("Dosya seçilmedi.");
                        return;
                    }
                }

                var reader = FileReader.GetReader(filePath);
                string content = reader.ReadFile(filePath);
                logger.log($"okunan dosya: {filePath}");

                var analyzer = new TextAnalyzer();
                var result = analyzer.Analyze(content);

                Console.WriteLine($"toplam kelime: {result.TotalWords}");
                Console.WriteLine($"tekrar eden: {result.RepeatingWords}");
                Console.WriteLine($"toplam noktalama işareti: {result.PuntactionCnt.Count}");

                foreach (var kv in result.PuntactionCnt)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                }

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

