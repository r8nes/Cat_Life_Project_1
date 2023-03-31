using CatLive.Entities;

namespace CatLive.Actions
{
    public class KickGreat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat flies away in an unknown direction...");
    }
}