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
        static int colaAvaible = 0;

        static Drink[] fantaSplit = new Drink[10];
        static int fantaAvaible = 0;

        static Producer producer = new Producer();
        
        static void Main(string[] args)
        {
            Thread addtoboat = new Thread(AddToBoat);
            Thread split = new Thread(Split);
            Thread colaConsumer = new Thread(ConsumeCola);
            Thread fantaConsumer = new Thread(ConsumeFanta);

            addtoboat.Start();
            split.Start();
            colaConsumer.Start();
            fantaConsumer.Start();
        }

        static void AddToBoat()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (boat.BoatLoad.Count == boat.MaxSize)
                        Monitor.Wait(_lock);;
                    
                    while (boat.BoatLoad.Count != boat.MaxSize)
                        boat.BoatLoad.Enqueue(producer.ProduceDrink());
                    
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
                    while (colaSplit.Length == colaAvaible && fantaSplit.Length == fantaAvaible)
                        Monitor.Wait(_lock);

                    if (boat.BoatLoad.Count != 0)
                    {
                        Drink drink = boat.BoatLoad.Dequeue();

                        if (drink.DrinkType == TypeOfDrink.Cola)
                        {
                            if (colaSplit.Length != colaAvaible)
                            {
                                InsertInFreeSpace(colaSplit, drink);
                                colaAvaible += 1;
                            }
                        }
                        else if (drink.DrinkType == TypeOfDrink.Fanta)
                        {
                            if (fantaSplit.Length != fantaAvaible)
                            {
                                InsertInFreeSpace(fantaSplit, drink);
                                fantaAvaible += 1;
                            }
                        }
                        
                        if (colaSplit.Length == colaAvaible && fantaSplit.Length == fantaAvaible)
                            Console.WriteLine("Splited");                     
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
                        Console.WriteLine("Customer wait for cola");
                        Monitor.Wait(_lock);
                    }

                    colaSplit[rnd.Next(0, colaSplit.Length)] = null;
                    Console.WriteLine("Customer have taken cola");
                    colaAvaible--;
                    
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
                        Console.WriteLine("Customer wait for fanta");
                        Monitor.Wait(_lock);
                    }

                    fantaSplit[rnd.Next(0, fantaSplit.Length)] = null;
                    Console.WriteLine("Customer have taken fanta");
                    fantaAvaible--;
                    
                    Monitor.PulseAll(_lock);
                }
                Thread.Sleep(10000);
            }
        }
    }
}
