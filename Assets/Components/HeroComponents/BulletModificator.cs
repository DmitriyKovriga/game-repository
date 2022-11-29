using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace hero
{
    public class BulletModificator : MonoBehaviour
    {

        [SerializeField] private float _speed;
        private Rigidbody2D _rb2d;

        [SerializeField] LayerMask _enemyLayer;
        [SerializeField] LayerMask _groundLayer;
        [SerializeField] LayerMask _platformLayer;
        [SerializeField] LayerMask _playerLayer;
        [SerializeField] LayerMask _bulletLayer;
        [SerializeField] AttackBulletModificators _logicModificator;


    private void Awake()
        {
            _rb2d = gameObject.GetComponent<Rigidbody2D>();

        }

        void Start()
        {
            _rb2d.velocity = transform.right * _speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo )
        {
            if (hitInfo.gameObject.layer != 11)
            {
                if (_logicModificator.isPierce())
                {
                    if (hitInfo.gameObject.layer == 3) //idk why it not working with _groundLayer, but wuth number 3 is all fine
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (hitInfo.TryGetComponent(out Rigidbody2D r2d2) && hitInfo.gameObject.layer != _playerLayer && hitInfo.gameObject.layer != _bulletLayer)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D hitInfo)
        {
            if (hitInfo.gameObject.layer != 11)
            {
                if (_logicModificator.isPierce())
                {
                    if (hitInfo.gameObject.layer == 3) //idk why it not working with _groundLayer, but wuth number 3 is all fine
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (hitInfo.TryGetComponent(out Rigidbody2D r2d2) && hitInfo.gameObject.layer != _playerLayer && hitInfo.gameObject.layer != _bulletLayer)
                    {
                        Destroy(gameObject);
                    }
                }
            }

        }

    }
}

