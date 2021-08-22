using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestAPI.Common;

namespace TechnicalTest.DTO
{
   public class Rulette
    {
        public int Id { get; set; }
        public RouletteStatus State { get; set; }
        public RulettePosition[] Positions{ get; set; }

        public Rulette(Int32 positions)
        {
            Positions = new RulettePosition[positions];
            for (int i = 0; i < Positions.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    Positions[i] = new RulettePosition(){Number = (i + 1), Color = RouletteColor.Red};
                }
                else
                {
                    Positions[i] = new RulettePosition() { Number = (i + 1), Color = RouletteColor.Black };
                }
            }
        }

    }
}
