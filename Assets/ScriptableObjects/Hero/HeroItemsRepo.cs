using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "New Hero Items Repo", menuName = "Create New Hero Items Repo", order = 51)]
    public class HeroItemsRepo : ScriptableObject
    {
        private LinkedList<IterableItemsData> _itemsData = new LinkedList<IterableItemsData>();

        public void addItemToDataBase(IterableItemsData item)
        {
            if (_itemsData.Contains(item))
            {
                _itemsData.Find(item).Value.addToCount();
            } else {
                _itemsData.AddLast(item).Value.addToCount();
            }
        }
    }
}

