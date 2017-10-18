using System;
using NineManMorrisSolver.Game;

namespace NineManMorrisSolver_ConsoleTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            byte[] bytes = { 1, 2, 3, 25 };

            // If the system architecture is little-endian (that is, little end first),
            // reverse the byte array.
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            int i = BitConverter.ToInt32(bytes, 0);
            var move = new Move(i);
            int tesmp = 0;
        }
    }
}
