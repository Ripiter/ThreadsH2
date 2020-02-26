using System;
using System.Threading;
using ThreadsH2.FlaskeAutomat;

namespace ThreadsH2
{
    class Program
    {
        static readonly object _lock = new object();

        static Producer producer = new Producer();
        static Buffers buffer = new Buffers();
        static Random rnd = new Random(Guid.NewGuid().GetHashCode());
        static bool refresh = true;

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
                    while (refresh == false)
                        Monitor.Wait(_lock);

                    while (buffer.BoatBuffer.BoatIsEmpty())
                        InsertInFreeSpace(buffer.BoatBuffer.BoatLoad, producer.ProduceDrink());

                    refresh = false;
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
                    while (buffer.ColaBuffer.Length == buffer.ColaAvaible && buffer.FantaBuffer.Length == buffer.FantaAvaible)
                        Monitor.Wait(_lock);

                    if (buffer.BoatBuffer.BoatIsEmpty() == false)
                    {
                        if (buffer.ColaBuffer.Length != buffer.ColaAvaible)
                        {
                            Drink temp = buffer.BoatBuffer.ReturnDesiredDrink(TypeOfDrink.Cola);

                            // if temp is null means that boat buffer doesnt have cola
                            // pulse should refresh the boat buffer
                            if (temp == null)
                            {
                                refresh = true;
                                Monitor.PulseAll(_lock);
                            }
                            else
                            {
                                InsertInFreeSpace(buffer.ColaBuffer, temp);
                                buffer.ColaAvaible += 1;
                            }
                        }
                        else if (buffer.FantaBuffer.Length != buffer.FantaAvaible)
                        {
                            Drink temp = buffer.BoatBuffer.ReturnDesiredDrink(TypeOfDrink.Fanta);

                            if (temp == null)
                            {
                                refresh = true;
                                Monitor.PulseAll(_lock);
                            }
                            else
                            {
                                InsertInFreeSpace(buffer.FantaBuffer, temp);
                                buffer.FantaAvaible += 1;
                            }
                        }


                        if (buffer.ColaBuffer.Length == buffer.ColaAvaible && buffer.FantaBuffer.Length == buffer.FantaAvaible)
                            Console.WriteLine("Splited");
                    }
                    else
                    {
                        refresh = true;
                        Monitor.PulseAll(_lock);
                    }
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
            while (true)
            {
                Thread.Sleep(rnd.Next(10000, 15000));
                lock (_lock)
                {
                    while (buffer.ColaAvaible == 0)
                    {
                        Console.WriteLine("Customer wait for cola");
                        Monitor.Wait(_lock);
                    }

                    buffer.ColaBuffer[rnd.Next(0, buffer.ColaBuffer.Length)] = null;
                    Console.WriteLine("Customer have taken cola");
                    buffer.ColaAvaible--;

                    Monitor.PulseAll(_lock);
                }
            }
        }


        static void ConsumeFanta()
        {
            while (true)
            {
                Thread.Sleep(rnd.Next(10000, 15000));
                lock (_lock)
                {
                    while (buffer.FantaAvaible == 0)
                    {
                        Console.WriteLine("Customer wait for fanta");
                        Monitor.Wait(_lock);
                    }

                    buffer.FantaBuffer[rnd.Next(0, buffer.FantaBuffer.Length)] = null;
                    Console.WriteLine("Customer have taken fanta");
                    buffer.FantaAvaible--;

                    Monitor.PulseAll(_lock);
                }
            }
        }
    }
}
