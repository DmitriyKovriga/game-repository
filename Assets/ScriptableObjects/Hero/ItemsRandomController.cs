using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
namespace hero
{
    [CreateAssetMenu(fileName = "New Item Random Controller", menuName = "Create New Item Random Controller", order = 51)]
    public class ItemsRandomController : ScriptableObject
    {
        public IterableItemsData[] _CommonitemsData;
        public IterableItemsData[] _RareitemsData;
        public IterableItemsData[] _UnicitemsData;
        Random _random;
        

        public IterableItemsData GetRandomCommonItem()
        {
            Debug.Log("Сгенерировали камонку");
            _random = new Random();
            int resultIndex = _random.Next(0, _CommonitemsData.Length -1);
            return _CommonitemsData[resultIndex];
        }

        public IterableItemsData GetRandomRareItem()
        {
            Debug.Log("Сгенерировали рарку");
            _random = new Random();
            int resultIndex = _random.Next(0, _RareitemsData.Length -1);
            return _RareitemsData[resultIndex];
        }

        public IterableItemsData GetRandomUnicItem()
        {
            Debug.Log("Сгенерировали уник");
            _random = new Random();
            int resultIndex = _random.Next(0, _UnicitemsData.Length -1);
            return _UnicitemsData[resultIndex];
        }
    }
}

