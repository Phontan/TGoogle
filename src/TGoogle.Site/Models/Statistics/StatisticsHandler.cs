using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TGoogle.Site.Models.Statistics
{
    public static class StatisticsHandler
    {
        private static readonly ConcurrentDictionary<string, int> KeywordsDictionary = new ConcurrentDictionary<string, int>();

        public static KeyValuePair<string, int>[] GetCurrentState(SortOption sortOption, int pageSize)
        {
            switch (sortOption)
            {
                case SortOption.None:
                    return KeywordsDictionary.Take(pageSize).ToArray();
                case SortOption.Keyword:
                    return KeywordsDictionary.OrderBy(pair => pair.Key).Take(pageSize).ToArray();
                case SortOption.KeywordDecrease:
                    return KeywordsDictionary.OrderByDescending(pair => pair.Key).Take(pageSize).ToArray();
                case SortOption.KeywordCount:
                    return KeywordsDictionary.OrderBy(pair => pair.Value).Take(pageSize).ToArray();
                case SortOption.KeywordCountDecrease:
                    return KeywordsDictionary.OrderByDescending(pair => pair.Value).ToArray();
            }
            return new KeyValuePair<string, int>[0];
        }

        public static void HandleExpresion(string keyWord)
        {
            KeywordsDictionary.AddOrUpdate(keyWord, s => 1, (s, i) => ++i);
        }
    }
}