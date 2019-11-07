using ConsoleWars.DAL.Interfaces;
using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleWars.DAL.Entities;
using ConsoleWars.DAL.Repositories;
using ConsoleWars.DAL.Dapper;
using ConsoleWars.Mapper;

namespace ConsoleWars.Game
{
    public class Menu
    {
        private IRepository<HeroFeature> repository;
        private HeroMapper<HeroFeature, Features> mapperToFeatures;
        private HeroMapper<Features, HeroFeature> mapperToHeroFeatures;
        public Menu(string dbName)
        {
            repository = new DapperRepository(dbName);
            mapperToHeroFeatures = new HeroMapper<Features, HeroFeature>();
            mapperToFeatures = new HeroMapper<HeroFeature, Features>();
        }

        internal void ChooseHero(string nickname, ConsoleWarsStateHandler created, 
            ConsoleWarsStateHandler killed, ConsoleWarsStateHandler gotLevel, 
            ConsoleWarsStateHandler moveToDung, ConsoleWarsStateHandler hited,
            ConsoleWarsStateHandler attacked, ConsoleWarsStateHandler heroInfo)
        {
            //Features hero = new WarriorHero(nickname);

            //if (nickname == null)
            //    throw new Exception("Error! Hero doesn't exist!");
            //else if(repository.Get(nickname)!=null)
            //{
            //    throw new Exception("Hero with such nickname doesn't exist");
            //}
            //else
            //{
            //    hero = mapperToFeatures.MapperMethod(((repository.Get(nickname))));
            //}

            //hero.Created += created;
            //hero.Attacked += attacked;
            //hero.GotLevel += gotLevel;
            //hero.HeroInfo += heroInfo;
            //hero.Hited += hited;
            //hero.Killed += killed;
            //hero.MovedToDungeon += moveToDung;
        }

        internal IEnumerable<HeroFeature> AllCharacters()
        {
            return repository.GetAll();
        }

        internal Features FindCharacter(string nickName)
        {
            return mapperToFeatures.MapperMethod(((repository.Get(nickName))));
        }

        internal string NewHero(Features hero)
        {
            if (repository.Get(hero.NickName) != null)
            {
                return "Character with such nickname already exist.\r\nTry to choose another one";
            }
            else
            {
                repository.Create(mapperToHeroFeatures.MapperMethod((hero)));
                return "Character successful created";
            }
        }
    }
}
