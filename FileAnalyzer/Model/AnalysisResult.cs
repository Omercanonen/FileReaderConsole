using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer.Model
{
    public class AnalysisResult
    {
        public int TotalWords { get; set; }
        public int RepeatingWords { get; set; }

        public List<KeyValuePair<string, int>> RepeatingWordsList { get; set; } // tekrar eden kelimeleri tutmak için KeyValuePair
        public List<KeyValuePair<char, int>> PuntactionCnt { get; set; }

        public AnalysisResult()
        {
            RepeatingWordsList = new List<KeyValuePair<string, int>>();
            PuntactionCnt = new List<KeyValuePair<char, int>>();
        }
    }
}
