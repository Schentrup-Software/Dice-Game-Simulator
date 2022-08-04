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

        public IEnumerable<int> ChooseDice(int currentScore, int currentBestScore, IEnumerable<int> givenDice)
        {
            var diceToKeep = new List<int>();
            var givenDiceList = givenDice.ToList();

            foreach (var dice in givenDiceList)
            {
                if (dice == 0 || (dice < 2 && givenDiceList.Count <= DiceLeft && (dice + currentScore) < currentBestScore))
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

        public int CompareTo(object? obj)
        {
            if (obj is not IDiceStrategy)
            {
                return 1;
            }
            var newobj = (IDiceStrategy)obj;
            return Name.CompareTo(newobj?.Name);
        }
    }
}
