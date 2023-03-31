using CatLive.Entities;
using UnityEngine.Events;

namespace CatLive.Actions.Conclusions
{
    [System.Serializable]
    public class ConsequenceEvent : UnityEvent<Entity, Entity>
    {
    }
}