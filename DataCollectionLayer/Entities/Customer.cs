using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Customer
    {
        private string _nameSurname;
        private string _address;
        private string _distance;

        public string nameSurname { get => _nameSurname; set => _nameSurname = value; }
        public string address { get => _address; set => _address = value; }
        public string distance { get => _distance; }

        public Customer(string nameSurname, string address)
        {
            _nameSurname = nameSurname;
            _address = address;

            Random rnd = new Random(DateTime.Now.Millisecond);
            _distance = rnd.Next(50, 999).ToString() + "km";
        }
    }
}
