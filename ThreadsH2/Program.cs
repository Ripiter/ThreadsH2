using System;
using System.Threading;

namespace ThreadsH2
{
    class Program
    {
        static char charPrint = '*';

        static void Main(string[] args)
        {
            Thread printer = new Thread(Print);
            Thread reader = new Thread(Reader);
            printer.Start();
            reader.Start();

        }

        static void Reader()
        {
            while (true)
            {
                char charTemp = Console.ReadKey().KeyChar;
                Console.ReadLine();

                charPrint = charTemp;
            }
        }

        

        static void Print()
        {
            while (true)
            {
                Console.Write(charPrint);
                Thread.Sleep(10);
            }
        }

    }
}
