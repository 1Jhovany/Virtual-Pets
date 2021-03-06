using System;
using System.Collections.Generic;
using System.Threading;

namespace VirtualPet
{
    class Program
    {
        public static Shelter MyShelter;
        public static Pet MyPet;
        public static Timer timer;
        static void Main(string[] args)
        {

            MyShelter = new Shelter();
            Console.WriteLine("Welcome to the Shelter!");
            bool Menu = true;


            while (Menu)
            {
                Console.Clear();
                Console.WriteLine("How can we help you today?");
                Console.WriteLine("Please select one of the following: ");

                Console.WriteLine("1.Admit a pet");
                Console.WriteLine("2.Check status of a pet");
                Console.WriteLine("3.Interact with a pet");
                Console.WriteLine("4.Interact with multiple pets");
                Console.WriteLine("5.Adopt a pet");
                Console.WriteLine("6.Leave the shelter");



                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        MyPet = NewPet();
                        MyShelter.AddPet(MyPet);
                        //NewPet needs to go into the pet list
                     
                        if(timer == null)
                        {
                            timer = new Timer(Tick, null, 0, 2000);
                        }
                        break;
                    case "2":
                        MyPet = MyShelter.PetChoiceList();
                        MyPet.GetStatus();
                        //print list of all pets in shelter and give the option to choose 

                        break;
                    case "3":
                        PetInteractions();
                        // print list of all pets in shelter and give option to interact with 1 or multiple pets
                        break;
                    case "4":
                        MultiPetInteractions();
                        break;
                    case "5":
                        AdoptPet();

                        break;
                    case "6":
                        Console.WriteLine("Thanks for visiting the shelter");
                        Console.WriteLine("Press any key to Exit the game");
                        Console.Clear();
                        Menu = false;

                        break;
                    default:
                        break;
                }
            }
        }
        static Pet NewPet()
        {
            Console.Clear();
            Console.WriteLine("What species is your pet?");
            string Species = Console.ReadLine();
            Console.WriteLine("What is the name of your pet?");
            string Name = Console.ReadLine();
            Console.WriteLine("Is your pet organic or robot");
            string TypeOfPet = Console.ReadLine();
            if (TypeOfPet == "robot" || TypeOfPet == "r")
            {
                Robot MyRobot = new Robot();
                MyRobot.Name = Name;
                MyRobot.Species = Species;
                return MyRobot;
            }
            else
            {
                return new Pet(Species, Name, TypeOfPet);
            }
            
          
        }




        static void AdoptPet()
        {
            MyPet = MyShelter.PetChoiceList();
            Console.Clear();
            Console.WriteLine("Would you like to adopt " + MyPet.Name + "?");
            Console.WriteLine("Press 1 for Yes \nPress 2 for No");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                MyShelter.AdoptPet(MyPet);
                Console.WriteLine("Enjoy your new pet!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Come back when you want to save a helpless animal");
            }
            else
            {
                Console.WriteLine("Please enter yes or no" );
            }

            Console.Read();


        }


        static void PetInteractions()
        {
            Console.Clear();
            Console.WriteLine("Choose a pet to interact with");
            MyPet = MyShelter.PetChoiceList();
            ListInteractions(MyPet);
        }

        static void MultiPetInteractions()
        {
            List<Pet> pets = MyShelter.PetChoiceMultiList();
            foreach (var p in pets)
            {
                ListInteractions(p);
            }
        }

        public static void ListInteractions(Pet p)
        {
            Console.ReadKey();
            Console.WriteLine("How would you like to interact with a pet today? ");
            Console.WriteLine("Enter 1 to play with the pet \nEnter 2 to feed the pet \nEnter 3 to take the pet to the doctor");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine(p.Name + " is " + p.GetBoredom() + "% bored");

                p.Play();

                Console.WriteLine(p.Name + " is playing");
                Console.WriteLine(p.Name + " is now " + p.GetBoredom() + "% bored");
                Console.Read();

            }
            else if (choice == 2)
            {
                Console.WriteLine(p.Name + "'s hunger level is at " + p.GetHunger() + "%");

                p.Feed();

                Console.WriteLine(p.Name + " is eating");
                Console.WriteLine(p.Name + " is now " + p.GetHunger() + "% hungry");
                Console.Read();

            }
            else if (choice == 3)
            {
                Console.WriteLine(p.Name + " is " + p.GetHealth() + "% healthy");

                p.SeeDoctor();

                Console.WriteLine(p.Name + " is getting checked out");
                Console.WriteLine(p.Name + " is now " + p.GetHealth() + "% healthy");
                Console.Read();

            }
            else
            {
                Console.WriteLine("Please choose option 1, 2 or 3");

                Console.Read();
            }
        }

        public static void Tick(Object o)
        {
            MyPet.Tick();
            foreach (var pet in MyShelter.ListOfPets)
            {
                pet.Tick();

            }
        }

    }
}

