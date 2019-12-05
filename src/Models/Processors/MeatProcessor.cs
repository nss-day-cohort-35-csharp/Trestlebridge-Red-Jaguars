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
        public List<IGrazing> allAnimalToProcess= new List<IGrazing>();

        public int GetFreeCapacity()
        {
            return _capacity - animalToProcess.Count();
        }

        public void AddResource(IMeatProducing animal)
        {
            animalToProcess.Add(animal);
        }

        public void AddResource(IGrazing animal)
        {
            allAnimalToProcess.Add(animal);
        }

        public void Process(Farm farm)
        {

            double processedAmount = 0;

            foreach( var item in animalToProcess )
            {
                farm.processedAnimals += item.Butcher();
                processedAmount += item.Butcher();
            }
            animalToProcess.Clear();
            Console.WriteLine($"{processedAmount} animals processed.");
        }

        public void AddResource(List<IGrazing> resources)
        {
            throw new NotImplementedException();
        }
    }
}
