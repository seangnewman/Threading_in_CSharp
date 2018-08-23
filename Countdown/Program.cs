using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Countdown
{
    
    class Program
    {
        static CountdownEvent newmanCountdown = new CountdownEvent(5);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);

            newmanCountdown.Wait();

            Console.WriteLine("Signal has been called 5 times");
        }

        private static void DoSomething()
        {
            Thread.Sleep(250);
            Console.WriteLine(Task.CurrentId + " is calling signal");
            newmanCountdown.Signal();
        }
    }
}
