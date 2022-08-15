using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    private Hero _hero;
    private Rigidbody2D _rigidbody2D;
    private float _moveSpeed;
    private float _horizontalInput;
    private float _verticalInput;

    private HeroAnimator _heroAnimator;

    //------rope-------
    private RopeMode ropeMode;
    private bool _isClimbing;

    
    private void Awake()
    {
        _moveSpeed = gameObject.GetComponent<Hero>().getMoveSpeed(); //�������� movespeed �� ������ Hero
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>(); //�������� ����������
        _hero = gameObject.GetComponent<Hero>(); //�������� ������ �����
        _heroAnimator = gameObject.GetComponent<HeroAnimator>();
        ropeMode = gameObject.GetComponent<RopeMode>();
        _isClimbing = ropeMode.getClimbing();

    }

    private void Update()
    {
        if (!_isClimbing) moveHero(); //�������� ������� ��������
    }

    public void flipHero ()
    {
        if (_horizontalInput > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (_horizontalInput < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    public void setHorizonalInput (InputAction.CallbackContext context) //�������� ����� �� � � �, ���������� �� � ���� ���� �������� ������� 2�
    {
        _horizontalInput = context.ReadValue<Vector2>().x;
        flipHero();
        _verticalInput = context.ReadValue<Vector2>().y;
         }

    public void moveHero () //������� ���������
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
     }

    public void jump (InputAction.CallbackContext context)
    {
        if (context.performed && _hero.getGround())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _hero.getJumpHeight()); //������ �������� �� y � jumpHeight �� Hero
        }

        if (context.canceled && _rigidbody2D.velocity.y > 0f)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f); //��������� �������� ���� ������ ������ � ������
        }
    }
}
