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

    public abstract class Hero : HeroFeatures, IHero
    {
        #region Events
        protected internal event HeroStateHandler Created;

        protected internal event HeroStateHandler Killed;

        protected internal event HeroStateHandler GotLevel;

        protected internal event HeroStateHandler MovedToDungeon;

        protected internal event HeroStateHandler HeroInfo;

        protected internal event HeroStateHandler Hited;

        protected internal event HeroStateHandler Attacked;
        #endregion

        static int _counter;

        Random random = new Random();

        public Hero(string nickName)
        {
            NickName = nickName;
            _counter++;
            Id = _counter;
            Experience = 0;
            Level = 1;
        }

        #region Methods
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
        #endregion

        #region Implement events
        public virtual void CreateHero()
        {
            Creating(new HeroEventArgs($"Character {NickName}, class {HeroType} created!", this.HealPoints, this.Experience));
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
            Killing(new HeroEventArgs($"Character {NickName}, has been slain. You lost 25% of experience", 0, this.Experience));
        }

        public virtual void LevelUp()
        {
            if (this.Experience >= ExperienceBar)
                Leveling(new HeroEventArgs($"Your character get level {Level}. Your features increased!", HealPoints, 0));
        }

        public virtual void MoveOnLevel()
        {
            MovingDungeon(new HeroEventArgs($"Your character come to dungeon", this.HealPoints, this.Experience));
        }

        public virtual void Hit()
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

        public virtual void GetDamage()
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
        #endregion
    }
}