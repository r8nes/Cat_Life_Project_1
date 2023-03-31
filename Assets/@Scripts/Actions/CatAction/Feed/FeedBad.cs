using CatLive.Entities;

namespace CatLive.Actions
{
    public class FeedBad : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("Turns the bowl on the floor and eats from the floor");
    }
}