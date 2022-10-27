using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "Hero Health Characteristic Scriptable Object", menuName = "Hero Health Characteristic Scriptable Object", order = 51)]
    public class HealthHeroCharacteristics : ScriptableObject
    {
        //-------------------HP------------------
        [SerializeField] float _maxHpBase;
        [SerializeField] float _maxHpModificator;
        [SerializeField] float _resultMaxHp;

        public void ComputeResultMaxHp ()
        {
            _resultMaxHp = _maxHpBase * _maxHpModificator;
        }

        public float GetResultMaxHp ()
        {
            return _resultMaxHp;
        }

        public void ModifyMaxHpBase (float number)
        {
            if (number < 0 && number != 0)
            {
                _maxHpBase -= number;
            }
            else if (number > 0 && number != 0)
            {
                _maxHpBase += number;
            }
        }

        public void ModifyMaxHpModificator(float number)
        {
            if (number < 0 && number != 0)
            {
                _maxHpModificator -= number;
            }
            else if (number > 0 && number != 0)
            {
                _maxHpModificator += number;
            }
        }
        //---------------------HP-----------------------

        //-----------------MoveSpeed--------------------
        [SerializeField] float _moveSpeedBase;
        [SerializeField] float _moveSpeedModificator;
        [SerializeField] float _resultMoveSpeed;

        public void ComputeResultMoveSpeed()
        {
            _resultMoveSpeed = _moveSpeedBase * _moveSpeedModificator;
        }

        public float GetResultMoveSpeed()
        {
            return _resultMoveSpeed;
        }

        public void ModifyMoveSpeedBase(float number)
        {
            if (number < 0 && number != 0)
            {
                _moveSpeedBase -= number;
            }
            else if (number > 0 && number != 0)
            {
                _moveSpeedBase += number;
            }
        }

        public void ModifyMoveSpeedModificator(float number)
        {
            if (number < 0 && number != 0)
            {
                _moveSpeedModificator -= number;
            }
            else if (number > 0 && number != 0)
            {
                _moveSpeedModificator += number;
            }
        }
        //------------------Move Speed------------------

        //------------------JUMP------------------------
        [SerializeField] private float _jumpHeight;

        public void ModifyJumpHeight (float number)
        {
            if (number < 0 && number != 0)
            {
                _jumpHeight -= number;
            }
            else if (number > 0 && number != 0)
            {
                _jumpHeight += number;
            }
        }

        public float GetJumpHeight ()
        {
            return _jumpHeight;
        }
        //-----------------JUMP-------------------------

        //-----------------Luck------------------------

        [SerializeField] private float _luck;

        public void ModifyLuck(float number)
        {
            if (number < 0 && number != 0)
            {
                _luck -= number;
            }
            else if (number > 0 && number != 0)
            {
                _luck += number;
            }
        }

        public float GetLuck()
        {
            return _luck;
        }

        //-----------------Luck------------------------

        //-----------------Sanity----------------------

        [SerializeField] private float _sanity;
        public void ModifySanity(float number)
        {
            if (number < 0 && number != 0)
            {
                _sanity -= number;
            }
            else if (number > 0 && number != 0)
            {
                _sanity += number;
            }
        }

        public float GetSanity()
        {
            return _sanity;
        }
        //-----------------Sanity----------------------

        //-----------------Stun Resustance and Stun Time---------------------

        [SerializeField] float _stunTime;
        [SerializeField] float _stunResistance;
        [SerializeField] float _resultStunTime;
        public void ComputeResultStunTime ()
        {
            _resultStunTime = _stunTime * _stunResistance;
        }

        public float GetResultStunTime()
        {
            return _resultMaxHp;
        }

        public void ModifyStunTime(float number)
        {
            if (number < 0 && number != 0)
            {
                _stunTime -= number;
            }
            else if (number > 0 && number != 0)
            {
                _stunTime += number;
            }
        }

        public void ModifyStunResistance(float number)
        {
            if (number < 0 && number != 0)
            {
                _stunResistance -= number;
            }
            else if (number > 0 && number != 0)
            {
                _stunResistance += number;
            }
        }
    }
}

