using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs
{
    public abstract class States : EnemyStateSwitcher
    {
        //protected float _moveSpeed;
        //protected EnemyStateSwitcher _transform;
        //protected States(EnemyStateSwitcher moveSpeed, EnemyStateSwitcher transform)
        //{
        //    _moveSpeed = moveSpeed;
        //    transform = _transform;
        //}
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void Fix()
        {

        }
    }
}
