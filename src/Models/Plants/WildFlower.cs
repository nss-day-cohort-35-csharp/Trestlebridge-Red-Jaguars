using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class WildFlower : IResource, ICompostProducing
    {
        private double _compostProduced = 30.3;
        public string Type { get; } = "WildFlower";

        public double Farmer()
        {
            return _compostProduced;
        }

        public override string ToString()
        {
            return $"WildFlower. Pretty!";
        }
    }
}