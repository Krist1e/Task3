using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;
using Task3.Game;

namespace Task3.Services;

public class ConsolePrinter : IPrinter
{
    public void PrintTable(Table table, TableConfig config)
    {
        table.Config = config;
        Console.WriteLine(table);
    }

    public void PrintMenu(string[] moves)
    {
        Console.WriteLine("Available moves:");
        for (var i = 0; i < moves.Length; i++) Console.WriteLine($"{i + 1} - {moves[i]}");

        Console.WriteLine("0 - Exit");
        Console.WriteLine("? - Help");
    }

    public void PrintHmac(string hmac)
    {
        Console.Write("HMAC: ");
        Console.WriteLine(hmac);
    }

    public void PrintKey(string key)
    {
        Console.Write("Key: ");
        Console.WriteLine(key);
    }

    public void PrintResult(GameResult result)
    {
        switch (result)
        {
            case GameResult.Win:
                Console.WriteLine("You win!");
                break;
            case GameResult.Lose:
                Console.WriteLine("You lose!");
                break;
            case GameResult.Draw:
                Console.WriteLine("Draw!");
                break;
        }
    }

    public void PrintError(string message)
    {
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = color;
    }

    public void PrintInfo(string message, bool newLine)
    {
        if (newLine)
            Console.WriteLine(message);
        else
            Console.Write(message);
    }
}