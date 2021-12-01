using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Cpu : IComponent
    {
        private string _type;
        private string _price;
        private string _weight;

        public string type { get => _type; set => _type = value; }
        public string price { get => _price; set => _price = value; }
        public string weight { get => _weight; set => _weight = value; }

        public static int amount;

        public Cpu(int type)
        {
            switch (type)
            {
                case (int)CpuEnums.CpuList.AMD_DecaCore:
                    _type = "AMD_DecaCore";
                    break;
            }
        }
    }
}
