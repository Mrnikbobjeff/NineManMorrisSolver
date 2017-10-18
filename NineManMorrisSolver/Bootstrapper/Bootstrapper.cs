using System;
using System.Threading.Tasks;
using NineManMorrisSolver.Bootstrapper.Interfaces;
using NineManMorrisSolver.Game;
using NineManMorrisSolver.Game.Interfaces;
using Splat;

namespace NineManMorrisSolver.Bootstrapper
{
    public class Bootstrapper : IBootstrapper
    {
        public async Task Initialize()
        {
            await Task.Run(() =>
            {
                Locator.CurrentMutable.RegisterConstant(new Board(), typeof(IBoard));
            });
        }
    }
}
