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
    private HeroAnimator _hr;
    private Rigidbody2D _rb2d;
    private Hero _hero;

    [SerializeField] private float _cooldownBetweenAttacks;
    private float _timer;

    private void Awake()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _hr = gameObject.GetComponent<HeroAnimator>();
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _hero = gameObject.GetComponent<Hero>();
    }

    public bool getFire()
    {
        return _isFire;
    }

    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_isFire)
        {
            _rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        } else
        {
            _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        if (_timer > _cooldownBetweenAttacks && _isFire)
        {
            _hr.ChangeHeroAnimationTo("Fire");
            Fire();
            _timer = 0;
            _hr.ChangeHeroAnimationTo("Idle");
        }
    }

    public void FireTrigger(InputAction.CallbackContext context)
    {
        if (context.started && !_hero.getClimbing())
        {
            _isFire = true;
        } else if (context.canceled)
        {
            _isFire = false;
            }
    }

    private void Fire()
    {
        
        Debug.Log("�������");
        if (_sr.flipX)
        {
            Instantiate(_bullet, _fireLeft.position, _fireLeft.rotation); //��������� ������ ������� (��� �������, ��� �������
            
        } else
        {
            Instantiate(_bullet, _fireRight.position, _fireRight.rotation); //��������� ������ ������� (��� �������, ��� �������
        }
        
        }
}
