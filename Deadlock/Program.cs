using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlock
{
    class Program
    {
        
        static void Main(string[] args)
        {
            object newmanueversLock = new object();
            object newmanueversLock2 = new object();

            new Thread( () => {
            lock (newmanueversLock){
                    Console.WriteLine("newmanuverslock obtained");
                    Thread.Sleep(2000);
                    lock (newmanueversLock2)
                    {
                        Console.WriteLine("newmanueverslock2 obtained");
                    }
                }
            }).Start();

            lock (newmanueversLock2)
            {
                Console.WriteLine("Main thread obtained newmanueverslock2");
                Thread.Sleep(1000);
                lock (newmanueversLock)
                {
                    Console.WriteLine("Main thread obtained newmanueverslock");
                }
            }
        }
    }
}
