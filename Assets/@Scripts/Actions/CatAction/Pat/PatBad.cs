using CatLive.Entities;

namespace CatLive.Actions
{
    public class PatBad : IAction
    {
        public void Execute(Entity sender, Entity receiver) => (sender as Pet).DoAction("The cat becomes a shinobi and uses the penetration technique");
    }
}