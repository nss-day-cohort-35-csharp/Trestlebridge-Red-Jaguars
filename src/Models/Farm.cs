using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();
        public List<DuckHouse> DuckHouses { get; } = new List<DuckHouse>();
        public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
        public List<IDualProducing> AllPlantFields { get; } = new List<IDualProducing>();

        // Processing equipment

        public double processedSeeds { get; set; }

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */

        //will be used in the future to add generic resources

        // public void PurchaseResource<T>(IResource resource, int index)
        // {
        //     Console.WriteLine(typeof(T).ToString());
        //     switch (typeof(T).ToString())
        //     {
        //         case "Cow":
        //             GrazingFields[index].AddResource((IGrazing)resource);
        //             break;
        //         default:
        //             break;
        //     }
        // }

        public void AddGrazingField(GrazingField field)
        {
            GrazingFields.Add(field);
            Console.WriteLine($"New field has been created!");
            Console.ReadLine();

        }

        public void AddChickenHouse(ChickenHouse house)
        {
            ChickenHouses.Add(house);
            Console.WriteLine($"New Chicken House has been created!");
            Console.ReadLine();

        }
        public void AddDuckHouse(DuckHouse house)
        {
            DuckHouses.Add(house);
            Console.WriteLine($"New Duck House has been created!");
            Console.ReadLine();

        }

        public void AddPlowedField(PlowedField field)
        {
            PlowedFields.Add(field);
            Console.WriteLine($"New Plowed Field has been created!");
            Console.ReadLine();

        }
        public void AddNaturalField(NaturalField field)
        {
            NaturalFields.Add(field);
            Console.WriteLine($"New Natural Field has been created!");
            Console.ReadLine();

        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(f => report.Append(f));

            ChickenHouses.ForEach(f => report.Append(f));
            DuckHouses.ForEach(f => report.Append(f));
            PlowedFields.ForEach(f => report.Append(f));
            NaturalFields.ForEach(f => report.Append(f));
            report.Append($"Total Seeds in storage is {processedSeeds}");

            return report.ToString();
        }
    }
}