using hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    //---------pick up logic--------
    [SerializeField] private HeroItemsRepo _heroItemsRepo;

    //---------generate logic---------
    [SerializeField] private ItemsRandomController _randomizer;
    private IterableItemsData _itemType;

    //---------items logic
    private SpriteRenderer _sprite;
    private Light _light;
    

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _light = gameObject.GetComponent<Light>();
        generateItemType();

        
    }

    public void AddToMassive()
    {
        _heroItemsRepo.addItemToDataBase(_itemType);
        Destroy(gameObject);
        Debug.Log("Отработал интеракт на ItemController");
    }

    public void tryToPickUp()
    {
        AddToMassive();
    }

    private void generateItemType ()
    {
        var _randomNumber = Random.Range(1, 100);
        if (_randomNumber < 2)
        {
            _itemType = _randomizer.GetRandomUnicItem();
            _light.color = Color.red;
            _sprite.sprite = _itemType.getSprite();
        }
        else if (_randomNumber > 2 && _randomNumber < 40)
        {
            _itemType = _randomizer.GetRandomRareItem();
            _light.color = Color.blue;
            _sprite.sprite = _itemType.getSprite();
        }
        else
        {
            _itemType = _randomizer.GetRandomCommonItem();
            _light.color = Color.white;
            _sprite.sprite = _itemType.getSprite();
        }
    }

    
}
