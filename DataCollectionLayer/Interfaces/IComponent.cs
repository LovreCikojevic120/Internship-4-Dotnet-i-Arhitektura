using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IComponent
    {
        public string type { get; set; }
        public string price { get; set; }
        public string weight { get; set; }

        public static int amount;
    }
}
