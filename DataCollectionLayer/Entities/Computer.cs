using System;
using System.Collections.Generic;
using DataCollectionLayer.Interfaces;

namespace DataCollectionLayer.Entities
{
    public class Computer
    {
        public List<IComponent> components = new List<IComponent>();
        public int numberOfRamCards;

        public Computer(int numberOfCards)
        {
            numberOfRamCards = numberOfCards;
        }
    }
}
