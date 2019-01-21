﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;

    private void Start()
    {
        Rigidbody rgbd = GetComponent<Rigidbody>();

        rgbd.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
