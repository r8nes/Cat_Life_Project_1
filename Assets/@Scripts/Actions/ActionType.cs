using UnityEngine;

namespace CatLive.Actions
{
    [CreateAssetMenu]
    public class ActionType : ScriptableObject
    {
        public string ActionName;
        public int Id;
    }
}