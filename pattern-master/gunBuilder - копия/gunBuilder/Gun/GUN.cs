using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gunBuilder.Gun
{
    public class GUN
    {
        public string name { get; set; }
        public Barrel Barrel { get; set; }
        public Priklad Priklad { get; set; }
        public Sight Sight { get; set; }
        public Trigger Trigger { get; set; }
        public Magazin Magazin { get; set; }
    }
}
