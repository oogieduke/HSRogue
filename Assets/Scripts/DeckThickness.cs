using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckThickness : MonoBehaviour {

	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, -gameManager.deckListCards.Count/100f);
		if (gameManager.deckListCards.Count <= 0) {
			GetComponent<SpriteRenderer>().enabled = false;
		}
		else {
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
