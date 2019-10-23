using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    class Program
    {
        private IMagic Magic;

        public void SetMagic(IMagic magic)
        {
            Magic = magic;
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.InputYourMagic();
            Console.ReadKey();
        }

        public void InputYourMagic()
        {
            Program program = new Program();
            Console.WriteLine("Choose your magic!\r\n1 - WhiteMagic\r\n2 - BlackMagic");
            string input = Console.ReadLine();
            int result = Convert.ToInt32(input);
            if (result == 1)
            {
                program.SetMagic(new WhiteMagic());
                program.Magic.DoMagic();
            }
            else if (result == 2)
            {
                program.SetMagic(new BlackMagic());
                program.Magic.DoMagic();
            }
            else
            {
                Console.WriteLine("There is no magic here! Try again");
                InputYourMagic();
            }
        }
    }

    interface IMagic
    {
        void DoMagic();
    }

    public class BlackMagic : IMagic
    {
        public void DoMagic()
        {
            Console.WriteLine("It's time for black magic");
        }
    }

    public class WhiteMagic : IMagic
    {
        public void DoMagic()
        {
            Console.WriteLine("You shell not pass! It's white power");
        }
    }
}
