using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class MonsterBasic : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed; //while here, then we put it to scriptable obj and put link of it to state
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
    }
}

