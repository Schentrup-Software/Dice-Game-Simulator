using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameSimulator.Strategies
{
    public class OnlyTakeThrees : IDiceStrategy
    {
        public string Name { get; set; }

        public OnlyTakeThrees(string name)
        {
            Name = name;
        }

        public IEnumerable<int> ChooseDice(IEnumerable<int> givenDice)
        {
            var diceToKeep = new List<int>();

            foreach (var dice in givenDice)
            {
                if (dice == 0)
                {
                    diceToKeep.Add(dice);
                }
            }

            if (diceToKeep.Count == 0)
            {
                diceToKeep.Add(givenDice.Min());
            } 
            
            return diceToKeep;  
        }
    }
}
