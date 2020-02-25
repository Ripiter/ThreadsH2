using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.Locks
{
    class StarAndHashtag
    {
        //static readonly object _lock = new object();

        //static void Main(string[] args)
        //{
        //    Thread t1 = new Thread(PrintHashtag);
        //    Thread t2 = new Thread(PrintStar);
        //    t1.Start();
        //    t2.Start();
        //}

        //static int numberToPrint = 60;
        //static int currNumber = 0;
        //static bool printingHashtag = true;

        //static void PrintHashtag()
        //{
        //    while (true)
        //        lock (_lock)
        //        {
        //            while (printingHashtag == false)
        //                Monitor.Wait(_lock);

        //            while (numberToPrint > currNumber)
        //            {
        //                Console.Write("#");
        //                currNumber++;
        //            }

        //            printingHashtag = false;

        //            numberToPrint += 60;
        //            Console.Write(currNumber);
        //            Console.WriteLine();
        //            Monitor.PulseAll(_lock);
        //        }
        //}

        //static void PrintStar()
        //{
        //    while (true)
        //        lock (_lock)
        //        {
        //            while (printingHashtag == true)
        //                Monitor.Wait(_lock);

        //            while (numberToPrint > currNumber)
        //            {
        //                Console.Write("*");
        //                currNumber++;
        //            }
        //            printingHashtag = true;

        //            numberToPrint += 60;
        //            Console.Write(currNumber);
        //            Console.WriteLine();
        //            Monitor.PulseAll(_lock);
        //        }
        //}
    }
}
