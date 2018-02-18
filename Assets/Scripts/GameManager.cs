using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	public GameObject cardHandler;
	[SerializeField] GameObject deck;
	[SerializeField] GameObject discard;
	[SerializeField] GameObject card;
	[SerializeField] GameObject spell;
	[SerializeField] GameObject discardCount;
	[SerializeField] GameObject deckCount;
	public Transform minionHandler;

	float startXPos;

	public int maxCards = 10;
	public float cardDistance = 1.2f;
	public List<GameObject> cardsInHand = new List<GameObject>();
	public List<GameObject> discardPile = new List<GameObject>();
	public DeckAsset deckList;
	public List<CardAsset> deckListCards = new List<CardAsset>();
	

	private void Start() {
		startXPos = cardHandler.transform.position.x;
		deckListCards.AddRange(deckList.cards);
		AddCards(4);
	}

	public void Update ()
    {
        UpdateHandlerPosition();
        UpdateUI();
    }

    void UpdateUI()
    {
        discardCount.GetComponent<Text>().text = discardPile.Count.ToString();
		deckCount.GetComponent<Text>().text = deckListCards.Count.ToString();
    }

    void UpdateHandlerPosition () {
		float numCards = cardsInHand.Count;
		float endPos = -numCards / 2 ;
		if (numCards > 1)
		{
			cardHandler.transform.DOMoveX(startXPos + endPos * cardDistance + 0.5f * cardDistance, 0.5f);
		}
		else { cardHandler.transform.DOMoveX(startXPos + 0f, 0.5f); }
	}

	public void AddCards (int num) {		
		for (int i = 0; i < num; i++)
		{
		if (deckListCards.Count <= 0) {return;};
		
		int cardIndex = Random.Range(0, deckListCards.Count - 1);
		Vector3 deckPosition = new Vector3(deck.transform.position.x, deck.transform.position.y, deck.transform.position.z - 1f);
		GameObject newCard;

		if(deckListCards[cardIndex].health == 0) {
			newCard = Instantiate(spell, deckPosition, deck.transform.rotation, cardHandler.transform);
			newCard.GetComponent<CardScript>().cardType = CardType.Spell;
			newCard.GetComponent<CardScript>().cardAsset = deckListCards[cardIndex];
		}
		else {
			newCard = Instantiate(card, deckPosition, deck.transform.rotation, cardHandler.transform);
			newCard.GetComponent<CardScript>().cardType = CardType.Minion;
			newCard.GetComponent<CardScript>().cardAsset = deckListCards[cardIndex];
		}

		if (cardsInHand.Count >= maxCards ) {DiscardCardFromHand(newCard, num-i); return;};
		cardsInHand.Add(newCard);
		newCard.GetComponent<CardConstruct>().UpdateAsset(deckListCards[cardIndex]);
		deckListCards.Remove(deckListCards[cardIndex]);
		}
	}

    public void DiscardCardFromHand(GameObject item, int iCard) {
		for (int i = 0; i < iCard; i++)
		{
		int cardIndex = Random.Range(0, deckListCards.Count - 1);
		item.GetComponent<CardConstruct>().UpdateAsset(deckListCards[cardIndex]);
		item.GetComponent<CardScript>().cardAsset = deckListCards[cardIndex];
		deckListCards.Remove(deckListCards[cardIndex]);
		item.GetComponent<CardScript>().isDiscard = true;		
		item.GetComponent<CardScript>().isOver = false;
		item.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
		item.transform.DOMove(discard.transform.position, 0.5f);
		item.transform.DORotate(discard.transform.eulerAngles, 0.5f);
		item.transform.parent = discard.transform;
		discardPile.Add(item);			
		}

    }

    public void DiscardCard (GameObject item) {
		item.GetComponent<CardScript>().isDiscard = true;		
		item.GetComponent<CardScript>().isOver = false;
		item.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
		item.transform.DOMove(discard.transform.position, 0.5f);
		item.transform.DORotate(discard.transform.eulerAngles, 0.5f);
		item.transform.parent = discard.transform;
		cardsInHand.Remove(item);
		discardPile.Add(item);
	}

	public void DiscardRandom (int num) {
		for (int i = 0; i < num; i++)
		{
		if (cardsInHand.Count <= 0 ) {return;};
		GameObject card = cardsInHand[Random.Range(0, cardsInHand.Count )];
		DiscardCard(card);
		}
	}

	public void CleanHand () {
		DiscardRandom(cardsInHand.Count);
	}

	public void Quit() {
		Application.Quit();
	}
}