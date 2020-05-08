using System;

namespace CS_20200422_Esercizio
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrello carr = new Carrello();
            bool execution = true;


            while (execution)
            {


                Console.WriteLine("Seleziona un'opzione");
                Console.WriteLine("1 - Inserisci un prodotto");
                Console.WriteLine("2 - Mostra carrello");
                Console.WriteLine("3 - Mostra totale");

                var select = int.Parse(Console.ReadLine());


                switch (select)
                {
                    case 1:
                        Console.WriteLine("Inserisci il prodotto");
                        Console.WriteLine("1 - Mela");
                        Console.WriteLine("2 - Pera");
                        Console.WriteLine("3 - Banana");
                        
                        int frutto = int.Parse(Console.ReadLine());
                        if (frutto == 1)
                        {
                            Console.WriteLine("Quante mele vuoi?");
                            int qty = int.Parse(Console.ReadLine());
                            carr.AddItem(new Apple(qty));

                        }
                        if (frutto == 2)
                        {
                            Console.WriteLine("Quante pere vuoi?");
                            int qty = int.Parse(Console.ReadLine());
                            carr.AddItem(new Pear(qty));

                        }
                        if (frutto == 3)
                        {
                            Console.WriteLine("Quante banane vuoi?");
                            int qty = int.Parse(Console.ReadLine());
                            carr.AddItem(new Banana(qty));

                        }
                        Console.WriteLine("Vuoi inserire un altro alimento? Y/N");
                        var ans = Console.ReadLine();
                        if (ans == "y")
                        {
                            goto case 1;
                        }
                        else
                        {
                            break;
                        }

                    case 2:
                        carr.ShowCart();
                        break;

                    case 3:
                        carr.ShowTotal();
                        break;

                    default:
                        execution = false;
                        break;
                }
            }
        }
    }
}
