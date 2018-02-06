using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour {

	[SerializeField] int num = 1;
	[SerializeField] GameObject gameManager;
	
	private void OnMouseDown() {
		gameManager.GetComponent<GameManager>().AddCards(num);
	}
}
