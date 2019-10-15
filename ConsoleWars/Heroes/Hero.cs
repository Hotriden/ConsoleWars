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

    public abstract class Hero:Features
    {
        protected internal event HeroStateHandler Created;

        protected internal event HeroStateHandler Killed;

        protected internal event HeroStateHandler GotLevel;

        protected internal event HeroStateHandler MovedToDungeon;

        protected internal event HeroStateHandler HeroInfo;

        protected internal event HeroStateHandler Hited;

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

        protected virtual void OnCreated(HeroEventArgs e)
        {
            CallEvent(e, Created);
        }

        protected virtual void OnKilled(HeroEventArgs e)
        {
            CallEvent(e, Killed);
        }

        protected virtual void GetLevel(HeroEventArgs e)
        {
            CallEvent(e, GotLevel);
        }

        protected virtual void MoveDungeon(HeroEventArgs e)
        {
            CallEvent(e, MovedToDungeon);
        }

        protected virtual void Hit(HeroEventArgs e)
        {
            CallEvent(e, Hited);
        }

        public string HeroesInfo()
        {
            return($"Hero name: {NickName}\r\nClass: {HeroType}\r\nLevel: {Level}, Experience: {Experience}\r\nCurrent features:\r\nStrength: {Strength}\r\n" +
                $"Vitality{Vitality}\r\nAgility: {Agility}\r\nMana: {Mana}");
        }

        protected internal virtual void HeroCreated()
        {
            OnCreated(new HeroEventArgs($"Character {NickName}, class {HeroType} created!", this.HealPoints, this.Experience));
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
            OnKilled(new HeroEventArgs($"Character {NickName}, has been slain. You lost 25% of experience", 0, this.Experience));
        }

        protected internal void LevelUp()
        {
            if (this.Experience >= ExperienceBar)
                GetLevel(new HeroEventArgs($"Your character get level {Level}. Your features increased!", HealPoints, 0));
        }

        protected interface void MoveForExp()
        {
            MovedToDungeon(th)
        }
    }
}
