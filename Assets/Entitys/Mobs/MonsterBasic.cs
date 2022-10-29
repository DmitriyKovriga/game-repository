using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class MonsterBasic : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private void Start()
        {  
            _stateMachine = new StateMachine();
            _stateMachine.Initialize(new IdleState(_stateMachine, gameObject));
        }

        private void Update()
        {
            _stateMachine._currentState.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine._currentState.FixedUpdate();
        }

        public void CallEdgeCheck()
        {
            Debug.Log("CallEdgeCheck!");
            _stateMachine._currentState.ToolTip();
        }
    }
}

