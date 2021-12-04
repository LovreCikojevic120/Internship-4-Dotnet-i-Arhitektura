using System;
using System.Collections.Generic;

namespace DataCollectionLayer.Entities
{
    public class Customer
    {
        private string _nameSurname;
        private string _address;
        private float _distance;

        public string nameSurname { get => _nameSurname; set => _nameSurname = value; }
        public string address { get => _address; set => _address = value; }
        public float distance { get => _distance; }

        public bool membershipCoupon = false;

        public bool quantityCoupon = false;
        public List<Order> orderList = new();

        public Customer(string nameSurname, string address)
        {
            _nameSurname = nameSurname;
            _address = address;

            Random rnd = new Random(DateTime.Now.Millisecond);
            _distance = rnd.Next(50, 999);
        }
    }
}
