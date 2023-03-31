using CatLive.Entities;

namespace CatLive.Actions
{
    public class PatGood : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat is quite purring");
    }
}