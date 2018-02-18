using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MinionManager : MonoBehaviour {

	public List<GameObject> minionsOnBoard = new List<GameObject>();

	float startXPos;
	public float cardDistance = 2f;
	public int maxMinion = 7;

	void Start () {
		startXPos = transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		UpdateHandlerPosition();
	}

	void UpdateHandlerPosition () {
		float numCards = minionsOnBoard.Count;
		float endPos = -numCards / 2 ;
		if (numCards > 1)
		{
			transform.DOMoveX(startXPos + endPos * cardDistance + 0.5f * cardDistance, 0.5f);
		}
		else { transform.DOMoveX(startXPos + 0f, 0.5f); }
	}
}
