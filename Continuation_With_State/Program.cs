using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continuation_With_State
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<DateTime> task = Task.Run(() => {
                return DoSomething();
            });

            List<Task<DateTime>> continuationTasks = new List<Task<DateTime>>();

            for (int i = 0; i < 3; i++)
            {
                task = task.ContinueWith( (x, y) => {
                     return DoSomething();
                },
                
                new Person { Id = i }

                );

                continuationTasks.Add(task);
            }

            task.Wait();

            foreach (var continuation in continuationTasks)
            {
                Person person = continuation.AsyncState as Person;
                Console.WriteLine("Task finished at {0} and Person id is {1}.", continuation.Result, person.Id);
            }
        }

        private static DateTime DoSomething()
        {
            return DateTime.Now;
        }
    }
}
