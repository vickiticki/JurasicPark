using System;
using System.Collections.Generic;
using System.Linq;


namespace JurasicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        // read up on datetime
        // public int Weight { get; set; }
        // public int EnclosureNumber { get; set; }

    }
    class DinosaurDatabase
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();

        // If view
        public List<Dinosaur> GetAllDinosaurs()
        {
            return dinosaurs;
        }
        // List all dinos
        // If add
        // Ask for name, diet, weight, and enclosure
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            dinosaurs.Add(newDinosaur);
        }
        // If remove
        // Ask for name and remove
        // If transfer
        // Ask for name and where to go
        // If summary
        // Ask for name and give summary


    }
    class Program
    {
        static string PromptForName(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;

        }
        static string PromptForDiet(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();
            //switch (userInput)
            switch (userInput)
            {
                case "C":
                    return "Carnivore";
                    break;
                case "H":
                    return "Herbivore";
                    break;
                default:
                    Console.WriteLine("Invalid food type");
                    return "unknown";
                    break;
            }


        }
        static void Main(string[] args)
        {
            var database = new DinosaurDatabase();

            Console.WriteLine("Dino Time");

            var keepGoing = true;

            while (keepGoing)
            {

                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(V)iew all dinosaurs, (A)dd a dinosaur, (R)emove a dinosaur, (T)ransfer a dinosaur, see a (S)ummary, or (Q)uit.");
                var choice = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (choice)
                {
                    case "V":
                        Console.WriteLine("View dino");
                        var dinosaurs = database.GetAllDinosaurs();

                        foreach (var dino in dinosaurs)
                        {
                            Console.WriteLine($"The dinosaur {dino.Name} has a diet of {dino.DietType}");
                        }
                        break;
                    case "A":
                        Console.WriteLine("Add dino");
                        // Make a new dino object
                        var dinosaur = new Dinosaur();
                        // Ask for name, diet, weight, and enclosure
                        dinosaur.Name = PromptForName("What is the dinosaur's name? ");
                        dinosaur.DietType = PromptForDiet("Is the dinosaur a (C)arnivore or (Herbivore)? ");
                        // Add it to the list
                        database.AddDinosaur(dinosaur);
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
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;

                }
            }

        }
    }
}
