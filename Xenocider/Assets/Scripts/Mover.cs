using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    private void Start()
    {
        Rigidbody rgbd = GetComponent<Rigidbody>();

        rgbd.velocity = transform.forward * speed;
    }
}
