using UnityEngine;

namespace Evazero.Player.FSM
{
    public abstract class Condition : ScriptableObject
    {
        public bool DebugEnabled;
        public abstract bool CheckCondition(Controller controller);
    }
}