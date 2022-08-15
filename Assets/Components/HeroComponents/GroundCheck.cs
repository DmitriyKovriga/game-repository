using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool _isGround;
    public Transform groundCheckObj;
    public LayerMask groundLayer;

    private Hero _hero;

    private void Awake() //�������������� ������ �� ������ hero
    {
        _hero = gameObject.GetComponent<Hero>();
    }

    public bool isGrounded() //����� ��������� ������������, �������� 0.2, ������� ���� ������ ����
    {
        return Physics2D.OverlapCircle(groundCheckObj.position, 0.2f, groundLayer);
    }

    private void FixedUpdate() //������ ������ �� ������ �������� isground � ���������� ��� � hero
    {
        _isGround = isGrounded();
        _hero.setGround(_isGround);
    }
}
