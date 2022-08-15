using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeMode : MonoBehaviour
{
    [SerializeField] private Transform _ropeTrigger; //������ ��� ������ �������
    [SerializeField] private LayerMask _ropeLayer; //��������� ���� �������

    private Rigidbody2D _rb2d; 
    private Hero _hero; //����� � ���������� �������� ����������

    private Vector2 positionOfRoupe; //���������� ��� �������� ������� ������� �� ��������

    private bool _isOnRope; //���������� � ������� �������� � ��������
    private bool _climbing; //��������� ����������

    private float _VerticalInput;

    private void Awake() //�������������
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _hero = gameObject.GetComponent<Hero>();
    }


    private void isOnRope() //����� ��������� ������������, �������� 0.2, ������� ���� ������ ����
    {
        _isOnRope = Physics2D.OverlapCircle(_ropeTrigger.position, 0.2f, _ropeLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision) //���� ������� � ��� ���������� ���������� � �������
    {
        if (collision.gameObject.layer == _ropeLayer)
        {
            positionOfRoupe = collision.GetComponent<Transform>().position;
        }
    }

    private void Update()
    {
        isOnRope(); //���� �������
        if (_climbing) climb(); //��������� ���� ����� � ����
    }

    private void climb()
    {
        _rb2d.velocity = new Vector2(0, _hero.getClimbingSpeed() * _VerticalInput);

    }

    public void EnterClimbingMode (InputAction.CallbackContext context) //�� ������� ������ ������������,
    {
        _VerticalInput = context.ReadValue<Vector2>().y;
        if (_isOnRope && !_climbing && _VerticalInput > 0) //���� �� �� ������ � �� �� ����������� � �� ������ �����, �� �� �������� �����������, ��������� ���������� � ������ ������ �� � � � �������
        {
            _climbing = true;
            _rb2d.gravityScale = 0;
            _rb2d.MovePosition(new Vector2(positionOfRoupe.x, _rb2d.position.y));
            _rb2d.constraints = RigidbodyConstraints2D.FreezePositionX; //������ �� �
            
        }
    }


    public void ExitClimbMode (InputAction.CallbackContext context) //����� �� ���������� �� �������
    {
        if (_climbing)
        {
            _climbing = false;
            _rb2d.gravityScale = 4;
            _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; //�������� �� �
        }
    }

    
    public bool getClimbing() //���-��� ��� ��������� ��������� ��-���
    {
        return _climbing;
    }
}
