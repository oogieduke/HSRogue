using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	TurnManager turnManager;

	// Use this for initialization
	void Start () {
		turnManager = FindObjectOfType<TurnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (turnManager.playerTurn)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}