using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string entityName;

    public bool isAlive;

    [SerializeField] private float weakMultiplier;
    [SerializeField] private float strongMultiplier;

    [SerializeField] private Affinity[] affinities;
    [SerializeField] private int healthPoints;
    [SerializeField] private int skillPoints;
    [SerializeField] private int strength;
    [SerializeField] private int magic;
    [SerializeField] private int endurance;
    [SerializeField] private int agility;
    [SerializeField] private int luck;

    public Entity CompareEntities(Entity otherEntity)
    {
        if (agility > otherEntity.agility)
        {
            return this;
        }
        else
        {
            return otherEntity;
        }
    }

    public int GetStrength()
    {
        return strength;
    }

    public int GetMagic()
    {
        return magic;
    }

    public void TakeDamage(string damageType, int damage)
    {
        float multiplier = 1.0f;

        foreach (Affinity affinity in affinities)
        {
            if (affinity.affinityName.Equals(damageType)) 
            {
                if (affinity.isWeak)
                    multiplier = weakMultiplier;
                else if (affinity.isStrong)
                    multiplier = strongMultiplier;
                break;
            }
        }

        healthPoints -= Mathf.FloorToInt((damage - endurance) * multiplier);
        Debug.Log(Mathf.FloorToInt((damage - endurance) * multiplier) + " damage taken!");

        if (healthPoints <= 0)
        {
            healthPoints = 0;
            OnDeath();
        }

        Debug.Log(name + " has " + healthPoints + " healthpoints!");
    }

    private void OnDeath()
    {
        isAlive = false;
    }
}