using ConsoleWars.DAL.EF;
using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Repositories
{
    class HeroEFRepository : IRepository<HeroFeature>
    {
        private HeroContext _heroContext;

        public HeroEFRepository(HeroContext heroContext)
        {
            _heroContext = heroContext;
        }

        public void Create(HeroFeature item)
        {
            _heroContext.Features.Add(item);
        }

        public void Delete(int id)
        {
            HeroFeature heroFeature = _heroContext.Features.Find(id);
            if (heroFeature != null)
                _heroContext.Features.Remove(heroFeature);
        }

        public HeroFeature Get(string nick)
        {
            return _heroContext.Features.Find(nick);
        }

        public IEnumerable<HeroFeature> GetAll()
        {
            return _heroContext.Features;
        }

        public void Update(HeroFeature item)
        {
            _heroContext.Entry(item).State = EntityState.Modified;
        }
    }
}
