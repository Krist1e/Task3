namespace Task3.Game;

public interface IGameRules
{
    GameResult DetermineWinner(int playerMove, int computerMove);
}