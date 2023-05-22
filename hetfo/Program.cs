using System.IO;

namespace hetfo
{
    internal class Program
    {
        static List<Kolcsonzes> rentals = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            readFile();
            searchName();
            searchTime();

            //8
            Console.WriteLine($"8. feladat: Napi Bevétel : {2400 * (rentals.Sum(ob => ob.IdoHossz() / 30 + 1))}");

            searchSuspect();

            //10.
            Console.WriteLine("10. feladat: Statisztika");
            rentals.GroupBy(x => x.Jazon).OrderBy(x => x.Key).ToList().ForEach(x => Console.WriteLine($"{x.Key} - {x.Count()}"));
        }


        static void readFile()
        {
            StreamReader sr = new StreamReader("kolcsonzesek.txt");
            sr.ReadLine();
            while (!(sr.EndOfStream))
            {
                string[] lines = sr.ReadLine().Split(";");
                Kolcsonzes newRental = new Kolcsonzes(lines[0], Convert.ToChar(lines[1]), Convert.ToInt32(lines[2]), Convert.ToInt32(lines[3]), Convert.ToInt32(lines[4]), Convert.ToInt32(lines[5]));
                rentals.Add(newRental);
            }
            sr.Close();

            //LINQ
            //List<Kolcsonzes> masiklista = File.ReadAllLines("kolcsonzesek.txt").Skip(1).Select(x => new Kolcsonzes(x)).ToList();

            Console.WriteLine($"5. Feladat: Napi kölcsönzések száma: {rentals.Count()}");
        }

        static void searchName()
        {
            Console.WriteLine("6. feladat: Kérek egy nevet: ");
            string name = Console.ReadLine();

            string rent = "";

            foreach (var item in rentals)
            {
                if (item.Nev == name)
                {
                    rent += item.EOra + ":" + item.EPerc + "  -  " + item.VOra + ":" + item.VPerc + "\n";
                }
            }
            if (rent == "")
            {
            Console.WriteLine("Nem volt ilyen nevű kölcsönző!");

            }
            else
            {
            Console.WriteLine(name + " Kölcsönzései : ");
            Console.WriteLine(rent);
            }

            //if (rentals.Count(x => x.Nev == name) == 0)
            //{
            //    Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            //}
            //else
            //{
            //    //foreach (var item in rentals.Where(x=> x.Nev == name))
            //    //{
            //    //    Console.WriteLine("ido...");
            //    //}

            //    rentals.Where(x => x.Nev == name).ToList().ForEach(x => Console.WriteLine(x));
            //}
        }

        static void searchTime()
        {
            Console.WriteLine("7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string rawTime = Console.ReadLine();
            int iHour = Convert.ToInt32(rawTime.Split(":")[0]);
            int iMin =  Convert.ToInt32(rawTime.Split(":")[1]);
            int Time = iHour * 60 + iMin;

            Console.WriteLine("A vízen lévő járművek:");
            foreach (var item in rentals)
            {
                if (item.EOra * 60 + item.EPerc < Time && Time < item.VOra * 60 + item.VPerc)
                {
                    Console.WriteLine($"{item.EOra}:{item.EPerc}-{item.VOra}:{item.VPerc} : {item.Nev}");
                }
            }
        }

        static void searchSuspect()
        {
            StreamWriter sw = new StreamWriter("txt.txt");
            foreach (var item in rentals)
            {
                if (item.Jazon == 'F')
                {
                    sw.WriteLine($"{item.EOra}:{item.EPerc}-{item.VOra}:{item.VPerc} : {item.Nev}");
                    Console.WriteLine(($"{item.EOra}:{item.EPerc}-{item.VOra}:{item.VPerc} : {item.Nev}"));
                }
            }
            sw.Close();
        }

    }
}