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

            //int Index = 0;

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field ({farm.NaturalFields[i].PlantsInFacility()} Plant(s) in the fiels)");
                farm.NaturalFields[i].PlantsGroups();
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field ({farm.PlowedFields[i].PlantsInFacility()} Plant(s) in the fiels)");
                farm.PlowedFields[i].PlantsGroups();
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.NaturalFields[choice - 1].AddResource(new Sunflower());

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(plant, choice);

        }
    }
}