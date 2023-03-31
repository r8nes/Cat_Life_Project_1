using CatLive.Entities;

namespace CatLive.Actions
{
    public class KickCat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Player).DoAction("Makes a low kick on the cat");
    }
}