using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Actions
{
    public class ChooseChickenhouseForMeat
    {
        public static void CollectInput(Farm farm, MeatProcessor meatprocessor)
        {
            var answer = "";
            do
            {

                Utils.Clear();

                var filterChickenHouse = farm.ChickenHouses.Where(house => house.AnimalsInFacility() > 0).ToList();
                if (filterChickenHouse.Count > 0)
                {
                    for (int i = 0; i < filterChickenHouse.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Chicken House ({filterChickenHouse[i].AnimalsInFacility()} Animal(s) in the House)");
                        
                    }

                    Console.WriteLine();

                    // How can I output the type of animal chosen here?
                    Console.WriteLine($"What house to start the killing?");

                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());
                    Utils.Clear();
                    // Console.Write("Heres are the animals in your chosen house");
                    // Console.WriteLine();
                    var animalsInFacility = filterChickenHouse[choice - 1]._animals;
                    //dont need groupby with chicken or duck houses
                    //var selectedFacilityGroup = animalsInFacility.GroupBy(g => g.Type).ToList();

                    /*foreach (var animal in selectedFacilityGroup)
                    {
                        Console.WriteLine($"This field has {animal.Count()} {animal.Key}(s)");
                    }*/

                    // for (int i = 0; i < animalsInFacility.Count; i++)
                    // {
                    //     Console.WriteLine($"{i+1}. {selectedFacilityGroup[i].Key} ({selectedFacilityGroup[i].Count()})");
                    // }

                    // Console.WriteLine();

                    // How can I output the type of animal chosen here?

                    // Console.WriteLine($"What animal to process?");
                    // Console.Write("> ");
                    // int animalChoice = Int32.Parse(Console.ReadLine());
                    // animalChoice--;

                    Console.WriteLine($"How many animals to process?");
                    Console.Write("> ");
                    int animalNumber = Int32.Parse(Console.ReadLine());

                    if ( (meatprocessor.GetFreeCapacity() >= animalNumber) && (animalsInFacility.Count() >= animalNumber))
                    {
                        for (int i = 0; i < animalNumber; i++)
                        {
                            Console.WriteLine(animalsInFacility.Last().ToString());
                            meatprocessor.AddResource(animalsInFacility.Last());
                            animalsInFacility.Remove(animalsInFacility.Last());

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
                    Console.WriteLine("no animals in field, processing everything in harvester");
                    Console.ReadLine();
                    answer = "N";
                }
            } while (answer.ToUpper() == "Y");

            meatprocessor.Process(farm);
            Console.ReadLine();

            //animalsInFacility[animalChoice].Harvest();

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IPlowed>(animal, choice);

        }
    }
}
