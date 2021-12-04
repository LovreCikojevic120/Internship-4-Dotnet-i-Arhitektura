using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;
namespace DataCollectionLayer.Entities
{
    public class PcCase : IComponent
    {
        private int _price = 20;
        private float _weight = 0;

        public string name { get; }
        public string type { get; set; }
        public int price { get => _price; }
        public float weight { get => _weight; }
        public PcCase(PCaseEnums caseType)
        {
            name = "Case";
            type = caseType.ToString().Replace("_", " ");
            if (caseType == PCaseEnums.Metal) _weight = 1.5f;
            if (caseType == PCaseEnums.Plastic) _weight = 1f;
            if (caseType == PCaseEnums.Carbon) _weight = 0.5f;
        }
    }
}
