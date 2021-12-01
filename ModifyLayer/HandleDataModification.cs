using System;
using System.Linq;
using PCPartPickerDataLayer;

namespace ModifyLayer
{
    public static class HandleDataModification
    {
        public static bool MakeNewCustomer()
        {
            var nameSurname = Console.ReadLine();

            Console.WriteLine("Upisite svoju adresu:");
            var address = Console.ReadLine();

            if (nameSurname.Any(letter => char.IsDigit(letter)))
                return false;

            DataBank.PopulateStore();
            DataBank.AddCustomer(nameSurname, address);
            return true;
        }

        public static void RetriveCustomerData()
        {
            var customer = DataBank.GetCustomer();
            Console.WriteLine($"Ime i prezime: {customer.nameSurname}\n" +
                $"Adresa: {customer.address}\n" +
                $"Udaljenost: {customer.distance}\n");
        }

        public static void MakeNewOrder(int cpu, int ramCard, int ramCardAmount, int massStorage, int pcCase)
        {
            var partsList = DataBank.availableParts;
            if (partsList["CPU"].Contains(cpu)) //&&
                //partsList["RAM"].Contains(ramCard) &&
                //partsList["MassStorage"].Contains(massStorage) &&
                //partsList["Case"].Contains(pcCase))
                    DataBank.AddOrder(cpu,ramCard,ramCardAmount,pcCase);
        }

        public static void RetriveOrderData()
        {
            Console.WriteLine("Lista narudzbi:\n");
            var listOfOrders = DataBank.GetOrderList();
            foreach(var order in listOfOrders)
            {
                foreach(var component in order.componentList)
                    Console.WriteLine($"CPU: {component.type}");
            }
        }
    }
}
