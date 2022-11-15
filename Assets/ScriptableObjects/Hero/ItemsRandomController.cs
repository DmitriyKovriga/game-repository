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
        public ScriptableObject[] _CommonitemsData = new ScriptableObject[] { };
        public ScriptableObject[] _RareitemsData = new ScriptableObject[] { };
        public ScriptableObject[] _UnicitemsData = new ScriptableObject[] { };
        Random _random;
        private void Awake()
        {
            _random = new Random();
            
        }


        public ScriptableObject GetRandomCommonItem()
        {
            return _CommonitemsData[_random.Next(0, _CommonitemsData.Length - 1)];
        }

        public ScriptableObject GetRandomRareItem()
        {
            return _RareitemsData[_random.Next(0, _RareitemsData.Length - 1)];
        }

        public ScriptableObject GetRandomUnicItem()
        {
            return _UnicitemsData[_random.Next(0, _UnicitemsData.Length - 1)];
        }
    }
}

