using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace PresentationLayer
{
    class Program
    {
        static void Main()
        {
            string menu = null;

            do
            {
                Console.WriteLine("=======PC Part Picker App=======\nDobrodosli, izaberite jednu od opcija:\n" +
                    "1 - Prijavi se novim racunom\n" +
                    "2 - Prijavi se postojecim racunom\n" +
                    "3 - Izadi iz aplikacije\n");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        SignUp(menu);
                        break;
                    case "2":
                        SignIn(menu);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Dovidenja!");
                        return;
                    default:
                        WriteExitMessage("Krivi unos izbornika");
                        break;
                }

            } while (menu is not "3");
        }

        static void SignUp(string option)
        {
            string nameSurname = null, address = null;
            bool isSuccessful = false;

            Console.WriteLine("Upisite ime i prezime:");
            nameSurname = Console.ReadLine();

            Console.WriteLine("Upisite svoju adresu:");
            address = Console.ReadLine();

            isSuccessful = HandleDataModification.HandleLogin(nameSurname, address, option);

            if (isSuccessful)
            {
                WriteExitMessage("Vas racun je uspjesno napravljen");
                CreateOrder();
                return;
            }

            WriteExitMessage("Unos krivo formatiran");
        }

        static void SignIn(string option)
        {
            string nameSurname = null, address = null;
            bool isSuccessful = false;

            Console.WriteLine("Upisite ime i prezime:");
            nameSurname = Console.ReadLine();

            Console.WriteLine("Upisite svoju adresu:");
            address = Console.ReadLine();

            isSuccessful = HandleDataModification.HandleLogin(nameSurname, address, option);

            if (isSuccessful)
            {
                WriteExitMessage("Uspjesno ste prijavljeni");
                CreateOrder();
                return;
            }

            WriteExitMessage("Unos krivo formatiran ili korisnik ne postoji");
        }

        static void CreateOrder()
        {
            string menu = null;

            do
            {
                Console.WriteLine("Izaberite akciju:\n" +
                    "1 - Sastavi i naruci novo racunalo\n" +
                    "2 - Prikazi moje narudzbe\n" +
                    "3 - Odjavi se");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        PrepareOrder();
                        break;
                    case "2":
                        Console.Clear();
                        HandleDataModification.RetriveOrderData();
                        WriteExitMessage("Narudzbe ispisane");
                        break;
                    case "3":
                        WriteExitMessage("Odjavljeni ste");
                        return;
                    default:
                        Console.WriteLine("Krivi unos na izborniku!");
                        break;
                }

            } while (menu is not "3");
        }

        static void WriteExitMessage(string message)
        {
            Console.WriteLine($"\n{message}, za nastavak pritisnite bilo koju tipku!");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrepareOrder()
        {
            Console.WriteLine("Sastavite komponente novog racunala!\n");
            Console.WriteLine("Izabreite CPU:\n" +
                "1 - AMD DecaCore\n" +
                "2 - AMD OctaCore\n" +
                "3 - INTEL OctaCore\n" +
                "4 - INTEL QuadCore");
            var cpu = int.Parse(Console.ReadLine());

            Console.WriteLine("Izaberite RAM:\n1 - 8GB card\n2 - 4GB card");
            var ramCard = int.Parse(Console.ReadLine());

            Console.WriteLine("Upisite kolicinu RAM kartica:");
            var ramCardAmount = int.Parse(Console.ReadLine());
            //Provjera kolicine

            Console.WriteLine("Izaberite HDD:\n1 - 2TB HDD\n2 - 1TB HDD\n3 - 2TB SSD\n4 - 1TB SSD");
            var massStorage = int.Parse(Console.ReadLine());

            Console.WriteLine("Izaberite kuciste:\n1 - Metalno\n2 - Plasticno\n3 - Karbonsko");
            var pcCase = int.Parse(Console.ReadLine());

            var isSuccessful = HandleDataModification.MakeNewOrder(cpu, ramCard, ramCardAmount, massStorage, pcCase);

            if (isSuccessful)
            {
                WriteExitMessage("Narudzba prihvacena");
                return;
            }
            WriteExitMessage("Narudzba odbijena zbog krivog unosa");
        }
    }
}
