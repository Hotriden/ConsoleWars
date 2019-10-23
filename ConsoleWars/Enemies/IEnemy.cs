using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Enemies
{
    public interface IEnemy
    {
        void Hit();
        void Kill();
        void Die();
        void Greating();
        void GetDamage();
    }
}
