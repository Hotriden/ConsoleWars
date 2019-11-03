using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        public IRepository<HeroFeature> Features => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
