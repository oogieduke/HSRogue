﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		Destroy(gameObject);

		if (other.transform.tag == "Enemy") {
			Destroy(other.gameObject);
		}
	}
}
