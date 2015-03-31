using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using gunBuilder.Abstract;
using gunBuilder.concrete;
using gunBuilder.Gun;
using gunBuilder.parts;
 

namespace gunBuilder
{


    class Program
    {


       
        static void Main(string[] args)
        {
            var hunterBuilder = new HunterRifleBuilder();
            var shopForYou = new Director();
            
            shopForYou.SetGunBuilder(hunterBuilder);
            shopForYou.ConstructGun();
            
            GUN gun = shopForYou.GetGun();
            Show(gun);
          
        }
        public static void Show(GUN gun)
        {
            string Barell = "Cal: " + gun.Barrel.cal + "\nMatherial: " + gun.Barrel.matherial + "\nModel: " + gun.Barrel.model + "\n";
            string Priklad = "Matherial: " + gun.Priklad.matherial + "\n";
            string Trigger = "Model: " + gun.Trigger.model + "\n";
            string Sight = "Model: " + gun.Sight.model + "\n";
            string Magazine = "Number of bullets: " + gun.Magazin.number_of_bulets + "\n";
            double RifleWeight = (gun.Barrel.weight + gun.Priklad.weight + gun.Trigger.weight + gun.Sight.weight + gun.Magazin.weight);
            Console.WriteLine(gun.name + ":\n" + Barell + Priklad + Trigger + Sight + Magazine + "Rifle weight: " + RifleWeight + "kg\n");
        }
    }
    
}
