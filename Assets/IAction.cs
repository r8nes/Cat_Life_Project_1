using CatLive.Entities;

namespace CatLive.Actions
{
    public interface IAction
    {
        public void Execute(Entity sender, Entity receiver);
    }
}

