using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck animal)
        {
            Utils.Clear();
    var filterDuckHouse = farm.DuckHouses.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterDuckHouse.Count; i++)
            {
            
                    Console.WriteLine($"{i + 1}. Duck House ({filterDuckHouse[i].AnimalsInFacility()} Duck(s) in the house)");
                    // filterDuckHouse[i].AnimalGroups();
                
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the duck where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            filterDuckHouse[choice - 1].AddResource(animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<Duck>(animal, choice);

        }
    }
}