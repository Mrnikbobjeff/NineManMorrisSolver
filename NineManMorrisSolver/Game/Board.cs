using System;
using ReactiveUI;
using NineManMorrisSolver.Extensions;
using NineManMorrisSolver.Game.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace NineManMorrisSolver.Game
{
    public enum GameState
    {
        Placing,
        Moving,
        Flying
    }

    public class Board : ReactiveObject, IBoard
    {
        private GameState state;
        private TileStatus _winner;
        private ReactiveList<Field> _tiles;
        private ReactiveList<Move> _moves;
        private int _moveCount;
        public Field CurrentlyMovingPiece { get; set; }

        public Board()
        {
            state = GameState.Placing;
            CreateTiles();
            _winner = TileStatus.Unoccupied;
        }

        public GameState State
        {
            get => state;
            set => this.RaiseAndSetIfChanged(ref state, value);
        }

        public ReactiveList<Move> Moves { get => _moves; set => this.RaiseAndSetIfChanged(ref _moves, value); }

        public ReactiveList<Field> Tiles
        {
            get => _tiles;
            set => this.RaiseAndSetIfChanged(ref _tiles, value);
        }

        public string Winner
        {
            get => _winner.ToString();
            set => this.RaiseAndSetIfChanged(ref _winner, value.ToEnum<TileStatus>());
        }
        public int MoveCount { get => _moveCount; set => this.RaiseAndSetIfChanged(ref _moveCount, value); }

        protected void CreateTiles()
        {
            // Create the initial tiles
            Tiles = new ReactiveList<Field>(
                new[]
                {
                    // Outer
                    new Field { TileName = "OuterTopLeft", Row = 0, Column = 0 },
                    new Field { TileName = "OuterTopMiddle", Row = 0, Column = 3 },
                    new Field { TileName = "OuterTopRight", Row = 0, Column = 6 },
                    new Field { TileName = "OuterMiddleLeft", Row = 3, Column = 0 },
                    new Field { TileName = "OuterMiddleRight", Row = 3, Column = 6 },
                    new Field { TileName = "OuterBottomLeft", Row = 6, Column = 0 },
                    new Field { TileName = "OuterBottomMiddle", Row = 6, Column = 3 },
                    new Field { TileName = "OuterBottomRight", Row = 6, Column = 6 },
                    // Middle
                    new Field { TileName = "MiddleTopLeft", Row = 1, Column = 1 },
                    new Field { TileName = "MiddleTopMiddle", Row = 1, Column = 3 },
                    new Field { TileName = "MiddleTopRight", Row = 1, Column = 5 },
                    new Field { TileName = "MiddleMiddleLeft", Row = 3, Column = 1 },
                    new Field { TileName = "MiddleMiddleRight", Row = 3, Column = 5 },
                    new Field { TileName = "MiddleBottomLeft", Row = 5, Column = 1 },
                    new Field { TileName = "MiddleBottomMiddle", Row = 5, Column = 3 },
                    new Field { TileName = "MiddleBottomRight", Row = 5, Column = 5 },
                    // Inner
                    new Field { TileName = "InnerTopLeft", Row = 2, Column = 2 },
                    new Field { TileName = "InnerTopMiddle", Row = 2, Column = 3 },
                    new Field { TileName = "InnerTopRight", Row = 2, Column = 4 },
                    new Field { TileName = "InnerMiddleLeft", Row = 3, Column = 2 },
                    new Field { TileName = "InnerMiddleRight", Row = 3, Column = 4 },
                    new Field { TileName = "InnerBottomLeft", Row = 4, Column = 2 },
                    new Field { TileName = "InnerBottomMiddle", Row = 4, Column = 3 },
                    new Field { TileName = "InnerBottomRight", Row = 4, Column = 4 }
                });

            // Make the connections

            // Outer
            Tiles[0].AdjacentTiles = new[] { Tiles[1], Tiles[3] };
            Tiles[1].AdjacentTiles = new[] { Tiles[0], Tiles[2], Tiles[9] };
            Tiles[2].AdjacentTiles = new[] { Tiles[1], Tiles[4] };
            Tiles[3].AdjacentTiles = new[] { Tiles[0], Tiles[5], Tiles[11] };
            Tiles[4].AdjacentTiles = new[] { Tiles[2], Tiles[7], Tiles[12] };
            Tiles[5].AdjacentTiles = new[] { Tiles[3], Tiles[6] };
            Tiles[6].AdjacentTiles = new[] { Tiles[5], Tiles[7], Tiles[14] };
            Tiles[7].AdjacentTiles = new[] { Tiles[4], Tiles[6] };
            // Middle
            Tiles[8].AdjacentTiles = new[] { Tiles[9], Tiles[11] };
            Tiles[9].AdjacentTiles = new[] { Tiles[1], Tiles[8], Tiles[10], Tiles[17] };
            Tiles[10].AdjacentTiles = new[] { Tiles[9], Tiles[12] };
            Tiles[11].AdjacentTiles = new[] { Tiles[3], Tiles[8], Tiles[13], Tiles[19] };
            Tiles[12].AdjacentTiles = new[] { Tiles[4], Tiles[10], Tiles[15], Tiles[20] };
            Tiles[13].AdjacentTiles = new[] { Tiles[11], Tiles[14] };
            Tiles[14].AdjacentTiles = new[] { Tiles[6], Tiles[13], Tiles[15], Tiles[22] };
            Tiles[15].AdjacentTiles = new[] { Tiles[12], Tiles[14] };
            // Outer
            Tiles[16].AdjacentTiles = new[] { Tiles[17], Tiles[19] };
            Tiles[17].AdjacentTiles = new[] { Tiles[9], Tiles[16], Tiles[18] };
            Tiles[18].AdjacentTiles = new[] { Tiles[17], Tiles[20] };
            Tiles[19].AdjacentTiles = new[] { Tiles[11], Tiles[16], Tiles[21] };
            Tiles[20].AdjacentTiles = new[] { Tiles[18], Tiles[12], Tiles[23] };
            Tiles[21].AdjacentTiles = new[] { Tiles[19], Tiles[22] };
            Tiles[22].AdjacentTiles = new[] { Tiles[14], Tiles[21], Tiles[23] };
            Tiles[23].AdjacentTiles = new[] { Tiles[20], Tiles[22] };

            this.RaisePropertyChanged(nameof(Tiles));
        }

        public async Task ApplyMove(Move mv)
        {
            await Task.Run(() => 
            {
                var startTile = Tiles.Single(tile => tile.Row == mv.InitialY && tile.Column == mv.InitialX);
                var destination = startTile.Status;
            });
        }
    }
}
