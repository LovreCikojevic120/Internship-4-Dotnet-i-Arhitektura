using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Interfaces;

namespace PCPartPickerDataLayer
{
    public static class DataBank
    {
        private static Customer _customer;
        private static List<Order> _orderList = new List<Order>();
        private static Dictionary<string, List<int>> _availableParts = new Dictionary<string, List<int>>();

        public static Customer customer { get => _customer; }
        public static List<Order> orderList { get => _orderList; }

        public static Dictionary<string, List<int>> availableParts { get => _availableParts; }

        public static void PopulateStore()
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
            _customer = new Customer(nameSurname, address);
        }

        public static void AddOrder(int cpu, int ram, int ramAmount, int pcCase)
        {
            Order order = new Order();
            IComponent newCpu = new Cpu(cpu);
            order.componentList.Add(newCpu);
            _orderList.Add(order);
        }
    }
}
