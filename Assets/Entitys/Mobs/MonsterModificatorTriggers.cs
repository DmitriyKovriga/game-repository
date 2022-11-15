using mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mobs
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private HPController _HPController;
        private MonsterBasic _monsterBasic;
        [SerializeField] ModificatorsToMonsterTrigger _modificatorsData;

        private void Awake()
        {
            _HPController = gameObject.GetComponent<HPController>();
            _monsterBasic = gameObject.GetComponent<MonsterBasic>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                //-------------checks-------------

                if (_modificatorsData.isNeedToResExposure())
                {
                    //resExposure realization
                }

                if (_modificatorsData.isNeedToStun())
                {
                    //_monsterBasic.Stun();
                }

                if (_modificatorsData.isNeedToSlowdown())
                {
                    //_monsterBasic.Slowdown();
                }

                if (_modificatorsData.isNeedToExplosion())
                {
                    //monsterBasic.Explosion();
                }
            }
        }
    }
}

