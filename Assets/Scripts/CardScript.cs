using UnityEngine;
using DG.Tweening;

public enum CardType{ Minion, Spell };
public class CardScript : MonoBehaviour {

	GameManager gameManager;

	public GameObject canvas;
	public CardType cardType;
	[HideInInspector] public bool isDiscard = false;
	[HideInInspector] public bool isOver = false;

	private void Start() {
		gameManager = FindObjectOfType<GameManager>();
	}

	private void Update() {
		if(isDiscard){
			float zDiscardPos = gameManager.discardPile.IndexOf(gameObject);
			transform.DOMoveZ(-zDiscardPos/100f, 0f);
			canvas.GetComponent<Canvas>().sortingOrder = gameManager.discardPile.IndexOf(gameObject);
			return;
		}
		float cardIndex = gameManager.cardsInHand.IndexOf(gameObject);
		float zPos = -cardIndex / 100f; 
		float xPos = gameManager.cardDistance;
		transform.DOMoveX(gameManager.cardHandler.transform.position.x + cardIndex * xPos, 0.5f);		
		transform.DORotate(Vector3.zero, 0.5f);
		
		if(isOver){return;};
		transform.DOMoveY(gameManager.cardHandler.transform.position.y, 0.5f);
		transform.DOMoveZ(gameManager.cardHandler.transform.position.z + zPos, 0.5f);
		canvas.GetComponent<Canvas>().sortingOrder = gameManager.cardsInHand.IndexOf(gameObject);
	}

	private void OnMouseEnter() {
		if(isDiscard){return;};
		isOver = true;
		transform.DOKill();
		transform.DOScale(new Vector3(1.3f, 1.3f, 1f), 0.1f);
		transform.DOMoveY(gameManager.cardHandler.transform.position.y + 1.4f, 0f);
		transform.DOMoveZ(-0.2f, 0.1f);
		canvas.GetComponent<Canvas>().sortingOrder = 50;
	}

	private void OnMouseExit() {
		if(isDiscard){return;};
		transform.DOKill();
		transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
		//transform.DOMoveZ(-gameManager.cardsInHand.IndexOf(gameObject)/100f, 0f);
		isOver = false;
	}

	private void OnMouseDown() {
		if(isDiscard){return;};
		gameManager.DiscardCard(gameObject);
	}
}