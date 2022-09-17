using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevColliderPlate : AudioReverb
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Cowboy")
        {
            Debug.Log("Cowboy Enters Plane");
            SetReverbPlate();
        }
    }
}