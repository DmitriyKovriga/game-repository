using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mobs
{
    public class WarningState : State
    {
        private Rigidbody2D _rb2d;
        private MonsterBasic _monsterStats;
        private float _movespeed;
        private Transform _transform;
        float _timer = 0;
        private GameObject _target;

        public WarningState(Rigidbody2D rb2d, MonsterBasic mb, float movespeed, Transform transform, GameObject target)
        {
            _rb2d = rb2d;
            _monsterStats = mb;
            _movespeed = movespeed;
            _transform = transform;
            _target = target;
        }

        public override void Enter()
        {
            Debug.Log("Вошли в Warning");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget ()
        {
            if (_target.transform.position.x > _transform.position.x)
            {
                Debug.Log("Бегу за игроком вправо");
                _rb2d.velocity = new Vector2(_movespeed * Time.fixedDeltaTime * 3, _rb2d.velocity.y);
            } else {
                Debug.Log("Бегу за игроком влево");
                _rb2d.velocity = new Vector2((_movespeed * Time.fixedDeltaTime * 3) * -1, _rb2d.velocity.y);
            }
        }
    }
    
}

