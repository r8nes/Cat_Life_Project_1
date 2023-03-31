using CatLive.Entities;

namespace CatLive.Actions
{
    public class FeedGreat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("Eats like hell");
    }
}
