using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Mapper
{
    public class HeroMapper<K, T> where T : class where K : class
    {
        public T MapperMethod(K arg)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<K, T>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<K, T>(arg);
        }
    }
}
