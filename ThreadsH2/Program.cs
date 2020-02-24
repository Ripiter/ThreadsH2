using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadsH2
{
    class Program
    {
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");

            stopwatch.Start();
            ProcessWithThreadPoolMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();
            Console.WriteLine("Thread Execution");

            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + stopwatch.ElapsedTicks.ToString());

            Console.Read();
        }

        static void ProcessWithThreadPoolMethod()
        {
            ThreadPool.QueueUserWorkItem(Process, "Jorge");
        }

        static void ProcessWithThreadMethod()
        {
            Thread obj = new Thread(Process);
            obj.Start("Hello world");
        }

        static void Process(object callback)
        {
            string msg = (string)callback;
            
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                }
            }
        }
    }
}
