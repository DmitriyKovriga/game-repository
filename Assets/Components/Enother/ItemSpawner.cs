using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _randomItemPrefab;
    public void spawnRandomItem ()
    {
        Instantiate(_randomItemPrefab, this.transform.position, this.transform.rotation);
    }
}
