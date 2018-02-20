using System.Collections.Generic;
using UnityEngine;

public class CardAsset : ScriptableObject {

	[Header("Info")]
	public string cardText;

	[Header("Graphics")]
	public Sprite image;
	public Sprite rarity;
	
	[Header("Stats")]
	public int manaCost;
	public int attack;
	public int health;

	[Header("Special")]
	public bool taunt;
	public bool charge;
	public bool shield;
	public int numAttacks = 1;

	[Header("Events")]
	public List<Events> events = new List<Events>();
}