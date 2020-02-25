using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2
{
    class Threadpool
    {


        //static void Main(string[] args)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    Console.WriteLine("Thread Execution");

        //    stopwatch.Start();
        //    // This method takes longer cuz its creates new object of thread
        //    // without creating the tread in the method the method seeed is the same
        //    ProcessWithThreadMethod();
        //    stopwatch.Stop();

        //    Console.WriteLine("thread " + stopwatch.ElapsedTicks);


        //    stopwatch.Reset();
        //    Console.WriteLine("Thread Pool Execution");

        //    stopwatch.Start();
        //    ProcessWithThreadPoolMethod();
        //    stopwatch.Stop();

        //    Console.WriteLine("pool " + stopwatch.ElapsedTicks);


        //    Console.Read();
        //}

        //static void ProcessWithThreadPoolMethod()
        //{
        //    ThreadPool.QueueUserWorkItem(Process, "threadpool");
        //}

        //static void ProcessWithThreadMethod()
        //{
        //    Thread obj = new Thread(Process);
        //    obj.Start("Thread");
        //}


        //static void Process(object callback)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    string msg = (string)callback;

        //    //Get speed of the tread
        //    stopwatch.Start();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            //if(msg != string.Empty)
        //            //    Console.WriteLine(msg);
        //        }
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine("Thread with name: " + msg + " ended with time: " + stopwatch.ElapsedTicks.ToString());
        //}
    }
}
