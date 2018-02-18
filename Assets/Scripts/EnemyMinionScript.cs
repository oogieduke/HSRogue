using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EnemyMinionScript : MonoBehaviour {

	GameManager gameManager;
	MinionManager minionManager;

	public CardAsset cardAsset;

	public int maxAttack;
	public int maxHealth;
	public int currentAttack;
	public int currentHealth;

	public GameObject cardImage;
	public GameObject cardAttack;
	public GameObject cardLife;
	public GameObject glow;


	void Start () {
		gameManager = FindObjectOfType<GameManager>();
		minionManager = FindObjectOfType<MinionManager>();
		StartStats();
	}
	
	void Update () {
        //UpdatePosition();
		CheckHealth();
    }

	private void CheckHealth() {
       if (currentHealth <= 0)
	   {
		   Destroy(gameObject);
		   //minionManager.minionsOnBoard.Remove(gameObject);
	   }
    }

    private void UpdatePosition() {
        float cardIndex = minionManager.minionsOnBoard.IndexOf(gameObject);
        float xPos = minionManager.cardDistance;
        transform.DOMoveX(gameManager.minionHandler.transform.position.x + cardIndex * xPos, 0.5f);
        transform.DORotate(Vector3.zero, 0.5f);
        transform.DOMoveY(gameManager.minionHandler.transform.position.y, 0.5f);
    }

	public void StartStats() {
		cardImage.GetComponent<Image>().sprite = cardAsset.image;
		maxAttack = cardAsset.attack;
		maxHealth = cardAsset.health;
		currentAttack = maxAttack;
		currentHealth = maxHealth;
		UpdateStats();
	}

	public void UpdateStats() {
		cardAttack.GetComponent<TextMeshProUGUI>().text = currentAttack.ToString();
        cardLife.GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();  
	}
}