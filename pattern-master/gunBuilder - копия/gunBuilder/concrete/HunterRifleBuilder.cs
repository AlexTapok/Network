using gunBuilder.Abstract;
using gunBuilder.parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gunBuilder.concrete
{
    class HunterRifleBuilder : GunBuilder
    {
        public override void SetName()
        {
            Gun.name = "hr21m3";
        }
        public override void SetBarrel()
        {
            Gun.Barrel = new HunterBarrel()
            {
                cal = "12x70",
                model = "h21m1",
                weight = 1.2,
                matherial = "steel"
            };          
        }
        public override void SetPriklad()
        {
            Gun.Priklad = new HunterPriklad
            {
                matherial = "wood",
                weight = 0.7
            };
        }
        public override void SetSight()
        {
            Gun.Sight = new ColimatorSight
            {
                model = "b786a",
                multiplicity = "1x",
                weight = 0.5
            };
        }
        public override void SetTrigger()
        {
            Gun.Trigger = new SoftTrigger()
            {
                model = "st12",
                weight = 0.9
            };
        }
        public override void SetMagazine()
        {
            Gun.Magazin = new SmallMagazine
            {
                number_of_bulets = 5,
                weight = 0.3
            };
        }
    }
}
