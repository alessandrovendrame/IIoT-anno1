﻿using System;

namespace _20200205
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------ESERCIZIO 1-------------------
            /*
            Console.Write("Inserisci la stringa: ");
            string s = Console.ReadLine();

            Console.WriteLine(s + " contiene " + contaSpazi(s) + " spazi.");
            */

            //----------------ESERCIZIO 2------------------
            /*
            Console.Write("Inserisci la stringa: ");
            string s = Console.ReadLine();

            if(palindromo(s))
            {
                Console.WriteLine("La stringa " + s + " è palindroma.");
            }else
            {
                Console.WriteLine("La stringa " + s + " non è palindroma.");
            }
            */

            //ESERCIZIO 3
            /*
            Console.Write("Inserisci il numero di subnet: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("La subnet-mask con numero " + n + " è " + calcolaSubnet(n));
            */

            //ESERCIZIO 4

            Console.Write("Inserisci l'indirizzo ip: ");
            string ip = Console.ReadLine();
            Console.Write("Inserisci la subnet-mask: ");
            int subnet = int.Parse(Console.ReadLine());

            calcolaIndirizzoRete(ip,subnet);
        }

        static int contaSpazi(string s)
        {
            return s.Split(" ").Length-1;
        }

        static bool palindromo(string s)
        {
            string aux="";

            for (int i = s.Length-1; i >= 0; i--)
            {
                aux = aux+s[i];
            }

            if(s.Equals(aux))
                return true;
            else
                return false;
        }

        static string calcolaSubnet(int n)
        {
            string s="";
            int bit=1;

            for(int i=0;i<4;i++)
            {
                double aux=0;
                for(int j=7;j>=0;j--)
                {
                    if(bit<=n)
                    {
                        aux=aux+Math.Pow(2,j);
                    }
                    bit++;
                }
                s=s+aux.ToString();
                if(i!=3)
                    s+=".";
            }

            return s;
        }

        static void calcolaIndirizzoRete(string s , int n)
        {
            string sub = calcolaSubnet(n);

            int networkAdd = 0;
            string [] subnet = sub.Split(".");
            string[] ip = s.Split(".");
            string ipAddress="";
            string broadcast="";
            int stop=0;

            int magicNumber=0;
            
            for (int i = 0; i < 4; i++)
            {
                if(!(subnet[i].Equals("255")))
                {
                    magicNumber=256-int.Parse(subnet[i]);
                    stop=i;
                    break;
                }
                
            }

            for (int i = 0; i <= 255;i+=magicNumber)
            {
                if(i+magicNumber>int.Parse(ip[stop]))
                {
                      networkAdd=i;
                      break; 
                }
            }

            for (int i = 0; i<stop; i++)
            {
                Console.WriteLine("SONO DENTRO");
                ipAddress+=ip[i]+".";
                broadcast+=ip[i]+".";
            }

            if(stop==3)
            {
                ipAddress+=networkAdd;
                Console.WriteLine("L' indirizzo di rete è " + ipAddress);
                int aux = networkAdd+magicNumber-1;
                broadcast+=aux;
                Console.WriteLine("L' indirizzo di broadcast è " + broadcast);
            }else
            {
                    if(stop==2)
                    {
                        ipAddress+=networkAdd+".0";                    
                        broadcast+=networkAdd+magicNumber-1 + ".255"; 
                    }else if(stop==1)
                    {
                        ipAddress+=networkAdd+".0.0";
                        broadcast+=networkAdd+magicNumber-1 + ".255.255";
                    }
                                       
                }

                Console.WriteLine("L' indirizzo di rete è " + ipAddress);
                Console.WriteLine("L' indirizzo di broadcast è " + broadcast);
                
            }
        }
    }
