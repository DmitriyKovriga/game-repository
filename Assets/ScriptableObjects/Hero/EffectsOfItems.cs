using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "Effects", menuName = "Create Item Effect Controller", order = 51)]
    public class EffectsOfItems : ScriptableObject
    {
        [SerializeField] AttackHeroÑharacteristics _attackCh;
        [SerializeField] HealthHeroCharacteristics _HpCh;
        [SerializeField] AttackBulletModificators _AttackCh;
        [SerializeField] ModificatorsToMonsterTrigger _ModificatorsCh;
        [SerializeField] GameObject _player;
        [SerializeField] HeroHpController _playerHpControl;
        public void ActivateItemEffect(int index)
        {
            switch(index)
            {
                case 1: //mermaid sheeet
                    _HpCh.ModifyMaxHpBase(25);
                    _HpCh.ComputeResultMaxHp();
                    Debug.Log("Óâåëè÷èë ìàêñ õï â ÑÎ, òåïåðü îíî ðàâíî - " + _HpCh.GetResultMaxHp());
                    _playerHpControl.updateMaxHp();
                    _playerHpControl.ModifyHp(25);
                    break;
                default:
                    Debug.Log("Bug With Item Effect");
                    break;
            }
        }

        public void setActivePlayer(GameObject player, HeroHpController playerHpControll)
        {
            _player = player;
            _playerHpControl = playerHpControll;
        }
    }
}

