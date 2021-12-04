using DataCollectionLayer.Enums;
using DataCollectionLayer.Interfaces;
namespace DataCollectionLayer.Entities
{
    public class Storage : IComponent
    {
        private int _price = 20;
        private float _weight = 0;

        public string name { get; }
        public string type { get; set; }
        public int price { get => _price; }
        public float weight { get => _weight; }
        public Storage(StorageEnums storageType)
        {
            name = "Storage";
            type = storageType.ToString().Replace("_", " ");
            if (storageType == StorageEnums.HDD_2TB) _weight = 2;
            if (storageType == StorageEnums.HDD_1TB) _weight = 1;
        }
    }
}
