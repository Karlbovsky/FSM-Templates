﻿using UnityEngine;
using UnityEngine.AI;

namespace Evazero.Player.FSM
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
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        private void Start()
        {
            _transform = this.transform;
            AnimatorHashes = new AnimatorHashes();
        }
        private void Update()
        {
            Delta = Time.deltaTime;

            if (UpdateEnabled)
                CurrentState?.Tick(this);
        }
        public void ForceTransition(State newState)
        {
            UpdateEnabled = false;

            CurrentState.OnExit(this);
            CurrentState = newState;
            CurrentState.OnEnter(this);

            UpdateEnabled = true;
        }
    }
}