using CatLive.Entities;

namespace CatLive.Actions
{
    public class PatGreat : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat likes the iron with which you stroke her");
    }
}