using System;

namespace JurasicPark
{
    class Dinosaur
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dino Time");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(A)dd a dinosaur, (V)iew all dinosaurs, (R)emove a dinosaur, (T)ransfer a dinosaur, see a (S)ummary, or (Q)uit.");
            var choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "A":
                    Console.WriteLine("Add dino");
                    break;
                case "V":
                    Console.WriteLine("View dino");
                    break;
                case "R":
                    Console.WriteLine("Remove dino");
                    break;
                case "T":
                    Console.WriteLine("Transfer dino");
                    break;
                case "S":
                    Console.WriteLine("Summary dino");
                    break;
                case "Q":
                    Console.WriteLine("Quit");
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;

            }

        }
    }
}
