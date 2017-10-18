using System;
using NineManMorrisSolver.Game;
using NUnit;
using NUnit.Framework;

namespace NineManMorrisSolver_Test
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void MoveTest_ConstructorGetsBytesFromIntValue()
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
