using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLocks
{
    class Program
    {
        static object newmanueversLock = new Object();
        static void Main(string[] args)
        {
            lock (newmanueversLock)
            {
                DoSth();
            }

        }

        private static void DoSth()
        {
            lock (newmanueversLock){
                Task.Delay(2000);
                AnotherMethod();
            }
        }

        private static void AnotherMethod()
        {
            lock (newmanueversLock)
            {

            }
        }
    }
}
