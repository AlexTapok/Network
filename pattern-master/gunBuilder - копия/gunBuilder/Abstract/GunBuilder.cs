using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gunBuilder.Gun;

namespace gunBuilder.Abstract
{
    abstract class GunBuilder
    {
        protected GUN Gun { get; private set; }
        public void CreateGun()
        {
            Gun = new GUN();
        }
        public GUN GetMyGun()
        {
            return Gun;
        }
        public abstract void SetName();
        public abstract void SetBarrel();
        public abstract void SetPriklad();
        public abstract void SetTrigger();
        public abstract void SetSight();
        public abstract void SetMagazine();

    }
}
