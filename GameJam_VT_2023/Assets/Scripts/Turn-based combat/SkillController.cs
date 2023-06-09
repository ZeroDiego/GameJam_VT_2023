using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private const int ONE = 1;
    private const int ONEHUNDRED = 100;

    private const int ZIOBASEPOWER = 80;
    private const int GARUBASEPOWER = 80;
    private const int BUFUBASEPOWER = 80;
    private const int LASTRESORTBASEPOWER = 90;

    private const string PHYSICAL = "Physical";
    private const string FIRE = "Fire";
    private const string ICE = "Ice";
    private const string ELEC = "Elec";
    private const string WIND = "Wind";

    [SerializeField] private TurnController turnController;

    public void Zio(Entity user, Entity target)
    {
        if (target.isAlive)
        {
            int damage = Mathf.FloorToInt(ZIOBASEPOWER * (((float)user.GetMagic() / ONEHUNDRED) + ONE));
            Debug.Log("Zio deals " + damage + " damage before endurance");
            target.TakeDamage(ELEC, damage);
            turnController.SetTurn();
        }
    }

    public void Garu(Entity user, Entity target)
    {
        if (target.isAlive)
        {
            int damage = Mathf.FloorToInt(GARUBASEPOWER * (((float)user.GetMagic() / ONEHUNDRED) + ONE));
            Debug.Log("Garu deals " + damage + " damage before endurance");
            target.TakeDamage(WIND, damage);
            turnController.SetTurn();
        }
    }

    public void Bufu(Entity user, Entity target)
    {
        if (target.isAlive)
        {
            int damage = Mathf.FloorToInt(BUFUBASEPOWER * (((float)user.GetMagic() / ONEHUNDRED) + ONE));
            Debug.Log("Bufu deals " + damage + " damage before endurance");
            target.TakeDamage(ICE, damage);
            turnController.SetTurn();
        }
    }

    public void LastResort(Entity user, Entity target)
    {
        if (target.isAlive)
        {
            int damage = Mathf.FloorToInt(LASTRESORTBASEPOWER * (((float)user.GetStrength() / ONEHUNDRED) + ONE));
            Debug.Log("Last Resort deals " + damage + " damage before endurance");
            target.TakeDamage(PHYSICAL, damage);
            turnController.SetTurn();
        }
    }
}
