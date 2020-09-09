using System.Collections.Generic;
using UnityEngine;

namespace Evazero.Player.FSM
{
    [CreateAssetMenu(menuName = "Evazero/Player/FSM/State")]
    public class State : ScriptableObject
    {
        public StateAction[] ActionsOnEnter;
        public StateAction[] ActionsOnState;
        public StateAction[] ActionsOnStateFixed;
        public StateAction[] ActionsOnExit;
        public List<Transition> Transitions = new List<Transition>();
        public void OnEnter(Controller controller)
        {
            ExecuteActions(controller, ActionsOnEnter);
        }
        public void Tick(Controller controller)
        {
            ExecuteActions(controller, ActionsOnState);
            CheckTransitions(controller);
        }
        public void OnExit(Controller controller)
        {
            ExecuteActions(controller, ActionsOnExit);
        }

        void ExecuteActions(Controller controller, StateAction[] actionsArray)
        {
            for (int i = 0; i < actionsArray.Length; i++)
            {
                if (actionsArray[i] != null)
                    actionsArray[i].Execute(controller);
            }
        }
        void CheckTransitions(Controller controller)
        {
            for (int i = 0; i < Transitions.Count; i++)
            {
                if (Transitions[i].Disabled)
                    continue;

                if (Transitions[i].Condition.CheckCondition(controller))
                {
                    if (Transitions[i].OnTrueState != null)
                    {
                        controller.CurrentState = Transitions[i].OnTrueState;
                        OnExit(controller);
                        controller.CurrentState.OnEnter(controller);
                    }

                    //return;
                    continue;
                }
                else
                {
                    if (Transitions[i].OnFalseState != null)
                    {
                        controller.CurrentState = Transitions[i].OnFalseState;
                        OnExit(controller);
                        controller.CurrentState.OnEnter(controller);
                    }

                    //return;
                    continue;
                }
            }
        }
    }
}