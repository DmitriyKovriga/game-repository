using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HPController : MonoBehaviour
{
    [SerializeField] private float _objectHp;
    

    public float getHp ()
    {
        return _objectHp;
    }

    public void setHp (float number)
    {
        if (number < 0)
        {
            Debug.Log("setHp:HPController (�������� ��������� ��: " + number + " - ��� ����� ������� ������ � ������� if number<0");
            _objectHp += number;
        } else
        {
            Debug.Log("setHp:HPController (�������� ��������� ��: " + number + " - ��� ����� ������� ������ � ������� if number>0");
            _objectHp += number;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DealDamage"))
        {
            setHp(collision.gameObject.GetComponent<DamageDealComponent>().getDamage()); 
            Debug.Log("������� ���� �����, �������� OnCollisionEnter2D");
            DeathCheck();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DealDamage"))
        {
            setHp(collision.gameObject.GetComponent<DamageDealComponent>().getDamage());
            Debug.Log("������� ���� �����, �������� OnTriggerEnter2D");
            DeathCheck();
        }
    }

    public void DeathCheck ()
    {
        if (_objectHp <= 0)
        {
            Debug.Log("��������� ���������");
            Destroy(gameObject);
        }
        }
}
