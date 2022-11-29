using hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Iterable", menuName = "Create New Iterable Item", order = 51)]
public class IterableItemsData : HeroItemData
{
    public int _maxCount;
    public int _count = 0;
    public int _effectIndex;
    public EffectsOfItems _effectsOfItemsLink;
    public string _rarity;

    

    public void addToCount()
    {
        if (_count < _maxCount)
        {
            _count++;
            itemEffect();
        }
    }

    private void OnEnable()
    {
        var isReturn = GameObject.FindGameObjectWithTag("ReturnToDefault");
        if (isReturn != null)
        {
            _count = 0;
        }
    }

    private void itemEffect()
    {
        _effectsOfItemsLink.ActivateItemEffect(_effectIndex);
    }

}
