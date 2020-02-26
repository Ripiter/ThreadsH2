namespace ThreadsH2.FlaskeAutomat
{
    class Boat
    {
        private Drink[] boatLoad;
        private int maxSize;

        internal Drink[] BoatLoad { get => boatLoad; set => boatLoad = value; }
        public int MaxSize { get => maxSize; set => maxSize = value; }

        public Boat(int size)
        {
            MaxSize = size;
            BoatLoad = new Drink[MaxSize];
        }


        public Drink ReturnDesiredDrink(TypeOfDrink type)
        {
            Drink drink = null;
            for (int i = 0; i < BoatLoad.Length; i++)
            {
                if (BoatLoad[i] != null)
                    if (BoatLoad[i].DrinkType == type)
                    {
                        if (drink == null)
                        {
                            drink = BoatLoad[i];
                            BoatLoad[i] = null;
                        }
                    }
            }

            return drink;
        }


        public bool BoatIsEmpty()
        {
            bool empty = false;

            for (int i = 0; i < BoatLoad.Length; i++)
            {
                if (boatLoad[i] == null)
                    empty = true;
            }

            return empty;
        }


        public int BoatSpaceTaken()
        {
            int temp = 0;
            for (int i = 0; i < BoatLoad.Length; i++)
            {
                if (BoatLoad[i] != null)
                    temp++;
            }
            return temp;
        }
    }
}
