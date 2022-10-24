using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunnerForMob : MonoBehaviour
{
    private Transform _targetTransform;
    private Transform _monsterTransform;
    private Rigidbody2D _rb2d;

    private float _moveSpeed = 5;

    private void Awake()
    {
        _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _monsterTransform = gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        _rb2d.WakeUp();
        if (_targetTransform.position.x - _monsterTransform.position.x > 0)
        {
            _rb2d.velocity = new Vector2(_moveSpeed, _rb2d.velocity.y);
            Debug.Log("Бегу! Бегу сука за тобой, сейчас я тебя буду резать, мой мс " + _moveSpeed + " магниьюда1 " + _rb2d.velocity.magnitude);
        }
        else
        {
            _rb2d.velocity = new Vector2(_moveSpeed * -1, _rb2d.velocity.y);
            Debug.Log("Бегу! Бегу сука за тобой, сейчас я тебя буду резать, мой мс " + _moveSpeed * -1 + " магниьюда1 " + _rb2d.velocity.magnitude);
        }
    }
}
