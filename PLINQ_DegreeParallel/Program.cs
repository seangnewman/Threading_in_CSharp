using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ_DegreeParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> webSites = new List<string>();
             
            webSites.Add("www.stackoverflow.com");
            webSites.Add("www.dotnetpearls.com");
            webSites.Add("www.github.com");
            webSites.Add("www.google.com");
            webSites.Add("www.microsoft.com");
            webSites.Add("www.google.com");

            List<PingReply> responses = webSites.AsParallel()
                                                        .WithDegreeOfParallelism(webSites.Count)
                                                        .Select(PingSites).ToList();

            foreach (var response in responses)
            {
                Console.WriteLine( "The address is " + response.Address +  "  Status  " + response.Status + " Time taken is " + response.RoundtripTime);
            }
            Console.ReadLine();
        }

        private static PingReply PingSites(string websiteName)
        {
            Ping ping = new Ping();
            return ping.Send(websiteName);
        }
    }
}
