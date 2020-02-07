using System;

namespace _20202901
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("Inserisci un numero in binario: ");

            string s = Console.ReadLine();

            int result =0;

            for(int i=0, a=s.Length-1; i<s.Length; i++, a--)
            {
                int power =(int)Math.Pow(2,i);
                Console.WriteLine(power);
                Console.WriteLine("s["+a+"] = " + s[a]);
                int aux=int.Parse(s[a].ToString());
                Console.WriteLine("aux="+aux);
                int prova=aux*power;
                result=result+prova;                
            }

            Console.WriteLine("Il tuo numero in binario è: " + s);
            Console.WriteLine("Il tuo numero in decimale è: " + result);
            */

            //ESERCIZIO 2
            /*Console.Write("Inserisci la stringa: ");

            string s= Console.ReadLine();
            string sol="";

            for(int i=s.Length-1;i>=0;i--)
            {
                sol=sol+s[i];
            }

            Console.WriteLine("La tua stringa è: "+s);
            Console.WriteLine("La stringa capovolta e: "+sol);*/

            int scelta=0;

            do{
                scelta=Menu();

                switch(scelta)
                {
                    case 0:
                        Console.WriteLine("Addio");
                        break;
                    case 1:
                        Console.Write("Inserisci la lunghezza del raggio: ");
                        int r=int.Parse(Console.ReadLine());
                        Console.WriteLine("L'area del cerchio risulta: " + AreaCerchio(r));
                        break;
                    case 2:
                        Console.Write("Inserisci lunghezza della base: ");
                        int b=int.Parse(Console.ReadLine());
                        Console.Write("Inserisci lunghezza dell'altezza: ");
                        int a=int.Parse(Console.ReadLine());
                        Console.WriteLine("L'area del rettangolo risulta: " + AreaRettangolo(b,a));
                        break;
                    case 3:
                        Console.Write("Inserisci lunghezza della base: ");
                        int ba=int.Parse(Console.ReadLine());
                        Console.Write("Inserisci lunghezza dell'altezza: ");
                        int al=int.Parse(Console.ReadLine());
                        Console.WriteLine("L'area del rettangolo risulta: " + AreaTriangolo(ba,al));
                        break;
                }
            }while(scelta!=0);

        }

        static int Menu()
        {
            Console.WriteLine("[0] - Esci ");
            Console.WriteLine("[1] - Calcola area cerchio.");
            Console.WriteLine("[2] - Calcola area rettangolo.");
            Console.WriteLine("[3] - Calcola area Triangolo.");
            Console.Write("Scelta: ");
            int s = int.Parse(Console.ReadLine());

            return s;
        }

        static double AreaCerchio(int raggio)
        {
            double result=Math.PI*((int)Math.Pow(raggio,2));
            return  result;
        }

        static double AreaRettangolo(int b,int a)
        {
            double result=b*a;
            return result;
        }

        static double AreaTriangolo(int b,int a)
        {
            double result=(b*a)/2;
            return result;
        }
    }
}
