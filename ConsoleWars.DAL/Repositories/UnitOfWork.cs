using ConsoleWars.DAL.EF;
using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private HeroContext context;
        private HeroFeatureRepository heroRepository;

        public IRepository<HeroFeature> Features
        {
            get
            {
                if(heroRepository == null)
                {
                    heroRepository = new HeroFeatureRepository(context);
                }
                return heroRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
