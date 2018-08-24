using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ_MergeOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 10);

            //var query = from n in list.AsParallel()
            //            .WithMergeOptions(ParallelMergeOptions.FullyBuffered);

             


        }
    }
}
