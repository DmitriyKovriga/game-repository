using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hero
{
    [CreateAssetMenu(fileName = "Hero Attack Characteristic Scriptable Object", menuName = "Hero Attack Characteristic Scriptable Object", order = 51)]
    public class AttackHero–°haracteristics : ScriptableObject
    {
        //----------------Damage var----------------
        [SerializeField] float _DamageBase;
        [SerializeField] float _DamageModificator;
        [SerializeField] float _resultDamage;
        private float _DamageBaseDefault = 25;
        private float _DamageModificatorDefault = 1;
        private float _DamageResultDefault = 25;
        public void ComputeDamage ()
        {
            _resultDamage = _DamageBase* _DamageModificator;
        }

        public void ModifyDamageBase (float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _DamageBase -= number;
            } else if (number > 0 && number != 0)
            {
                _DamageBase += number;
            }
        }

        public void ModifyDamageModificator(float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _DamageModificator -= number;
            }
            else if (number > 0 && number != 0)
            {
                _DamageModificator += number;
            }
        }

        public float _getResultDamage ()
        {
            return _resultDamage;
        }

        //------------Damage var-----------------

        //------------Attack speed---------------

        [SerializeField] float _attackSpeed; //Time between attacks ?
        private float _attackSpeedDefault = 0.4f;
        public float GetAttackSpeed ()
        {
            return _attackSpeed;
        }

        public void ModifyAttackSpeed (float number)
        {
            if (number < 0 && number != 0)
            {
                _attackSpeed -= number;
            }
            else if (number > 0 && number != 0)
            {
                _attackSpeed += number;
            }
        }
        //-----------Attack speed---------------

        //-----------Critical Chanse and Multiplayer----------
        [SerializeField] private float _criticalChanseBase;
        [SerializeField] private float _criticalChanseModiificator;
        [SerializeField] private float _resultCriticalChanse;
        private float _criticalChanseBaseDefault = 10;
        private float _criticalChanseModificatorDefault = 1;
        private float _ResultcriticalChanseDefault = 10;

        public void ComputeCriticalChanse()
        {
            _resultCriticalChanse = _criticalChanseBase * _criticalChanseModiificator;
        }

        public void ModifyCriticalChanseBase(float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _criticalChanseBase -= number;
            }
            else if (number > 0 && number != 0)
            {
                _criticalChanseBase += number;
            }
        }

        public void ModifyCriticalChanseModificator(float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _criticalChanseModiificator -= number;
            }
            else if (number > 0 && number != 0)
            {
                _criticalChanseModiificator += number;
            }
        }

        public float _getResultCriticalChanse()
        {
            return _resultCriticalChanse;
        }

        [SerializeField] private float _criticalMultiplayerBase;
        [SerializeField] private float _criticalMultiplayerModificator;
        [SerializeField] private float _resultCriticalMultiplayer;
        private float _criticalMultiplayerBaseDefault = 2;
        private float _criticalMultiplayerModificatorDefault = 1;
        private float _resultCriticalMultiplayerDefault = 2;

        public void ComputeCriticalMultiplayer()
        {
            _resultCriticalMultiplayer = _criticalMultiplayerBase * _criticalMultiplayerModificator;
        }

        public void ModifyCriticalMultiplayerBase(float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _criticalMultiplayerBase -= number;
            }
            else if (number > 0 && number != 0)
            {
                _criticalMultiplayerBase += number;
            }
        }

        public void ModifyCriticalMultiplayerModificator(float number) // Just plus and minus things with flat damage. For regulate just set - or + value.
        {
            if (number < 0 && number != 0)
            {
                _criticalMultiplayerModificator -= number;
            }
            else if (number > 0 && number != 0)
            {
                _criticalMultiplayerModificator += number;
            }
        }

        public float _getResultCriticalMultiplayer()
        {
            return _resultCriticalMultiplayer;
        }

        public float _getFustCriticalDamage()
        {
            return _resultDamage * _resultCriticalMultiplayer;
        }

        private void OnEnable()
        {
            var isReturn = GameObject.FindGameObjectWithTag("ReturnToDefault");
            if (isReturn != null)
            {
                _DamageBase = _DamageBaseDefault;
                _DamageModificator = _DamageModificatorDefault;
                _resultDamage = _DamageResultDefault;
                _attackSpeed = _attackSpeedDefault;
                _criticalChanseBase = _criticalChanseBaseDefault;
                _criticalChanseModiificator = _criticalChanseModificatorDefault;
                _resultCriticalChanse = _ResultcriticalChanseDefault;
                _criticalMultiplayerBase = _criticalMultiplayerBaseDefault;
                _criticalMultiplayerModificator = _criticalMultiplayerModificatorDefault;
                _resultCriticalMultiplayer = _resultCriticalMultiplayerDefault;
            }
        }
    }
}

