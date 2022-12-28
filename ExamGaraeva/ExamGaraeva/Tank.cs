using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGaraeva
{
    class Tank : Unit
    {
        public Tank(string name, int health) : base(name, health)
        {
        }

        public void Bury() { }
        public void HealthPlus() { }
    }
}
