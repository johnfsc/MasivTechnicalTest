using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestAPI.Data.Model;

namespace TechnicalTestAPI.Data.Repository
{
    public interface IRouletteRepository
    {
        Task<RouletteModel> GetByIdAsync(string id);
        Task<List<RouletteModel>> GetItemsAsync();
        Task<Guid> CreateAsync(RouletteModel _item);
        Task<RouletteModel> UpdateItemAsync(RouletteModel _item);
       
    }
}
