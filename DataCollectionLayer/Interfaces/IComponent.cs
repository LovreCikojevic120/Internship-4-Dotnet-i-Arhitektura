using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionLayer.Interfaces
{
    public interface IComponent
    {
        public string name { get; }
        public string type { get; set; }
        public int price { get; }
        public float weight { get; }

        public static int amount;
    }
}
