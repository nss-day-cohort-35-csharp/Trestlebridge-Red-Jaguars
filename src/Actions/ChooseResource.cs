using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Processors;


namespace Trestlebridge.Actions
{
    public class ChooseResource
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Seed Harvester");
            Console.WriteLine("2. Compost Harvester");

            Console.WriteLine("4. Chicken Harvester");

            Console.WriteLine();
            Console.WriteLine("Choose equipment to use");

            Console.Write("> ");
            try
            {
                string input = Console.ReadLine();
                switch (Int32.Parse(input))
                {
                    case 1:
                        SeedHarvester seedHarvester = new SeedHarvester();
                        ChoosePlowedFieldForSeed.CollectInput(farm, seedHarvester);
                        break;
                    case 2:
                        CompostHarvester compostHarvester = new CompostHarvester();
                        ChooseNaturalFieldForCompost.CollectInput(farm, compostHarvester);
                        break;
                    case 4:
                        MeatProcessor meatProcessor = new MeatProcessor();
                        ChooseChickenhouseForMeat.CollectInput(farm, meatProcessor);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Input, please hit any key to return to main menu");
                // Console.ReadLine();
            }
        }
    }
}