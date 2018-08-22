using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafety
{
    class Program
    {
        static Dictionary<int, string> items = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(AddItem);
            var task2 = Task.Factory.StartNew(AddItem);
            var task3 = Task.Factory.StartNew(AddItem);
            var task4 = Task.Factory.StartNew(AddItem);
            var task5 = Task.Factory.StartNew(AddItem);
            var task6 = Task.Factory.StartNew(AddItem);

            Task.WaitAll(task1, task2, task3, task4, task5, task6);
        }

        private static void AddItem()
        {
            lock (items)
            {
                Console.WriteLine("Lock acquired by {0}", Task.CurrentId);
                items.Add(items.Count, "newmanuevers" + items.Count);
            }

            Dictionary<int, string> dictionary;
            lock (items)
            {

                Console.WriteLine("Additional lock acquired by  {0}", Task.CurrentId);
                dictionary = items;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("The item key is {0} and the value is {1}", item.Key, item.Value);
            }
        }
    }
}
