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
    public class DapperRepository : IRepository<HeroFeature>
    {
        private HeroDapper dapper;

        public DapperRepository(string name)
        {
            dapper = new HeroDapper(name);
        }

        public void Create(HeroFeature item)
        {
            dapper.InsertHero(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HeroFeature Get(string nick)
        {
            return dapper.FindHero(nick);
        }

        public IEnumerable<HeroFeature> GetAll()
        {
            return dapper.GetHeroes();
        }

        public void Update(HeroFeature item)
        {
            throw new NotImplementedException();
        }
    }
}
