using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class StateMachine
    {
        public State _currentState { get; set; }

        public void Initialize(State startState)
        {
            _currentState = startState;
            _currentState.Enter();
        }

        public void ChangeState(State newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}

