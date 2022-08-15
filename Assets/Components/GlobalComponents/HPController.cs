using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HPController : MonoBehaviour
{
    [SerializeField] private float _objectHp;
    

    

    public float getHp ()
    {
        return _objectHp;
    }

    public void setHp (float number)
    {
        if (number < 0)
        {
            _objectHp -= number;
        } else
        {
            _objectHp += number;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DealDamage"))
        {
            _objectHp -= collision.gameObject.GetComponent<DamageDealComponent>().getDamage();
            Debug.Log("Больно в ноге");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DealDamage"))
        {
            _objectHp -= collision.gameObject.GetComponent<DamageDealComponent>().getDamage();
            Debug.Log("Больно в ноге");
        }
    }
}
