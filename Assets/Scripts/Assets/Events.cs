using UnityEngine;

public enum Effect { 
	Damage,
	Heal,
	Draw,
	Discard,
	Kill,
	GainMana,
	GainManaMax
}

public enum Target {
	All,
	AllMinions,
	Enemy,
	EnemyHero,
	EnemyMinions,
	Ally,
	AllyHero,
	AllyMinions
}

public enum CardEvent {
	Targeted,
	OnPlay,
	OnDeath,
	StartTurn,
	EndTurn,
	DoDamages,
	TakeDamages,
	CardIsPlayed,
	MinionIsPlayed,
	SpellIsPlayed,
	CardIsDrawn,
	CardIsDiscarded
}

[System.Serializable]
public class Events {
	[SerializeField] CardEvent _event;
	[SerializeField] Effect _effect;
	[SerializeField] int _value;
	[SerializeField] Target _target;
	[SerializeField] bool random;
	[SerializeField] int randValue;
}