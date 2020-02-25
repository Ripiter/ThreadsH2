using System;
using System.Threading;
using ThreadsH2.FlaskeAutomat;

namespace ThreadsH2
{
    class Program
    {
        static readonly object _lock = new object();

        static Boat boat = new Boat(10);
        static Drink[] colaSplit = new Drink[10];
        static Drink[] fantaSplit = new Drink[10];

        static Producer producer = new Producer();


        static bool shouldSplit = false;

        static void Main(string[] args)
        {
            Thread boatT = new Thread(AddToBoat);
            boatT.Start();
        }

        static void AddToBoat()
        {
            while (true)
            {
                lock (_lock)
                {
                    if (boat.BoatLoad.Count < boat.MaxSize)
                        boat.BoatLoad.Enqueue(producer.ProduceDrink());
                }
            }
        }


        static void Split()
        {
            while (true)
            {
                lock (_lock)
                {
                    if(shouldSplit == true)
                    {
                        //Split to arrays
                    }
                }
            }
        }

        static void Consume()
        {
            while (true)
            {
                lock (_lock)
                {
                    //Consume here
                }
            }
        }





    }
}
