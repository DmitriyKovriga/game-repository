using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class EdgeCheck : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _edgeCheck;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _edgeCheck.Invoke();
            }
        }
    }
}
