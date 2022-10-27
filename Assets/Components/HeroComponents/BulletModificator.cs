using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletModificator : MonoBehaviour
{

    [SerializeField] public float _speed;
    public Rigidbody2D _rb2d;

    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] LayerMask _platformLayer;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] LayerMask _bulletLayer;


    private void Awake()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        _rb2d.velocity = transform.right * _speed;
    }

     private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.TryGetComponent(out Rigidbody2D r2d) && hitInfo.gameObject.layer != _playerLayer && hitInfo.gameObject.layer != _bulletLayer)
        {
            Destroy(gameObject);
        }
    }
    
}
