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
        private string DbName;

        public HeroDapper(string db)
        {
            DbName = db;
        }

        public List<HeroFeature> GetHeroes()
        {
            using (IDbConnection connection = new SqlConnection(DapperHelper.CnnVal(DbName)))
            {
                connection.Open();
                return connection.Query<HeroFeature>("SELECT * FROM Features").ToList();
            }
        }

        public void InsertHero(HeroFeature hero)
        {
            using (IDbConnection connection = new SqlConnection(DapperHelper.CnnVal(DbName)))
            {
                string query = "INSERT INTO dbo.Features" +
                    "(NickName, HeroType, IsAlive, Strength, Vitality, HealPoints, Agility, " +
                    "Mana, Level, Experience, ExperienceBar, Damage) VALUES " +
                    "(@NickName, @HeroType, @IsAlive, @Strength, @Vitality," +
                    " @HealPoints, @Agility, @Mana, @Level, @Experience, @ExperienceBar, @Damage)";
                connection.Execute(query, hero);
            }
        }

        public HeroFeature FindHero(string nickName)
        {
            using(IDbConnection connection = new SqlConnection(DapperHelper.CnnVal(DbName)))
            {
                connection.Open();
                return connection.Query<HeroFeature>("SELECT NickName, HeroType, Level FROM Features WHERE NickName='nickName'").SingleOrDefault();
            }
        }
    }
}
