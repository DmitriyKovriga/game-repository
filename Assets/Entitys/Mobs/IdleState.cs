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
        float _timer = 0;
        
        public IdleState (Rigidbody2D rb2d, MonsterBasic mb, float movespeed, Transform transform)
        {
            _rb2d = rb2d;
            _monsterStats = mb;
            _movespeed = movespeed;
            _transform = transform;
        }
        
        public override void Enter()
        {
            Debug.Log("Вошли в Idle");
        }

        public override void Exit()
        {
            
            base.Exit();
        }
        public override void Update()
        {
            
            _timer += Time.deltaTime;
            if (_timer < 3)
            {
                Patrule();
            } else if (_timer >=3 && _timer < 6)
            {
                wait();
            } else
            {
                flip();
                _timer = 0;
            }
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
}
}

