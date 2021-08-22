using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.DTO;

namespace TechnicalTestAPI.Services
{
    public abstract class BaseService :IService
    {
        public BaseService()
        {

        }
        public abstract MapperConfiguration ConfigureMappings();
        public abstract Task<Guid> Create(int positions);
        public abstract void Update(Rulette rouletteGuid);
        public abstract Task<bool> BetToRoulette(Bet betData);
        public abstract Task<List<Rulette>> GetRulettes();
       
        
    }
}
