using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAnalyzer.Model;

namespace FileAnalyzer.Services
{
    internal class TextAnalyzer
    {
        private readonly HashSet<string> _stopWords;

        // Bağlaçları at
        public TextAnalyzer()
        {
            _stopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "ve", "ile", "ama", "ancak", "veya", "de", "da", "ancak",
            };
        }
        public AnalysisResult Analyze(string content)
        {
            var result = new AnalysisResult(); // nesne oluşturma 

            if (string.IsNullOrWhiteSpace(content)) // boş kontrolü 
                return result;

            var words = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries); // kelimeleri ayır

            result.TotalWords = words.Length; 

            var wordGroups = words
                .Where(w => !_stopWords.Contains(w)) // bağlaçları seç
                .GroupBy(w => w, StringComparer.OrdinalIgnoreCase) // aynı kelime varsa grupla 
                .Where(g => g.Count() > 1) // 1 den fazla olanları seç
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count())) 
                .ToList();

            result.RepeatingWords = wordGroups.Count; 
            result.RepeatingWordsList = wordGroups;

            // Her bir noktalama işaretinin kaç kez geçtiği raporlanmalıdır.
            var punctuation = content.Where(char.IsPunctuation)
                                     .GroupBy(c => c)
                                     .Select(g => new KeyValuePair<char, int>(g.Key, g.Count())) // kaç tane olduğunu say 
                                     .ToList();
            result.PuntactionCnt = punctuation;

            return result;

        }
    }
}

