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

        protected internal event HeroStateHandler GetLevel;

        protected internal event HeroStateHandler MovedToDungeon;

        protected internal event HeroStateHandler HeroInfo;

        private int _counter;

        public Hero(string nickName)
        {
            NickName = nickName;
            _counter++;
            Id = _counter;
            Experience = 0;
            Level = 1;
            IdentifyClass(HeroType);
        }

        public void IdentifyClass(HeroType heroType)
        {
            switch (heroType)
            {
                case HeroType.Mage:
                    Mana = 35;
                    Vitality = 20;
                    Strength = 20;
                    Agility = 25;
                    break;
                case HeroType.Rogue:
                    Mana = 15;
                    Vitality = 25;
                    Strength = 25;
                    Agility = 35;
                    break;
                case HeroType.Warrior:
                    Mana = 10;
                    Vitality = 35;
                    Strength = 35;
                    Agility = 20;
                    break;
            }
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

        public string HeroesInfo()
        {
            return($"Hero name: {NickName}\r\nClass: {HeroType}\r\nLevel: {Level}, Experience: {Experience}\r\nCurrent features:\r\nStrength: {Strength}\r\n" +
                $"Vitality{Vitality}\r\nAgility: {Agility}\r\nMana: {Mana}");
        }
    }
}
