using System;
using System.Collections.Generic;
using Kneat.Business;
using Kneat.Domain;
using static Kneat.Helper.CustomExceptions;

namespace Kneat.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nWelcome!");
                Console.WriteLine("The purpose of this application is to calculate the amount of stops to resupply");
                Console.WriteLine("all starships needs to travel some distance in mega lights.");

                do
                {
                    Console.WriteLine("\nPlease, type the distance in mega lights!");

                    double distanceInMGLT = CalculateMGLT.ValidMGLTInput(Console.ReadLine());

                    Console.WriteLine("\nGood Job! Now I'll get all the starships available...");
                    Console.WriteLine("=================================================================\n");
                    System.Threading.Thread.Sleep(1000);

                    List<StarshipModel> starships = Starship.GetStarshipsAsync();
                    int Id = 1;

                    System.Threading.Thread.Sleep(3000);

                    Console.WriteLine("\n{0,5} | {1,-30}| {2,1}", "Id", "Name", "Amount of Stops");
                    starships.ForEach((starship) =>
                    {
                        if (starship.Consumables != "unknown" && starship.MGLT != "unknown")
                        {
                            if (CalculateMGLT.ValidateConsumable(starship.Consumables))
                            {
                                starship.ConsumablesInHours = CalculateMGLT.ConsumablesToHours(starship.Consumables);
                                starship.AmountOfStops = CalculateMGLT.CalculateAmountOfStops(
                                    distanceInMGLT, Convert.ToInt32(starship.MGLT), starship.ConsumablesInHours);
                            }
                        }

                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("{0, 5} | {1,-30}| {2,1}",
                            Id++, starship.Name,
                            starship.AmountOfStops != null ? starship.AmountOfStops.ToString() : "unknown");
                    });

                    Console.WriteLine("\nThat's all! If you'd like to exit the application, press ESC, or press another key to try again!");
                    Console.WriteLine("=================================================================\n");

                    
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                Console.WriteLine("\nThanks!");
                Console.WriteLine("Closing the application...");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("=================================================================\n");

                if (ex is InputNegativeValueException || ex is InputNotANumberException)
                {
                    Console.WriteLine("Try again!");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Main(args);
                }
            }
        }
    }
}
