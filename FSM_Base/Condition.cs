using UnityEngine;

namespace ChangeToYourNamespace
{
    public abstract class Condition : ScriptableObject
    {
        public bool DebugEnabled;
        public abstract bool CheckCondition(Controller controller);
    }
}