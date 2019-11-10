using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Interfaces;
using ConsoleWars.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Ninject
{
    class NinjectService : NinjectModule
    {
        private string connectionString;
        public NinjectService(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public override void Load()
        {
            Bind<IRepository<HeroEntityDAL>>().To<DapperRepository>().WithConstructorArgument(connectionString);
        }
    }
}
