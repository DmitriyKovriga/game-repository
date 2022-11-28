using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] public UnityEvent _action;
    public void interact()
    {
        _action?.Invoke();
    }
    
}
