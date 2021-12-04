using System;
using System.Collections.Generic;
using DataCollectionLayer.Entities;
using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer
{
    public static class DataBank
    {
        public static List<string> componentNames = new List<string>() { "CPU", "RAM", "Storage", "Case" };

        public static List<Type> listOfComponents = new List<Type>() { typeof(CpuEnums), typeof(RamEnums), typeof(StorageEnums), typeof(PCaseEnums) };

        private static List<Customer> customers = new();
        public static Customer currentCustomer { get; set; }
        public static Order currentOrder { get; set; }

        public static Dictionary<string, float> coupons = new Dictionary<string, float>() { { "popustza10", 0.1f }, {"popustza20", 0.2f} };

        public static void AddCustomer(string nameSurname, string address)
        {
            var customer = new Customer(nameSurname, address);
            customers.Add(customer);
            currentCustomer = customer;
        }

        public static void AddNewComputer(List<int> listOfChoices, int numberOfRamCards)
        {
            IComponent newCpu = new Cpu((CpuEnums)listOfChoices[0]);
            IComponent newRam = new Ram((RamEnums)listOfChoices[1], numberOfRamCards);
            IComponent newStorage = new Storage((StorageEnums)listOfChoices[2]);
            IComponent newCase = new PcCase((PCaseEnums)listOfChoices[3]);

            Computer computer = new Computer(numberOfRamCards);
            computer.components.Add(newCpu);
            computer.components.Add(newRam);
            computer.components.Add(newStorage);
            computer.components.Add(newCase);

            AddToOrder(computer);
        }

        private static void AddToOrder(Computer computer)
        {
            if (currentOrder is null)
            {
                Order order = new Order();
                order.computers.Add(computer);
                currentCustomer.orderList.Add(order);
                currentOrder = order;
                return;
            }

            currentOrder.computers.Add(computer);
        }

        public static Customer GetCustomer(string nameSurname, string address)
        {
            foreach(var customer in customers)
            {
                if (customer.nameSurname == nameSurname && customer.address == address) return customer;
            }
            return null;
        }
    }
}
