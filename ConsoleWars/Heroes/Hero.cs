using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    public enum HeroType
    {
        Warrior,
        Mage,
        Rogue
    }

    public enum Weapons
    {
        Sword,
        Axe,
        Staff,
        Dagger,
        Mace
    }

    public abstract class Hero : Features
    {
        Random random = new Random();

        protected internal event HeroStateHandler Created;

        protected internal event HeroStateHandler Killed;

        protected internal event HeroStateHandler GotLevel;

        protected internal event HeroStateHandler MovedToDungeon;

        protected internal event HeroStateHandler HeroInfo;

        protected internal event HeroStateHandler Hited;

        protected internal event HeroStateHandler Attacked;

        private int _counter;

        public Hero(string nickName)
        {
            NickName = nickName;
            _counter++;
            Id = _counter;
            Experience = 0;
            Level = 1;
        }

        private void CallEvent(HeroEventArgs e, HeroStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }

        protected virtual void Creating(HeroEventArgs e)
        {
            CallEvent(e, Created);
        }

        protected virtual void Killing(HeroEventArgs e)
        {
            CallEvent(e, Killed);
        }

        protected virtual void Leveling(HeroEventArgs e)
        {
            CallEvent(e, GotLevel);
        }

        protected virtual void MovingDungeon(HeroEventArgs e)
        {
            CallEvent(e, MovedToDungeon);
        }

        protected virtual void Hitting(HeroEventArgs e)
        {
            CallEvent(e, Hited);
        }

        protected virtual void Attacking(HeroEventArgs e)
        {
            CallEvent(e, Attacked);
        }

        public string HeroesInfo()
        {
            return ($"Hero name: {NickName}\r\nClass: {HeroType}\r\nLevel: {Level}, Experience: {Experience}\r\nCurrent features:\r\nStrength: {Strength}\r\n" +
                $"Vitality{Vitality}\r\nAgility: {Agility}\r\nMana: {Mana}");
        }

        protected internal virtual void HeroCreated()
        {
            Creating(new HeroEventArgs($"Character {NickName}, class {HeroType} created!", this.HealPoints, this.Experience));
        }

        protected internal virtual void HeroKilled()
        {
            if (this.Experience <= ExperienceBar)
            {
                this.Experience = 0;
            }
            else
            {
                this.Experience = this.Experience - ExperienceBar / 4;
            }
            Killing(new HeroEventArgs($"Character {NickName}, has been slain. You lost 25% of experience", 0, this.Experience));
        }

        protected internal void LevelUp()
        {
            if (this.Experience >= ExperienceBar)
                Leveling(new HeroEventArgs($"Your character get level {Level}. Your features increased!", HealPoints, 0));
        }

        protected internal virtual void MoveForExp()
        {
            MovingDungeon(new HeroEventArgs($"Your character come to dungeon", this.HealPoints, this.Experience));
        }

        protected internal virtual void DoHit()
        {
            int rand = random.Next(0, 100);
            if (rand >= 50)
            {
                Hitting(new HeroEventArgs($"{NickName} dealed {Damage * 1.5} damage", this.HealPoints, this.Experience));
            }
            else
            {
                Hitting(new HeroEventArgs($"{NickName} dealed {Damage} damage", this.HealPoints, this.Experience));
            }
        }

        protected internal virtual void GetAttack()
        {
            int rand = random.Next(0, 100);
            if (rand >= 50)
            {
                Attacking(new HeroEventArgs($"{NickName} got {Damage * 1.5} damage", this.HealPoints-(int)(Damage*1.5), this.Experience));
            }
            else
            {
                Attacking(new HeroEventArgs($"{NickName} got {Damage} damage", this.HealPoints-(int)Damage, this.Experience));
            }
        }
    }
}
