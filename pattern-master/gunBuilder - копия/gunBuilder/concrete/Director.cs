using gunBuilder.Abstract;
using gunBuilder.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gunBuilder.concrete
{
    class Director
    {
        private GunBuilder _gunBuilder;
        public void SetGunBuilder(GunBuilder gBuilder)
        {
            _gunBuilder = gBuilder;
        }
        public GUN GetGun()
        {
            return _gunBuilder.GetMyGun();
        }
        public void ConstructGun()
        {
            _gunBuilder.CreateGun();
            _gunBuilder.SetName();
            _gunBuilder.SetBarrel();
            _gunBuilder.SetPriklad();
            _gunBuilder.SetSight();
            _gunBuilder.SetTrigger();
            _gunBuilder.SetMagazine();
        }
    }
}
