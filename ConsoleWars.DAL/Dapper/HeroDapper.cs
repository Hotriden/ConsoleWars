using ConsoleWars.DAL.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Dapper
{
    public class HeroDapper
    {
        public List<HeroFeature> GetHeroes()
        {
            using (IDbConnection connection = new SqlConnection(DapperHelper.CnnVal("ConsoleWars.HeroModel")))
            {
                connection.Open();
                return connection.Query<HeroFeature>("SELECT * FROM Features").ToList();
            }
        }

        public void InsertHero(HeroFeature hero)
        {
            List<HeroFeature> heroes = new List<HeroFeature>();
            heroes.Add(new HeroFeature{ Agility=hero.Agility, Damage=hero.Damage, Experience = hero.Experience,
            ExperienceBar = hero.ExperienceBar, HealPoints=hero.HealPoints, HeroType=hero.HeroType, Id=hero.Id,
            IsAlive=hero.IsAlive, Level=hero.Level, Mana=hero.Mana, NickName=hero.NickName, Strength=hero.Strength,
            Vitality=hero.Vitality});

            using (IDbConnection connection = new SqlConnection(DapperHelper.CnnVal("HeroContext")))
            {
                connection.Execute("dbo.Features_Insert @Agility, @Damage, @Experience, @ExperienceBar, @HealPoints," +
                    "@HeroType, @Id, @IsAlive, @Level, @Mana, @NickName, @Strenght, @Vitality", heroes);
            }
        }
    }
}
