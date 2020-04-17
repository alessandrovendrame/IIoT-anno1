using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS_20200417_Scrubble
{
    class ScrubbleSolve
    {
        private static String path = Path.Combine(Directory.GetCurrentDirectory(), "zingarelli2005.txt");
        private static StreamReader sr = new StreamReader(path);
        private static String testo = sr.ReadToEnd().ToString();
        private static String[] parole = testo.Split("\n");
        private String[] lettere;
        private int numeroJolly;

        public ScrubbleSolve(String[] lettere, int Jolly)
        {
            this.lettere = lettere;
            numeroJolly = Jolly;
        }

        public List<String> getParole()
        {
            List<String> paroleTrovate = new List<String>();
            char[] lettereParola;
            for (int i = 0; i < parole.Length; i++)
            {
                if(parole[i].Length <= lettere.Length)
                {
                    lettereParola = new char[parole[i].Trim().Length];

                    for (int x = 0; x < lettereParola.Length; x++)
                    {
                        lettereParola[x] = parole[i][x];
                    }

                    if (checkParola(lettereParola))
                    {
                        paroleTrovate.Add(parole[i]);
                    }
                }
                
            }

            return paroleTrovate;
        }

        private bool checkParola(char[] lettereParola)
        {
            bool aggiungi = true;
            bool contains = false;
            int jolly = 0;
            bool[] flagCaselle = new bool[7];
            for (int i = 0; i < lettereParola.Length; i++)
            {
                contains = false;
                for (int j = 0; j < lettere.Length; j++)
                {
                    if (!contains)
                    {
                        if (lettere[j] == lettereParola[i].ToString() && flagCaselle[j]==false)
                        {
                            contains = true;
                            flagCaselle[j] = true;
                        }else if(lettere[j].Equals("*") && jolly <= numeroJolly && flagCaselle[j] == false)
                        {
                            jolly++;
                            contains = true;
                            flagCaselle[j] = true;
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
