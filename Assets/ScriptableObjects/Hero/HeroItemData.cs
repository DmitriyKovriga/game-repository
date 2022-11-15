using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hero
{

    public abstract class BaseItemData : ScriptableObject
    {
        public Sprite _icon;

        public string _title;

        public string _description;
    }
    [CreateAssetMenu(fileName = "New Iterable", menuName = "Create New Iterable Item", order = 51)]
    public class IterableItemsData : BaseItemData
    {
        public int _maxCount;
        public int _count;
        public int _effectIndex;
        public EffectsOfItems _effectsOfItemsLink;

        public void addToCount()
        {
            if (_count <= _maxCount)
            {
                _count++;
                itemEffect();
            }
        }

        private void itemEffect()
        {
            _effectsOfItemsLink.ActivateItemEffect(_effectIndex);
        }
        
    }
}
