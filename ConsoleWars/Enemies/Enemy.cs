using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Enemies
{
    abstract class Enemy : EnemyFeatures, IEnemy
    {
        Random random = new Random();
        public void Create()
        {
            Console.WriteLine($"{this.ToString()} was created");
        }

        public void Die()
        {
            Console.WriteLine($"{this.ToString()} has been slain. You gained {this.GainExperience} experience!");
        }

        public void Hit()
        {
            int rand = random.Next(25, 75);
            Console.WriteLine($"{this.ToString()} dealed {this.Damage + this.Damage * rand/100}");
        }

        public override string ToString()
        {
            return this.GetType().ToString();
        }
    }
}
