using CatLive.Moods;
using Sirenix.OdinInspector;

namespace CatLive.Actions.Conclusions
{
    public struct Conclusion
    {
        public ConsequenceEvent OnActionPerformed;

        [ToggleLeft] public bool changeMood;
        [ShowIf("changeMood")] public Mood newMood;
    }
}
