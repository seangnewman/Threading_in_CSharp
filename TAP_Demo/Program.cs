using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TAP_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            var token = tokenSource.Token;

            Task.Factory.StartNew( () => {
                Thread.Sleep(10000);

                tokenSource.Cancel();
            });

            DownloadAsync(new Uri("https://jsonplaceholder.typicode.com/posts"), token).Wait();
        }

        public static async Task DownloadAsync(Uri uri, CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                try
                {
                    HttpResponseMessage result = await GetAsync(uri);
                    Console.WriteLine("Result is {0}", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        private static Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync(uri);
            return result;
        }
    }
}
