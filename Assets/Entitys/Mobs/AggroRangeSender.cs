using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class AggroRangeSender : MonoBehaviour
    {
        [SerializeField] UnityEvent _warningSender;
        [SerializeField] UnityEvent _idleSender;
        private GameObject _lastPlayerDetection;
        [SerializeField] LayerMask _playerLayer;

        

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _lastPlayerDetection = collision.gameObject;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _lastPlayerDetection = collision.gameObject;
                _warningSender.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _idleSender.Invoke();
                _lastPlayerDetection = null;
            }
        }

        

        public GameObject getLastPlayerDetection()
        {
            return _lastPlayerDetection;
        }
    }
}

