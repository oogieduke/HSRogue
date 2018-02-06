using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAsset : ScriptableObject {

	[Header("Info")]
	public string cardName;
	public string cardText;

	[Header("Graphics")]
	public Sprite image;
	public Sprite rarity;
	
	[Header("Stats")]
	public int manaCost;
	public int attack;
	public int health;
}
