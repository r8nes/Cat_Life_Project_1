using CatLive.Entities;

namespace CatLive.Actions
{
    public class PlayGood : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("Arrange a rally with a cat around the house");
    }
}
