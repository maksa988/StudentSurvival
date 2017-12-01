using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public bool avaliable = true;
    public Transform target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(avaliable)
        {
            other.gameObject.transform.position = target.position;
            Camera.main.transform.position = target.position;
        }
    }
}
