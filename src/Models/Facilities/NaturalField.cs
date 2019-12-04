using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostProducing>
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();

        public List<ICompostProducing> _plants = new List<ICompostProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public int IsSpaceAvailable()
        {
            return _capacity - _plants.Count;
        }
        public int PlantsInFacility()
        {
            return _plants.Count;
        }

        public void PlantsGroups()
        {
            var groups = _plants.GroupBy(g => g.Type);
            foreach (var group in groups)
            {
                Console.WriteLine($"This field has {group.Count()} rows of {group.Key}(s)");
            }

        }
        public void AddResource(ICompostProducing plant)
        {
            // TODO: implement this...
            _plants.Add(plant);
        }
        // public void AddResource(IDualProducing plant)
        // {
        //     // TODO: implement this...
        //     _plants.Add(plant);
        // }

        public void AddResource(List<ICompostProducing> plants)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}