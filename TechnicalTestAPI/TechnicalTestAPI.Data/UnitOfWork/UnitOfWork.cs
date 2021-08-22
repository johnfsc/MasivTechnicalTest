using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestAPI.Data.Repository;

namespace TechnicalTestAPI.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
		private IRouletteRepository _roulette;
        
		public IDatabase RedisDatabase { get; set; }

        public UnitOfWork()
        {
			InitRedisCache();
        }

		public IRouletteRepository Roulette
		{
			get
			{
				return _roulette ?? (_roulette = new RouletteRepository(RedisDatabase));
			}

		}

		public void InitRedisCache()
		{
			this.RedisDatabase = RedisConnectorHelper.GetConnection();
		}
	}
}

