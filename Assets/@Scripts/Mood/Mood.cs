using CatLive.Actions;
using CatLive.Actions.Conclusions;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace CatLive.Moods
{
    [CreateAssetMenu]
    public class Mood : SerializedScriptableObject
    {
        [SerializeField] public string MoodName { get; protected set; }
        [SerializeField] public int MoodIndex { get; protected set; }

        [DictionaryDrawerSettings]
        public Dictionary<ActionType, Conclusion> Conclusions =
            new Dictionary<ActionType, Conclusion>(4);

#if UNITY_EDITOR
        public void OnValidate()
        {
            if (string.IsNullOrEmpty(MoodName))
            {
                MoodName = name;
            }
        }
#endif
    }
}