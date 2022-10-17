using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroItemData : ScriptableObject
{
    
}

//--------------------------------------------Iterable Item Abstact class------------------------------------
public abstract class IterableItem
{
    private int _count = 0;
    private int _maxCount;

    public abstract void _AddToCount();

    public abstract void ItemEffect();
}

public abstract class UnicItem
{
    public abstract void ItemEffect();
}

//-------------------------------------------Our Items-------------------------------------------------------

public class MermaidTear : IterableItem
{
    private int _count = 0;
    private int _maxCount;

    public override void _AddToCount()
    {
        if (_count < _maxCount) //if we have count < maxCount, we add 1 to count and run itemEffect
        {
            _count++;
            ItemEffect();
        }
    }

    public override void ItemEffect()
    {
        // add +25 hp to our hero hp pool
    }
}