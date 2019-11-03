using ConsoleWars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<HeroFeature> Features { get; }
        void Save();
    }
}
