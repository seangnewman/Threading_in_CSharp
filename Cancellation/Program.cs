using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 10000000).ToArray();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            Console.WriteLine("Press X to cancel");

            Task.Factory.StartNew(()=> {
                if(Console.ReadKey().KeyChar == 'x')
                {
                    cancellationTokenSource.Cancel();
                }
            });

            long total = 0;
            try
            {
                
                Parallel.For <long>(0, 
                                        list.Length, 
                                        parallelOptions, 
                                        () => {
                                            return 0;
                                        }, 
                                        (count, ParallelLoopState, subtotal) => {
                                            //Thread.Sleep(200);
                                            parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                                            subtotal += list[count];
                                            return subtotal;
                                        },
                                        (subtotal) =>
                                        {
                                             Interlocked.Add(ref total, subtotal);
                                        } ) ;


            }
            catch (OperationCanceledException e )
            {
                Console.WriteLine("Cancelled by Sean" + e.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

            Console.WriteLine("The final sum is {0}", total);
            



        }
    }
}
