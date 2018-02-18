using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spells { 
	Fireball, 
	Pyroblast, 
	ArcaneMissile,
	ArcaneExplosion, 
	Innervation, 
	ShadoworldPain
}

[System.Serializable]
public class SpellEvent {
	[SerializeField] Spells spell;
	[SerializeField] int value;
}