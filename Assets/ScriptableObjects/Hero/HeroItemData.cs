using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hero
{

    public abstract class HeroItemData : ScriptableObject
    {
        public Sprite _icon;

        public string _title;

        public string _description;

        public Sprite getSprite()
        {
            return _icon;
        }
    }
}
