using BoardGamesRanking;

Console.WriteLine("**************************");
Console.WriteLine();
Console.WriteLine("Board Game Ranking");
Console.WriteLine();
Console.WriteLine("**************************");

Console.WriteLine("Insert game name:");
string gameName = Console.ReadLine();

Console.WriteLine("Insert game publisher:");
string gamePublisher = Console.ReadLine();

var game = new GameInDocument($"{gameName}",$"{gamePublisher}");

game.RateAdded += Game_RateAdded;

void Game_RateAdded(object sender, EventArgs args)
{
    Console.WriteLine("Rate added");
}

while (true)
{
    Console.WriteLine($"Game name: {game.Name} / Publisher: {game.Publisher}");
    Console.WriteLine("Insert game rate. From 0 to 10");
    var input = Console.ReadLine();

    if (input == "q")
    {
        break;
    }
    try
    {
        game.AddRate(input);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
    }
}
Statistics statistics = game.GetStatistics();
Console.WriteLine("**************************");
Console.WriteLine($"The lowest rate: {statistics.Min}");
Console.WriteLine($"The highest rate: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average}");
Console.WriteLine($"Polled opinion about the {game.Name} : {statistics.AverageSentence}");