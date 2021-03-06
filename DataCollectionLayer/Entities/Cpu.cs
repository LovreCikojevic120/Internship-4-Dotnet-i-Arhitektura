using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer.Entities
{
    public class Cpu : IComponent
    {
        private int _price = 20;
        private float _weight = 0;

        public string name { get; }
        public string type { get; set; }
        public int price { get => _price; }
        public float weight { get => _weight; }

        public Cpu(CpuEnums cpuType)
        {
            name = "CPU";
            type = cpuType.ToString().Replace("_", " ");
        }
    }
}
