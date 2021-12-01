using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer.Entities
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

        public Cpu(CpuEnums.CpuList type)
        {
            switch (type)
            {
                case CpuEnums.CpuList.AMD_DecaCore:
                    _type = "AMD DecaCore";
                    break;
                case CpuEnums.CpuList.AMD_OctaCore:
                    _type = "AMD OctaCore";
                    break;
                case CpuEnums.CpuList.Intel_OctaCore:
                    _type = "Intel OctaCore";
                    break;
                case CpuEnums.CpuList.Intel_QuadCore:
                    _type = "Intel QuadCore";
                    break;
            }
        }
    }
}
