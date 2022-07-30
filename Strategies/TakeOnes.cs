using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameSimulator.Strategies
{
    public class TakeOnes : IDiceStrategy
    {
        public string Name { get; set; }
        public int DiceLeft { get; set; }

        public TakeOnes(string name, int diceLeft)
        {
            Name = name;
            DiceLeft = diceLeft;
        }

        public IEnumerable<int> ChooseDice(IEnumerable<int> givenDice)
        {
            var diceToKeep = new List<int>();
            var givenDiceList = givenDice.ToList();

            foreach (var dice in givenDiceList)
            {
                if (dice < 2 && givenDiceList.Count <= DiceLeft)
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
