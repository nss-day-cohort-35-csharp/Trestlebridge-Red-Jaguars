using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        public List<Duck> _animals = new List<Duck>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public int IsSpaceAvailable()
        {
            return _capacity - _animals.Count;
        }
        public int AnimalsInFacility()
        {
            return _animals.Count;
        }

        // public void AnimalGroups()
        // {
        //     var groups = _animals.GroupBy(g => g.Type);
        //     foreach (var group in groups)
        //     {
        //         Console.WriteLine($"This field has {group.Count()} {group.Key}(s)");
        //     }

        // }
        public void AddResource(Duck animal)
        {
            // TODO: implement this...
            _animals.Add(animal);
        }

        public void AddResource(List<Duck> animals)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._animals.Count} Ducks\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}