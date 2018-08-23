using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoWaySignaling
{
    class Program
    {
        static EventWaitHandle first = new AutoResetEvent(false);
        static EventWaitHandle second = new AutoResetEvent(false);
        static object newmanLock = new object();
        static string value = string.Empty;

        static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);
            Console.WriteLine("Main thread is waiting");
            first.WaitOne();

            lock (newmanLock)
            {
                value = "Updating value in main thread";
                Console.WriteLine(value);
            }

            Thread.Sleep(1000);
            second.Set();
            Console.WriteLine("Released worker thread");
            
        }

        private static void WorkerThread()
        {
            Thread.Sleep(1000);

            lock (newmanLock)
            {
                value = "Updating value in worker thread";
                Console.WriteLine(value);
            }
            first.Set();
            Console.WriteLine("Released main thread");
        }
    }
}
