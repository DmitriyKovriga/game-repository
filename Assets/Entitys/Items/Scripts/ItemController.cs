using hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    private bool _isPickUpAllowed;
    [SerializeField] private UnityEvent _TryPickUP;

    public void AddToMassive()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isPickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isPickUpAllowed = false;
        }
    }

    public void Interact ()
    {
        if (_isPickUpAllowed)
        {
            _TryPickUP.Invoke();
        }
    }
}
