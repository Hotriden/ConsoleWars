using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    public delegate void HeroStateHandler(object s, HeroEventArgs e);

    public class HeroEventArgs
    {
        public string Message { get; private set; }

        public int Heals { get; private set; }

        public int Experience { get; private set; }

        public HeroEventArgs(string mes, int heals, int exp)
        {
            Message = mes;
            Heals = heals;
            Experience = exp;
        }
    }
}
