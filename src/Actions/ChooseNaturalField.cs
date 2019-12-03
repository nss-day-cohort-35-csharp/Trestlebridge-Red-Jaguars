using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.plants;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ICompostProducing seed )
        {
            Utils.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field ({farm.NaturalFields[i].plantsInFacility()} plants(s) in the fiels)");
                farm.NaturalFields[i].plantsGroups();
            }

            Console.WriteLine();

            // How can I output the type of plants chosen here?
            Console.WriteLine($"Place the plants where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.NaturalFields[choice - 1].AddResource(plants);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(plants, choice);

        }
    }
}