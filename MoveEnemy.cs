﻿using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public float moveSpeed = 2.0f;
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (-moveSpeed * Time.deltaTime, 0, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;

	
	}
}
