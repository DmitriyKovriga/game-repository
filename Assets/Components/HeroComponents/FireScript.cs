using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FireScript : MonoBehaviour
{
    
    //------------------------------------------------��������� �������� � ����� � ��������------------------------------------------
    [SerializeField] private Transform _fireRight;
    [SerializeField] private Transform _fireLeft;
    [SerializeField] private UnityEvent _fireLeftEvenet;
    [SerializeField] private UnityEvent _fireRightEvenet;

    
    private bool _isFire = false; //��������� ��������
    [SerializeField] private GameObject _bullet; //������ ����
    private SpriteRenderer _sr; //����� ��� �������� �������
    private HeroAnimator _hr; //����� ��� �������� ������� �� ���������
    private Rigidbody2D _rb2d; //������
    private Hero _hero; //����� ����� �� �����
    private RopeMode _ropeMode; //��� ������� �������� �� �������

    [SerializeField] private float _cooldownBetweenAttacks;
    private float _timer;

    private void Awake()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _hr = gameObject.GetComponent<HeroAnimator>();
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _hero = gameObject.GetComponent<Hero>();
        _ropeMode = gameObject.GetComponent<RopeMode>();
    }

    public bool getFire()
    {
        return _isFire;
    }

    private void Start()
    {
        _cooldownBetweenAttacks = _hero.getResultAttackSpeed();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        

        if (_isFire)
        {
           _rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            if (!_ropeMode.getClimbing()) _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        if (_timer > _cooldownBetweenAttacks && _isFire)
        {
            _hr.FireAnimation();
            Fire();
            _timer = 0;
            
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
        
        
        if (_sr.flipX)
            {
            Instantiate(_bullet, _fireLeft.position, _fireLeft.rotation).gameObject.GetComponent<DamageDealComponent>().setNewDamage(_hero.getResultHeroDamage()); //��������� ������ ������� � �������� ��� ������ �����
            _fireLeftEvenet.Invoke(); //�������� ��������
            } else
            {
            Instantiate(_bullet, _fireRight.position, _fireRight.rotation).gameObject.GetComponent<DamageDealComponent>().setNewDamage(_hero.getResultHeroDamage()); //��������� ������ ������� � �������� ��� ������ �����
            _fireRightEvenet.Invoke(); //�������� ��������
        }
        
        // Play oneshot SFX
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Shots DRY/Shots_1_DRY");

    }

}
