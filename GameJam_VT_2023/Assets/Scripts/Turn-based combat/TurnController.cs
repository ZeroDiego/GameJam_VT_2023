using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] private static List<Entity> entities = new List<Entity>();
    [SerializeField] private static List<Entity> enemies = new List<Entity>();
    private static int indexTurn = 0;
    
    void Start()
    {
        foreach (Entity entity in FindObjectsOfType<Entity>())
        {
            entities.Add(entity);

            if (entity.gameObject.CompareTag("Enemy"))
                enemies.Add(entity);
        }
        entities.OrderByDescending(v => v.agility).ToList();
        Debug.Log(entities[0]);
        SpellButtons.ChangeCurrentPerson(entities[0]);
	}

    public static void NextTurn()
    {
        entities[indexTurn].myTurn = false;
        indexTurn++;
        if (indexTurn + 1 > entities.Count)
        {
            indexTurn = 0;
        }

        if (AssertNoEnemiesLeft())
        {
            EndCombat();
            return;
        }

        if (entities[indexTurn].isAlive)
        {
            Debug.Log("Next turn: " + entities[indexTurn].gameObject.name);

            if (entities[indexTurn].gameObject.CompareTag("Player"))
                SpellButtons.ChangeCurrentPerson(entities[indexTurn]);
            else
                entities[indexTurn].EntityBehaviour();
        }
        else
        {
            NextTurn();
        }
    }

    private static bool AssertNoEnemiesLeft()
    {
        int enemyDeadCount = 0;

        foreach (Entity enemy in enemies)
        {
            if (!enemy.isAlive)
                enemyDeadCount++;
        }

        if (enemyDeadCount == enemies.Count)
            return true;
        else
            return false;
    }

    private static void EndCombat()
    {

    }
}
