using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Enemies
{
    public abstract class Enemy : EnemyFeature, IEnemy
    {
        public void Die()
        {
            throw new NotImplementedException();
        }

        public void GetDamage()
        {
            throw new NotImplementedException();
        }

        public void Greating()
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }
    }
}
