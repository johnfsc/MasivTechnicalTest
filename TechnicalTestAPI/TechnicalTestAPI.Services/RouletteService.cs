using AutoMapper;
using System;
using System.Threading.Tasks;
using TechnicalTest.DTO;
using TechnicalTestAPI.Common;
using TechnicalTestAPI.Data.Model;
using TechnicalTestAPI.Data.Repository;
using TechnicalTestAPI.Data.UnitOfWork;
using System.Linq;
using System.Collections.Generic;

namespace TechnicalTestAPI.Services
{
    public class RouletteService:BaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        

        public RouletteService()
        {

        }

        public RouletteService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork; 
        }

        public override Task<Guid> Create(Int32 positions)
        {
            IMapper iMapper = ConfigureMappings().CreateMapper();
            var rouletteToCreate = new Rulette(positions);
            var itemInsert = iMapper.Map < Rulette, RouletteModel>(rouletteToCreate);
            return this.UnitOfWork.Roulette.CreateAsync(itemInsert);
        }

        public override MapperConfiguration ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RouletteModel, Rulette>();
                cfg.CreateMap<Rulette, RouletteModel>();
            });
            return config;
        }

        public override void Update(Rulette rulette)
        {
            IMapper iMapper = ConfigureMappings().CreateMapper();
            var itemUpdate = iMapper.Map<Rulette, RouletteModel>(rulette);
            this.UnitOfWork.Roulette.UpdateItemAsync(itemUpdate);
        }

        public async override Task<bool> BetToRoulette(Bet betData)
        {
            bool hasWonTheBet = false;
            var bettingRoulette= await this.UnitOfWork.Roulette.GetByIdAsync(betData.Roulette);
            if (bettingRoulette.State==Common.RouletteStatus.Open)
            {
                int number = Util.GetRandomNumber(bettingRoulette.Positions.GetLowerBound(0), bettingRoulette.Positions.GetUpperBound(0));
                var query= from p in bettingRoulette.Positions
                           where betData.Numbers.Select(t=>t.Number).Contains(number) && betData.Numbers.Select(t=>t.Color).Contains(bettingRoulette.Positions.ElementAt(number).Color)
                           select p;
                if(query.Any())
                {
                    hasWonTheBet=true;
                }
            }
            return hasWonTheBet;
        }

        public override async Task<List<Rulette>> GetRulettes()
        {
            var roulettes = await this.UnitOfWork.Roulette.GetItemsAsync();
            IMapper iMapper = ConfigureMappings().CreateMapper();
            var items = iMapper.Map<List<RouletteModel>, List<Rulette>>(roulettes);
            return items;
        }
    }
}
