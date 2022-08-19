using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModificator : MonoBehaviour
{

    [SerializeField] public float _speed;
    public Rigidbody2D _rb2d;

    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] LayerMask _platformLayer;

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
        
        if (hitInfo.TryGetComponent(out Rigidbody2D r2d))
        {
            Debug.Log("���� ��������� ��: " + hitInfo);
            Destroy(gameObject);
        }
        
    }
}
