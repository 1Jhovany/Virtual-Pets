using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Robot : Pet
    {
        public string OilType { get; set; }
        public DateTime LastMaintenance { get; set; }

        public int Battery()
        {
            return GetHealth();
        }
        public void ChargeLvl()
        {
            Hunger += 5;
            Boredom -= 5;
        }
        public void Oil()
        {
            Boredom += 5;
            Hunger += 5;
            Health += 10;
        }
        public void Hack()
        {
            Boredom -= 10;
            Health -= 5;
        }

        public override void Tick()
        {
            //base.Tick();
            ChargeLvl();
        }

        public override void GetStatus()
        {
            Console.WriteLine("ChargeLvl: " + GetHunger());
            Console.WriteLine("SleepMode: " + GetBoredom());
            Console.WriteLine("Oil" + GetHealth());
        }
    } 
}