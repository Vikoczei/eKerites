using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kerites
{
    class Program
    {

        class Telek
        {
            public string paritas;
            public int szelesseg;
            public string szin;
            public int hazszam;

            public static int paros = 0;
            public static int paratlan = -1;


            public static List<Telek> lista = new List<Telek>();
            public static List<Telek> paros_lista = new List<Telek>();
            public static List<Telek> paratlan_lista = new List<Telek>();


            public Telek(string[] sortomb)
            {
                this.paritas = sortomb[0];
                this.szelesseg = int.Parse(sortomb[1]);
                this.szin = sortomb[2];

                if (sortomb[0] == "0")
                {
                    this.hazszam = paros + 2;
                    paros += 2;
                    Telek.paros_lista.Add(this);
                    Telek.lista.Add(this);
                }

                else
                {
                    this.hazszam = paratlan + 2;
                    paratlan += 2;
                    Telek.paratlan_lista.Add(this);
                    Telek.lista.Add(this);
                }
            }
        }

        static (string,int) feladat_3(List<Telek> lista)
        {
            int i = lista.Count - 1;

            if (lista[i].hazszam % 2 == 0)
            {
                return ("páros", lista[i].hazszam);

            }

            else
            {
                return ("páratlan",lista[i].hazszam);
            }
        }
        /*
        static int feladat_4(List<Telek> lista)
        {
            int i = 0;

            while (i < lista.Count && lista[i].hazszam)
            {

            }
        }
        */
        
        static void feladat_5a(List<Telek> lista)
        {
            string szin = null;
            int hazszam = int.Parse(Console.ReadLine());

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].hazszam == hazszam)
                {
                    szin = lista[i].szin;
                }
            }

            Console.WriteLine($"A kerítés színe / állapota: {szin}"); 
        }
        
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("kerites.txt", Encoding.UTF8);



            foreach (string sor in sorok)
            {
                string[] sortomb = sor.Split(' ');
                new Telek(sortomb);
            }


            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az eladott telkek száma: {Telek.lista.Count}");

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"A {feladat_3(Telek.lista).Item1} oldalon adták el az utolsó telket.");
            Console.WriteLine($"Az utolsó telek házszáma: {feladat_3(Telek.lista).Item2}");

            Console.WriteLine("4. feladat:");
            Console.WriteLine($"{feladat_4(Telek.paratlan_lista)}");

            Console.WriteLine("5. feladat:");
            Console.WriteLine("Adjon meg egy házszámot!");
            feladat_5a(Telek.lista);
            

            Console.ReadKey();
        }
    }
}
