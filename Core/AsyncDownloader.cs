using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OSMTilesDownloader.Helper;
using System;
using System.ComponentModel;
using System.IO;

namespace OSMTilesDownloader.Core
{
    public class AsyncDownloader
    {
        private static readonly string[] _serverEndpoints = { "a", "b", "c" };
        private static List<Task> tasks = new List<Task>();
        private Form1 form1;

        public AsyncDownloader(Form1 form1)
        {
            this.form1 = form1;
        }

        private static Task ForEachAsync(IEnumerable<Task> tasks, int concurrency)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(tasks).GetPartitions(concurrency)
                select Task.Run(async delegate
                {
                    using (partition)
                    {
                        while (partition.MoveNext())
                        {
                            await partition.Current;
                        }
                    }
                }));
        }

        internal void Download(TileRange tiles)
        {
            Random random = new Random();
            int iterator = 0;
            {
                Task.Factory.StartNew(() =>
                    {
                        foreach (Tile tile in tiles)
                        {
                            String choosen_server = _serverEndpoints[random.Next(0, 2)];
                            var endpointUrl = "http://" + choosen_server + ".tile.openstreetmap.org/" + Config.ZOOM + "/" + tile.X + "/" + tile.Y + ".png";

                            //only one server name is just for the example. It's not recommended to use only 1 server endpoint
                            //tasks.Add(Task.Run(() =>
                            //{
                                SingleTask(endpointUrl, choosen_server);
                            //}));
                            double progress = (iterator / tiles.Count) * 100;
                            form1.UpdateProgressBar((int)progress);
                            iterator++;

                            form1.Log(iterator + "/" + tiles.Count + " - " + endpointUrl);
                        }
                        //AsyncDownloader.ForEachAsync(tasks, 2);
                    });
            }
        }

        private System.ComponentModel.AsyncCompletedEventHandler client_DownloadFileCompleted(string endpointUrl)
        {
            Action<object, AsyncCompletedEventArgs> action = (sender, e) =>
            {
                var _filename = endpointUrl;
                form1.Log(">> - " + _filename);
                if (e.Error != null)
                {
                    throw e.Error;
                }
            };
            return new AsyncCompletedEventHandler(action);
        }

        private void SingleTask(String endpointUrl, String choosen_server)
        {
            
            using (var client = new WebClient())
            {
                String filename = endpointUrl.Replace("http://" + choosen_server + ".tile.openstreetmap.org/", "").Replace("/", "_");
                String SavedPath = @"Tiles\" + filename;
                if (!File.Exists(SavedPath))
                {
                    client.DownloadFileCompleted += client_DownloadFileCompleted(endpointUrl);
                    client.DownloadFileAsync(new Uri(endpointUrl), SavedPath);
                }
            }
        }

    }
}
