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
        static Customer customer;
        static List<Order> orderList = new List<Order>();
        public static Dictionary<string, List<int>> availableParts = new Dictionary<string, List<int>>();

        public static void PopulateStore()
        {
            availableParts.Add("CPU", new List<int> {
                (int)CpuEnums.CpuList.AMD_DecaCore,
                (int)CpuEnums.CpuList.AMD_OctaCore,
                (int)CpuEnums.CpuList.Intel_OctaCore,
                (int)CpuEnums.CpuList.Intel_QuadCore});
        }

        public static void AddCustomer(string nameSurname, string address)
        {
            customer = new Customer(nameSurname, address);
        }

        public static Customer GetCustomer()
        {
            return customer;
        }

        public static void AddOrder(int cpu, int ram, int ramAmount, int pcCase)
        {
            Order order = new Order();
            IComponent newCpu = new Cpu(cpu);
            order.componentList.Add(newCpu);
            orderList.Add(order);
        }

        public static List<Order> GetOrderList()
        {
            return orderList;
        }
    }
}
