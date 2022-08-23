using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerToHp : MonoBehaviour
{
    [SerializeField] private float HpModifie;
    [SerializeField] private LayerMask layerMask;

    public void setHpModifie(float newHpModifie)
    {
        HpModifie = newHpModifie;
    }

    
}
