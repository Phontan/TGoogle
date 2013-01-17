using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ServerLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"D:\apps\test\TGoogle\src\ServerLoad\KeyValuePairs.txt";

            var flooder = new ServerLoadImitation(filePath);
            flooder.Start();
            Thread.Sleep(100000);
        }
    }
}
