using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<ISeedProducing>
    {
        private int _capacity = 13;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
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
        public void AddResource(ISeedProducing plant)
        {
            // TODO: implement this...
            _plants.Add(plant);
        }

        public void AddResource(List<ISeedProducing> plants)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}