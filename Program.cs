﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace JurasicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public string Description()
        {
            string desMartin = $"{Name} was acquired at {WhenAcquired}. It eats a {DietType} diet, weighs {Weight} pounds, and lives in enclosure {EnclosureNumber}.";
            return desMartin;
        }


    }
    class DinosaurDatabase
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();

        // If view
        // List all dinos
        public List<Dinosaur> GetAllDinosaurs()
        {
            return dinosaurs;
        }

        // If add
        // Ask for name, diet, weight, and enclosure
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            dinosaurs.Add(newDinosaur);
        }
        // If remove
        // Ask for name and remove
        public void RemoveDinosaur(string dinosaurToRemove)
        {
            dinosaurs.RemoveAll(dino => dino.Name == dinosaurToRemove);

        }

        // If transfer
        // Ask for name and where to go
        // and transfer
        // If summary
        // display carnivores and herbivores
        public void SummaryTime()
        {
            var numberOfCarnivores = dinosaurs.Count(dino => dino.DietType == "Carnivore");
            var numberOfHerbivores = dinosaurs.Count(dino => dino.DietType == "Herbivore");
            var numberLeftOver = dinosaurs.Count(dino => dino.DietType == "unknown");
            string theSummary = $"There are {numberOfCarnivores} carnivores and {numberOfHerbivores} herbivores (and {numberLeftOver} not known.)";
            Console.WriteLine(theSummary);
        }







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
        static int PromptForInt(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisInteger = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisInteger)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Not a valid answer. Entering 0.");
                return 0;
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
                Console.WriteLine("(V)iew all dinosaurs, (A)dd a dinosaur, (R)emove a dinosaur, (T)ransfer a dinosaur, see a (S)ummary of carnivores and herbivores, or (Q)uit.");
                var choice = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (choice)
                {
                    case "V":
                        Console.WriteLine("View dino");
                        var dinosaurs = database.GetAllDinosaurs();

                        foreach (var dino in dinosaurs)

                        {
                            Console.WriteLine();
                            // Console.WriteLine($"The dinosaur {dino.Name} eats a {dino.DietType} diet.");
                            // Console.WriteLine($"It weighs {dino.Weight} pounds and lives in Enclosure {dino.EnclosureNumber}.");
                            // Console.WriteLine($"It was acquired at {dino.WhenAcquired}.");
                            Console.WriteLine(dino.Description());

                        }
                        break;
                    case "A":
                        // Make a new dino object
                        var dinosaur = new Dinosaur();
                        // Ask for name, diet, weight, and enclosure
                        dinosaur.Name = PromptForName("What is the dinosaur's name? ");
                        dinosaur.DietType = PromptForDiet("Is the dinosaur a (C)arnivore or (H)erbivore? ");
                        dinosaur.Weight = PromptForInt("How much does the dinosaur weigh? ");
                        dinosaur.EnclosureNumber = PromptForInt("What enclosure will you put the dinosaur in? ");
                        dinosaur.WhenAcquired = DateTime.Now;
                        // Add it to the list
                        database.AddDinosaur(dinosaur);
                        break;
                    case "R":
                        //ask for name
                        Console.Write("Who would you like to remove? ");
                        string byeDino = Console.ReadLine();
                        //and remove
                        database.RemoveDinosaur(byeDino);
                        break;
                    case "T":
                        //ask for name and new enclosure
                        Console.Write("Who do you want to transfer? ");
                        string dinoToTransfer = Console.ReadLine();
                        int transferEnclosure = PromptForInt("To which enclosure? ");
                        //and transfer

                        break;
                    case "S":

                        database.SummaryTime();

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
