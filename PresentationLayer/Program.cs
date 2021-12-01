using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLayer;

namespace PCPartPickerPresentation
{
    class Program
    {
        static void Main()
        {
            string menu = null;

            EnterUser();

            do
            {
                Console.WriteLine("Izaberite akciju:\n1 - Sastavi i naruci novo racunalo\n" +
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
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Dovidenja!");
                        return;
                    default:
                        Console.WriteLine("Krivi unos na izborniku!");
                        break;
                }

            } while (menu is not "3");
        }

        static void HandleError(string message)
        {
            Console.WriteLine($"\n{message}, za povratak na izbornik pritisnite bilo koju tipku!");
            Console.ReadKey();
            Console.Clear();
        }

        static void EnterUser()
        {
            bool isSuccessfulEntry;

            do
            {
                Console.WriteLine("=======PC Part Picker App=======\nDobrodosli, upisite svoje ime i prezime:");
                isSuccessfulEntry = HandleDataModification.MakeNewCustomer();

                if (!isSuccessfulEntry)
                    HandleError("Ime i prezime krivo upisani");

                Console.Clear();
                Console.WriteLine("Logirani korisnik:\n");
                HandleDataModification.RetriveCustomerData();

            } while (isSuccessfulEntry is false);
        }

        static void PrepareOrder()
        {
            Console.WriteLine("Sastavljam novo racunalo:\n\n");
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

            HandleDataModification.MakeNewOrder(cpu, ramCard, ramCardAmount, massStorage, pcCase);
        }
    }
}
