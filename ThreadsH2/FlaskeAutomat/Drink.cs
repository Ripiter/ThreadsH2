using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsH2.FlaskeAutomat
{
    public enum TypeOfDrink
    {
        Cola,
        Fanta
    }

    class Drink
    {
        private TypeOfDrink drinkType;

        public TypeOfDrink DrinkType
        {
            get { return drinkType; }
            set { drinkType = value; }
        }
        


        public Drink()
        {
            Array values = Enum.GetValues(typeof(TypeOfDrink));

            this.DrinkType = (TypeOfDrink)values.GetValue(new Random(Guid.NewGuid().GetHashCode()).Next(values.Length));
        }

        public Drink(TypeOfDrink typeOfDrink)
        {
            this.DrinkType = typeOfDrink;
        }
    }
}
