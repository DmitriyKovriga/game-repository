using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireScript : MonoBehaviour
{
    [SerializeField] public Transform _fireRight;
    [SerializeField] public Transform _fireLeft;

    private bool _isFire = false;
    [SerializeField] public GameObject _bullet;
    private SpriteRenderer _sr;

    [SerializeField] private float _cooldownBetweenAttacks;
    private float _timer;

    private void Awake()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer > _cooldownBetweenAttacks && _isFire)
        {
            Fire();
            _timer = 0;
            }
    }

    public void FireTrigger(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isFire = true;
            _timer = _cooldownBetweenAttacks;
        } else if (context.canceled)
        {
            _isFire = false;
        }
    }

    private void Fire()
    {
        Debug.Log("Стреляю");
        if (_sr.flipX)
        {
            Instantiate(_bullet, _fireLeft.position, _fireLeft.rotation); //появление нашего префаба (что создаем, где создаем
            
        } else
        {
            Instantiate(_bullet, _fireRight.position, _fireRight.rotation); //появление нашего префаба (что создаем, где создаем
            
        }
        
    }
}
