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

    public UnityEvent _unityEvent;


    private TriggerToHp _damageTrigger;
    

    private void Awake()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _damageTrigger = gameObject.GetComponent<TriggerToHp>();
        
    }

    void Start()
    {
        _rb2d.velocity = transform.right * _speed;
        _damageTrigger.setHpModifie(10); //задали урон пуле 10
    }

     private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.TryGetComponent(out Rigidbody2D r2d))
        {
            Debug.Log("Пуля разбилась об: " + hitInfo);
            Destroy(gameObject);
        }
    }
    
}
