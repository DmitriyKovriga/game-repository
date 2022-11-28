using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace hero
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private HealthHeroCharacteristics _heroC;
        private Rigidbody2D _rigidbody2D;
        private float _moveSpeed;
        [SerializeField] private float _horizontalInput;
        private float _verticalInput;
        [SerializeField ]private LayerMask _interactionLayer;
        private Collider2D[] _interactionResult = new Collider2D[1];

        private HeroAnimator _heroAnimator;
        private GroundCheck _groundCheck;

        //------rope-------
        private RopeMode _ropeMode;
        private bool _isClimbing;


        private void Awake()
        {
            _moveSpeed = _heroC.GetResultMoveSpeed(); //�������� movespeed �� ������ Hero
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>(); //�������� ����������
            _heroAnimator = gameObject.GetComponent<HeroAnimator>();
            _ropeMode = gameObject.GetComponent<RopeMode>();
            _isClimbing = _ropeMode.getClimbing();
            _groundCheck = gameObject.GetComponent<GroundCheck>();


        }


        private void FixedUpdate()
        {
            if (!_isClimbing) moveHero(); //�������� ������� �������� 
        }

        public void flipHero()
        {
            if (_horizontalInput > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (_horizontalInput < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }


        public void setHorizonalInput(InputAction.CallbackContext context) //�������� ����� �� � � �, ���������� �� � ���� ���� �������� ������� 2�
        {
            _horizontalInput = context.ReadValue<Vector2>().x;
            flipHero();
            _verticalInput = context.ReadValue<Vector2>().y;
        }

        public void moveHero() //������� ���������
        {
            _rigidbody2D.velocity = new Vector2(_horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
        }

        public void jump(InputAction.CallbackContext context)
        {
            if (context.performed && _groundCheck.isGrounded())
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _heroC.GetJumpHeight()); //������ �������� �� y � jumpHeight �� Hero
            }

            if (context.canceled && _rigidbody2D.velocity.y > 0f)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f); //��������� �������� ���� ������ ������ � ������
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                var hit = Physics2D.OverlapCircleNonAlloc(   //������ ����� ���������� ��� ������ ������� (����������� ��������� �������� � ������ �����),
                    transform.position, //������� ��������� �����
                    1, //������ �����
                    _interactionResult, //������ ��������� �����������2�
                    _interactionLayer); //����� �� �������� ����

                for (int i = 0; i < hit; i++)
                {
                    var interactable = _interactionResult[i].GetComponent<Interactable>();
                        if (interactable != null)
                    {
                        Debug.Log("���������� ������ ������� ��������� ����������, ��� ��������� � �������� " + interactable);
                        interactable.interact();
                    }
                }
            }
        }
    }
}

