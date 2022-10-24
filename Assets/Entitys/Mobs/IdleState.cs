using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class IdleState : State
    {
        //-----------------logic var-------------------
        private Transform _targetTransform;
        private Transform _monsterTransform;
        private float _timerForCompare;
        private float _delayForCompare = 5;

        private Rigidbody2D _rb2d; //for patrule realization

        //-----------------State logic var--------------
        private StateMachine _stateMachine;
        private GameObject _monsterGameOnject;

        //-----------------Logic for patrule------------
        private float _patruleTimer;
        private float _moveSpeed = 5;

        public IdleState(StateMachine stateMachine, GameObject monster)
        {
            _stateMachine = stateMachine;
            _monsterGameOnject = monster;
        }
        public override void Enter()
        {
            Debug.Log("Join to Idle State");
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _monsterTransform = _monsterGameOnject.GetComponent<Transform>();
            _rb2d = _monsterGameOnject.GetComponent<Rigidbody2D>();
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
            Patrule();
        }
        public override void Update()
        {
            CompareWithTimer();
        }

        private void Patrule ()
        {
            _patruleTimer += Time.deltaTime;

            if (_patruleTimer <= 3f)
            {
                _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y);
            } else if (_patruleTimer > 3f && _patruleTimer <= 6f)
            {
                return;
            } else
            {
                _moveSpeed = _moveSpeed * -1;
                _monsterTransform.localScale = new Vector2(_monsterTransform.localScale.x * -1, _monsterTransform.localScale.y);
                _patruleTimer = 0;
            }
        }

        private bool CompareXZWithTarget() //checkout from looking range
        {
            if (_targetTransform.position.x - _monsterTransform.position.x > -10 && _targetTransform.position.x - _monsterTransform.position.x < 10 && _targetTransform.position.y - _monsterTransform.position.y > -10 && _targetTransform.position.y - _monsterTransform.position.y < 10)
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
                if (CompareXZWithTarget()) //need to switch to warning ?
                {
                    _stateMachine.ChangeState(new WarningState(_stateMachine, _monsterGameOnject));
                }
                _timerForCompare = 0;
            }
        }
    }
}

