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

    private void Awake()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_isFire)
        {
            Fire();
        }
    }

    public void FireTrigger(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!!!");
        if (context.started)
        {
            Debug.Log("������ ������");
            _isFire = true;
        } else if (context.canceled)
        {
            Debug.Log("������ ���������");
            _isFire = false;
        }
    }

    private void Fire()
    {
        if (_sr.flipX)
        {
            Instantiate(_bullet, _fireLeft.position, _fireLeft.rotation); //��������� ������ ������� (��� �������, ��� �������
            _isFire = false;
        } else
        {
            Instantiate(_bullet, _fireRight.position, _fireRight.rotation); //��������� ������ ������� (��� �������, ��� �������
            _isFire = false;
        }
        
    }
}
