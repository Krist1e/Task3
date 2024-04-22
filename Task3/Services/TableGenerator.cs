using BetterConsoles.Tables;
using Task3.Game;

namespace Task3.Services;

public class TableGenerator
{
    private readonly string[] _moves;
    private readonly IGameRules _rules;


    public TableGenerator(IGameRules rules, string[] moves)
    {
        _rules = rules;
        _moves = moves;
    }

    public Table GenerateTable()
    {
        var table = new Table();
        var headers = _moves.Prepend(@"v PC \ User >").ToArray();
        table.AddColumns(Alignment.Center, Alignment.Center, headers);
        for (var i = 0; i < _moves.Length; i++)
        {
            var row = new string[_moves.Length + 1];
            row[0] = _moves[i];
            for (var j = 0; j < _moves.Length; j++) row[j + 1] = _rules.DetermineWinner(i, j).ToString();
            table.AddRow(row);
        }

        return table;
    }
}