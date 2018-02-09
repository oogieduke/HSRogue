using UnityEngine;

public class TurnManager : MonoBehaviour {

	public bool playerTurn;
	ManaPool manaPool;

	void Start () {
		playerTurn = true;
		manaPool = FindObjectOfType<ManaPool>();
	}
	
	public void SwitchTurn() {
		playerTurn = !playerTurn;
		if (playerTurn) { NewTurn(); }
	}

    void NewTurn()
    {
        manaPool.AddCurrentMaxMana(1);
		manaPool.RefillMana();
		GetComponent<GameManager>().AddCards(1);
    }
}