using CatLive.Entities;

namespace CatLive.Actions
{
    public class PatCat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Player).DoAction("Trying to stroke koschka");
    }
}