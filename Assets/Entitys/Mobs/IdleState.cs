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
        private float _delayForCompare = 1;

        private Rigidbody2D _rb2d; //for patrule realization

        //-----------------State logic var--------------
        private StateMachine _stateMachine;
        private GameObject _monsterGameObject;
        private SpriteRenderer _monsterSprite;
        private Animator _monsterAnim;

        //-----------------Logic for patrule------------
        private float _patruleTimer;
        private float _moveSpeed = 2;

        public IdleState(StateMachine stateMachine, GameObject monster)
        {
            _stateMachine = stateMachine;
            _monsterGameObject = monster;
        }
        public override void Enter()
        {
            Debug.Log("Join to Idle State");
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _monsterTransform = _monsterGameObject.GetComponent<Transform>();
            _rb2d = _monsterGameObject.GetComponent<Rigidbody2D>();
            _monsterSprite = _monsterGameObject.GetComponent<SpriteRenderer>();
            _monsterAnim = _monsterGameObject.GetComponent<Animator>();
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

        public override void ToolTip()
        {
            _monsterSprite.flipX = !_monsterSprite.flipX;
        }

        private void Patrule ()
        {
            _patruleTimer += Time.deltaTime;

            if (_patruleTimer <= 3f)
            {
                _monsterAnim.Play("Walk");
                if (_monsterSprite.flipX == true)
                {
                    _rb2d.velocity = new Vector2(_moveSpeed * -1, _rb2d.velocity.y);
                }
                else 
                _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y);
            }
            else if (_patruleTimer > 3f && _patruleTimer <= 6f)
            {
                _monsterAnim.Play("Idle");
                _rb2d.velocity = new Vector2(0, _rb2d.velocity.y);
            } else
            {
                _monsterSprite.flipX = !_monsterSprite.flipX;
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
                    _stateMachine.ChangeState(new WarningState(_stateMachine, _monsterGameObject));
                }
                _timerForCompare = 0;
            }
        }

    }
}

