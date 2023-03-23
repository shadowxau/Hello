﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start ()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
