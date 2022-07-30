
using DiceGameSimulator;
using DiceGameSimulator.Strategies;

// Setup

var dice = new[] { 1, 2, 0, 4, 5, 6 };

var players = new List<IDiceStrategy> {
    new TakeOnes("TakeOnes 0\t", 0),
    new TakeOnes("TakeOnes 1\t", 1),
    new TakeOnes("TakeOnes 2\t", 2),
    new TakeOnes("TakeOnes 3\t", 3),
    new TakeOnes("TakeOnes 4\t", 4),
    new TakeOnes("TakeOnes 5\t", 5),
    new TakeOnes("TakeOnes 6\t", 6),

    new TakeTwos("TakeTwos 2 1\t", 2, 1),
    new TakeTwos("TakeTwos 3 1\t", 3, 1),
    new TakeTwos("TakeTwos 4 1\t", 4, 1),
    new TakeTwos("TakeTwos 5 1\t", 5, 1),
    new TakeTwos("TakeTwos 6 1\t", 6, 1),

    new TakeTwos("TakeTwos 3 2\t", 3, 2),
    new TakeTwos("TakeTwos 4 2\t", 4, 2),
    new TakeTwos("TakeTwos 5 2\t", 5, 2),
    new TakeTwos("TakeTwos 6 2\t", 6, 2),

    new TakeTwos("TakeTwos 4 3\t", 4, 3),
    new TakeTwos("TakeTwos 5 3\t", 5, 3),
    new TakeTwos("TakeTwos 6 3\t", 6, 3),

    new TakeTwos("TakeTwos 5 4\t", 5, 4),
    new TakeTwos("TakeTwos 6 4\t", 6, 4),

    new TakeTwos("TakeTwos 6 5\t", 6, 5),
};

//Simulate

var gameResults = new List<GameResult>();

for (int i = 0; i < 100000; i++)
{

    var playerResults = players.Select(player => {
        var diceLeft = 5;
        var diceValuesKept = new List<int>();
        var numberOfRolls = 0;

        do
        {
            var roll = GetDiceValues(diceLeft);

            var diceKept = player.ChooseDice(roll).ToList();
            diceValuesKept.AddRange(diceKept);
            diceLeft -= diceKept.Count;

            numberOfRolls++;
        } while (diceLeft > 0);

        return new PlayerResult(player.Name, player.GetType().Name, diceValuesKept, numberOfRolls);
    });

    var minScore = int.MaxValue;
    PlayerResult? winner = null;

    foreach (var playerResult in playerResults)
    {
        var result = playerResult.ChosenValues.Aggregate((x, y) => x + y);
        if (result < minScore)
        {
            winner = playerResult;
            minScore = result;
        }
    }

    var gameResult = new GameResult(winner?.Name ?? "", winner?.ClassName ?? "", winner?.ChosenValues ?? Enumerable.Empty<int>());
    gameResults.Add(gameResult);

    //Console.WriteLine(gameResult.WinnerName + ": " + gameResult.WinningValues.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y));
    //Console.WriteLine("Total: " + gameResult.WinningValues.Aggregate((x, y) => x + y));
}

Console.WriteLine(gameResults.GroupBy(x => x.WinnerName).OrderBy(x => x.Count()).Select(x => x.Key + ": " + x.Count()).Aggregate((x, y) => x + "\n" + y));


IEnumerable<int> GetDiceValues(int numOfDice)
{
    var rand = new Random();

    for (int i = 0; i < numOfDice; i++)
    {
        yield return dice[rand.Next(0, 6)];
    }
}
