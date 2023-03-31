using CatLive.Entities;

namespace CatLive.Actions
{
    public class PlayGreat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat agrees to be a projectile");
    }
}
