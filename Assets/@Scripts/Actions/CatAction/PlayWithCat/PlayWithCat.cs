using CatLive.Entities;

namespace CatLive.Actions
{
    public class PlayWithCat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Player).DoAction("Decides to play catch-up with the cat with a vacuum cleaner");
    }
}