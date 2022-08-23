using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //------------movement
    [Header("Movement Hero Basics")]
    [SerializeField] private bool _isGround;
    [SerializeField] private bool _isClimbing;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _climbingSpeed;

    //-----------Damage

    [Header("Damage Hero Basics")]
    [SerializeField] private float _basicFlatDamage; //Задаем значение ТОЛЬКО через юнити. Это базовое значение которое мы не изменяем.
    [SerializeField] private float _basicModificatorForFlatDamage;
    [SerializeField] private float _resultFlatDamage;

    [Space]

    [SerializeField] private float _persentDamageModify;
    [SerializeField] private float _persentDamageModificator;
    [SerializeField] private float _resultDamageModificator;

    [Space]

    [SerializeField] private float _basicAttackSpeed;
    [SerializeField] private float _attackSpeedModificator;
    [SerializeField] private float _resultAttackSpeed;

    //-------------------------------------------------------------------------------------------------------------------БЛОК РАСЧЕТОВ------------------------------------------------------------------------------------------------------------


    //---------методы добавления флатового урона предметам и получение итогового флатового урона
    public void setNewFlatDamageModificator(float newFlatDamage)
    {
        _basicModificatorForFlatDamage = newFlatDamage;
    } 

    public void plusToFlatDamageModificator(float FlatDamage)
    {
        _basicModificatorForFlatDamage += FlatDamage;
    }

    public float getResultFlatDamage()
    {
        return _resultFlatDamage;
    }

    //---------методы добавления % урона предметам и получение итогового % урона
    public void setNewPersentDamageModify (float newPersent)
    {
        _persentDamageModificator = newPersent;
    }

    public void plusPersentDamageModify( float persent)
    {
        _persentDamageModificator += persent;
    }

    public float getResultPersentDamageModify()
    {
        return _resultDamageModificator;
    }

    //---------методы добавления скорости атаки предметам и получение итоговой скорости атаки
    public void setNewAttackSpeedModify(float newPersent)
    {
        _attackSpeedModificator = newPersent;
    }

    public void plusAttackSpeedModify(float persent)
    {
        _attackSpeedModificator += persent;
    }

    public float getResultAttackSpeed()
    {
        return _resultAttackSpeed;
    }

    //---------методы расчета результатов статов
    public void CalculateFlatDamage ()
    {
        _resultFlatDamage = _basicFlatDamage * _basicModificatorForFlatDamage;
    }

    public void CalculateDamageModificator ()
    {
        _resultDamageModificator = _persentDamageModify * _persentDamageModificator;
    }

    public void CalculateAttackSpeed ()
    {
        _resultAttackSpeed = _basicAttackSpeed * _attackSpeedModificator;
    }

    public void CalculateAll()
    {
        CalculateDamageModificator();
        CalculateFlatDamage();
        CalculateAttackSpeed();
        }

    public void CalculateDamage()
    {
        CalculateDamageModificator();
        CalculateFlatDamage();
    }

    public float getResultHeroDamage()
    {
        return _resultFlatDamage * _resultDamageModificator;
    }
    //-------------------------------------------------------------------------------------------------------------------БЛОК РАСЧЕТОВ------------------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------------------БЛОК ПОЛУЧЕНИЯ ЗНАЧЕНИЙ------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        CalculateAll();
    }

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

    public bool getClimbing()
    {
        return _isClimbing;
    }

    public void setClimbing(bool newState)
    {
        _isClimbing = newState;
    }

    //---------------------------------------------------------------------------------------------------------------БЛОК ПОЛУЧЕНИЯ ЗНАЧЕНИЙ------------------------------------------------------------------------------------------------------

}
