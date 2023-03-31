using System;
using UnityEngine.Events;

namespace CatLive.Moods
{
    [Serializable]
    public class OnMoodChangedEvent : UnityEvent<Mood>
    {
    }
}