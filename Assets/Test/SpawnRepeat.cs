using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRepeat : MonoBehaviour {

	public float repeatTime = 2;
	public GameObject _object;
	public GameObject path;
	public Transform[] transforms;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0f, repeatTime);
		transforms = path.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {
		var obj = Instantiate(_object, transforms[0].position, transforms[0].rotation);
		obj.GetComponent<NavPatrol>().destinations = transforms;
	}
}
