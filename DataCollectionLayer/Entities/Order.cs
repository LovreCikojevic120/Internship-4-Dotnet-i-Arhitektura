using System;
using System.Collections.Generic;
using DataCollectionLayer.Enums;

namespace DataCollectionLayer.Entities
{
    public class Order
    {
        public float orderPrice;
        public float priceReduction;
        public float deliveryPrice { get; set; }
        public DeliveryEnums deliveryOption;
        public float totalWeight;
        private int _orderNumber;

        public List<Computer> computers = new List<Computer>();
        public int orderNumber { get => _orderNumber; }

        public Order()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            _orderNumber = rnd.Next(1000, 9999);
        }

        public void CalculateDelivery()
        {
            var customerDistance = DataBank.currentCustomer.distance;
            CalculateWeight();

            if (totalWeight < 3f)
            {
                deliveryOption = DeliveryEnums.Motocikl;
                deliveryPrice = 0.5f * customerDistance;
            }
            if (totalWeight > 10f)
            {
                deliveryOption = DeliveryEnums.Kamion;
                deliveryPrice = 50f + 0.5f * customerDistance;
            }
            else 
            {
                deliveryOption = DeliveryEnums.Automobil;
                deliveryPrice = 0.6f * customerDistance;
            }
        }

        private void CalculateWeight()
        {
            foreach(var computer in computers)
                foreach(var component in computer.components)
                    totalWeight += component.weight;
        }

        public void CalculateOrderPrice()
        {
            foreach (var computer in computers) {
                foreach (var component in computer.components)
                {
                    if(component.name == "RAM")
                        orderPrice += component.price * computer.numberOfRamCards;

                    else orderPrice += component.price;
                }
            }

            if (orderPrice > 1000) DataBank.currentCustomer.membershipCoupon = true;
        }

        public float CalculatePriceReduction()
        {
            float reducedPrice = 0f;
            var numOfFreeItems = (computers.Count) / 3;

            foreach (var computer in computers)
            {
                var numOfFreeCards = computer.numberOfRamCards / 3;
                reducedPrice += (numOfFreeCards * computer.components[1].price) + (numOfFreeItems * (computer.components[0].price));
            }
            priceReduction = reducedPrice;
            return reducedPrice;
        }
    }
}
