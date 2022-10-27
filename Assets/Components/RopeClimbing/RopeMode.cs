using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace hero
{
    public class RopeMode : MonoBehaviour
    {
        [SerializeField] private Transform _ropeTrigger; //объект для поиска веревок
        [SerializeField] private LayerMask _ropeLayer; //указываем слой веревки

        private Rigidbody2D _rb2d;
        private Transform _t1;
        private Hero _hero; //класс с переменной скорости карабканья
        private GroundCheck _groundCheck;

        private Vector2 positionOfRoupe; //переменная для хранения позиции веревки из коллизии

        [SerializeField] private bool _isOnRope; //переменная о наличии контакта с веревкой
        [SerializeField] private bool _climbing; //состояние карабканья
        private FireScript _fireCheck;

        private float _VerticalInput;

        private void Awake() //инициализация
        {
            _rb2d = gameObject.GetComponent<Rigidbody2D>();
            _hero = gameObject.GetComponent<Hero>();
            _t1 = gameObject.GetComponent<Transform>();
            _groundCheck = gameObject.GetComponent<GroundCheck>();
            _fireCheck = gameObject.GetComponent<FireScript>();
        }


        private void isOnRope() //метод отрисовки оверлапкруга, радиусом 0.2, который ищет граунд леер
        {
            _isOnRope = Physics2D.OverlapCircle(_ropeTrigger.position, 0.2f, _ropeLayer);
        }


        private void Update()
        {

            isOnRope(); //ищем веревку
            if (!_isOnRope)
            {
                _climbing = false;
                _hero.setClimbing(false); _rb2d.gravityScale = 4;
                _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            if (_climbing) climb(); //двигаемся пока вверх и вниз
        }

        private void climb()
        {
            if (_climbing) _rb2d.velocity = new Vector2(0, _hero.getClimbingSpeed() * _VerticalInput);

        }

        public void EnterClimbingMode(InputAction.CallbackContext context) //по нажатию кнопок передвижения,
        {
            _VerticalInput = context.ReadValue<Vector2>().y;
            if (_isOnRope && !_climbing && _VerticalInput > 0 && !_fireCheck.getFire() || _isOnRope && !_climbing && _VerticalInput < 0 && !_fireCheck.getFire()) //если мы на вереве и мы не карабкаемся и мы нажали вверх, то мы начинаем карабкаться, выключаем гравитацию и крепим игрока по х к х веревки
            {
                RopeModOn();
            }
        }

        private void RopeModOn()
        {
            _climbing = true;
            _hero.setClimbing(true); _rb2d.gravityScale = 0;
            _t1.position = new Vector2(positionOfRoupe.x, _t1.position.y);
            Debug.Log("Позиция игрока: " + _rb2d.position.x + " Позиция веревки: " + positionOfRoupe.x);
            _rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; //фризим по х
        }

        private void RopeModOff()
        {
            _climbing = false;
            _rb2d.gravityScale = 4;
            _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; //анфризим по х
        }


        public void ExitClimbMode(InputAction.CallbackContext context) //выход из карабканья по пробелу
        {
            if (_climbing && context.started)
            {
                RopeModOff();
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, _hero.getJumpHeight());
            }
        }

        public bool getClimbing() //гет-тер для получения параметра из-вне
        {
            return _climbing;
        }



        public void setPosOfRoupe(Vector3 number)
        {
            positionOfRoupe = number;
            Debug.Log("Нам известна позиция веревки, она находится по адрессу: " + number);
        }
    }
}

