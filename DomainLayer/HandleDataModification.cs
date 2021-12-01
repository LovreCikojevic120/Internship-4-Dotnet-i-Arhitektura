using System;
using System.Linq;
using DataCollectionLayer;

namespace DomainLayer
{
    public static class HandleDataModification
    {
        private static bool IsValidString(string suspectString)
        {
            return (suspectString.Any(letter => char.IsDigit(letter)) && string.IsNullOrWhiteSpace(suspectString)) ? false : true;
        }

        public static bool HandleLogin(string nameSurname, string address, string option)
        {

            if (option is "1")
            {
                if (!IsValidString(nameSurname) && !IsValidString(address))
                    return false;

                if (DataBank.GetCustomer(nameSurname, address) is not null) return false;
                
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

        public static bool MakeNewOrder(int cpu, int ramCard, int ramCardAmount, int massStorage, int pcCase)
        {
            var partsList = DataBank.availableParts;
            if (partsList["CPU"].Contains(cpu) &&
                partsList["RAM"].Contains(ramCard))// && 
                                                   //partsList["MassStorage"].Contains(massStorage) && 
                                                   //partsList["PcCase"].Contains(pcCase))
            {
                DataBank.AddOrder(cpu, ramCard, ramCardAmount, pcCase);
                return true;
            }
            return false;
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

            foreach (var order in listOfOrders)
            {
                Console.WriteLine($"================================\nNarudzba #{order.orderNumber}\n");
                foreach (var component in order.componentList)
                    Console.WriteLine($"CPU: {component.type}");
                Console.WriteLine("================================\n");
            }
        }
    }
}
