using UnityEngine;

public enum Effect { 
	Damage,
	Heal,
	Draw,
	Discard,
	Kill,
	BuffAttack,
	BuffHealth,
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
	AllyMinions,
	Itself
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
	[SerializeField] bool randomValues;
	[SerializeField] int _from;
	[SerializeField] int _to;
	[SerializeField] Target _target;
	[SerializeField] bool randomTargets;
	[SerializeField] int _targets;
}