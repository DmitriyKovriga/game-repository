using UnityEngine;
namespace hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private Animator _animator;
        private string _currentState;

        private Rigidbody2D _r2D;
        private GroundCheck _groundChecker;
        private RopeMode _rope;
        private FireScript _fireScript;
        private bool _isFire;

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
            _r2D = gameObject.GetComponent<Rigidbody2D>();
            _groundChecker = gameObject.GetComponent<GroundCheck>();
            _rope = gameObject.GetComponent<RopeMode>();
            _fireScript = gameObject.GetComponent<FireScript>();
        }

        public void ChangeHeroAnimationTo(string newState)
        {
            //if (_currentState == newState) return; //сейвим ресурсы и не позволяем зациклить вызов стейта
            _animator.Play(newState);
            _currentState = newState;
        }

        public void FireAnimation()
        {
            _animator.SetTrigger("Fire");
        }



        private void Update()
        {
            AutoCheckState();
            _isFire = _fireScript.getFire();
        }



        public void AutoCheckState()
        {
            if (_groundChecker.isGrounded() && !_rope.getClimbing() && !_isFire)
            {
                if (_r2D.velocity.x == 0)
                {
                    ChangeHeroAnimationTo("Idle");
                }
                else
                {
                    ChangeHeroAnimationTo("Run");
                }
            }
            else if (_r2D.velocity.y > 1f && !_rope.getClimbing() && !_isFire)
            {
                ChangeHeroAnimationTo("Jump");
            }
            else if (_r2D.velocity.y < -1f && !_rope.getClimbing() && !_isFire)
            {
                ChangeHeroAnimationTo("Fall");
            }
            else if (_rope.getClimbing() && _r2D.velocity.y == 0 && !_isFire)
            {
                ChangeHeroAnimationTo("IdleClimb");
            }
            else if (_rope.getClimbing() && _r2D.velocity.y > 0 && !_isFire)
            {
                ChangeHeroAnimationTo("Climbing");
            }
            else if (_rope.getClimbing() && _r2D.velocity.y < 0 && !_isFire)
            {
                ChangeHeroAnimationTo("ClimbingDown");
            }
        }
    }
}

