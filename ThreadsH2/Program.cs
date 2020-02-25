using System;
using System.Threading;

namespace ThreadsH2
{
    class Program
    {
        static readonly object _lock = new object();

        static int[] buffer = new int[3];
        static int amountAvaible = buffer.Length;

        static void Main(string[] args)
        {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = 1;

            Thread procuder = new Thread(Producer);
            Thread customer = new Thread(Customer);
            procuder.Start();
            customer.Start();
        }

        static void Producer()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (amountAvaible == buffer.Length)
                    {
                        Console.WriteLine("Procuder waiting");
                        Monitor.Wait(_lock);
                    }

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (buffer[i] == 0)
                        {
                            buffer[i] = 1;
                            Console.WriteLine("Procuder replenished");
                        }
                    }
                    amountAvaible = buffer.Length;

                    Monitor.PulseAll(_lock);
                }
            }
        }

        static void Customer()
        {
            Random rnd = new Random();
            while (true)
            {
                lock (_lock)
                {

                    while (amountAvaible == 0)
                    {
                        Console.WriteLine("Customer wait");
                        Monitor.Wait(_lock);
                    }

                    buffer[rnd.Next(0, buffer.Length - 1)] = 0;
                    Console.WriteLine("Customer have taken");
                    amountAvaible--;
                    Monitor.PulseAll(_lock);
                }
                //Thread.Sleep(rnd.Next(1000, 5000));
            }
        }
    }
}
