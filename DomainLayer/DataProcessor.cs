using System;
using System.Collections.Generic;
using System.Linq;
using DataCollectionLayer;
using DataCollectionLayer.Enums;
using UtilsClass;

namespace DomainLayer
{
    public static class DataProcessor
    { 
        private static int? IsValidComponentChoice(List<int> choices)
        {
            var suspectChoice = Console.ReadLine();
            if (int.TryParse(suspectChoice, out int result) && choices.Contains(result-1))
                return result - 1;
            return null;
        }

        private static bool HandleRAMPick(string checkNumber)
        {
            if (!string.IsNullOrEmpty(checkNumber) && int.TryParse(checkNumber, out int result) && result is not 0)
                return true;
            Console.WriteLine("Iznos krivo upisan, ponovite unos RAM kartice");
            return false;
        }

        private static (int,int) HandlePickingProcess(Type component, List<int> listOfPossibleChoices)
        {
            bool goodInput = false;
            int numberOfRamCards;
            int? choice = 0;

            do
            {
                goodInput = false;
                numberOfRamCards = 1;
                choice = IsValidComponentChoice(listOfPossibleChoices);

                if (choice is not null)
                {
                    goodInput = true;

                    if (component == typeof(RamEnums))
                    {
                        Console.WriteLine("Upisi broj RAM kartica:");
                        var itemNumber = Console.ReadLine();
                        goodInput = HandleRAMPick(itemNumber);
                        numberOfRamCards = int.Parse(itemNumber);
                    }
                }
                else Console.WriteLine("Opcija krivo unesena ili ne postoji, pokušajte ponovno!\n");

            } while (goodInput is false);

            return ((int)choice, numberOfRamCards);
        }

        public static bool LoginProccess(string nameSurname, string address, string option)
        {

            if (option is "1")
            {
                if (DataBank.currentCustomer is not null) return false;
                
                DataBank.AddCustomer(nameSurname, address);
                return true;
            }

            var currentCustomer = DataBank.GetCustomer(nameSurname, address);

            if (currentCustomer is null)
                return false;

            DataBank.currentCustomer = currentCustomer;

            return true;
        }

        public static void RetriveCustomerData()
        {
            var customer = DataBank.currentCustomer;
            Console.WriteLine($"Ime i prezime: {customer.nameSurname}\n" +
                $"Adresa: {customer.address}\n" +
                $"Udaljenost: {customer.distance}\n");
        }

        public static void RetriveOrderData()
        {
            Console.WriteLine("Lista narudzbi:\n");
            var listOfOrders = DataBank.currentCustomer.orderList;

            if (listOfOrders.Count is 0)
            {
                Console.WriteLine("Lista prazna!");
                return;
            }

            PrintOrderData(listOfOrders);
        }

        private static void PrintOrderData(List<DataCollectionLayer.Entities.Order> listOfOrders)
        {
            foreach (var order in listOfOrders)
            {
                Console.WriteLine($"================================\nNarudzba #{order.orderNumber}\n");

                foreach (var computer in order.computers)
                {
                    Console.WriteLine("Racunalo:");
                    for (int i = 0; i < computer.components.Count; i++)
                    {
                        Console.WriteLine($"{DataBank.componentNames[i]}: {computer.components[i].type}");
                    }
                }
                Console.WriteLine($"\nPocetna cijena racunala: {order.orderPrice}kn\n" +
                    $"Cijena sa popustom: {order.orderPrice - order.priceReduction}kn\n" +
                    $"Cijena dostave: {order.deliveryPrice}kn\n" +
                    $"Ukupna cijena: {order.orderPrice-order.priceReduction+order.deliveryPrice}\n" +
                    $"Nacin dostave: {order.deliveryOption}\n");

                Console.WriteLine("================================\n");
            }
        }

        public static void ComponentPicker()
        {
            var listOfPossibleChoices = new List<int>();
            var listOfPickedChoices = new List<int>();
            int numberOfRamCards = 0, counter = 0;

            foreach (var component in DataBank.listOfComponents)
            {
                Console.WriteLine($"Sastavite komponente novog racunala!\n\nIzaberite {DataBank.componentNames[counter]}\n");

                var componentEnum = component.GetEnumNames();
                var legalComponentChoices = component.GetEnumValues();
                listOfPossibleChoices = Validator.ArrayToList(legalComponentChoices);

                for (int i = 0; i < componentEnum.Length; i++)
                    Console.WriteLine($"{i + 1} - {componentEnum[i]}");

                var pickResult = HandlePickingProcess(component, listOfPossibleChoices);
                listOfPickedChoices.Add(pickResult.Item1);

                if(component == typeof(RamEnums))
                    numberOfRamCards = pickResult.Item2;

                Validator.WriteExitMessage($"{DataBank.componentNames[counter++]} izabran");
            }

            DataBank.AddNewComputer(listOfPickedChoices, numberOfRamCards);
        }

        public static void DeliveryProccess(string option)
        {
            switch (option)
            {
                case "1":
                    DataBank.currentOrder.deliveryPrice = 0;
                    DataBank.currentOrder.deliveryOption = DeliveryEnums.Osobno;
                    break;
                case "2":
                    DataBank.currentOrder.CalculateDelivery();
                    break;
                default:
                    Console.WriteLine("Krivi unos izbornika");
                    break;
            }
            DataBank.currentOrder = null;
        }

        public static bool CouponProccess(string option)
        {
            DataBank.currentOrder.CalculateOrderPrice();

            if (option=="1" && DataBank.currentCustomer.membershipCoupon is true)
            {
                DataBank.currentOrder.priceReduction = 100;
                return true;
            }

            if (option == "2" &&
                (DataBank.currentOrder.computers.Count > 2 ||
                DataBank.currentOrder.computers.Any(computer => computer.numberOfRamCards > 2)))
            {
                DataBank.currentOrder.CalculatePriceReduction();
                return true;
            }

            if (option == "3" && DataBank.coupons.Count is not 0)
            {
                Console.WriteLine("Unesite kod kupona:");
                var code = Console.ReadLine();
                if (DataBank.coupons.ContainsKey(code))
                {
                    DataBank.currentOrder.priceReduction = DataBank.currentOrder.orderPrice * DataBank.coupons[code];
                    DataBank.coupons.Remove(code);
                    return true;
                }

                Console.WriteLine("Kupon koji ste unijeli nije ispravan!");
                return false;
            }

            if (option == "0") return true;

            return false;
        }

        public static void Logout()
        {
            DataBank.currentCustomer = null;
        }
    }
}
