using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;
namespace DataCollectionLayer.Entities
{
    public class Ram : IComponent
    {
        private int _price = 20;
        private float _weight = 0;

        public string name { get; }
        public string type { get; set; }
        public int price { get => _price; }
        public float weight { get => _weight; }
        public Ram(RamEnums ramType, int numberOfCards)
        {
            name = "RAM";
            type = ramType.ToString().Replace("_", " ");
        }
    }
}
