using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPatrol : MonoBehaviour {
	
	public Transform[] destinations;
	public int nextDest;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		GoToNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			GoToNextPoint();
		}
	}

	void GoToNextPoint() {
		if (destinations.Length == 0) { return; }
		
		agent.destination = destinations[nextDest].position;
		nextDest = (nextDest + 1) % destinations.Length;
	}
}
