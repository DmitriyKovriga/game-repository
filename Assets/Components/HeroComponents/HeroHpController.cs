using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    public class HeroHpController : MonoBehaviour
    {
        [SerializeField] private float _objectHp;
        private float _objectMaxHp;

        [SerializeField] HealthHeroCharacteristics _heroC;


        public float getHp()
        {
            return _objectHp;
        }

        private void Start()
        {
            _objectMaxHp = _heroC.GetResultMaxHp();
            _objectHp = _objectMaxHp;
        }

        public void ModifyHp(float number)
        {
            if (number < 0 && number != 0)
            {
                _objectHp += number;
            }
            else if (number < 0 && number != 0)
            {
                _objectHp += number;
            }
            DeathCheck();
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DealDamage"))
            {
                ModifyHp(collision.gameObject.GetComponent<DamageDealComponent>().getDamage());
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



