using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using CatLive.Moods;

namespace CatLive.UI
{
    public class UIStatus : SerializedMonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _moodText;
        [SerializeField] private Image _moodImage;
        [SerializeField] private Sprite _normalState;

        [SerializeField] Dictionary<Mood, Sprite> _spritesPallete = new Dictionary<Mood, Sprite>();

        public void OnMoodChanged(Mood newMood)
        {
            _moodText.text = newMood.MoodName;
            if (_spritesPallete.TryGetValue(newMood, out Sprite sprite))
            {
                _moodImage.sprite = sprite;
            }
            else
            {
                _moodImage.sprite = _normalState;
            }
        }
    }
}
