using System;

namespace _20200325
{
    class Program
    {
        static void Main(string[] args)
        {
            Calcolatore calcolatrice;
            Menu myMenu = new Menu();

            int scelta;
            string continua="";
            int num1,num2;

            do{
                Console.Write("Inserisci primo numero: ");
                num1=int.Parse(Console.ReadLine());
                Console.Write("Inserisci secondo numero: ");
                num2=int.Parse(Console.ReadLine());                
                
                calcolatrice=new Calcolatore(num1,num2);

                scelta=myMenu.showMenu();

                while(scelta!=0)
                {
                    switch(scelta){
                        case 0:
                            Console.WriteLine("Sto uscendo...");
                            break;
                        case 1:
                            int somma=calcolatrice.Somma();
                            Console.WriteLine("La somma tra i due numeri è " + somma);
                            break;
                        case 2:
                            int differenza=calcolatrice.Differenza();
                            Console.WriteLine("La differenza tra i due numeri è " + differenza);
                            break;
                        case 3:
                            int prodotto=calcolatrice.Moltiplicazione();
                            Console.WriteLine("Il prodotto tra i due numeri è " + prodotto);
                            break;     
                        case 4:
                            double divisione=calcolatrice.Divisione();
                            Console.WriteLine("La divisione tra i due numeri è " + divisione);
                            break;                  
                    }
                    scelta=myMenu.showMenu();
                }

                Console.Write("Vuoi continuare? <y/n> : ");
                continua = Console.ReadLine();

             }while(continua!="n");
        }
    }

    class Calcolatore{
        private int num1;
        private int num2;

        public Calcolatore(){
            num1=0;
            num2=0;
        }

        public Calcolatore(int n1, int n2)
        {
            num1=n1;
            num2=n2;
        }

        public int Somma(){
            int somma;

            somma=num1+num2;

            return somma;
        }

        public int Differenza(){
            int dif;

            dif=num1-num2;

            return dif;
        }

        public int Moltiplicazione(){
            int molt;

            molt=num1*num2;

            return molt;
        }

        public double Divisione(){
            double div;

            div=num1/num2;

            return div;
        }
    }

    class Menu{

        private int scelta;

        public Menu(){}

        public int showMenu(){
            Console.WriteLine("Menu:");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Somma");
            Console.WriteLine("2. Differenza");
            Console.WriteLine("3. Moltiplicazione");
            Console.WriteLine("4. Divisione");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());

            return scelta;
        }
    }
}
