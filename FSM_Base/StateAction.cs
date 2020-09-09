using UnityEngine;

namespace Evazero.Player.FSM
{
    public abstract class StateAction : ScriptableObject
    {
        public bool DebugEnabled;
        public abstract void Execute(Controller controller);
    }
}