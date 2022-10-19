using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mobs
{
    public class WarningState : State
    {
        private Rigidbody2D _rb2d;
        
        private float _movespeed;
        private Transform _transform;
        private GameObject _agrro;
        private AggroRangeSender _agrroRS;
        float _timer = 0;
        private GameObject _target;
        private Animator _animator;

        public WarningState(Rigidbody2D rb2d, float movespeed, Transform transform, GameObject target, Animator animator, GameObject agrro)
        {
            _rb2d = rb2d;
            _agrro = agrro;
            _movespeed = movespeed;
            _transform = transform;
            _target = target;
            _animator = animator;
            _agrroRS = _agrro.GetComponent<AggroRangeSender>();
        }

        public override void Enter()
        {
            Debug.Log("¬ошли в Warning");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            UpdateTarget();
        }

        public override void FixedUpdate()
        {
            MoveToTarget();
        }

        private void UpdateTarget()
        {
            _target = _agrroRS.getLastPlayerDetection();
        }

        private void MoveToTarget ()
        {
            if (_target.transform.position.x > _transform.position.x)
            {
                _rb2d.velocity = new Vector2(_movespeed, _rb2d.velocity.y);
                Debug.Log("Ѕегу за игроком вправо, противник в координатах: " + _target.transform.position.x + " наш велосити " + _rb2d.velocity.x);
            } else if (_target.transform.position.x < _transform.position.x)
            {
                _rb2d.velocity = new Vector2(_movespeed * -1, _rb2d.velocity.y);
                Debug.Log("Ѕегу за игроком влево, противник в координатах: " + _target.transform.position.x + " наш велосити " + _rb2d.velocity.x);
            } else
            {
                Debug.Log("—тою в противнике ?");
            }
        }
    }
    
}

