using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class AggroRangeSender : MonoBehaviour
    {
        [SerializeField] UnityEvent _SearchingSender;
        [SerializeField] UnityEvent _IdleSender;
        [SerializeField] UnityEvent _FightSender;
        private Transform _lastPlayerDetection;
        [SerializeField] LayerMask _playerLayer;

        private void Update()
        {
            
        }

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    _lastPlayerDetection = collision.transform;
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //_lastPlayerDetection = collision.transform;
                Debug.Log("переходим в Search из OnTriggerEnter2D");
                _SearchingSender.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("переходим в Idle из OnTriggerExit2D");
                _IdleSender.Invoke();
                //_lastPlayerDetection = null;
            }
        }
        //public Transform getLastPlayerDetection()
        //{
        //    return _lastPlayerDetection;
        //}
    }
}

