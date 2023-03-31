using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CatLive.Actions;

namespace CatLive.Entities
{
    public class Player : Entity
    {
        [SerializeField] private Pet _pet;
        [SerializeField] private TextMeshProUGUI _log;

        public List<Action> _availablesAction = new List<Action>(4);

        public void Apply(Action action)
        {
            action.Execute(this, _pet);
            _pet.ApplyAction(action.actionType, this);
        }

        public override void DoAction(string action) => _log.text = $"Игрок: {action}";
    }
}
