using System;
using System.Collections.Concurrent;
using System.Linq;

namespace TGoogle.Site.Models.Statistics
{
    public static class StatisticsHandler
    {
        private static readonly ConcurrentDictionary<string, int> KeywordsDictionary = new ConcurrentDictionary<string, int>();

        public static void HandleExpresion(string keyWord)
        {
            try
            {
                KeywordsDictionary.AddOrUpdate(keyWord, s => 1, (s, i) => ++i);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static StatData[] GetCurrentState(SortOption sortOption, int pageNumber, int pageSize)
        {
            var startPosition = pageSize*pageNumber;
            switch (sortOption)
            {
                case SortOption.None:
                    return KeywordsDictionary.Skip(startPosition).Take(pageSize).Select(kvp => new StatData(kvp.Key, kvp.Value)).ToArray();
                case SortOption.Keyword:
                    return KeywordsDictionary.OrderBy(pair => pair.Key).Skip(startPosition).Take(pageSize).Select(kvp => new StatData(kvp.Key, kvp.Value)).ToArray();
                case SortOption.KeywordDecrease:
                    return KeywordsDictionary.OrderByDescending(pair => pair.Key).Skip(startPosition).Take(pageSize).Select(kvp => new StatData(kvp.Key, kvp.Value)).ToArray();
                case SortOption.KeywordCount:
                    return KeywordsDictionary.OrderBy(pair => pair.Value).Skip(startPosition).Take(pageSize).Select(kvp => new StatData(kvp.Key, kvp.Value)).ToArray();
                case SortOption.KeywordCountDecrease:
                    return KeywordsDictionary.OrderByDescending(pair => pair.Value).Skip(startPosition).Take(pageSize).Select(kvp => new StatData(kvp.Key, kvp.Value)).ToArray();
            }
            return new StatData[0];
        }
    }

    public class StatData
    {
        public string Expression { get; set; }
        public int Count { get; set; }

        public StatData()
        {
        }

        public StatData(string key, int value)
        {
            Expression = key;
            Count = value;
        }
    }
}