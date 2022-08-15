using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealComponent : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void setNewDamage(float _newDamage)
    {
        _damage = _newDamage;
    }

    public float getDamage ()
    {
        return _damage;
    }
}
