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

        public List<HeroEntityDAL> GetHeroes()
        {
            using (IDbConnection connection = new SqlConnection(DapperHelper.CnnVal(DbName)))
            {
                connection.Open();
                return connection.Query<HeroEntityDAL>("SELECT * FROM Features").ToList();
            }
        }

        public void InsertHero(HeroEntityDAL hero)
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

        public HeroEntityDAL FindHero(string nickName)
        {
            using(IDbConnection connection = new SqlConnection(DapperHelper.CnnVal(DbName)))
            {
                connection.Open();
                var result = connection.Query<HeroEntityDAL>($"SELECT NickName, HeroType, IsAlive, Strength, Vitality," +
                    $"HealPoints, Agility, Mana, Level, Experience, ExperienceBar, Damage FROM dbo.Features WHERE NickName='{nickName}'").FirstOrDefault();
                return result;
            }
        }
    }
}
