using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.ProducerConsumer
{
    class Opg5Cusumer
    {
        //static readonly object _lock = new object();

        //static int[] buffer = new int[3];
        //static bool customerTake = false;

        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < buffer.Length; i++)
        //        buffer[i] = 1;

        //    Thread procuder = new Thread(Producer);
        //    Thread customer = new Thread(Customer);
        //    procuder.Start();
        //    customer.Start();
        //}

        //static void Producer()
        //{
        //    while (true)
        //    {
        //        lock (_lock)
        //        {
        //            while (customerTake == false)
        //            {
        //                Console.WriteLine("Waiting");
        //                Monitor.Wait(_lock);
        //            }

        //            for (int i = 0; i < buffer.Length; i++)
        //            {
        //                if (buffer[i] == 0)
        //                {
        //                    buffer[i] = 1;
        //                    Console.WriteLine("Procuder replenished");
        //                }
        //            }
        //            customerTake = false;
        //        }
        //    }
        //}

        //static void Customer()
        //{
        //    Random rnd = new Random();
        //    while (true)
        //    {
        //        lock (_lock)
        //        {
        //            buffer[rnd.Next(0, buffer.Length - 1)] = 0;
        //            Console.WriteLine("Customer have taken");
        //            customerTake = true;
        //            Monitor.PulseAll(_lock);
        //        }
        //        Thread.Sleep(rnd.Next(1000, 5000));
        //    }
        //}
    }
}
