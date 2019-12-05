using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
namespace Trestlebridge.Models.Processors
{
    public class MeatProcessor
    {
        public int _capacity {get;} = 5;
        public List<IMeatProducing> animalToProcess= new List<IMeatProducing>();
        public int GetFreeCapacity()
        {
            return _capacity - animalToProcess.Count();
        }
        public void AddResource(IMeatProducing seed)
        {
            animalToProcess.Add(seed);
        }
        public void Process(Farm farm)
        {
            double processedAmount = 0;
            double processedFeathers = 0;
            foreach( var item in animalToProcess )
            {
                farm.processedAnimals += item.Butcher();
                processedAmount += item.Butcher();
                farm.processedFeathers += item.Feather();
                processedFeathers += item.Feather();
            }
            animalToProcess.Clear();
            Console.WriteLine($"{processedAmount} kg of meat processed.");
            Console.WriteLine($"{processedFeathers} kg of feathers processed.");
        }
        public void AddResource(List<IMeatProducing> resources)
        {
            throw new NotImplementedException();
        }
    }
}