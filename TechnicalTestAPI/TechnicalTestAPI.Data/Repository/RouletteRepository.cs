using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestAPI.Common;
using TechnicalTestAPI.Data.Model;

namespace TechnicalTestAPI.Data.Repository
{
    public class RouletteRepository : IRouletteRepository
    {
        private IDatabase DatabaseInstance { get; set; }

        public RouletteRepository(IDatabase database)
        {
            this.DatabaseInstance = database;
        }

        public async Task<Guid> CreateAsync(RouletteModel _item)
        {
            Guid rouletteId = new Guid();
            string rouleteKey = $"Roulette_${rouletteId}";
            await DatabaseInstance.StringSetAsync(rouleteKey, Util.ConvertToJson(_item));
            return rouletteId;
        }

        public async Task<RouletteModel> GetByIdAsync(string id)
        {
            RouletteModel rouletteItem = null;
            var roulette=await DatabaseInstance.StringGetAsync(id);
            if (roulette!=default(RedisValue))
            {
                rouletteItem=(RouletteModel)Util.ConvertJsonToObjec(roulette.ToString());
            }
            return rouletteItem;
        }

        public async Task<RouletteModel> UpdateItemAsync(RouletteModel item)
        {
            RouletteModel rouletteToUpdate = null;
            var rouletteItem=DatabaseInstance.StringGet(item.Id);
            if(rouletteItem!=default(RedisValue))
            {
                rouletteToUpdate= (RouletteModel)Util.ConvertJsonToObjec(rouletteItem.ToString());
                rouletteToUpdate.State = item.State;
            }
            return rouletteToUpdate;
        }


        public async Task<List<RouletteModel>> GetItemsAsync()
        {
            var items = RedisConnectorHelper.RedisInstance.GetServer("localhost").Keys();
            string[] keysArr = items.Select(key => (string)key).ToArray();
            List<RouletteModel> roulettes = new List<RouletteModel>();
            foreach (string key in keysArr)
            {
                string rouletteItem=await DatabaseInstance.StringGetAsync(key);
                RouletteModel roulette= (RouletteModel)Util.ConvertJsonToObjec(rouletteItem.ToString());
                roulettes.Add(roulette);
            }
            return roulettes;
        }
    }
}
