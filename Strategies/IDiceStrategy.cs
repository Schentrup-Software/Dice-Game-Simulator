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

        public IEnumerable<int> ChooseDice(int currentScore, int currentBestScore, IEnumerable<int> givenDice); 
    }
}
