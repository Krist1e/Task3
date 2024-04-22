namespace Task3.Game;

public class GameRules(int movesCount) : IGameRules
{
    public GameResult DetermineWinner(int playerMove, int computerMove)
    {
        if (playerMove == computerMove) return GameResult.Draw;

        var sign = Math.Sign((playerMove - computerMove + (movesCount >> 1) + movesCount) % movesCount -
                             (movesCount >> 1));
        return sign switch
        {
            -1 => GameResult.Win,
            1 => GameResult.Lose,
            _ => GameResult.Draw
        };
    }
}