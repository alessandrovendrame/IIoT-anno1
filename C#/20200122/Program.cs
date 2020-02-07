using System;

namespace _20202201
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRIMO ESERCIZIO

            /*Console.Write("Inserisci il numero di elementi da archiviare nell'array: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci " + num + " elementi dell'array: ");
            int [] v = new int [num];
            for(int i=0; i<num; i++)
            {
                Console.Write("Elemento - " + i + ": ");
                v[i]=int.Parse(Console.ReadLine());
            }
            
            Console.WriteLine("I valori memorizzati nell'array sono: ");
            for(int i=0; i<num; i++)
            {
                Console.Write(v[i]+ " ");
            }
            Console.WriteLine("\nI valori nell' array letti al contrario sono: ");
            for(int i=num-1; i>=0; i--)
            {
                Console.Write(v[i]+ " ");
            }9*/

            //SECONDO ESERCIZIO

            /*Console.Write("Inserisci il numero di elementi da archiviare nell'array: ");
            int num = int.Parse(Console.ReadLine());
            int num2 = 2*num;
            Console.WriteLine("Inserisci " + num + " elementi dell'array: ");
            int [] v = new int [num];
            int [] v2 = new int [num2];
            int j=num-1;
            for(int i=0; i<num; i++)
            {
                Console.Write("Elemento - " + i + ": ");
                v[i]=int.Parse(Console.ReadLine());
            }
            for(int i=0; i<num; i++)
            {
                v2[i]=v[i];
            }
            for(int i=num; i<num2;i++)
            {                
                v2[i]=v[j];
                j--;
            }
            Console.WriteLine("L'array che ho generato è: ");
            for(int i=0;i<num2;i++)
            {
                Console.Write(v2[i] + " ");
            }*/

            //TERZO ESERCIZIO

            /*Console.Write("Inserisci il numero di elementi da archiviare nell'array: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci " + num + " elementi dell'array: ");
            bool conta=false;
            int [] v = new int [num];
            int [] v2 = new int [num];
            int j=0;
            for(int i=0; i<num; i++)
            {
                Console.Write("Elemento - " + i + ": ");
                v[i]=int.Parse(Console.ReadLine());
            }

            for(int i=0; i<num; i++)
            {
                conta=false;
                for(int k=0;k<num;k++)
                {
                    if(k!=i)
                    {
                        if(v[i]==v[k])
                        {
                            conta=true;
                            break;
                        }
                    }
                }
                if(conta==false)
                {
                    v2[j]=v[i];
                    j++;
                }

            }

            Console.WriteLine("I numeri inseriti una volta sola sono: ");

            for(int i=0;i<j;i++)
            {
                Console.Write(v2[i] + " ");
            }*/

            //QUARTO ESERCIZIO

            //bool conta=false;
            int j=0;
            //int minimo=100000;

            Console.Write("Inserisci il numero di elementi da archiviare nell primo array: ");
            int num = int.Parse(Console.ReadLine());
            int [] v = new int [num];
            
            Console.WriteLine("Inserisci " + num + " elementi dell'array: ");
            for(int i=0; i<num; i++)
            {
                Console.Write("Elemento - " + i + ": ");
                v[i]=int.Parse(Console.ReadLine());
            }

            Console.Write("Inserisci il numero di elementi da archiviare nell secondo array: ");
            int num2 = int.Parse(Console.ReadLine());
            int num3=num+num2;
            int [] v2 = new int [num2];
            int [] v3 = new int [num3];

            Console.WriteLine("Inserisci " + num2 + " elementi dell'array: ");
            for(int i=0; i<num2; i++)
            {
                Console.Write("Elemento - " + i + ": ");
                v2[i]=int.Parse(Console.ReadLine());
            }

            for(int i=0; i<num; i++)
            {
                v3[i]=v[i];
            }
            for(int i=num; i<num3; i++)
            {
                v3[i]=v2[j];
                j++;
            }

            /*for (int i = 0; i < num3-1; i++)  
            {  
                // Find the minimum element in unsorted array  
                int min_idx = i;  
                for (int k = i+1; k < num3; k++)  
                    if (v3[j] < v3[min_idx])  
                        min_idx = k;  
                // Swap the found minimum element with the first element  

                int temp = v3[min_idx] ;  
                v3[min_idx] = v3[i];  
                v3[i] = temp;  
            }*/

            Array.Sort(v3);  

            Console.WriteLine("I numeri in ordine sono: ");
            for(int i=0;i<num3;i++)
            {
                Console.Write(v3[i] + " ");
            }
        }
    }
}

