using Unity.VisualScripting;
using UnityEngine;

public abstract class Spell : ScriptableObject
{

	[SerializeField] public string spellName = "";
	[SerializeField] protected int accuracy;

	public AffinityType affinity;
	public int damage = 0;
	public int cost = 0;

	protected const int ONEHUNDRED = 100;

	private bool Roll(int roll)
	{
		int hit = Random.Range(1, ONEHUNDRED);
		if (hit <= roll)
			return true;

		return false;
	}

	protected void DealDamage(Entity caster, Entity target)
	{
		if (target.isAlive)
		{
			if (Roll(accuracy))
			{
				int calcDamage;
				bool crit = false;

				if (affinity == AffinityType.Physical)
				{
					calcDamage = Mathf.FloorToInt(damage * (((float)caster.strength / ONEHUNDRED) + 1));
					if (Roll(caster.luck)) // Crit chance
						crit = true;
				}
				else
					calcDamage = Mathf.FloorToInt(damage * (((float)caster.magic / ONEHUNDRED) + 1));

				Debug.Log(spellName + " deals " + damage + " damage before endurance");
				target.TakeDamage(affinity, calcDamage, crit);
			}
			else
				Debug.Log("Miss");
		}
		TurnController.NextTurn();
	}

	private bool TryCastSpell(Entity caster)
	{ 

		if (affinity == AffinityType.Physical && ((float) caster.maxhealthPoints / (cost / 100) < caster.healthPoints))
		{
			caster.healthPoints -= (int)((float) caster.maxhealthPoints / (cost / 100));
			return true;
		}
		else if (caster.skillPoints >= cost)
		{
			caster.skillPoints -= cost;
			return true;
		}
		return false;
	}

	public bool CastSpell(Entity caster, Entity target)
	{
		if (TryCastSpell(caster))
		{
			Cast(caster, target);
			return true;
		}
		return false;
	}

	protected abstract void Cast(Entity caster, Entity target);
}
