using System;
using System.Drawing;

namespace CS_20200408
{
    class Program
    {
        static void Main(string[] args)
        {
            //Esercizio 1
            Menu myMenu = new Menu();
            Draw drawer = new Draw();
            string path = @"C:\Users\Alessandro Vendrame\Desktop\Scuola\IIoT-anno1\C#_bitmaps\bitmap.bmp";

            int partenzax=0;
            int partenzay=0;
            int maxy=0;

            Console.Write("Inserisci altezza bitmap: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Inserisci larghezza bitmap:");
            int width = int.Parse(Console.ReadLine());

            Bitmap bitmap = new Bitmap(width,height);

            int scelta=myMenu.showMenu();

                while(scelta!=0)
                {
                    switch(scelta){
                        case 0:
                            Console.WriteLine("Sto uscendo...");
                            break;
                        case 1:
                            Console.Write("Inserisci altezza rettangolo da disegnare: ");
                            int altezza = int.Parse(Console.ReadLine());
                            Console.Write("Inserisci lunghezza rettangolo da disegnare: ");
                            int lunghezza = int.Parse(Console.ReadLine());
                            if((partenzax+lunghezza)>=width){
                                if((maxy+altezza)>=height){
                                    Console.WriteLine("Il foglio è pieno!");
                                    break;
                                }else{
                                    partenzay=maxy;
                                    partenzax=0;
                                    drawer.drawContorno(bitmap,altezza,lunghezza,partenzax,partenzay);
                                    partenzax+=lunghezza+10;
                                }
                            }else{
                                if(maxy<(partenzay+altezza+10))
                                     maxy=partenzay+altezza+10;
                                     Console.WriteLine("maxy="+maxy);
                                drawer.drawContorno(bitmap,altezza,lunghezza,partenzax,partenzay);
                                partenzax+=lunghezza+10; 
                            }
                            break;
                        case 2:
                            Console.Write("Inserisci altezza rettangolo da disegnare: ");
                            int h = int.Parse(Console.ReadLine());
                            Console.Write("Inserisci lunghezza rettangolo da disegnare: ");
                            int l = int.Parse(Console.ReadLine());
                            drawer.drawRectangle(bitmap,h,l,partenzax);
                            partenzax+=l+10;
                            break;
                        case 3:
                        //W.I.P.
                            int sceltaf = myMenu.showFigure();  
                            while(sceltaf!=0){
                                switch(sceltaf){
                                    case 0:
                                        Console.WriteLine("Non hai scelto nessuna figura!");
                                        break;
                                    case 1:
                                        Console.WriteLine("Inserisci base rettangolo: ");
                                        int baser = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Inserisci altezza rettangolo: ");
                                        int altezzar = int.Parse(Console.ReadLine());
                                        drawer.drawFigureRectangle(bitmap,partenzax,baser,altezzar);
                                        partenzax+=baser+10;
                                        break;
                                    case 2:
                                        Console.WriteLine("Inserisci lunghezza lato del quadrato: ");
                                        int lato = int.Parse(Console.ReadLine());
                                        drawer.drawFigureSquare(bitmap,partenzax,lato);
                                        partenzax+=lato+10;
                                        break;
                                    case 3:
                                        Console.WriteLine("Inserisci valore raggio: ");
                                        int raggio = int.Parse(Console.ReadLine());
                                        drawer.drawFigureCircle(bitmap,partenzax,raggio);
                                        partenzax+=raggio+10;
                                        break;
                                    default:
                                        Console.WriteLine("Inserisci un numero tra quelli proposti!");
                                        break;
                                }
                                sceltaf=myMenu.showFigure();
                            }
                            break;     
                        case 4:
                            drawer.saveImage(path,bitmap);
                            break;
                        default:
                            Console.WriteLine("Inserisci un valore valido!!");
                            break;               
                    }
                    scelta=myMenu.showMenu();
                }            

        }
    }
}
