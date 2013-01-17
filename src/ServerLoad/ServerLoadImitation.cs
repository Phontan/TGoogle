using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ServerLoad
{
    internal class ServerLoadImitation
    {
        private readonly string _filePath;
        private readonly int _maxRequestPerSecond;
        private readonly ConcurrentBag<KeyValuePair<string, int>> _links;
        private readonly Task _loadTask;
        private const string BaseUrl = "http://localhost/tgoogle/Search?keyWord={0}";

        public ServerLoadImitation(string filePath, int maxRequestPerSecond = 10000)
        {
            _filePath = filePath;
            _maxRequestPerSecond = maxRequestPerSecond;
            _links = new ConcurrentBag<KeyValuePair<string, int>>();
            _loadTask = new Task(HandleLinks);
        }

        private void HandleLinks()
        {
            string url;
            HttpWebRequest sender;
            while (true)
            {
                foreach (var linkStruct in _links)
                {
                    url = string.Format(BaseUrl, HttpUtility.UrlEncode(linkStruct.Key));
                    
                    for (var i = 0; i < linkStruct.Value; i++)
                    {
                        sender = (HttpWebRequest)WebRequest.Create(url);
                        sender.GetResponseAsync();
                    }
                    Console.Write(".");
                }
            }
        }

        public void Start()
        {
            _loadTask.Start();
            using (var sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var readLine = sr.ReadLineAsync().Result;
                        var splitedLine = readLine.Split(' ');
                        var numberString = splitedLine[splitedLine.Length - 1];
                        var keyWord = readLine.Substring(0, readLine.Length - numberString.Length - 1);
                        _links.Add(new KeyValuePair<string, int>(keyWord, int.Parse(numberString)));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void Stop()
        {
        }
    }
}