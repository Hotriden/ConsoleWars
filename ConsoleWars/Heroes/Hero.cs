using ConsoleWars.Commands;
using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    internal abstract class Hero : HeroEntity, IHero
    {
        #region Events
        protected internal event ConsoleWarsStateHandler Created;

        protected internal event ConsoleWarsStateHandler Killed;

        protected internal event ConsoleWarsStateHandler GotLevel;

        protected internal event ConsoleWarsStateHandler MovedToDungeon;

        protected internal event ConsoleWarsStateHandler HeroInfo;

        protected internal event ConsoleWarsStateHandler Hited;

        protected internal event ConsoleWarsStateHandler Attacked;
        #endregion

        private static int _counter;

        #region Methods
        private void CallEvent(ConsoleWarsEventArgs e, ConsoleWarsStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }

        protected virtual void Creating(ConsoleWarsEventArgs e)
        {
            CallEvent(e, Created);
        }

        protected virtual void Killing(ConsoleWarsEventArgs e)
        {
            CallEvent(e, Killed);
        }

        protected virtual void Leveling(ConsoleWarsEventArgs e)
        {
            CallEvent(e, GotLevel);
        }

        protected virtual void MovingDungeon(ConsoleWarsEventArgs e)
        {
            CallEvent(e, MovedToDungeon);
        }

        protected virtual void Hitting(ConsoleWarsEventArgs e)
        {
            CallEvent(e, Hited);
        }

        protected virtual void HeroInf(ConsoleWarsEventArgs e)
        {
            CallEvent(e, HeroInfo);
        }

        protected virtual void Attacking(ConsoleWarsEventArgs e)
        {
            CallEvent(e, Attacked);
        }

        public string HeroesInfo()
        {
            return ($"Hero name: {NickName}\r\nClass: {HeroType}\r\nLevel: {Level}, Experience: {Experience}\r\nCurrent features:\r\nStrength: {Strength}\r\n" +
                $"Vitality{Vitality}\r\nAgility: {Agility}\r\nMana: {Mana}");
        }
        #endregion

        #region Based implementation of events
        public virtual void CreateHero()
        {
            Creating(new ConsoleWarsEventArgs($"Character {NickName}, class {HeroType} created!", this.HealPoints, this.Experience, this.Damage));
        }

        public virtual void HeroKilled()
        {
            if (this.Experience <= ExperienceBar)
            {
                this.Experience = 0;
            }
            else
            {
                this.Experience = this.Experience - ExperienceBar / 4;
            }
            Killing(new ConsoleWarsEventArgs($"Character {NickName}, has been slain. You lost 25% of experience", 0, this.Experience, this.Damage));
        }

        public virtual void LevelUp()
        {
            if (this.Experience >= ExperienceBar)
                Leveling(new ConsoleWarsEventArgs($"Your character get level {Level}. Your features increased!", HealPoints, 0, this.Damage));
        }

        public virtual void MoveOnLevel()
        {
            MovingDungeon(new ConsoleWarsEventArgs($"Your character come to dungeon", this.HealPoints, this.Experience, this.Damage));
        }

        public virtual void Hit()
        {
            int rand = RandomGenerator.RandomMethod(0, 100);
            if (rand >= 50)
            {
                Hitting(new ConsoleWarsEventArgs($"{NickName} dealed {Damage * 1.5} damage", this.HealPoints, this.Experience, this.Damage));
            }
            else
            {
                Hitting(new ConsoleWarsEventArgs($"{NickName} dealed {Damage} damage", this.HealPoints, this.Experience, this.Damage));
            }
        }

        public virtual void GetDamage()
        {
            int rand = RandomGenerator.RandomMethod(0, 100);
            if (rand >= 50)
            {
                Attacking(new ConsoleWarsEventArgs($"{NickName} got {Damage * 1.5} damage", this.HealPoints-(int)(Damage*1.5), this.Experience, this.Damage));
            }
            else
            {
                Attacking(new ConsoleWarsEventArgs($"{NickName} got {Damage} damage", this.HealPoints-(int)Damage, this.Experience, this.Damage));
            }
        }
        #endregion
    }
}