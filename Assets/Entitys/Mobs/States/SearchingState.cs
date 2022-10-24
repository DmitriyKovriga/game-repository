using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class SearchingState : States
    {
        private float _timer;

        public SearchingState(StateController StateController, Rigidbody2D rb2d, float moveSpeed, Transform transform, Animator anim, Transform target)
        {
            _StateController = StateController;
            _rb2d = rb2d;
            _moveSpeed = moveSpeed;
            _transform = transform;
            _anim = anim;
            _target = target;
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
            CompareTargetPos();
            Debug.Log("Chasing Player!");
            //GetPlayerPos();
            //Debug.Log("Позиция моба: " + _transform.position.x);
            //Debug.Log("Позиция игрока: " + _target.position.x);
        }

        public override void Fix()
        {
            base.Fix();
            _moveSpeed *= -1;
        }

        //void GetPlayerPos()
        //{
        //    _target = _aggro.getLastPlayerDetection().GetComponent<Transform>();
        //}

        private void MoveToTarget()
        {
            _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y);
            var testPos = new Vector2 (_transform.position.x, _transform.position.y);

            _timer += Time.deltaTime;
            if (_timer > 2 && (testPos.Equals(_transform)))
            {
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, 4);
                //_anim.Play("Jump");
                _timer = 0;
            }
            
            //if (_target.transform.position.x > _transform.position.x)
            //{
            //    _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y);
            //    //Debug.Log("Моб бежит вправо: " + (_moveSpeed, _rb2d.velocity.y));
            //}
            //else if (_target.transform.position.x < _transform.position.x)
            //{
            //    Debug.Log("Позиция моба (влево): " + _transform.position.x + " " + _transform.position.y);
            //    Debug.Log("Позиция игрока (влево): " + _target.position.x + " " + _target.position.y);
            //    _rb2d.velocity = new Vector2(_moveSpeed * -1, _rb2d.velocity.y);
            //    //Debug.Log("Моб бежит влево: " + (_moveSpeed * -1, _rb2d.velocity.y));
            //}
            //else
            //{
            //    Debug.Log("Стоит кряхтит");
            //}
        }

        private void CompareTargetPos()
        {
            if (_target.position.x - _transform.position.x > -10 && _target.position.x - _transform.position.x < 0)
            {
                if (_target.position.y - _transform.position.y > -10 && _target.position.y - _transform.position.y < 0)
                {
                    if (_transform.localScale.x == -1)
                    {
                        FlipEnemyFacing();
                    }
                    _moveSpeed /= 1.5f;
                    MoveToTarget();
                }
            }
            else if (_target.position.x - _transform.position.x < 10 && _target.position.x - _transform.position.x > 0)
            {
                if (_target.position.y - _transform.position.y < 10 && _target.position.y - _transform.position.y > 0)
                {
                    if (_transform.localScale.x == 1)
                    {
                        FlipEnemyFacing();
                    }
                    _moveSpeed /= 1.5f;
                    MoveToTarget();
                }
            }
            else
                _timer += Time.deltaTime;

            if (_timer > 3f)
            {
                _timer = 0f;
                _moveSpeed *= 1.5f;
                setIdleState();
            }
        }
    }
}

// прыжок и замедление моба