using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace hero 
{
    public class FireScript : MonoBehaviour
    {

        [SerializeField] private Transform _fireRight; //where is right
        [SerializeField] private Transform _fireLeft; //where is left
        [SerializeField] private UnityEvent _fireLeftEvenet; //play fire animation
        [SerializeField] private UnityEvent _fireRightEvenet; //play fire animation

        [SerializeField] private AttackHeroСharacteristics _attackCharacteristics; //have stats from this
        [SerializeField] private GameObject _bullet; //prefab bullet

        //----------local logic var---------- 
        private bool _isFire = false;
        private float _timer;
        private float _cooldownBetweenAttacks; //swap to attack speed and need to delete
                                               //----------local logic var---------- 

        //----------enother staff, need to clear------------------
        private SpriteRenderer _sr;
        private Rigidbody2D _rb2d;
        private RopeMode _ropeMode;
        private HeroAnimator _hr;
        //----------enother staff, need to clear------------------

        private void Awake()
        {
            _sr = gameObject.GetComponent<SpriteRenderer>();
            _hr = gameObject.GetComponent<HeroAnimator>();
            _rb2d = gameObject.GetComponent<Rigidbody2D>();
            _ropeMode = gameObject.GetComponent<RopeMode>();
        }

        public bool getFire()
        {
            return _isFire;
        }

        private void Start()
        {
            _cooldownBetweenAttacks = _attackCharacteristics.GetAttackSpeed();
        }

        public void AttackSpeedFix () //this method we use when in enother script we change attack speed won't to put new value in to FireScript
        {
            _cooldownBetweenAttacks = _attackCharacteristics.GetAttackSpeed();
        }

        private void Update()
        {
            _timer += Time.deltaTime;


            if (_isFire)
            {
                _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                if (!_ropeMode.getClimbing()) _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            if (_timer > _cooldownBetweenAttacks && _isFire)
            {
                _hr.FireAnimation();
                Fire();


            }
        }

        public void FireTrigger(InputAction.CallbackContext context)
        {
            if (context.started && !_ropeMode.getClimbing())
            {
                _isFire = true;
            }
            else if (context.canceled)
            {
                _isFire = false;
            }
        }

        private void Fire()
        {


            if (_sr.flipX)
            {
                Instantiate(_bullet, _fireLeft.position, _fireLeft.rotation).gameObject.GetComponent<DamageDealComponent>().setNewDamage(_attackCharacteristics._getResultDamage());
                _fireLeftEvenet.Invoke();
            }
            else
            {
                Instantiate(_bullet, _fireRight.position, _fireRight.rotation).gameObject.GetComponent<DamageDealComponent>().setNewDamage(_attackCharacteristics._getResultDamage());
                _fireRightEvenet.Invoke();
            }
            _timer = 0;

            // Play oneshot SFX
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Shots DRY/Shots_1_DRY");

        }

    }
}

