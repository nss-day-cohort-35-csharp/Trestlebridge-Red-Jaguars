using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedFieldForSeed
    {
        public static void CollectInput(Farm farm, ISeedProducing plant)
        {
            Utils.Clear();
             var filterPlowedField = farm.PlowedFields.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                
                    Console.WriteLine($"{i + 1}. Plowed Field ({filterPlowedField[i].PlantsInFacility()} Plant(s) in the fields)");
                    filterPlowedField[i].PlantsGroups();
       
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            filterPlowedField[choice - 1].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IPlowed>(plant, choice);

        }
    }
}