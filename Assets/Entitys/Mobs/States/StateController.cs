using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class StateController
    {
        public States _currentState { get; set; }

        public void Initialize(States FirstState)
        {
            _currentState = FirstState;
            _currentState.Enter();
        }

        public void NextState(States state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}

