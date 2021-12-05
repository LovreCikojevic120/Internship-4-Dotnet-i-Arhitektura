using System;
using DomainLayer;
using UtilsClass;

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
                        SignUp(menu, "Racun uspjesno napravljen");
                        break;
                    case "2":
                        SignUp(menu, "Uspjesno ste prijavljeni");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Dovidenja!");
                        return;
                    default:
                        Validator.WriteExitMessage("Krivi unos izbornika");
                        break;
                }

            } while (menu is not "3");
        }

        static void SignUp(string option, string message)
        {
            string nameSurname = null, address = null;
            bool isSuccessful = false;

            nameSurname = Validator.ValidateString("ime i prezime");

            address = Validator.ValidateString("adresu");

            isSuccessful = DataProcessor.LoginProccess(nameSurname, address, option);

            if (isSuccessful)
            {
                Validator.WriteExitMessage(message);
                DisplayMainMenu();
                return;
            }

            Validator.WriteExitMessage("Unos krivo formatiran ili korisnik ne postoji");
        }

        static void DisplayMainMenu()
        {
            string menu = null;

            do
            {
                DataProcessor.RetriveCustomerData();

                Console.WriteLine("Izaberite akciju:\n" +
                    "1 - Sastavi i naruci novo racunalo\n" +
                    "2 - Prikazi moje narudzbe\n" +
                    "3 - Odjavi se");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        ComputerAssembler();
                        Console.Clear();
                        HandleCoupons();
                        Console.Clear();
                        HandleDelivery();
                        break;
                    case "2":
                        Console.Clear();
                        DataProcessor.RetriveOrderData();
                        Validator.WriteExitMessage("Narudzbe ispisane");
                        break;
                    case "3":
                        DataProcessor.Logout();
                        Validator.WriteExitMessage("Odjavljeni ste");
                        return;
                    default:
                        Console.WriteLine("Krivi unos na izborniku!");
                        break;
                }

            } while (menu is not "3");
        }

        static void HandleCoupons()
        {
            bool isSuccessful;
            bool hasCoupon;
            string option = null;

            do
            {
                Console.WriteLine("Iskoristite svoje kupone:\n" +
                    "1 - Kupon za vjerno clanstvo\n" +
                    "2 - Iskoristi kupi 3 plati 2 ponudu\n" +
                    "3 - Iskoristi bon za kupon\n" +
                    "0 - Ne zelim iskoristiti kupon");
                option = Console.ReadLine();
                isSuccessful = Validator.IsValidMenuOption("0", "3", option);

                hasCoupon = DataProcessor.CouponProccess(option);

                if (isSuccessful is false)
                    Validator.WriteExitMessage("Krivo ste unijeli opciju izbornika");
                if (hasCoupon is false)
                    Validator.WriteExitMessage("Nemate izabrani kupon");

            } while (hasCoupon is false);

            
        }

        static void HandleDelivery()
        {
            bool isSuccessful;
            string option = null;
            do
            {
                Console.WriteLine("Kako zelite preuzeti narudzbu:\n1 - Osobno\n2 - Dostava");
                option = Console.ReadLine();
                isSuccessful = Validator.IsValidMenuOption("1", "2", option);

                if (isSuccessful is false)
                    Validator.WriteExitMessage("Krivi unos izbornika");
            } while (isSuccessful is false);

            DataProcessor.DeliveryProccess(option);
            Validator.WriteExitMessage("Narudzba prihvacena");
        }

        static void ComputerAssembler()
        {
            string menu = null;
            DataProcessor.ComponentPicker();

            do
            {
                Console.WriteLine("Racunalo uspjesno sastavljeno!\n" +
                    "1 - Sastavi jos racunala\n" +
                    "2 - Nastavi na narucivanje i placanje");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        DataProcessor.ComponentPicker();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Krivi unos izbornika");
                        break;
                }
            } while (menu is not "2");
        }
    }
}
