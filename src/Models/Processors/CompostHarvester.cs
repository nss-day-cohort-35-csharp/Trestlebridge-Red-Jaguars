using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;


namespace Trestlebridge.Models.Processors
{
    public class CompostHarvester// : IFacility<ICompostProducing>
    {
        public int _capacity {get;} = 5;

        //public double Capacity => throw new NotImplementedException();

        public List<ICompostProducing> compostToProcess= new List<ICompostProducing>();

        public int GetFreeCapacity()
        {
            return _capacity - compostToProcess.Count();
        }

        public void AddResource(ICompostProducing compost)
        {
            compostToProcess.Add(compost);
        }

        public void Process(Farm farm)
        {

            double harvestedAmount = 0;

            foreach( var item in compostToProcess )
            {
                farm.processedCompost += item.Farmer();
                harvestedAmount += item.Farmer();
                //compostToProcess.Remove(item);
            }
            compostToProcess.Clear();
            Console.WriteLine($"{harvestedAmount} compost processed.");
        }

        public void AddResource(List<ICompostProducing> resources)
        {
            throw new NotImplementedException();
        }
    }
}
