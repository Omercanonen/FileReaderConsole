using FileAnalyzer.Core;
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
                        Console.WriteLine("Dosya Secilmedi.");
                        return;
                    }
                }

                var reader = FileReader.GetReader(filePath);
                string content = reader.ReadFile(filePath);
                logger.log($"Okunan Dosya: {filePath}");

                var analyzer = new TextAnalyzer();
                var result = analyzer.Analyze(content);

                Console.WriteLine($"Toplam Kelime: {result.TotalWords}");
                Console.WriteLine($"Tekrar Eden: {result.RepeatingWords}");
                Console.WriteLine($"Toplam Noktalama Isareti: {result.PuntactionCnt.Count}");

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
                logger.logError("Bu Dosya Turu Desteklenmiyor.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Olustu");
                logger.logError("Hata", ex);
            }

            Console.ReadKey();
        }
    }
}

