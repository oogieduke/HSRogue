using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float force = 1;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce(Vector3.right * force);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(Vector3.left * force);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			rb.AddForce(Vector3.up * force * 100f);
		}
	}
}
