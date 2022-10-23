using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class IdleState : States
    {
        private float _timer;
        //private Rigidbody2D _rb2d;
        //private float _moveSpeed;
        //private Transform _transform;
        //private Animator _anim;

        public IdleState(StateController StateController, Rigidbody2D rb2d, float moveSpeed, Transform transform, Animator anim, Transform target)
        {
            _rb2d = rb2d;
            _moveSpeed = moveSpeed;
            _transform = transform;
            _anim = anim;
            _target = target;
            _StateController = StateController;
        }
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            IdleCheck();
            CompareTargetPos();
        }

        public override void Fix()
        {
            base.Fix();
            _moveSpeed *= -1;
        }

        private void IdleCheck()
        {
            Debug.Log(_moveSpeed + "IdleState");
            _timer += Time.deltaTime;
            //Debug.Log(_timer);

            if (_timer < 5)
            {
                _anim.Play("Walk");
                SetPatrol(true);
                Debug.Log("Im on patrol");
            }
            else if (_timer >= 5 && _timer <= 10)
            {
                _anim.Play("Idle");
                SetPatrol(false);
                Debug.Log("Im chilling");
            }
            else
            {
                _timer = 0;
            }
        }

        private void SetPatrol(bool _isOnPatrol)
        {
            if (_isOnPatrol)
            {
                _rb2d.velocity = new Vector2(_moveSpeed, 0f);
                Debug.Log("Patrol is true");
            }
            else
            {
                _rb2d.velocity = new Vector2(_moveSpeed * 0, 0f);
                Debug.Log("Patrol is false");

            }
        }

        private void CompareTargetPos()
        {
            if (_target.position.x - _transform.position.x > -10 && _target.position.x - _transform.position.x < 10)
            {
                setSearchingState();
            }
            if (_target.position.x - _transform.position.x > -10 && _target.position.x - _transform.position.x < 10)
            {

            }
        }
    }
}

