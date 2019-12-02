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

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T>(IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

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

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(f => report.Append(f));
            ChickenHouses.ForEach(f => report.Append(f));

            return report.ToString();
        }
    }
}