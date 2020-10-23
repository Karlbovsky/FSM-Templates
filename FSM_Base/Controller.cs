using UnityEngine;
using UnityEngine.AI;

namespace ChangeToYourNamespace
{
    public class Controller : MonoBehaviour
    {
        [Header("Data References")]
        public NavMeshAgent Agent;
        public Animator Animator;
        [SerializeField] Transform _transform;
        public Transform Transform { get { return _transform; } }
        public AnimatorHashes AnimatorHashes;
        public State CurrentState;
        [HideInInspector]
        public float Delta;
        public bool UpdateEnabled;
        private float _timer;
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        private void Start()
        {
            _transform = this.transform;
            AnimatorHashes = new AnimatorHashes();
             _timer = 0f;
            //(optional)call OnEnter @ start    
            if (CurrentState != null)
                CurrentState.OnEnter(this);
        }
        private void Update()
        {
            Delta = Time.deltaTime;

            if (UpdateEnabled)
                CurrentState?.Tick(this);
        }
        /**
            Useful if we want to change state via an xternal script/component.
            WE can grab the reference to this controller in another component and
            force a state transition when needed. This allows to have a more generic 
            controller. It can be used with differents system/component types.
        */
        public void ForceTransition(State newState)
        {
            UpdateEnabled = false;

            CurrentState.OnExit(this);
            CurrentState = newState;
            CurrentState.OnEnter(this);

            UpdateEnabled = true;
        }
        //useful for FSM components to have time related logics
        public bool TimeElapsed(float secondsToWait)
        {
            if (_timer < secondsToWait)
            {
                _timer += 1 * Delta;
            }
            else
            {
                _timer = 0;
                return true;
            }

            return false;
        }
    }
}
