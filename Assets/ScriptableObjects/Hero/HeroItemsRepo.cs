using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hero
{
    [CreateAssetMenu(fileName = "New Hero Items Repo", menuName = "Create New Hero Items Repo", order = 51)]
    public class HeroItemsRepo : ScriptableObject
    {
        private LinkedList<IterableItemsData> _itemsData = new LinkedList<IterableItemsData>();
        private bool _nullOrNot;


        private void OnEnable()
        {
            var isReturn = GameObject.FindGameObjectWithTag("ReturnToDefault");
            if (isReturn != null)
            {
                _itemsData.Clear();
            }
        }

        public void addItemToDataBase(IterableItemsData item)
        {
            if (_itemsData.Count == 0)
            {
                Debug.Log("Отработал _itemsData.Count == 0");
                _itemsData.AddLast(item).Value.addToCount();
                return;
            }
            if (_itemsData.Contains(item))
            {
                Debug.Log("Отработа _itemsData.Contains(item)");
                _itemsData.Find(item).Value.addToCount();
            } else {
                Debug.Log("Отработа else");
                _itemsData.AddLast(item).Value.addToCount();
            }
        }
    }
}

