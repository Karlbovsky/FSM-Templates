using UnityEngine;

namespace Evazero.Player.FSM
{
    [System.Serializable]
    public class Transition
    {
        public bool Disabled;
        public Condition Condition;
        [Tooltip("TIP: It is safe to keep this null, it's like saying : Remain in State.")]
        public State OnTrueState;
        [Tooltip("TIP: It is safe to keep this null, it's like saying : Remain in State.")]
        public State OnFalseState;
    }
}