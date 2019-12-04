using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Utils.Clear();
    var filterGrazingField = farm.GrazingFields.Where(field => field.IsSpaceAvailable() > 0).ToList();
            for (int i = 0; i < filterGrazingField.Count; i++)
            {
           
                    Console.WriteLine($"{i + 1}. Grazing Field ({filterGrazingField[i].AnimalsInFacility()} Animal(s) in the fields)");
                    filterGrazingField[i].AnimalGroups();
        
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            filterGrazingField[choice - 1].AddResource(animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}