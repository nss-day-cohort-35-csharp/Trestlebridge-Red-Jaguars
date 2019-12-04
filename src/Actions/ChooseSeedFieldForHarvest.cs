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
            var filterPlowedField = farm.PlowedFields.Where(field => field.PlantsInFacility() > 0).ToList();
            for (int i = 0; i < filterPlowedField.Count; i++)
            {

                Console.WriteLine($"{i + 1}. Plowed Field ({filterPlowedField[i].PlantsInFacility()} Plant(s) in the fields)");
                filterPlowedField[i].PlantsGroups();

            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"What field to harvest?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            var selectedFacility = filterPlowedField[choice - 1];
            for (int i = 0; i < selectedFacility._plants.Count; i++)
            {
                Console.WriteLine($"{i+1}. {selectedFacility._plants[i].Type} ");

            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"What plant to process?");
             Console.Write("> ");
            int plantChoice = Int32.Parse(Console.ReadLine()); 
            

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IPlowed>(plant, choice);

        }
    }
}