using System.Collections.Concurrent;
using System.Linq;

namespace TGoogle.Site.Models.Statistics
{
    public static class StatisticsHandler
    {
        private static readonly ConcurrentDictionary<string, int> KeywordsDictionary = new ConcurrentDictionary<string, int>();

        public static ConcurrentDictionary<string, int> GetCurrentState(SortOption sortOption, int pageSize)
        {
            switch (sortOption)
            {
                case SortOption.None:
                    return new ConcurrentDictionary<string, int>(KeywordsDictionary.Take(pageSize));
                case SortOption.Keyword:
                    return new ConcurrentDictionary<string, int>(KeywordsDictionary.OrderBy(pair => pair.Key).Take(pageSize));
                case SortOption.KeywordDecrease:
                    return new ConcurrentDictionary<string, int>(KeywordsDictionary.OrderByDescending(pair => pair.Key).Take(pageSize));
                case SortOption.KeywordCount:
                    return new ConcurrentDictionary<string, int>(KeywordsDictionary.OrderBy(pair => pair.Value).Take(pageSize));
                case SortOption.KeywordCountDecrease:
                    return new ConcurrentDictionary<string, int>(KeywordsDictionary.OrderByDescending(pair => pair.Value));
            }
            return KeywordsDictionary;
        }

        public static void HandleExpresion(string keyWord)
        {
            KeywordsDictionary.AddOrUpdate(keyWord, s => 0, (s, i) => ++i);
        }
    }
}