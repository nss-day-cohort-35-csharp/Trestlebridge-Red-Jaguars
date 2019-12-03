using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. WildFlower");
            Console.WriteLine("2. Sesame");
            Console.WriteLine("3. Sunflower");

            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();

            try
            {

            switch (Int32.Parse(choice))
            {
                case 1:
                    ChooseNaturalField.CollectInput(farm, new WildFlower());
                    break;
                case 2:
                    ChoosePlowedField.CollectInput(farm, new Sesame());
                    break;
                case 3:
                    ChooseDualField.CollectInput(farm, new Sunflower());
                    break;

                default:
                    break;
            }
            } catch {
                Console.WriteLine("Incorrect Input, please hit any key to return to main menu");
                // Console.ReadLine();
            }
        }
    }
}