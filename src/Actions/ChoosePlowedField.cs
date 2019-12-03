using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeedProducing plant)
        {
            Utils.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].IsSpaceAvailable() > 0)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].PlantsInFacility()} Plant(s) in the fields)");
                    farm.PlowedFields[i].PlantsGroups();
                }
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.PlowedFields[choice - 1].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IPlowed>(plant, choice);

        }
    }
}