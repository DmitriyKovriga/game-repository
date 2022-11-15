using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "Effects", menuName = "Create Item Effect Controller", order = 51)]
    public class EffectsOfItems : ScriptableObject
    {
        [SerializeField] AttackHero—haracteristics _attackCh;
        [SerializeField] HealthHeroCharacteristics _HpCh;
        [SerializeField] AttackBulletModificators _AttackCh;
        [SerializeField] ModificatorsToMonsterTrigger _ModificatorsCh;
        public void ActivateItemEffect(int index)
        {
            switch(index)
            {
                case 1: //mermaid sheeet
                    _HpCh.ModifyMaxHpBase(25);
                    break;
                default:
                    Debug.Log("Bug With Item Effect");
                    break;
            }
        }
    }
}

