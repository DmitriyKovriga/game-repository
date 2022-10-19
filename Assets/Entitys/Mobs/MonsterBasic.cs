using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class MonsterBasic : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private StateMachine _stateMachine;
        [SerializeField] private GameObject _aggro;
        private Animator _animator;
        private void Start()
        {  
            _stateMachine = new StateMachine();
            _animator = gameObject.GetComponent<Animator>();
            _stateMachine.Initialize(new IdleState (gameObject.GetComponent<Rigidbody2D>(), this, _moveSpeed, gameObject.GetComponent<Transform>(), _animator));
        }

        private void Update()
        {
            _stateMachine._currentState.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine._currentState.FixedUpdate();
        }

        public float getMoveSpeed()
        {
            return _moveSpeed;
        }

        public void setWarningState()
        {
            GameObject target = _aggro.GetComponent<AggroRangeSender>().getLastPlayerDetection();
            _stateMachine.ChangeState(new WarningState(gameObject.GetComponent<Rigidbody2D>(), _moveSpeed, gameObject.GetComponent<Transform>(), target, _animator, _aggro));
        }

        public void setIdleState()
        {
            _stateMachine.ChangeState(new IdleState(gameObject.GetComponent<Rigidbody2D>(), this, _moveSpeed, gameObject.GetComponent<Transform>(), _animator));
        }
    }
}

