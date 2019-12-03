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
                Console.WriteLine($"{i + 1}. Natural Field ({farm.NaturalFields[i].PlantsInFacility()} Plant(s) in the field)");
                farm.NaturalFields[i].PlantsGroups();
               // Index++;
            }

            //int Index2 = Index;
            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{i + 1 + farm.NaturalFields.Count}. Plowed Field ({farm.PlowedFields[i].PlantsInFacility()} Plant(s) in the field)");
                farm.PlowedFields[i].PlantsGroups();
               // Index++;
            }



            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            //choice--;
            //Index2--;

            if( choice < farm.NaturalFields.Count )
            {
                farm.NaturalFields[--choice].AddResource(new Sunflower());
            }
            else
            {
                farm.PlowedFields[ --choice - farm.NaturalFields.Count].AddResource(new Sunflower());
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(plant, choice);

        }
    }
}