using CatLive.Entities;

namespace CatLive.Actions
{
    public class PlayBad : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat intercepts the vacuum cleaner and arranges punishment for you");
    }
}