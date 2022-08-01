
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
    PlayerResult? bestPlayerResult = null;

    foreach (var player in players)
    {
        var diceLeft = 5;
        var diceValuesKept = new List<int>();
        var numberOfRolls = 0;
        var scoreToBeat = bestPlayerResult?.ChosenValues?.Sum() ?? int.MaxValue;

        do
        {
            var roll = GetDiceValues(diceLeft);

            var diceKept = player.ChooseDice(diceValuesKept.Sum(), scoreToBeat, roll).ToList();
            diceValuesKept.AddRange(diceKept);
            diceLeft -= diceKept.Count;

            numberOfRolls++;

            if (diceValuesKept.Sum() > scoreToBeat)
            {
                break;
            }
        } while (diceLeft > 0);

        if (diceValuesKept.Sum() < scoreToBeat)
        {
            bestPlayerResult = new PlayerResult(player.Name, player.GetType().Name, diceValuesKept, numberOfRolls);
        }
    }

    var gameResult = new GameResult(bestPlayerResult?.Name ?? "", bestPlayerResult?.ClassName ?? "", bestPlayerResult?.ChosenValues ?? Enumerable.Empty<int>());
    gameResults.Add(gameResult);

    var lastWinnerIndex = bestPlayerResult == null ? 0 : players.FindIndex(x => x.Name == bestPlayerResult?.Name);
    players = players.Select((x, i) => players.ElementAt((i + lastWinnerIndex) % players.Count)).ToList();
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
