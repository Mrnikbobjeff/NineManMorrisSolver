using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NineManMorrisSolver.Game
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Move
    {
        public Move(short movenullvektor)
        {
            SubMoves = new List<Move>();
            InitialX = 0;
            InitialY = 0;
            FinalX = (byte)(movenullvektor >> 8);
            FinalY = (byte)(movenullvektor);
        }
        public Move(int movevektor)
        {
            SubMoves = new List<Move>();
            InitialX = (byte)(movevektor >> 24);
            InitialY = (byte)(movevektor >> 16);
            FinalX = (byte) (movevektor >> 8);
            FinalY = (byte)(movevektor);
        }
        public byte InitialX;
        public byte InitialY;
        public byte FinalX;
        public byte FinalY;
        public List<Move> SubMoves { get; set; }
    }
}
