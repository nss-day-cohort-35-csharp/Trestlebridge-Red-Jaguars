using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;


namespace Trestlebridge.Models.Processors
{
    public class SeedHarvester// : IFacility<ISeedProducing>
    {
        public int _capacity {get;} = 5;

        //public double Capacity => throw new NotImplementedException();

        public List<ISeedProducing> seedToProcess= new List<ISeedProducing>();

        public int GetFreeCapacity()
        {
            return _capacity - seedToProcess.Count();
        }

        public void AddResource(ISeedProducing seed)
        {
            seedToProcess.Add(seed);
        }

        public void Process(Farm farm)
        {

            double harvestedAmount = 0;

            foreach( var item in seedToProcess )
            {
                farm.processedSeeds += item.Harvest();
                harvestedAmount += item.Harvest();
                //seedToProcess.Remove(item);
            }
            seedToProcess.Clear();
            Console.WriteLine($"{harvestedAmount} seeds processed.");
        }

        public void AddResource(List<ISeedProducing> resources)
        {
            throw new NotImplementedException();
        }
    }
}
