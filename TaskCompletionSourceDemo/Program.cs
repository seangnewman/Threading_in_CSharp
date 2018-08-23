using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSourceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCompletionSource<Product> taskCompletionSource = new TaskCompletionSource<Product>();

            Task<Product> lazyTask = taskCompletionSource.Task;

            Task.Factory.StartNew( () => {
                Thread.Sleep(2000);
                taskCompletionSource.SetResult(new Product { Id=1, Model="Lightning"});
            });

            Task.Factory.StartNew( () => {
                if(Console.ReadKey().KeyChar == 'x')
                {
                    Product result = lazyTask.Result;
                    Console.WriteLine("\nThe Result of the task is {0}", result.Model);
                }
            });

            Thread.Sleep(2000);
            Console.ReadLine();
        }
    }
}
