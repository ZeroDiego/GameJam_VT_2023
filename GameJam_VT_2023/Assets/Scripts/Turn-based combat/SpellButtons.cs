using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellButtons : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            buttons.Add(b);
        }
    }

    public void ChangeCurrentPerson(Entity caster)
    {
        for (int i = 0; i < caster.spells.Length; i++)
        {
            if (buttons.Count < i)
                return;
            buttons[i].onClick.RemoveAllListeners();
            Spell spell = caster.spells[i];
            Text text = buttons[i].GetComponentInChildren<Text>();
            text.text = spell.spellName + " ";
            if (spell.affinity == AffinityType.Physical)
            {
                text.text += spell.cost + "% HP";
            }
            else
            {
                text.text += spell.cost + " SP";
            }
            buttons[i].onClick.AddListener(delegate { spell.CastSpell(caster, caster.enemiesToTarget[0]); });
        }
    }

    public void TurnOffButtons()
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
            button.GetComponentInChildren<Text>().text = "";
        }
    }
}