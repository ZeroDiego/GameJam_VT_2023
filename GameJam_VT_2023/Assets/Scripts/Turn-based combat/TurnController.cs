using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    private static Text turnText;
    private static SpellButtons spellButtons;
    private List<Entity> entities = new List<Entity>();
    private static List<Entity> enemies = new List<Entity>();
    private static int indexTurn = 0;

    private static float turnTransistionTimer;
    private static float turnTransistionDuration = 2f;
    private static bool turnTransistionBoolean;

    void Start()
    {
        turnTransistionTimer = turnTransistionDuration;
        turnText = GameObject.Find("TurnText").GetComponent<Text>();
        spellButtons = GameObject.Find("Canvas").GetComponent<SpellButtons>();

        foreach (Entity entity in FindObjectsOfType<Entity>())
        {
            entities.Add(entity);

            if (entity.gameObject.CompareTag("Enemy"))
                enemies.Add(entity);
        }

        entities.OrderByDescending(v => v.agility).ToList();
        turnText.text = "Actor\n" + entities[0].entityName;
        spellButtons.ChangeCurrentPerson(entities[0]);
    }

    private void Update()
    {
        if (turnTransistionTimer <= 0.0f)
        {
            turnTransistionBoolean = false;
            turnTransistionTimer = turnTransistionDuration;
            NextTurn();
        }

        if (turnTransistionBoolean)
        {
            turnTransistionTimer -= Time.deltaTime;
        }
    }

    public static void SetTurn()
    {
        spellButtons.TurnOffButtons();
        turnTransistionBoolean = true;
    }

    public void NextTurn()
    {
        indexTurn++;

        if (indexTurn + 1 > entities.Count)
            indexTurn = 0;

        if (AssertNoEnemiesLeft() || AssertYuIsDead())
        {
            EndCombat();
            return;
        }

        if (entities[indexTurn].isAlive)
        {
            turnText.text = "Actor\n" + entities[indexTurn].gameObject.name;

            if (entities[indexTurn].gameObject.CompareTag("Player"))
                spellButtons.ChangeCurrentPerson(entities[indexTurn]);
            else
                entities[indexTurn].EntityBehaviour();
        }
        else
            NextTurn();
    }

    private bool AssertYuIsDead()
    {
        if (entities[indexTurn].entityName.Equals("Yu Narukami") && !entities[indexTurn].isAlive)
        {
            turnText.text = "Yu died!";
            return true;
        }

        return false;
    }

    private bool AssertNoEnemiesLeft()
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
        SceneManager.LoadScene("philip");
    }
}