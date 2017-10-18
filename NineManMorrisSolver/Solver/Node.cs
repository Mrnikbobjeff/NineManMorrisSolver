using System;
using System.Collections.Generic;

namespace NineManMorrisSolver
{
    public class Node
    {

        public List<Node> Children(bool maximizingPlayer)
        {
            List<Node> children = new List<Node>();

            // Create your subtree here and return the results

            return children;
        }

        public bool IsTerminal(bool maximizingPlayer)
        {
            var terminalNode = false;

            // Game over?

            return terminalNode;
        }

        public int GetTotalScore(bool maximizingPlayer)
        {
            int totalScore = 0;

            // This method is a heuristic evaluation function to evaluate
            // the current situation of the player
            // It depends on the game. For example chess, tic-tac-to or other games suitable
            // for the minimax algorithm can have different evaluation functions.

            return totalScore;
        }

    }
}
