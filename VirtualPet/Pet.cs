using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        private const int MAXHEALTH = 100;
        private const int MAXHUNGER = 100;
        private const int MAXBOREDOM = 100;

        public string TypeOfPet { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Hunger;
        public int Boredom;
        public int Health;


        public void Play()
        {
            SetHunger(Hunger += 10);
            SetBoredom(Boredom -= 20);
            SetHealth(Health - 20);


        }
        public void Feed()
        {
            SetHunger(Hunger -= 40);
            SetHealth(Health += 10);
        }
        public void SeeDoctor()
        {
            SetHealth(Health += 30);
        }
        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("");
        }
        public Pet(string species, string name, string typeOfPet)
        {
            TypeOfPet = typeOfPet;
            Name = name;
            Species = species;
            Hunger = 50;
            Boredom = 60;
            Health = 30;

        }

        public Pet()
        {
            Hunger = 50;
            Boredom = 60;
            Health = 30;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetSpecies(string species)
        {
            Species = species;
        }

        public string GetSpecies()
        {
            return Species;
        }

        public int GetHunger()
        {
            return this.Hunger;
        }
        public int GetHealth()
        {
            return this.Health;
        }
        public int GetBoredom()
        {
            return this.Boredom;
        }
        public void SetHealth(int health)
        {
            this.Health = Math.Max(0, Math.Min(MAXHEALTH, health));
        }
        public void SetHunger(int hunger)
        {
            this.Hunger = Math.Max(0, Math.Min(MAXHUNGER, hunger));
        }
        public void SetBoredom(int boredom)
        {
            this.Boredom = Math.Max(0, Math.Min(MAXBOREDOM, boredom));
        }

        public virtual void Tick()
        {
            SetHunger(Hunger += 5);
            SetBoredom(Boredom += 5);
            SetHealth(Health -= 5);
        }

        public virtual void GetStatus()  //Move to program.cs

        {

            Console.Clear();
            //Console.WriteLine(MyPet.Name + "'s current status:");
            Console.WriteLine("Hunger: " + GetHunger());
            Console.WriteLine("Boredom: " + GetBoredom());
            Console.WriteLine("Health: " + GetHealth());

            Console.Read();
          
        }


    }
}
