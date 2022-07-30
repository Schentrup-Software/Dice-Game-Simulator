using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameSimulator
{
    public record PlayerResult(string Name, string ClassName, IEnumerable<int> ChosenValues, int NumberOfRolls);

    public record GameResult(string WinnerName, string ClassName, IEnumerable<int> WinningValues);
}
