using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGaraeva
{
    class Soldier : Unit
    {
        public Soldier(string name, int health) : base(name, health)
        {
        }

        public void Grenade() { }
    }
}
