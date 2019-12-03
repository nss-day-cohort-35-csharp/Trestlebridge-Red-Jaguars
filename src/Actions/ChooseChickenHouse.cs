using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, Chicken animal)
        {
            Utils.Clear();
          var filterChickenHouse = farm.ChickenHouses.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterChickenHouse.Count; i++)
            {
           
                    Console.WriteLine($"{i + 1}. Chicken House ({filterChickenHouse[i].AnimalsInFacility()} Chicken(s) in the house)");
                    // filterChickenHouse[i].AnimalGroups();
                
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the chicken where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            filterChickenHouse[choice - 1].AddResource(animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<Chicken>(animal, choice);

        }
    }
}