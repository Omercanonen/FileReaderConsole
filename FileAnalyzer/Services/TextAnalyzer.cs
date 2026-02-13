using System;
using System.Collections.Generic;
using System.Linq;
using FileAnalyzer.Model;

namespace FileAnalyzer.Services
{
    public class TextAnalyzer
    {
        private readonly HashSet<string> _stopWords;

        public TextAnalyzer()
        {
            _stopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "ve", "ile", "ama", "ancak", "veya", "de", "da", "ancak",
            };
        }
        public AnalysisResult Analyze(string content)
        {
            var result = new AnalysisResult();

            if (string.IsNullOrWhiteSpace(content))
                return result;


            var words = content
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Any(char.IsLetter))
                .ToArray();

            result.TotalWords = words.Length;

            var wordGroups = words
                .Where(w => !_stopWords.Contains(w))
                .GroupBy(w => w, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(kv => kv.Value)
                .ToList();

            result.RepeatingWords = wordGroups.Count;
            result.RepeatingWordsList = wordGroups;

     
            var punctuation = content.Where(char.IsPunctuation)
                                     .GroupBy(c => c)
                                     .Select(g => new KeyValuePair<char, int>(g.Key, g.Count())) 
                                     .OrderByDescending(kv => kv.Value)
                                     .ToList();
            result.PuntactionCnt = punctuation;

            return result;

        }
    }
}

