using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseDualField
    {
        public static void CollectInput(Farm farm, IDualProducing plant)
        {
            Utils.Clear();
                var filterNaturalFields = farm.NaturalFields.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterNaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field ({filterNaturalFields[i].PlantsInFacility()} Plant(s) in the field)");
                    filterNaturalFields[i].PlantsGroups();
                

            }
            var filterPlowedField = farm.PlowedFields.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterPlowedField.Count; i++)
            {
                Console.WriteLine($"{i + 1 + filterNaturalFields.Count}. Plowed Field ({filterPlowedField[i].PlantsInFacility()} Plant(s) in the field)");
                    filterPlowedField[i].PlantsGroups();
                

            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            if (choice <filterNaturalFields.Count)
            {
               filterNaturalFields[--choice].AddResource(new Sunflower());
            }
            else
            {
               filterPlowedField[--choice -filterNaturalFields.Count].AddResource(new Sunflower());
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(plant, choice);

        }
    }
}