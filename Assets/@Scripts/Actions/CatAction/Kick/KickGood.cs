using CatLive.Entities;

namespace CatLive.Actions
{
    public class KickGood : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat flies like a rocket and swears revenge");
    }
}