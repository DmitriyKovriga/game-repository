using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "AttackBulletModificatorsData", menuName = "AttackBulletModificators", order = 51)]
    public class AttackBulletModificators : ScriptableObject
    {
        private void OnEnable()
        {
            var isReturn = GameObject.FindGameObjectWithTag("ReturnToDefault");
            if (isReturn != null)
            {
                _isPierce = false;
            }
        }

        [SerializeField] private bool _isPierce;

        public bool isPierce()
        {
            return _isPierce;
        }

        public void setPierce(bool newValue)
        {
            _isPierce = newValue;
        }
    }
}

