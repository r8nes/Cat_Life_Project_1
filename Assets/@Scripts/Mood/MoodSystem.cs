using System;
using System.Collections.Generic;
using System.Linq;
using CatLive.Actions;
using CatLive.Actions.Conclusions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CatLive.Moods
{
    [Serializable]
    public class MoodSystem
    {
        [ReadOnly, SerializeField]
        public Mood CurrentMood { get; private set; } 

        [PropertySpace]
        public OnMoodChangedEvent OnMoodChanged;

#if UNITY_EDITOR
        [ListItemSelector("SetSelected")]
#endif

        [SerializeField]
        private List<Mood> _availableMoods = new List<Mood>();

#if UNITY_EDITOR
        [BoxGroup("Mood Preview"), ShowInInspector, InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        private Mood _selectedMood;
#endif

        public void ChangeMood(Mood newMood)
        {
            if (!_availableMoods.Contains(newMood))
            {
                throw new ArgumentException($"No cat for this state. State is {newMood}");
            }

            CurrentMood = newMood;
            OnMoodChanged.Invoke(CurrentMood);
            return;
        }

        public void ChangeMood(string newMood)
        {
            Mood mood = _availableMoods.Find((x) => x.MoodName == newMood);
            if (mood == null)
            {
                throw new ArgumentException($"No cat for this state. State is {mood}");
            }

            ChangeMood(mood);
            return;
        }

        public void InitMood(Mood mood)
        {
            if (mood == null)
            {
                throw new ArgumentNullException($"{mood}: Is absent");
            }
            if (CurrentMood != null)
            {
                throw new Exception($" {CurrentMood}: Mood initializated");
            }
            if (!_availableMoods.Contains(mood))
            {
                throw new ArgumentException($"{mood}: Is not for this entity");
            }
;
            ChangeMood(mood);
            return;
        }

        public Mood GetMood(string mood) => _availableMoods.Find((x) => x.MoodName == mood);

#if UNITY_EDITOR
        #region EditorPreview

        public void SetSelected(int index) => _selectedMood = index >= 0 ? _availableMoods[index] : null;

        #endregion
        public void ValidateMoods() => _availableMoods = _availableMoods.Distinct().Where((x) => x != null).ToList();

        public void CheckAvailableAction(ActionType action)
        {
            foreach (var mood in _availableMoods)
            {
                if (mood != null)
                {
                    if (mood.Conclusions == null)
                    {
                        mood.Conclusions = new Dictionary<ActionType, Conclusion>();
                    }
                    if (!mood.Conclusions.ContainsKey(action))
                    {
                        mood.Conclusions.Add(action, new Conclusion());
                    }
                }
            }
        }

        public void CheckExtraActions(ref List<ActionType> actions)
        {
            foreach (var mood in _availableMoods)
            {
                if (mood != null)
                {
                    while (RemoveExtra(mood, ref actions)) ;
                }
            }
        }

        public void NotifyOnValidate()
        {
            foreach (var mood in _availableMoods)
            {
                mood.OnValidate();
            }
        }

        private bool RemoveExtra(Mood mood, ref List<ActionType> actions)
        {
            foreach (var consequence in mood.Conclusions)
            {
                if (actions == null || !actions.Contains(consequence.Key))
                {
                    mood.Conclusions.Remove(consequence.Key);
                    return true;
                }
            }
            return false;
        }
#endif
    }
}