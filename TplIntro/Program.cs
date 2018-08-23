using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Time Taken {0}",stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();

            stopwatch.Start();
            Parallel.For(0, 10, (i) => {
                Console.WriteLine(i);
            });
            Console.WriteLine("Time Taken {0}",stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();


        }
    }
}
