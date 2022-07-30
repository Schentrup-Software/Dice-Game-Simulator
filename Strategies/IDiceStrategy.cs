using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameSimulator.Strategies
{
    public interface IDiceStrategy
    {
        public string Name { get; set; }

        public IEnumerable<int> ChooseDice(IEnumerable<int> givenDice); 
    }
}
