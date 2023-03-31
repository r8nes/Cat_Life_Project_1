using Sirenix.OdinInspector;
using UnityEngine;

namespace CatLive.Entities
{
    public class Entity : SerializedMonoBehaviour
    {
        public virtual void DoAction(string action)
        {
            Debug.Log(action);
        }
    }
}