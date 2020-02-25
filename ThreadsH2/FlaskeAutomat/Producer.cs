using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.FlaskeAutomat
{
    class Producer
    {
        public Producer() { }

        public Drink ProduceDrink()
        {
            return new Drink();
        }

        public Drink ProduceDrink(TypeOfDrink typeOfDrink)
        {
            return new Drink(typeOfDrink);
        }
    }
}
