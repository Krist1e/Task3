using Task3.Game;
using Task3.Services;

var game = new Game(new GameRules(args.Length), args, new ConsolePrinter(), new ConsoleReader());
game.Start();