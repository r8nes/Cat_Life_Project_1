using CatLive.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CatLive.Actions
{
    [CreateAssetMenu]
    public class Action : SerializedScriptableObject
    {
        public IAction action;
        public ActionType actionType;

        public void Execute(Entity sender, Entity recipient)
        {
            action.Execute(sender, recipient);
        }
    }
}