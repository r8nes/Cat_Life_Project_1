using System.Collections.Generic;
using System.Linq;
using CatLive.Actions;
using CatLive.Actions.Conclusions;
using CatLive.Moods;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace CatLive.Entities
{
    public class Pet : Entity
    {
        private const string INIT_MOOD = "Good";

#if UNITY_EDITOR
        [ListItemSelector("SetSelected")]
#endif

        [SerializeField]
        private List<ActionType> _availableActions;

        [SerializeField]
        public MoodSystem Mood { get; private set; }

        [SerializeField, PropertySpace(spaceBefore: 10, spaceAfter: 10)]
        private TextMeshProUGUI _log;

#if UNITY_EDITOR
        [BoxGroup("Action Type Preview"), ShowInInspector, InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        private ActionType _selectedActionType;
#endif

        private void Awake()
        {
            if (Mood.CurrentMood == null)
            {
                Mood.InitMood(Mood.GetMood(INIT_MOOD));
            }
        }

        public override void DoAction(string action) => _log.text += $", {action}";

        public void ApplyAction(ActionType actionType, Entity sender)
        {
            if (_availableActions.Contains(actionType))
            {
                Conclusion conclusion = Mood.CurrentMood.Conclusions[actionType];
                conclusion.OnActionPerformed.Invoke(this, sender);
                if (conclusion.changeMood)
                    Mood.ChangeMood(conclusion.newMood);
            }
            else
                Debug.LogError($"Cat doesn't know how to respond to Action: {actionType.name}");
        }
#if UNITY_EDITOR
        #region EditorPreview

        public void SetSelected(int index)
        {
            _selectedActionType = index >= 0 ? _availableActions[index] : null;
        }

        #endregion
        private void OnValidate()
        {
            Mood.ValidateMoods();
            _availableActions = _availableActions.Distinct().Where((x) => x != null).ToList();
            if (_availableActions != null && _availableActions.Count > 0)
            {
                foreach (var actionType in _availableActions)
                {
                    if (actionType != null)
                    {
                        Mood.CheckAvailableAction(actionType);
                    }
                }
            }
            Mood.CheckExtraActions(ref _availableActions);
            Mood.NotifyOnValidate();
        }
#endif
    }
}
