using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualReseet
{
   
    class Program
    {
        private static ManualResetEvent newmanEvent = new ManualResetEvent(false);
        //private static EventWaitHandle newman = new EventWaitHandle(false, EventResetMode.ManualReset);
        static void Main(string[] args)
        {
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Thread.Sleep(1000);

            Console.WriteLine("Press a key to release all threads so far");
            Console.ReadKey();

            newmanEvent.Set();

            Thread.Sleep(1000);
            Console.WriteLine("Press a key again.  Threads won't block");

            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Thread.Sleep(1000);

            Console.WriteLine("Press a key tagin.  Threads will block if called waitone ");
            Console.ReadKey();
            newmanEvent.Reset();
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);
            Console.WriteLine("Press a key tagin.  Calls Set() ");
            Console.ReadKey();
            newmanEvent.Set();

            Console.ReadKey();

        }

        private static void CallWaitOne()
        {
            Console.WriteLine(Task.CurrentId + " has called WaitOne");
            newmanEvent.WaitOne();
            Console.WriteLine(Task.CurrentId + " finally ended");
        }
    }
}
