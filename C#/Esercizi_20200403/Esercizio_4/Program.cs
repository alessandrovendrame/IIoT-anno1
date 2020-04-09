using System;
using System.IO;

namespace Esercizio_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Esercizio\File_es4.dat";

            var file = File.Create(path);
            file.Close();

            BinaryWriter bw = new BinaryWriter(File.Open(path,FileMode.Create));
            bw.Write("Ciao sono la stringa scritta in binario");
            bw.Close();

            BinaryReader br = new BinaryReader(File.Open(path,FileMode.Open));
            string testo = br.ReadString();
            br.Close();

            Console.WriteLine("Nel file c'era scritto: " + testo);
        }
    }
}
