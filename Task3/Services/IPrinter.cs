using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;
using Task3.Game;

namespace Task3.Services;

public interface IPrinter
{
    void PrintTable(Table table, TableConfig config);
    void PrintMenu(string[] moves);
    void PrintHmac(string hmac);
    void PrintKey(string key);
    void PrintResult(GameResult result);
    void PrintError(string message);
    void PrintInfo(string message, bool newLine = false);
}