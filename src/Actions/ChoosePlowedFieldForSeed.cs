using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedFieldForSeed
    {
        public static void CollectInput(Farm farm, SeedHarvester seedHarvester)
        {
            var answer = "";
            do
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
                Utils.Clear();
                Console.Write("Heres a list of plants in your chosen field");
                Console.WriteLine();
                var plantsInFacility = filterPlowedField[choice - 1]._plants;
                var selectedFacilityGroup = plantsInFacility.GroupBy(g => g.Type).ToList();

                /*foreach (var plant in selectedFacilityGroup)
                {
                    Console.WriteLine($"This field has {plant.Count()} {plant.Key}(s)");
                }*/

                for (int i = 0; i < selectedFacilityGroup.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {selectedFacilityGroup[i].Key} ({selectedFacilityGroup[i].Count()})");
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?

                Console.WriteLine($"What plant to process?");
                Console.Write("> ");
                int plantChoice = Int32.Parse(Console.ReadLine());
                plantChoice--;

                Console.WriteLine($"How many plants to process?");
                Console.Write("> ");
                int plantNumber = Int32.Parse(Console.ReadLine());

                if (seedHarvester.GetFreeCapacity() >= plantNumber)
                {
                    for (int i = 0; i < plantNumber; i++)
                    {
                        Console.WriteLine(selectedFacilityGroup[plantChoice].Last().ToString());
                        seedHarvester.AddResource(selectedFacilityGroup[plantChoice].Last());
                        plantsInFacility.Remove(plantsInFacility.Last(p => p.Type == selectedFacilityGroup[plantChoice].Key));

                    }
                    Console.WriteLine("Do you want to add more? Y/N");
                    answer = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("No more space! Processing current resource.");
                    Console.ReadLine();
                    answer = "N";
                }

            } while (answer == "Y");

            //plantsInFacility[plantChoice].Harvest();

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IPlowed>(plant, choice);

        }
    }
}