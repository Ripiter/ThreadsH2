using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.FlaskeAutomat
{
    class Buffers
    {
        Boat boatBuffer = new Boat(10);

        Drink[] colaBuffer = new Drink[10];
        int colaAvaible = 0;

        Drink[] fantaBuffer = new Drink[10];
        int fantaAvaible = 0;

        public int ColaAvaible { get => colaAvaible; set => colaAvaible = value; }
        public int FantaAvaible { get => fantaAvaible; set => fantaAvaible = value; }
        internal Boat BoatBuffer { get => boatBuffer; set => boatBuffer = value; }
        internal Drink[] ColaBuffer { get => colaBuffer; set => colaBuffer = value; }
        internal Drink[] FantaBuffer { get => fantaBuffer; set => fantaBuffer = value; }
    }
}
