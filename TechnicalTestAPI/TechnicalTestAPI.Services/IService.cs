using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.DTO;

namespace TechnicalTestAPI.Services
{
    public interface IService
    {
        public abstract Task<Guid> Create(Int32 positions);
        public abstract void Update(Rulette rouletteGuid);
        public abstract Task<bool> BetToRoulette(Bet bettingData);
        public abstract Task<List<Rulette>> GetRulettes();

    }
}
