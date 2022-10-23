using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class IdleState : State
    {
        //-----------------logic var------------------
        private Transform _targetTransform;
        private Transform _monsterTransform;
        private float _timerForCompare;
        private float _delayForCompare = 5;

        private Rigidbody2D _rb2d; //for patrule realization

        //-----------------State logic var--------------
        private StateMachine _stateMachine;

        public IdleState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public override void Enter()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _monsterTransform = gameObject.GetComponent<Transform>();
            _rb2d = gameObject.GetComponent<Rigidbody2D>();
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
            
        }
        public override void Update()
        {
            CompareWithTimer();
        }

        private void Patrule ()
        {
            //patrule
        }

        private bool CompareXZWithTarget() //checkout from looking range
        {
            if (_targetTransform.position.x - _monsterTransform.position.x > -100 && _targetTransform.position.x - _monsterTransform.position.x < 100)
            {
                return true;
            }
            if (_targetTransform.position.y - _monsterTransform.position.y > -100 && _targetTransform.position.y - _monsterTransform.position.y < 100)
            {
                return true;
            }
            return false;
        }

        private void CompareWithTimer() //do we see player and do we need to switch on Warning state? 
        {
            _timerForCompare += Time.deltaTime;

            if (_timerForCompare >= _delayForCompare)
            {
                if (CompareXZWithTarget()) //need to switch to idle ?
                {
                    _stateMachine.ChangeState(new WarningState(_stateMachine));
                }
                _timerForCompare = 0;
            }
        }
    }
}

