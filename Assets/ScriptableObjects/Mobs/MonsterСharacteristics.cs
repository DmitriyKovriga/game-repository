using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New Monster Data", menuName = "New Monster Data", order = 51)]
    public class Monster—haracteristics : ScriptableObject
    {
        [SerializeField] private float _maxHp;
        [SerializeField] private float _maxHpModificator;
        [SerializeField] private float _attackDamage;
        [SerializeField] private float _attackDamageModificator;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _moveSpeedModificator;
        [SerializeField] private float _dropBlood;
        [SerializeField] private float _dropBloodModificator;
        [SerializeField] private float _dropMoney;
        [SerializeField] private float _dropMoneyModiificator;
        [SerializeField] private float _stunTime;
        [SerializeField] private float _stunResistance;
        [SerializeField] private float _pushbackDistance;
        [SerializeField] private float _pushbackResistance;


        public float getMaxHp()
        {
            return _maxHp;
        }

        public void setMaxHp(float newValue)
        {
            _maxHp += newValue;
        }

        public void setMaxHpModificator(float newValue)
        {
            _maxHp = newValue;
        }

        public float getMaxHpModificator()
        {
            return _maxHpModificator;
        }

        public void setAttackDamage(float newValue)
        {
            _attackDamage = newValue;
        }

        public float getAttackDamage()
        {
            return _attackDamage;
        }

        public void setAttackDamageModificator(float newValue)
        {
            _attackDamageModificator = newValue;
        }

        public float getAttackDamageModificator()
        {
            return _attackDamageModificator;
        }

        public void setMoveSpeed(float newValue)
        {
            _moveSpeed = newValue;
        }

        public float getMoveSpeed()
        {
            return _moveSpeed;
        }

        public void setMoveSpeedModificator(float newValue)
        {
            _moveSpeedModificator = newValue;
        }

        public float getMoveSpeedModificator()
        {
            return _moveSpeedModificator;
        }

        public void setDropBlood(float newValue)
        {
            _dropBlood = newValue;
        }

        public float getDropBlood()
        {
            return _dropBlood;
        }

        public void setDropBloodModificator(float newValue)
        {
            _dropBloodModificator = newValue;
        }

        public float getDropBloodModificator()
        {
            return _dropBloodModificator;
        }

        public void setDropMoney(float newValue)
        {
            _dropMoney = newValue;
        }

        public float getDropMoney()
        {
            return _dropMoney;
        }

        public void setDropMoneyModiificator(float newValue)
        {
            _dropMoneyModiificator = newValue;
        }

        public float getDropMoneyModiificator()
        {
            return _dropMoneyModiificator;
        }

        public void setStunTime(float newValue)
        {
            _stunTime = newValue;
        }

        public float getStunTime()
        {
            return _stunTime;
        }

        public void setStunResistance(float newValue)
        {
            _stunResistance = newValue;
        }

        public float getStunResistance()
        {
            return _stunResistance;
        }

        public void setPushbackDistance(float newValue)
        {
            _pushbackDistance = newValue;
        }

        public float getPushbackDistance()
        {
            return _pushbackDistance;
        }

        public void setPushbackResistance(float newValue)
        {
            _pushbackResistance = newValue;
        }

        public float getPushbackResistance()
        {
            return _pushbackResistance;
        }
    }


