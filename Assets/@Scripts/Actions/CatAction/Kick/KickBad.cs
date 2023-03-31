using CatLive.Entities;

namespace CatLive.Actions
{
    public class KickBad : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("Missed with a kick to the cat");
    }
}