using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool myTurn = false;
	public bool isKnockedDown = false;
	public bool isAlive = true;

	protected static float WEAKMULTIPLIER = 1.4f;
	protected static float STRONGMULTIPLIER = 0.6f;
    [SerializeField] private string entityName;
    [SerializeField] private Affinity[] affinities;
	public Spell[] spells;

    public List<Entity> enemiesToTarget = new List<Entity>();

	public int healthPoints;
	[NonSerialized] public int maxhealthPoints;
	public int skillPoints;
	[NonSerialized] public int maxskillPoints;

    public int strength;
    public int magic;
    public int endurance;
    public int agility;
    public int luck;

	private void Start()
	{
        maxhealthPoints = healthPoints;
		maxskillPoints = skillPoints;
        string tag = gameObject.tag == "Player" ? "Enemy" : "Player";
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(tag))
        {
            enemiesToTarget.Add(gameObject.GetComponent<Entity>());
        }
	}

	public void TakeDamage(AffinityType affinityType, int damage, bool crit)
    {
        float multiplier = 1.0f;

        if (crit)
        {
            multiplier = WEAKMULTIPLIER;
			KnockDown();
		}
        else
        {
            foreach (Affinity affinity in affinities)
            {
                if (affinity.type.Equals(affinityType)) 
                {
                    if (affinity.isWeak)
                    { 
                        multiplier = WEAKMULTIPLIER;
                        KnockDown();
                        crit = true;
					}
                    else if (affinity.isStrong)
                        multiplier = STRONGMULTIPLIER;
                    break;
                }
            }
        }

        healthPoints -= Mathf.FloorToInt((damage - endurance) * multiplier);
        Debug.Log(Mathf.FloorToInt((damage - endurance) * multiplier) + " damage taken! Crit: " + crit);

        if (healthPoints <= 0)
        {
            healthPoints = 0;
            OnDeath();
        }

        Debug.Log(name + " has " + healthPoints + " healthpoints!");
    }

    public void EntityBehaviour()
    {
        Spell spell = spells[UnityEngine.Random.Range(0, spells.Length)];
        spell.CastSpell(this, enemiesToTarget[UnityEngine.Random.Range(0, enemiesToTarget.Count)]);
    }

    private void KnockDown()
    {
        if (!isKnockedDown)
        {
            isKnockedDown = true;
            // Give opponent extra turn
        }
    }

    private void OnDeath()
    {
        isAlive = false;
    }
}