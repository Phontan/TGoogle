using System;
using System.IO;

namespace RandomExpressionsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string randomTextFile = @"D:\apps\test\TGoogle\src\RandomExpressionsGenerator\RandomText.txt";
            const string resultFile = @"D:\apps\test\TGoogle\src\ServerLoad\KeyValuePairs.txt";
            const int maxRequestsCount = 100;
            using (var sr = new StreamReader(randomTextFile))
            {
                var text = sr.ReadToEndAsync().Result;
                var random = new Random();
                using (var sw = new StreamWriter(resultFile))
                {
                    foreach (var expression in text.Split(' '))
                    {
                        sw.WriteLine(string.Format("{0} {1}", expression, random.Next(1, maxRequestsCount)));
                    }
                }
            }
        }
    }
}
