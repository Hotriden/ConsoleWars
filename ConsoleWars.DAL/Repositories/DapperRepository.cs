using ConsoleWars.DAL.Dapper;
using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Repositories
{
    public class DapperRepository : IRepository<HeroEntityDAL>
    {
        private HeroDapper dapper;

        public DapperRepository(string name)
        {
            dapper = new HeroDapper(name);
        }

        public void Create(HeroEntityDAL item)
        {
            dapper.InsertHero(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HeroEntityDAL Get(string nick)
        {
            return dapper.FindHero(nick);
        }

        public IEnumerable<HeroEntityDAL> GetAll()
        {
            return dapper.GetHeroes();
        }

        public void Update(HeroEntityDAL item)
        {
            throw new NotImplementedException();
        }
    }
}
