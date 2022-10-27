using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mobs
{
    public class DeepOneNavigableScript : MonoBehaviour
    {
        [SerializeField] private Monster—haracteristics _monsterC;
        private HPController _monsterHP;
        private void Awake()
        {
            _monsterHP = gameObject.GetComponent<HPController>();
            _monsterHP.setHp(_monsterC.getMaxHp() * _monsterC.getMaxHpModificator());
        }
    }
}

