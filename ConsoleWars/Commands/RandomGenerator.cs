﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Commands
{
    public static class RandomGenerator
    {
        public static int RandomMethod(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}