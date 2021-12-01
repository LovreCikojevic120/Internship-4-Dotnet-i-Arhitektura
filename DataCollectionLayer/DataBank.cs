using System.Collections.Generic;
using DataCollectionLayer.Entities;
using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer
{
    public static class DataBank
    {
        private static Customer _currentCustomer;
        private static List<Customer> _customers = new List<Customer>();
        private static Dictionary<string, List<int>> _availableParts = new Dictionary<string, List<int>>();

        public static List<Customer> customers { get => _customers; }
        public static Customer currentCustomer { get => _currentCustomer; set => _currentCustomer = value; }
        public static Dictionary<string, List<int>> availableParts { get => _availableParts; }

        static DataBank()
        {
            _availableParts.Add("CPU", new List<int> {
                (int)CpuEnums.CpuList.AMD_DecaCore,
                (int)CpuEnums.CpuList.AMD_OctaCore,
                (int)CpuEnums.CpuList.Intel_OctaCore,
                (int)CpuEnums.CpuList.Intel_QuadCore});

            _availableParts.Add("RAM", new List<int>
            {
                (int)RamEnums.RamList.Card4GB,
                (int)RamEnums.RamList.Card8GB
            });

            _availableParts.Add("MassStorage", new List<int>
            {

            });

            _availableParts.Add("PcCase", new List<int>
            {

            });
        }

        public static void AddCustomer(string nameSurname, string address)
        {
            var customer = new Customer(nameSurname, address);
            _customers.Add(customer);
            _currentCustomer = customer;
        }

        public static void AddOrder(int cpu, int ram, int ramAmount, int pcCase)
        {
            IComponent newCpu = new Cpu((CpuEnums.CpuList)cpu);

            Order order = new Order();
            order.componentList.Add(newCpu);
            _customers[_customers.IndexOf(currentCustomer)].orderList.Add(order);
        }

        public static Customer GetCustomer(string nameSurname, string address)
        {
            foreach(var customer in _customers)
            {
                if (customer.nameSurname == nameSurname && customer.address == address) return customer;
            }
            return null;
        }
    }
}
