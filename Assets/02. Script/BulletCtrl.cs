﻿using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour {

	public int damage = 20;
	public float speed = 1000.0f;

	void Start () {

		this.GetComponent<Rigidbody>().AddForce (transform.forward * speed);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
