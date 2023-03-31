using CatLive.Entities;

namespace CatLive.Actions
{
    public class FeedCat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Player).DoAction("Pours into a bowl of cat food");
    }
}