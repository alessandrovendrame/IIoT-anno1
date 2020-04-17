using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS_20200417_Scrubble
{
    class WordUtilities
    {
        char[] frase;
        int Numerojolly = 1;
        public WordUtilities(char[] frase)
        {
            this.frase = frase;
        }
        public List<string> readFile()
        {
            String path = Path.Combine(Directory.GetCurrentDirectory(), "zingarelli2005.txt");
            StreamReader sr = new StreamReader(path);
            String testo = sr.ReadToEnd().ToString();
            String[] paroleDizionario = testo.Split("\n");
            char[] lettereParola;
            List<String> paroleTrovate = new List<String>();
            for (int i = 0; i < paroleDizionario.Length; i++)
            {
                if (paroleDizionario[i].Length >= frase.Length - 1)
                {
                    lettereParola = new char[paroleDizionario[i].Trim().Length];

                    for (int x = 0; x < lettereParola.Length; x++)
                    {
                        lettereParola[x] = paroleDizionario[i][x];
                    }
                    if (checkParola(lettereParola))
                    {
                        paroleTrovate.Add(paroleDizionario[i]);
                    }
                }
            }
            return paroleTrovate;
        }
        private bool checkParola(char[] lettereParola)
        {
            bool[] flagCaselle = new bool[7];
            bool aggiungi = true;
            bool contains = false;
            int jolly = 0;
            for (int i = 0; i < lettereParola.Length; i++)
            {
                contains = false;
                for (int j = 0; j < frase.Length; j++)
                {
                    if (!contains)
                    {
                        if (frase[j] == lettereParola[i] && flagCaselle[j] == false)
                        {
                            flagCaselle[j] = true;
                            contains = true;
                        }
                        else if (frase[j] == '*' && jolly < Numerojolly && flagCaselle[j] == false)
                        {
                            contains = true;
                            flagCaselle[j] = true;
                            jolly++;
                        }
                    }
                }
                if (!contains)
                {
                    aggiungi = false;
                    return aggiungi;
                }
            }

            return aggiungi;
        }
    }
}

