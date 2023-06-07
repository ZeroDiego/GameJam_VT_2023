using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Damage")]
public class DamageSpell : Spell
{
	protected override void Cast(Entity caster, Entity target)
	{
		DealDamage(caster, target);
	}
}
