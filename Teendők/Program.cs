using ConsoleTools;
using System.Text;

namespace Teendők
{
    internal class Program
    {
        //Ebben tároljuk el az összes teendőt
        static List<Teendo> Teendok = new List<Teendo>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.OutputEncoding = Encoding.UTF8; //Ez kell ahhoz, hogy tudjunt emojikat kiírni.

            ConsoleMenu teendomenu = new ConsoleMenu();

            Teendo tesztadat = new Teendo();

            tesztadat.Feladat = "Első tesztadat";

            tesztadat.Idopont = DateTime.Parse("2025.05.17. 12:30");

            tesztadat.Azonosito = 1;

            Teendok.Add(tesztadat);

            Teendo tesztadat2 = new Teendo();

            tesztadat2.Feladat = "Második tesztadat";

            tesztadat2.Idopont = DateTime.Parse("2025.05.17. 13:30");

            tesztadat2.Azonosito = 2;

            Teendok.Add(tesztadat2);

            teendomenu.Add("Teendő hozzáadása",Hozzaadas);

            teendomenu.Add("Teendő törlése", TeendoTorlese);

            teendomenu.Add("Összes teendő kiírása", Kiiras);

            teendomenu.Add("Teendő megcsinálása", Megcsinalas);

            teendomenu.Add("Megcsinált teendők", MegcsinaltTeendok);

            teendomenu.Add("Nem megcsinált teendők", NemMegcsinaltTeendok);

            teendomenu.Add("Kilépés", teendomenu.CloseMenu);

            teendomenu.Show();
        }

        static void Megcsinalas()
        {
            Console.WriteLine("Add meg az azonosítóját a teendőnek!");

            try
            {
                int bekertszam = int.Parse(Console.ReadLine());

                foreach (var Teendom in Teendok)
                {
                    if (Teendom.Azonosito == bekertszam)
                    {
                        Teendom.Megcsinaltae = true;
                        Console.WriteLine("Teendő megcsinálva!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("HIBA: Nem jó számot adtál meg.");
            }

            Console.ReadLine();
        }

        static void NemMegcsinaltTeendok()
        {
            foreach (var Teendom in Teendok)
            {
                if (Teendom.Megcsinaltae == false)
                {
                    Console.WriteLine(Teendom);
                }
            }

            Console.ReadLine();
        }

        static void MegcsinaltTeendok()
        {
            foreach (var Teendom in Teendok)
            {
                if(Teendom.Megcsinaltae == true)
                {
                    Console.WriteLine(Teendom);
                }
            }

            Console.ReadLine();
        }

        static void Kiiras()
        {
            foreach (var Teendom in Teendok)
            {
                Console.WriteLine(Teendom);
            }

            Console.ReadLine();
        }

        static void TeendoTorlese()
        {
            Console.WriteLine("Add meg az azonosítóját a teendőnek!");

            try
            {
                int bekertszam = int.Parse(Console.ReadLine());

                for (int i = 0; i < Teendok.Count; i++) //Végigmegyünk az összes teendőn
                {
                    if (Teendok[i].Azonosito == bekertszam) //Ha megtaláltuk a törlendő teendőt
                    {
                        Teendok.Remove(Teendok[i]);

                        Console.WriteLine("A teendő törölve.");
                    }

                }

                int ujazonosito = 1; //Újra állítjuk az azonosítókat

                foreach (var alma in Teendok)
                {
                    alma.Azonosito= ujazonosito;

                    ujazonosito++;
                }
            }
            catch
            {
                Console.WriteLine("HIBA: Nem jó számot adtál meg.");
            }

            Console.ReadLine();
        }

        static void Hozzaadas()
        {
            try
            {
                Console.WriteLine("Add meg a teendő szövegét!");

                string bekertSzoveg = Console.ReadLine();

                Console.WriteLine("Add meg a teendő időpontját PL: 2025.05.03. 14:30");

                DateTime idopont = DateTime.Parse(Console.ReadLine());

                Teendo teendo = new Teendo();

                teendo.Idopont = idopont;

                teendo.Feladat = bekertSzoveg;

                int osszesteendoszama = Teendok.Count; //Megszámoljuk, hogy mennyi teendonk van

                teendo.Azonosito = osszesteendoszama + 1;

                Teendok.Add(teendo);

                Console.WriteLine("A teendő sikeresen hozzáadva.");

                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("HIBA: Nem jól adtad meg a dátumot. Próbáld meg újra.");

                Console.ReadLine();
            }
        }
    }
}