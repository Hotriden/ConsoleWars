using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Handlers
{
    public delegate void ConsoleWarsStateHandler(object s, ConsoleWarsEventArgs e);

    public class ConsoleWarsEventArgs
    {
        public string Message { get; private set; }

        public int Heals { get; private set; }

        public int Experience { get; private set; }

        public ConsoleWarsEventArgs(string mes, int heals, int exp)
        {
            Message = mes;
            Heals = heals;
            Experience = exp;
        }
    }
}
