using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>( ( ) =>
            {
                return GetPosts("https://jsonplaceholder.typicode.com/posts");
            });

            SomethingElse();
  
            try
            {
                
                Console.WriteLine(task.Result);
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SomethingElse()
        {
             //Dummy implementaton
        }

        private static string GetPosts(string url)
        {
            
             using(var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
