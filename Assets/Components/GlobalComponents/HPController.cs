using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hero
{
    public class HPController : MonoBehaviour
    {
        [SerializeField] private float _objectHp;


        public float getHp()
        {
            return _objectHp;
        }

        public void setHp(float number)
        {
            if (number < 0 && number != 0)
            {
                Debug.Log("setHp:HPController �� " + _objectHp + " ��� ���������� �� " + number);
                _objectHp += number;
            }
            else if (number < 0 && number != 0)
            {
                Debug.Log("setHp:HPController �� " + _objectHp + " ��� ���������� �� +" + number);
                _objectHp += number;
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

