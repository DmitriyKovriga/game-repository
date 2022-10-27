using hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mobs
{
    public class HPController : MonoBehaviour
    {
        [SerializeField] private float _objectHp;
        [SerializeField] private float _objectMaxHp;


        public float getHp()
        {
            return _objectHp;
        }

        public void modifyHp(float number)
        {
            if (number < 0 && number != 0)
            {
                _objectHp += number;
            }
            else if (number < 0 && number != 0)
            {
                _objectHp += number;
            }
        }

        public void setHp(float newValue)
        {
            _objectHp = newValue;
            _objectMaxHp = newValue;
        }

        private void FixedUpdate()
        {
            if (_objectHp > _objectMaxHp)
            {
                _objectHp = _objectMaxHp;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DealDamage"))
            {
                setHp(collision.gameObject.GetComponent<DamageDealComponent>().getDamage());
                DeathCheck();
            }
        }

        public void DeathCheck()
        {
            if (_objectHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

