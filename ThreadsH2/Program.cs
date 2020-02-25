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
        static int colaAvaible = colaSplit.Length;
        static Drink[] fantaSplit = new Drink[10];
        static int fantaAvaible = fantaSplit.Length;

        static Producer producer = new Producer();


        static bool shouldSplit = false;

        static void Main(string[] args)
        {
            Thread addtoboat = new Thread(AddToBoat);
            Thread split = new Thread(Split);
            Thread colaconsumer = new Thread(ConsumeCola);
            addtoboat.Start();
            split.Start();
            colaconsumer.Start();
        }

        static void AddToBoat()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (boat.BoatLoad.Count == boat.MaxSize)
                        Monitor.Wait(_lock);

                    while (boat.BoatLoad.Count < boat.MaxSize)
                        boat.BoatLoad.Enqueue(producer.ProduceDrink());

                    Console.WriteLine("Added");

                    Monitor.PulseAll(_lock);

                }
            }
        }


        static void Split()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (shouldSplit == false)
                        Monitor.Wait(_lock);

                    if (boat.BoatLoad.Count != 0)
                    {
                        Console.WriteLine("Splited");
                        Drink drink = boat.BoatLoad.Peek();

                        if (drink.DrinkType == TypeOfDrink.Cola)
                        {
                            while (colaSplit.Length != colaAvaible)
                            {
                                InsertInFreeSpace(colaSplit, boat.BoatLoad.Dequeue());
                                colaAvaible++;
                            }
                        }
                        else if (drink.DrinkType == TypeOfDrink.Fanta)
                        {
                            while (fantaSplit.Length != fantaAvaible)
                            {
                                InsertInFreeSpace(fantaSplit, boat.BoatLoad.Dequeue());
                                fantaAvaible++;
                            }
                        }

                        if (colaSplit.Length == colaAvaible && fantaSplit.Length == fantaAvaible)
                            shouldSplit = false;

                    }
                    else
                        Monitor.PulseAll(_lock);
                }
            }
        }


        static void InsertInFreeSpace(Drink[] drinks, Drink drink)
        {
            for (int i = 0; i < drinks.Length; i++)
            {
                if (drinks[i] == null)
                {
                    drinks[i] = drink;
                    return;
                }
            }
        }

        static void ConsumeCola()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                lock (_lock)
                {
                    while (colaAvaible == 0)
                    {
                        Console.WriteLine("Customer wait");
                        Monitor.Wait(_lock);
                    }

                    colaSplit[rnd.Next(0, colaSplit.Length)] = null;
                    Console.WriteLine("Customer have taken cola");
                    colaAvaible--;
                    shouldSplit = true;

                    Monitor.PulseAll(_lock);
                }
                Thread.Sleep(10000);
            }
        }
        static void ConsumeFanta()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                lock (_lock)
                {
                    while (fantaAvaible == 0)
                    {
                        Console.WriteLine("Customer wait");
                        Monitor.Wait(_lock);
                    }

                    fantaSplit[rnd.Next(0, fantaSplit.Length)] = null;
                    Console.WriteLine("Customer have taken cola");
                    fantaAvaible--;
                    shouldSplit = true;

                    Monitor.PulseAll(_lock);
                }
                Thread.Sleep(10000);
            }

        }





    }
}
