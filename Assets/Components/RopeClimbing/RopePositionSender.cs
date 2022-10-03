using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePositionSender : MonoBehaviour
{

    private Transform _transform;
    [SerializeField] private LayerMask _layerTarget;

    private void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name + " " + collision.gameObject.layer);
        
        if (collision.gameObject.layer == 6)
        {
            collision.GetComponent<RopeMode>().setPosOfRoupe(_transform.position);
        }
        }
}
