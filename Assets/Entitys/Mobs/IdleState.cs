using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class IdleState : State
    {
        private Rigidbody2D _rb2d;
        private MonsterBasic _monsterStats;
        private float _movespeed;
        private Transform _transform;
        private Animator _animator;
        private string _currentState;
        float _timer = 0;
        
        public IdleState (Rigidbody2D rb2d, MonsterBasic mb, float movespeed, Transform transform, Animator animator)
        {
            _rb2d = rb2d;
            _monsterStats = mb;
            _movespeed = movespeed;
            _transform = transform;
            _animator = animator;
        }
        
        public override void Enter()
        {
            Debug.Log("Вошли в Idle");
        }

        public override void Exit()
        {
            
            base.Exit();
        }

        public override void FixedUpdate()
        {
            _timer += Time.deltaTime;
            if (_timer < 3)
            {
                Patrule();
            }
            else if (_timer >= 3 && _timer < 6)
            {
                wait();
            }
            else
            {
                flip();
                _timer = 0;
            }
        }
        public override void Update()
        {
            
            
        }
        private void Patrule ()
        {
            _rb2d.velocity = new Vector2(_movespeed * Time.fixedDeltaTime * 3, _rb2d.velocity.y);
        }
        private void flip()
        {   
            _transform.localScale = new Vector2(_transform.localScale.x * -1, _transform.localScale.y);
            _movespeed *= -1;
        }
        private void wait()
        {
            _rb2d.velocity = new Vector2(0, 0);
        }


        public void ChangeHeroAnimationTo(string newState)
        {
            if (_currentState == newState) return; //сейвим ресурсы и не позволяем зациклить вызов стейта
            _animator.Play(newState);
            _currentState = newState;
        }
    }
}

