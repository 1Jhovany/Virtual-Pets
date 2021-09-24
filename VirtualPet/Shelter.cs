using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Shelter
    {
        public List<Pet> ListOfPets = new List<Pet>();

        public Shelter()
        {
        }
        public void PetsInShelter()
        {
            foreach (Pet MyPet in ListOfPets)
            {
                Console.WriteLine(MyPet.Name);
            }
        }
        public void AddPet(Pet o)
        {
            ListOfPets.Add(o);

        }

        public void PetInteract()
        {
           // ListOfPets
        }
        public void AdoptPet(Pet o)
        {
            ListOfPets.Remove(o);

            if (o.GetType() == typeof(Robot))
            {
                Console.WriteLine("Robot has been scrapped");
            }
            else if (o.GetType() == typeof(Pet))
            {
                Console.WriteLine("Pet has been adopted");
            }
        }

        public List<Pet> PetChoiceMultiList()
        {
            List<Pet> pets = new List<Pet>();
            Console.WriteLine("How many pets would you like to select?");
            int amount = Convert.ToInt32(Console.ReadLine());

            for(int i=1; i <= amount; i++)
            {
                Console.WriteLine("Enter pet " + i + " choice: ");
                var pet = PetChoiceList();
                pets.Add(pet);
            }

            return pets;
        }

        public Pet PetChoiceList()
        {
            int i = 1;
            foreach (Pet pet in ListOfPets)

            {
                Console.WriteLine(i + ". " + pet.Name + ", " + pet.Species);
                i++;
            }

            int selectedIndex = Convert.ToInt32(Console.ReadLine());

            return ListOfPets[selectedIndex-1];

        }
    }
}