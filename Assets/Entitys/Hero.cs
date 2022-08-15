using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private bool _isGround;
    [SerializeField] private bool _isClimbing;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _climbingSpeed;
    

    public void setGround(bool isground) //аккуратно, не проверил нулл
    {
        _isGround = isground;
    }

    public bool getGround() //аккуратно, не проверил нулл
    {
        return _isGround;
    }

    public void setJumpHeight (float newJumpHeight)
    {
        _jumpHeight = newJumpHeight;
    }

    public float getJumpHeight ()
    {
        return _jumpHeight;
    }

    public void setMoveSpeed (float newMoveSpeed) 
    {
        _moveSpeed = newMoveSpeed;
    }

    public float getMoveSpeed ()
    {
        return _moveSpeed;
    }

    public void setClimbingSpeed(float newSpeed)
    {
        _climbingSpeed = newSpeed;
    }

    public float getClimbingSpeed()
    {
        return _climbingSpeed;
    }

}
