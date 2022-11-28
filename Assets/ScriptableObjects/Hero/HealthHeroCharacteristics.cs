using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "Hero Health Characteristic Scriptable Object", menuName = "Hero Health Characteristic Scriptable Object", order = 51)]
    public class HealthHeroCharacteristics : ScriptableObject
    {
        private void OnEnable()
        {
            var isReturn = GameObject.FindGameObjectWithTag("ReturnToDefault");
            if (isReturn != null)
            {
                _maxHpBase = _maxHpBaseDefault;
                _maxHpModificator = _maxHpModificatorDefault;
                _resultMaxHp = _ResultmaxHpDefault;

                _moveSpeedBase = _moveSpeedBaseDefault;
                _moveSpeedModificator = _moveSpeedModificatorDefault;
                _resultMoveSpeed = _resultMoveSpeedDefault;

                _jumpHeight = _jumpHightDefault;

                _luck = _luckDefault;
                _sanity = _sanityDefault;

                _stunTime = _stunTimeDefault;
                _stunResistance = _stunResistanceDefault;
                _resultStunTime = _resultStunTimeDefault;
            }
        }



        //-------------------HP------------------
        [SerializeField] float _maxHpBase;
        [SerializeField] float _maxHpModificator;
        [SerializeField] float _resultMaxHp;
        private float _maxHpBaseDefault = 100;
        private float _maxHpModificatorDefault = 1;
        private float _ResultmaxHpDefault = 100;

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
            _maxHpBase += number;
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
        float _moveSpeedBaseDefault = 7;
        float _moveSpeedModificatorDefault = 1;
        float _resultMoveSpeedDefault = 7;

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
        private float _jumpHightDefault = 14;

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
        private float _luckDefault = 10;

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
        private float _sanityDefault = 10;
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
        private float _stunTimeDefault = 2;
        private float _stunResistanceDefault = 1;
        private float _resultStunTimeDefault = 2;
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

