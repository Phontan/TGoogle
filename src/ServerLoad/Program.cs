using System;
using System.Threading;

namespace ServerLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"D:\apps\test\TGoogle\src\ServerLoad\KeyValuePairs.txt";

            var flooder = new ServerLoadImitation(filePath);
            Console.WriteLine("first time starting");
            flooder.Start(10);
            Console.WriteLine("first time started");
            Thread.Sleep(10000);
            flooder.Stop();
            Console.WriteLine("first time stopped");
            Thread.Sleep(10000);
            Console.WriteLine("second time starting");
            flooder.Start(100);
            Console.WriteLine("second time started");
            Thread.Sleep(5000);
        }
    }
}
