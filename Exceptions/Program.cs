using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo();
        }

        private static void Demo()
        {
            try
            {

                new Thread(Execute).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Execute()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Example {0}",ex.Message);
            }
        }
    }
}
