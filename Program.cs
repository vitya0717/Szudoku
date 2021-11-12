using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
          
            string[] sorok = File.ReadAllLines("feladvanyok.txt");
            List<Feladvany> sudokuk = new List<Feladvany>();

            foreach (var item in sorok)
            {
                sudokuk.Add(new Feladvany(item));
            }
            
            Console.WriteLine("3.feladat: Beolvasva {0} feladvány \n", sudokuk.Count);


            Console.Write("4.feladat: Kérem a feladvány méretét: ");
            int meret = int.Parse(Console.ReadLine());
            Console.WriteLine();
            List<Feladvany> meretlista = new List<Feladvany>();
            meretlista.Clear();
            int db = 0;

            while (meret < 4 || meret > 9)
            {
                Console.Write("4.feladat: Kérem a feladvány méretét: ");
                meret = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            for (int i = 0; i < sudokuk.Count; i++)
            {
                if (sudokuk[i].Meret == meret)
                {
                    db++;
                    meretlista.Add(sudokuk[i]);

                }
            }
            Console.WriteLine("{0}x{1} Méretű feladványból {2} darab van tárolva.\n", meret, meret, db);

            Random r = new Random();

            int rancsi_szamcsi = r.Next(meret);

            Feladvany kival = meretlista[rancsi_szamcsi];


            Console.WriteLine("5.feladat: A kiválasztott feladvány:\n{0}\n", kival.Kezdo);

            int nulla = 0;
            for (int i = 0; i < kival.Kezdo.Length; i++)
            {
                if (kival.Kezdo[i].ToString() == "0")
                {
                    nulla++;
                }
            }
            double teljes = kival.Kezdo.Length;
            double nulla_nelkul = kival.Kezdo.Length - nulla;

            double hello = nulla_nelkul / teljes * 100;

            Console.WriteLine("6.feladat: A feladvány kitöltöttsége: {0}%\n", Math.Round(hello, 1));

            Console.WriteLine("7.feladat: A feladvány kirajzolva:");
            kival.Kirajzol();
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }

}
