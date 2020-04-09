using System;
using System.IO;

namespace Esercizio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Esercizio\Prova.txt";
            string text = File.ReadAllText(path);

            string[] s = text.Split(new Char[] {' ', '\n' , '\t'});

            int count = 0;
            int index = 0;

            for(int i=0;i<s.Length;i++){
                if(s[i].Length>count){
                    count=s[i].Length;
                    index = i;
                }
            }

            Console.WriteLine("La parola più lunga è " + s[index]);
        }
    }
}
