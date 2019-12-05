using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalFieldForCompost
    {
        public static void CollectInput(Farm farm, CompostHarvester compostHarvester)
        {
            var answer = "";
            do
            {

                Utils.Clear();

                var filterNaturalField = farm.NaturalFields.Where(field => field.PlantsInFacility() > 0).ToList();
                if (filterNaturalField.Count > 0)
                {
                    for (int i = 0; i < filterNaturalField.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Natural Field ({filterNaturalField[i].PlantsInFacility()} Plant(s) in the fields)");
                        filterNaturalField[i].PlantsGroups();
                    }

                    Console.WriteLine();

                    // How can I output the type of plant chosen here?
                    Console.WriteLine($"What field to harvest?");

                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());
                    Utils.Clear();
                    Console.Write("Heres a list of plants in your chosen field");
                    Console.WriteLine();
                    var plantsInFacility = filterNaturalField[choice - 1]._plants;
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

                    if ( (compostHarvester.GetFreeCapacity() >= plantNumber) && (selectedFacilityGroup[plantChoice].Count() >= plantNumber))
                    {
                        for (int i = 0; i < plantNumber; i++)
                        {
                            Console.WriteLine(selectedFacilityGroup[plantChoice].Last().ToString());
                            compostHarvester.AddResource(selectedFacilityGroup[plantChoice].Last());
                            plantsInFacility.Remove(plantsInFacility.Last(p => p.Type == selectedFacilityGroup[plantChoice].Key));

                        }
                        Console.WriteLine("Do you want to add more? Y/N");
                        answer = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input (capacity or plants number). Processing current resource.");
                        Console.ReadLine();
                        answer = "N";
                    }
                }
                else
                {
                    Console.WriteLine("no plants in field, processing everything in harvester");
                    Console.ReadLine();
                    answer = "N";
                }
            } while (answer.ToUpper() == "Y");

            compostHarvester.Process(farm);
            Console.ReadLine();

            //plantsInFacility[plantChoice].Harvest();

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(plant, choice);

        }
    }
}