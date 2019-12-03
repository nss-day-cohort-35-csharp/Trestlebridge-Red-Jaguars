using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostProducing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> plants = new List<ICompostProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public int plantsInFacility()
        {
            return plants.Count;
        }

        public void PlantsGroups()
        {
            var groups = plants.GroupBy(g => g.Type);
            foreach (var group in groups)
            {
                Console.WriteLine($"This field has {group.Count()} {group.Key}(s)");
            }

        }
        public void AddResource(ICompostProducing plants)
        {
            // TODO: implement this...
            plants.Add(plants);
        }

        public void AddResource(List<ICompostProducing> plants)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this.plants.Count} plants\n");
            this.plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}