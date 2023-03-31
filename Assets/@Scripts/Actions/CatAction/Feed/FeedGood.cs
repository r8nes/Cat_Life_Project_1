using CatLive.Entities;

namespace CatLive.Actions
{
    public class FeedGood : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("Eats impressively and slowly");
    }
}
