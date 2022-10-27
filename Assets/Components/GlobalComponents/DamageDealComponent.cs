using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    public class DamageDealComponent : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private AttackHero—haracteristics _attackC;
        [SerializeField] private AttackBulletModificators _attackB;

        private void Start()
        {
            CritChanseRoll();
        }

        public void setNewDamage(float _newDamage)
        {
            _damage = _newDamage;
        }

        public float getDamage()
        {
            return _damage;
        }

        private void CritChanseRoll()
        {
            var check = Random.Range(0, 100);

            if (check <= _attackC._getResultCriticalChanse())
            {
                _damage *= _attackC._getResultCriticalMultiplayer();
                Debug.Log("¬€œ¿À  –»“ - ƒ∆≈ œŒ“!");
            }
        }
    }
}

