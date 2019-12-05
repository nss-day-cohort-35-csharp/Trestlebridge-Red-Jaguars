using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingFieldForMeat
    {
        public static void CollectInput(Farm farm, MeatProcessor meatProcessor)
        {
            var answer = "";
            do
            {
                Utils.Clear();

                var filterGrazingField = farm.GrazingFields.Where(field => field.AnimalsInFacility() > 0).ToList();
                if (filterGrazingField.Count > 0)
                {
                    for (int i = 0; i < filterGrazingField.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Grazing Field ({filterGrazingField[i].AnimalsInFacility()} Animal(s) in the fields)");
                        filterGrazingField[i].AnimalGroups();
                    }
                    Console.WriteLine();

                    // How can I output the type of animal chosen here?
                    Console.WriteLine($"What field to process?");

                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());
                    Utils.Clear();
                    Console.Write("Heres a list of animals in your chosen field");
                    Console.WriteLine();
                    var AnimalsInFacility = filterGrazingField[choice - 1]._animals.Where(a => a.Type != "Goat").ToList();
                    var selectedFacilityGroup = AnimalsInFacility.GroupBy(a => a.Type).ToList();

                    for (int i = 0; i < selectedFacilityGroup.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {selectedFacilityGroup[i].Key} ({selectedFacilityGroup[i].Count()})");
                    }

                    Console.WriteLine();

                    // How can I output the type of plant chosen here?

                    Console.WriteLine($"What animal to process?");
                    Console.Write("> ");
                    int animalChoice = Int32.Parse(Console.ReadLine());
                    animalChoice--;

                    Console.WriteLine($"How many animals to process?");
                    Console.Write("> ");
                    int animalNumber = Int32.Parse(Console.ReadLine());

                    if ( (meatProcessor.GetFreeCapacity() >= animalNumber) && (selectedFacilityGroup[animalChoice].Count() >= animalNumber))
                    {
                        for (int i = 0; i < animalNumber; i++)
                        {
                            Console.WriteLine(selectedFacilityGroup[animalChoice].Last().ToString());
                            meatProcessor.AddResource(selectedFacilityGroup[animalChoice].Last());
                            AnimalsInFacility.Remove(AnimalsInFacility.Last(p => p.Type == selectedFacilityGroup[animalChoice].Key));
                        }
                        Console.WriteLine("Do you want to add more? Y/N");
                        answer = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input (capacity or animals number). Processing current resource.");
                        Console.ReadLine();
                        answer = "N";
                    }
                }
                else
                {
                    Console.WriteLine("no animals in field, processing everything in processor");
                    Console.ReadLine();
                    answer = "N";
                }
            } while (answer.ToUpper() == "Y");

            meatProcessor.Process(farm);
            Console.ReadLine();
        }
    }
}