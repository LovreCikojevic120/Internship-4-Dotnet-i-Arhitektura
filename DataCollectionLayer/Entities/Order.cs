using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer.Entities
{
    public class Order
    {
        private int _totalPrice;
        private DeliveryOption _deliveryOption;
        private int _orderNumber;

        public int orderNumber { get => _orderNumber; }
        public List<IComponent> componentList = new List<IComponent>();

        public enum DeliveryOption
        {
            Personally,
            OnAdress
        };

        public Order()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            _orderNumber = rnd.Next(1000, 9999);
        }
    }
}
