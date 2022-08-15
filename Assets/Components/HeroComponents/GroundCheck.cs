using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool _isGround;
    public Transform groundCheckObj;
    public LayerMask groundLayer;

    private Hero _hero;

    private void Awake() //инициализируем ссылку на скрипт hero
    {
        _hero = gameObject.GetComponent<Hero>();
    }

    public bool isGrounded() //метод отрисовки оверлапкруга, радиусом 0.2, который ищет граунд леер
    {
        return Physics2D.OverlapCircle(groundCheckObj.position, 0.2f, groundLayer);
    }

    private void FixedUpdate() //каждый апдейт мы задаем значение isground и отправляем его в hero
    {
        _isGround = isGrounded();
        _hero.setGround(_isGround);
    }
}
