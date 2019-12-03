using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseResource
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1.Seed Harvester");
           
      
            Console.WriteLine();
            Console.WriteLine("Choose equipment to use");

            Console.Write("> ");
            try 
            {
            string input = Console.ReadLine();
            switch (Int32.Parse(input))
            {
                case 1:
                  

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