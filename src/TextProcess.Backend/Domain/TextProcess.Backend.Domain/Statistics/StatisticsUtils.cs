using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Statistics
{
    internal static class StatisticsUtils
    {
        internal static TextStatisticsEntity GetStatisticsOfText(string textToAnalize)
        {
            return new TextStatisticsEntity(CountCharacters(textToAnalize, '-'), CountWords(textToAnalize), CountCharacters(textToAnalize, ' '));
        }

        private static int CountWords(string text)
        {
           return text.Trim('-').Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
        }

        private static int CountCharacters(string text, char character)
        {
            return text.Count(c => c == character);
        }
    }
}
