using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool isAlive;

    [SerializeField] private float weakMultiplier;
    [SerializeField] private float strongMultiplier;

    private const int ONE = 1;
    private const int ONEHUNDRED = 100;
    private const int ZIOBASEPOWER = 80;

    [SerializeField] private string entityName; 

    private const string PHYSICAL = "Physical";
    private const string FIRE = "Fire";
    private const string ICE = "Ice";
    private const string ELEC = "Elec";
    private const string WIND = "Wind";

    [SerializeField] private int healthPoints;
    [SerializeField] private int skillPoints;
    [SerializeField] private int strength;
    [SerializeField] private int magic;
    [SerializeField] private int endurance;
    [SerializeField] private int agility;
    [SerializeField] private int luck;

    [SerializeField] private Affinity[] affinities;

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

    public void Zio(Entity target)
    {
        if (target.isAlive)
        {
            int damage = Mathf.FloorToInt(ZIOBASEPOWER * (((float) magic / ONEHUNDRED) + ONE));
            Debug.Log("Zio deals " + damage + " damage before endurance");
            target.TakeDamage(ELEC, damage);
        }
    }

    private void OnDeath()
    {
        isAlive = false;
    }
}