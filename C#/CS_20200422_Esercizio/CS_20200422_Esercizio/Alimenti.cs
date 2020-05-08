using System;
using System.Collections.Generic;
using System.Text;

namespace CS_20200422_Esercizio
{
    class Alimenti
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public Alimenti()
        {

        }

    }
    class Apple : Alimenti
    {
        public Apple(int quantity) : base()
        {
            Description = "Mela";

            Price = 0.50;
            Quantity = quantity;
        }


    }

    class Pear : Alimenti
    {
        public Pear(int quantity) : base()
        {
            Description = "Pera";
            Quantity = quantity;
            Price = 0.70;

        }
    }

    class Banana : Alimenti
    {
        public Banana(int quantity) : base()
        {
            Description = "Banana";
            Quantity = quantity;
            Price = 0.30;

        }
    }
}
