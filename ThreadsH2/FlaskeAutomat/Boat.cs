using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.FlaskeAutomat
{
    class Boat
    {
        private Queue<Drink> boatLoad = new Queue<Drink>();
        private int maxSize;

        internal Queue<Drink> BoatLoad { get => boatLoad; set => boatLoad = value; }
        public int MaxSize { get => maxSize; set => maxSize = value; }

        public Boat(int size)
        {
            MaxSize = size;
        }
        
    }
}
