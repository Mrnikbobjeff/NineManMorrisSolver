using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace NineManMorrisSolver.Game.Interfaces
{
    public interface IBoard
    {
        GameState State { get; set; }
        ReactiveList<Move> Moves { get; set; }
        ReactiveList<Field> Tiles { get; set; }
        Field CurrentlyMovingPiece { get; set; }
        string Winner { get; set; }
        int MoveCount { get; set; }
        Task ApplyMove(Move mv);
    }
}
