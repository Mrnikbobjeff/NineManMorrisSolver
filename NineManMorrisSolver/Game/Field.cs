using System;
using System.Collections.Generic;
using ReactiveUI;
namespace NineManMorrisSolver.Game
{
    public enum TileStatus
    {
        Unoccupied,
        MaximizingPlayer,
        MinimizingHumanPlayer
    }

    public class Field : ReactiveObject
    {
        private TileStatus _tileStatus;

        public Field()
        {
            Status = TileStatus.Unoccupied;
        }

        public TileStatus Status { get => _tileStatus; set => this.RaiseAndSetIfChanged(ref _tileStatus, value); }
 

        public string TileName { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public IEnumerable<Field> AdjacentTiles { get; set; }
    }
}
