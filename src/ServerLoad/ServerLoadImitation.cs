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
        private readonly ConcurrentBag<KeyValuePair<string, int>> _links;
        private CancellationTokenSource _cancellationToken;
        private const string BaseUrl = "http://localhost/tgoogle/Search?keyWord={0}";

        public ServerLoadImitation(string filePath)
        {
            _filePath = filePath;
            _links = new ConcurrentBag<KeyValuePair<string, int>>();
        }

        private void HandleLinks(object arg)
        {
            var maxRequestsPerSecond = (int) arg;
            var token = _cancellationToken.Token;
            string url;
            HttpWebRequest sender;
            while (true)
            {
                foreach (var linkStruct in _links)
                {
                    url = string.Format(BaseUrl, HttpUtility.UrlEncode(linkStruct.Key));
                    for (var i = 0; i < linkStruct.Value; i++)
                    {
                        if (token.IsCancellationRequested)
                            return;
                        sender = (HttpWebRequest)WebRequest.Create(url);
                        sender.GetResponseAsync();
                        Thread.Sleep(1000/maxRequestsPerSecond);
                    }
                }
            }
        }

        public void Start(int maxRequestsPerSecond)
        {
            _cancellationToken = new CancellationTokenSource();
            var loadTask = new Task(HandleLinks, maxRequestsPerSecond, _cancellationToken.Token);
            loadTask.Start();
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
            _cancellationToken.Cancel();
        }
    }
}