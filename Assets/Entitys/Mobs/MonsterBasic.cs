using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public class MonsterBasic : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private StateMachine _stateMachine;
        [SerializeField] private AggroRangeSender _aggro;
        private void Start()
        {  
            _stateMachine = new StateMachine();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            _stateMachine.Initialize(new IdleState (gameObject.GetComponent<Rigidbody2D>(), this, _moveSpeed, gameObject.GetComponent<Transform>()));
        }

        private void Update()
        {
            _stateMachine._currentState.Update();
        }

        public float getMoveSpeed()
        {
            return _moveSpeed;
        }

        public void setWarningState()
        {
            GameObject target = _aggro.getLastPlayerDetection();
            _stateMachine.ChangeState(new WarningState(gameObject.GetComponent<Rigidbody2D>(), this, _moveSpeed, gameObject.GetComponent<Transform>(), target));
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 55, 55);
        }

        public void setIdleState()
        {
            _stateMachine.ChangeState(new IdleState(gameObject.GetComponent<Rigidbody2D>(), this, _moveSpeed, gameObject.GetComponent<Transform>()));
        }
    }
}
