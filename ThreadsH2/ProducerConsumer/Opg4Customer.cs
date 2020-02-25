using System;

namespace ThreadsH2.ProducerConsumer
{
    class Opg4Customer
    {
    //    static readonly object _lock = new object();

    //    static int[] buffer = new int[3];

    //    static void Main(string[] args)
    //    {

    //        for (int i = 0; i < buffer.Length; i++)
    //        {
    //            buffer[i] = 1;
    //        }

    //        Thread procuder = new Thread(Producer);
    //        Thread customer = new Thread(Customer);
    //        procuder.Start();
    //        customer.Start();
    //    }


    //    static void Producer()
    //    {
    //        while (true)
    //        {
    //            lock (_lock)
    //                for (int i = 0; i < buffer.Length; i++)
    //                {
    //                    if (buffer[i] == 0)
    //                    {
    //                        buffer[i] = 1;
    //                        Console.WriteLine("Procuder replenished");
    //                    }
    //                }
    //            Console.WriteLine("Waiting");
    //        }
    //    }

    //    static void Customer()
    //    {
    //        while (true)
    //            lock (_lock)
    //            {
    //                Random rnd = new Random();
    //                buffer[rnd.Next(0, buffer.Length - 1)] = 0;
    //                Console.WriteLine("Customer have taken");
    //                Thread.Sleep(rnd.Next(1000, 5000));
    //            }

    //    }




    }
}
