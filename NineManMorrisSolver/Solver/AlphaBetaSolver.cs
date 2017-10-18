using System;
using System.Threading.Tasks;

namespace NineManMorrisSolver
{
    public class AlphaBetaSolver
    {
        bool MaximizingPlayer = true;


        public async Task<int> Iterate(Node node, int depth, int alpha, int beta, bool Player)
        {
            if (depth == 0 || node.IsTerminal(Player))
            {
                return node.GetTotalScore(Player);
            }

            if (Player == MaximizingPlayer)
            {
                await Task.Run(async () =>
                {
                    foreach (Node child in node.Children(Player))
                    {
                        alpha = Math.Max(alpha, await Iterate(child, depth - 1, alpha, beta, !Player));
                        if (beta < alpha)
                        {
                            break;
                        }

                    }
                }).ConfigureAwait(false);


                return alpha;
            }
            else
            {
                await Task.Run(async () => 
                {
                    foreach (Node child in node.Children(Player))
                    {
                        beta = Math.Min(beta, await Iterate(child, depth - 1, alpha, beta, !Player));

                        if (beta < alpha)
                        {
                            break;
                        }
                    }

                }).ConfigureAwait(false);
                return beta;
            }
        }
    }
}


