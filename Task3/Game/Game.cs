using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;
using Task3.Services;

namespace Task3.Game;

public class Game
{
    private readonly string[] _moves;
    private readonly IPrinter _printer;
    private readonly IReader _reader;
    private readonly IGameRules _rules;
    private readonly SecurityService _securityService = new();
    private readonly TableGenerator _tableGenerator;

    public Game(IGameRules rules, string[] moves, IPrinter printer, IReader reader)
    {
        _rules = rules;
        _moves = moves;
        _printer = printer;
        _reader = reader;
        _tableGenerator = new TableGenerator(rules, moves);
    }

    public void Start()
    {
        if (!ValidateArgs(_moves))
        {
            _printer.PrintError("Invalid number of moves: must be odd number of moves");
            return;
        }

        var table = _tableGenerator.GenerateTable();
        var key = _securityService.GenerateKey();
        var computerMoveIndex = new Random().Next(0, _moves.Length);
        var computerMove = _moves[computerMoveIndex];
        var hmac = _securityService.GenerateHmac(key, computerMove);

        _printer.PrintHmac(hmac);
        _printer.PrintMenu(_moves);

        while (true)
        {
            _printer.PrintInfo("Enter your move: ");
            int input;
            while (!TryGetInput(out input))
            {
                _printer.PrintError(
                    $"Invalid move: choose values from menu such as 0, ? and from 1 to {_moves.Length}");
                _printer.PrintInfo("Enter your move: ");
            }

            var isFinished = HandleInput(input, table, computerMoveIndex, key);
            if (isFinished) return;
        }
    }

    private bool HandleInput(int input, Table table, int computerMoveIndex, string key)
    {
        switch (input)
        {
            case -1:
                _printer.PrintTable(table, TableConfig.Unicode());
                return false;
            case 0: return true;
            default:
                _printer.PrintInfo($"Your move: {_moves[input - 1]}", true);
                _printer.PrintInfo($"Computer move: {_moves[computerMoveIndex - 1]}", true);
                _printer.PrintResult(_rules.DetermineWinner(input - 1, computerMoveIndex));
                _printer.PrintKey(key);
                _printer.PrintInfo("Hmac checker website: https://www.freeformatter.com/hmac-generator.html");
                return true;
        }
    }

    private bool TryGetInput(out int input)
    {
        var userInput = _reader.Read();
        switch (userInput)
        {
            case "?":
                input = -1;
                return true;
            case "0":
                input = 0;
                return true;
        }

        return int.TryParse(userInput, out input) && input > 0 && input <= _moves.Length;
    }

    private static bool ValidateArgs(string[] args)
    {
        return args.Length % 2 != 0;
    }
}