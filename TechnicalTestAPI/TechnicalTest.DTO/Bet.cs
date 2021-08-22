using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.DTO
{
    public class Bet
    {
        public decimal Money {  get; set; }
        public List<RulettePosition> Numbers {  get; set; }
        public string Roulette { get; set; }
    }
}
