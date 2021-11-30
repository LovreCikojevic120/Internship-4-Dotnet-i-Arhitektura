using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Order
    {
        private int _totalPrice;
        private DeliveryOption _deliveryOption;

        public List<IComponent> componentList = new List<IComponent>();

        public enum DeliveryOption
        {
            Personally,
            OnAdress
        };
    }
}
