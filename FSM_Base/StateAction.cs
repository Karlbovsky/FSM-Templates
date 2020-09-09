using UnityEngine;

namespace ChangeToYourNamespace
{
    public abstract class StateAction : ScriptableObject
    {
        public bool DebugEnabled;
        public abstract void Execute(Controller controller);
    }
}