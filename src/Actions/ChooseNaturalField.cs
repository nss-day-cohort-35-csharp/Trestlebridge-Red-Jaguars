using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ICompostProducing plant)
        {
            Utils.Clear();
            var filterNaturalField = farm.NaturalFields.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterNaturalField.Count(); i++)
            {

                Console.WriteLine($"{i + 1}. Natural Field ({filterNaturalField[i].PlantsInFacility()} Plant(s) in the fields)");
                filterNaturalField[i].PlantsGroups();

            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            filterNaturalField[choice - 1].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(plant, choice);

        }
    }
}