using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    class Program
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(EnterSemaphoer).Start(i + 1);

            }
        }

        private static void EnterSemaphoer(object id)
        {
            Console.WriteLine("{0} is waiting to be part of the club", id);
            semaphoreSlim.Wait();
            Console.WriteLine("{0} is part of the club", id);
            Thread.Sleep(1000 / (int)id);
            Console.WriteLine("{0} has left the club", id);
        }
    }
}
