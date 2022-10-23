using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipSender : MonoBehaviour
{
    [SerializeField] UnityEvent _FlipSender;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _FlipSender.Invoke();
    }

}
