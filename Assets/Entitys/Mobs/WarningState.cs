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
        private float _delayForCompare = 2;

        private float _timerForCompareAttack; 
        private float _delayForCompareAttack = 1; //mb link it to monster attack speed ?

        private Rigidbody2D _rb2d; //for move to target

        //-----------------State logic var--------------
        private StateMachine _stateMachine;
        private GameObject _monsterGameOnject;

        //-----------------Logic for chasing------------
        private float _moveSpeed = 5;

        public WarningState (StateMachine stateMachine, GameObject monster)
        {
            _stateMachine = stateMachine;
            _monsterGameOnject = monster;
        }

        public override void Enter()
        {
            Debug.Log("Enter Warning");
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _monsterTransform = _monsterGameOnject.GetComponent<Transform>();
            _rb2d = _monsterGameOnject.GetComponent<Rigidbody2D>();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            CompareWithTimer(); //check for switch to idle
            CompareWithTimerForAttack(); //check for attack
        }

        public override void FixedUpdate()
        {
            MoveToTarget();
        }

        private bool CompareXZWithTarget () //checkout from looking range
        {
            if (_targetTransform.position.x - _monsterTransform.position.x < -10 || _targetTransform.position.x - _monsterTransform.position.x > 10 || _targetTransform.position.y - _monsterTransform.position.y < -10 || _targetTransform.position.y - _monsterTransform.position.y > 10)
            {
                return true;
            }
            return false;
        }

        private int CompareXZWithTargetForAttack() // return 1 for right attack, -1 for left attack and 0 for non-attack (or for special attack under him self) 
        {
            if (_targetTransform.position.x - _monsterTransform.position.x > -1 && _targetTransform.position.x - _monsterTransform.position.x < 1) //check for attack
            {
                if (_targetTransform.position.x - _monsterTransform.position.x > 0)
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

        private void CompareWithTimer () //do we see player and do we need to switch on idle state? 
        {
            _timerForCompare += Time.deltaTime;

            if (_timerForCompare >= _delayForCompare) 
            {
                if (CompareXZWithTarget()) //need to switch to idle ?
                {
                    _stateMachine.ChangeState(new IdleState(_stateMachine, _monsterGameOnject));
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
            if (_targetTransform.position.x - _monsterTransform.position.x > 0)
            {
                _rb2d.WakeUp();
                _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y); 
                Debug.Log("Бегу! Бегу сука за тобой, сейчас я тебя буду резать, мой мс " + _moveSpeed + " магнитуда " + _rb2d.velocity.magnitude);
            } else
            {
                _rb2d.WakeUp();
                _rb2d.velocity = new Vector2(_moveSpeed * -1, _rb2d.velocity.y);
               Debug.Log("Бегу! Бегу сука за тобой, сейчас я тебя буду резать, мой мс " + _moveSpeed * -1 + " магнитуда " + _rb2d.velocity.magnitude);
            }
        }

    }
    
}

