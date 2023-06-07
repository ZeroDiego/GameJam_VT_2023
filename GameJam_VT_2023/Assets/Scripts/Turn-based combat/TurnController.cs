using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] private static List<Entity> entities = new List<Entity>();
    private static int indexTurn = 0;
    
    void Start()
    {
        foreach (Entity entity in FindObjectsOfType<Entity>())
        {
            entities.Add(entity);
        }
        entities.OrderByDescending(v => v.agility).ToList();
		entities[0].myTurn = true;
		SpellButtons.ChangeCurrentPerson(entities[0]);
		Debug.Log(entities[indexTurn].gameObject.name + "s turn");
	}

    public static void NextTurn()
    {
        entities[indexTurn].myTurn = false;
        indexTurn++;
        if (indexTurn + 1 > entities.Count)
        {
            indexTurn = 0;
        }
        entities[indexTurn].myTurn = true;
		Debug.Log("Next turn: " + entities[indexTurn].gameObject.name);
        if (entities[indexTurn].gameObject.tag == "Player")
        {
            SpellButtons.ChangeCurrentPerson(entities[indexTurn]);
        }
        else
        {
            entities[indexTurn].EntityBehaviour();
		}
    }
}
