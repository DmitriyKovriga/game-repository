using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class EnemyStateSwitcher : MonoBehaviour
    {
        private StateController _SC;
        [SerializeField] 
        protected AggroRangeSender _aggro;
        protected float _moveSpeed = 10f;
        protected Transform _transform;
        protected Rigidbody2D _rb2d;
        protected Animator _anim;
        protected Transform _target;
        protected bool Flip = true;

        protected StateController _StateController;

        [SerializeField]
        public UnityEvent _lastPlayerPos;

        [SerializeField]
        protected GameObject LargeLookBox;
        [SerializeField]
        protected GameObject SmallLookBox;
        [SerializeField]
        private GameObject CheckForObstacles;

        void Start()
        {
            _transform = gameObject.GetComponent<Transform>();
            _rb2d = gameObject.GetComponent<Rigidbody2D>();
            _anim = gameObject.GetComponent<Animator>();

            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            _SC = new StateController();
            _SC.Initialize(new IdleState(_StateController, _rb2d, _moveSpeed, _transform, _anim, _target));
        }

        void Update()
        {
            _SC._currentState.Update();
            Debug.Log(_moveSpeed + " EnemyStateSwitcher");
        }

       public void FlipEnemyFacing()
        {
            _SC._currentState.Fix();
            _transform.localScale = new Vector2(_transform.localScale.x * -1, _transform.localScale.y);
        }

        public void setSearchingState()
        {
            _SC.NextState(new SearchingState(_StateController, _rb2d, _moveSpeed, _transform, _anim, _target));
        }

        public void setIdleState()
        {
            _SC.NextState(new IdleState(_StateController, _rb2d, _moveSpeed, _transform, _anim, _target));
        }

    }
}

