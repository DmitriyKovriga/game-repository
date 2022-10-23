using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mobs
{
    public class WarningState : State
    {
        //-----------------logic var------------------
        private Transform _targetTransform;
        private Transform _monsterTransform;
        private float _timerForCompare;
        private float _delayForCompare = 5;

        private float _timerForCompareAttack; 
        private float _delayForCompareAttack = 2; //mb link it to monster attack speed ?

        private bool _isNeedTofacingRight;
        private Rigidbody2D _rb2d; //for move to target

        //-----------------State logic var--------------
        private StateMachine _stateMachine;

        public WarningState (StateMachine stateMachine)
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
            base.Exit();
        }

        public override void Update()
        {
            Flipper(); //flipp to player
            CompareWithTimer(); //check for switch to idle
            CompareWithTimerForAttack(); //check for attack
        }

        public override void FixedUpdate()
        {
            
        }

        private bool CompareXZWithTarget () //checkout from looking range
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

        private int CompareXZWithTargetForAttack() // return 1 for right attack, -1 for left attack and 0 for non-attack (or for special attack under him self) 
        {
            var result = _targetTransform.position.x - _monsterTransform.position.x;
            
            if (result > -100 && result < 100) //check for out facing
            {
                if (result > 0)
                {
                    _isNeedTofacingRight = false;
                } else
                {
                    _isNeedTofacingRight = true;
                }
            }

            if (result > -10 && result < 10) //check for attack
            {
                if (result > 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        private void Flipper() //flip monster in a righgt way
        {
            if (_isNeedTofacingRight && _monsterTransform.localScale.x > 0)
            {
                _monsterTransform.localScale = new Vector2(_monsterTransform.localScale.x * -1, _monsterTransform.localScale.y);
            } else if (!_isNeedTofacingRight && _monsterTransform.localScale.x < 0)
            {
                _monsterTransform.localScale = new Vector2(_monsterTransform.localScale.x * -1, _monsterTransform.localScale.y);
            }
        }

        private void CompareWithTimer () //do we see player and do we need to switch on idle state? 
        {
            _timerForCompare += Time.deltaTime;

            if (_timerForCompare >= _delayForCompare) 
            {
                if (!CompareXZWithTarget()) //need to switch to idle ?
                {
                    _stateMachine.ChangeState(new IdleState(_stateMachine));
                }
                _timerForCompare = 0;
            }
        }

        private void CompareWithTimerForAttack() //do we need to attack ?
        {
            _timerForCompareAttack += Time.deltaTime;

            if (_timerForCompareAttack >= _delayForCompareAttack)
            {
                //attack
            }
            _delayForCompareAttack = 0;
        }

        
        private void MoveToTarget()
        {
            var result = _targetTransform.position.x - _monsterTransform.position.x;
            if (result > 0)
            {
                //go to the right
            } else if (result < 0)
            {
                //go to the left
            }
        }

    }
    
}

