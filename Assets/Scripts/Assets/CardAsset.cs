using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
	public int numAttacks = 1;
	public bool targeted;

	[Header("Events")]
	public List<SpellEvent> events = new List<SpellEvent>();
	public List<SpellEvent> targetedEvents = new List<SpellEvent>();
	public List<SpellEvent> deathEvents = new List<SpellEvent>();
}