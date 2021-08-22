using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestAPI.Common;

namespace TechnicalTestAPI.Data.Model
{
   public class RouletteModel
    {
        public string Id { get; set; }
        public RouletteStatus State { get; set; }
        public RoulettePositionModel[] Positions { get; set; }
    }
}
