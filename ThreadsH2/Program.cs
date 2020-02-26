using System;
using System.Threading;
using ThreadsH2.FlaskeAutomat;

namespace ThreadsH2
{
    class Program
    {
        static readonly object _lock = new object();
        
        static Boat boatBuffer = new Boat(10);

        static Drink[] colaBuffer = new Drink[10];
        static int colaAvaible = 0;

        static Drink[] fantaBuffer = new Drink[10];
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
                    while (boatBuffer.BoatLoad.Count == boatBuffer.MaxSize)
                        Monitor.Wait(_lock);;
                    
                    while (boatBuffer.BoatLoad.Count != boatBuffer.MaxSize)
                        boatBuffer.BoatLoad.Enqueue(producer.ProduceDrink());
                    
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
                    while (colaBuffer.Length == colaAvaible && fantaBuffer.Length == fantaAvaible)
                        Monitor.Wait(_lock);

                    if (boatBuffer.BoatLoad.Count != 0)
                    {
                        // Change Q to array
                        Drink drink = boatBuffer.BoatLoad.Dequeue();

                        if (drink.DrinkType == TypeOfDrink.Cola)
                        {
                            if (colaBuffer.Length != colaAvaible)
                            {
                                InsertInFreeSpace(colaBuffer, drink);
                                colaAvaible += 1;
                            }
                        }
                        else if (drink.DrinkType == TypeOfDrink.Fanta)
                        {
                            if (fantaBuffer.Length != fantaAvaible)
                            {
                                InsertInFreeSpace(fantaBuffer, drink);
                                fantaAvaible += 1;
                            }
                        }
                        
                        if (colaBuffer.Length == colaAvaible && fantaBuffer.Length == fantaAvaible)
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

                    colaBuffer[rnd.Next(0, colaBuffer.Length)] = null;
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

                    fantaBuffer[rnd.Next(0, fantaBuffer.Length)] = null;
                    Console.WriteLine("Customer have taken fanta");
                    fantaAvaible--;
                    
                    Monitor.PulseAll(_lock);
                }
                Thread.Sleep(10000);
            }
        }
    }
}
