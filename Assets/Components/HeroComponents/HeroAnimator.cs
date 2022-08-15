using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private Animator _animator;
    private string _currentState;
    
    private Rigidbody2D _r2D;
    private Hero _hero;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _r2D = gameObject.GetComponent<Rigidbody2D>();
        _hero = gameObject.GetComponent<Hero>();
    }

    public void ChangeHeroAnimationTo(string newState)
    {
        if (_currentState == newState) return; //сейвим ресурсы и не позволяем зациклить вызов стейта
        _animator.Play(newState);
        _currentState = newState;
    }

    private void Update()
    {
        AutoCheckState();
    }

    public void AutoCheckState()
    {
        if (_hero.getGround())
        {
            if (_r2D.velocity.x == 0)
            {
                ChangeHeroAnimationTo("Idle");
            } else
            {
                ChangeHeroAnimationTo("Run");
            }
        } 
        else if (_r2D.velocity.y > 1f)
        {
            ChangeHeroAnimationTo("Jump");
        } else if (_r2D.velocity.y < -1f)
        {
            ChangeHeroAnimationTo("Fall");
        } 
    }
}
