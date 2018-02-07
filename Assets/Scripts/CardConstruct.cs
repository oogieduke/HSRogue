﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]

public class CardConstruct : MonoBehaviour {

	public GameObject cardName;
	public GameObject cardText;
	public GameObject cardImage;
	public GameObject cardCost;
	public GameObject cardRarity;
	public GameObject cardAttack;
	public GameObject cardLife;


	private void OnEnable()
    {
       // UpdateAsset();
    }

    public void UpdateAsset(CardAsset asset)
    {
        cardName.GetComponent<TextMeshProUGUI>().text = asset.cardName;
        cardText.GetComponent<TextMeshProUGUI>().text = asset.cardText;
        cardCost.GetComponent<TextMeshProUGUI>().text = asset.manaCost.ToString();
        cardImage.GetComponent<SpriteRenderer>().sprite = asset.image;
        cardRarity.GetComponent<Image>().sprite = asset.rarity;
        
        if (cardLife == null) {return;}
        cardAttack.GetComponent<TextMeshProUGUI>().text = asset.attack.ToString();
        cardLife.GetComponent<TextMeshProUGUI>().text = asset.health.ToString();  
    }
}